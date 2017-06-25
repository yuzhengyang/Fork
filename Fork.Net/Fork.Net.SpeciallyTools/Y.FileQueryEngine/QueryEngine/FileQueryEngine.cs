using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Y.FileQueryEngine.UsnOperation;

namespace Y.FileQueryEngine.QueryEngine
{
    public class FileQueryEngine
    {
        /// <summary>
        /// When its values is 1407374883553285(0x5000000000005L), it means this file/folder is under drive root
        /// </summary>
        public const UInt64 ROOT_FILE_REFERENCE_NUMBER = 0x5000000000005L;

        protected static readonly string excludeFolders = string.Join("|",
            new string[]
            {
                "$RECYCLE.BIN",
                "System Volume Information",
                "$AttrDef",
                "$BadClus",
                "$BitMap",
                "$Boot",
                "$LogFile",
                "$Mft",
                "$MftMirr",
                "$Secure",
                "$TxfLog",
                "$UpCase",
                "$Volume",
                "$Extend"
            }).ToUpper();
        /// <summary>
        /// 获取所有NTFS文件系统的固定磁盘
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<DriveInfo> GetFixedNtfsDrives()
        {
            return DriveInfo.GetDrives()
                .Where(d => d.DriveType == DriveType.Fixed && d.DriveFormat.ToUpper() == "NTFS");
        }
        /// <summary>
        /// 获取所有NTFS文件系统的磁盘
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<DriveInfo> GetReadyNtfsDrives()
        {
            return DriveInfo.GetDrives()
                .Where(d => d.IsReady && d.DriveFormat.ToUpper() == "NTFS");
        }
        /// <summary>
        /// 查询磁盘的所有文件
        /// </summary>
        /// <param name="drive"></param>
        /// <returns></returns>
        public static List<UsnEntry> GetAllFiles(DriveInfo drive)
        {
            var usnOperator = new UsnOperator(drive);
            return usnOperator.GetEntries().Where(e => !excludeFolders.Contains(e.FileName.ToUpper())).ToList();
        }
        public static bool FileIsExist(string drive, long usn)
        {
            var d = DriveInfo.GetDrives().FirstOrDefault(x => x.Name == drive);
            if (d != null)
            {
                var usnOperator = new UsnOperator(d);
                return usnOperator.UsnIsExist(usn);
            }
            return false;
        }
        /// <summary>
        /// 查询磁盘的所有文件
        /// </summary>
        /// <param name="drive"></param>
        /// <returns></returns>
        public static List<FileAndDirectoryEntry> GetAllFileEntrys(DriveInfo drive)
        {
            List<FileAndDirectoryEntry> result = new List<FileAndDirectoryEntry>();
            var usnOperator = new UsnOperator(drive);
            var usnEntries = usnOperator.GetEntries().Where(e => !excludeFolders.Contains(e.FileName.ToUpper()));
            var folders = usnEntries.Where(e => e.IsFolder).ToArray();
            List<FrnFilePath> paths = GetFolderPath(folders, drive);
            var range = usnEntries.Join(
                paths,
                usn => usn.ParentFileReferenceNumber,
                path => path.FileReferenceNumber,
                (usn, path) => new FileAndDirectoryEntry(usn, path.Path));
            result.AddRange(range);
            return result;
        }

        private static List<FrnFilePath> GetFolderPath(UsnEntry[] folders, DriveInfo drive)
        {
            Dictionary<UInt64, FrnFilePath> pathDic = new Dictionary<ulong, FrnFilePath>();
            pathDic.Add(ROOT_FILE_REFERENCE_NUMBER,
                new FrnFilePath(ROOT_FILE_REFERENCE_NUMBER, null, string.Empty, drive.Name.TrimEnd('\\')));

            foreach (var folder in folders)
            {
                pathDic.Add(folder.FileReferenceNumber,
                    new FrnFilePath(folder.FileReferenceNumber, folder.ParentFileReferenceNumber, folder.FileName));
            }

            Stack<UInt64> treeWalkStack = new Stack<ulong>();

            foreach (var key in pathDic.Keys)
            {
                treeWalkStack.Clear();

                FrnFilePath currentValue = pathDic[key];

                if (string.IsNullOrWhiteSpace(currentValue.Path)
                    && currentValue.ParentFileReferenceNumber.HasValue
                    && pathDic.ContainsKey(currentValue.ParentFileReferenceNumber.Value))
                {
                    FrnFilePath parentValue = pathDic[currentValue.ParentFileReferenceNumber.Value];

                    while (string.IsNullOrWhiteSpace(parentValue.Path)
                        && parentValue.ParentFileReferenceNumber.HasValue
                        && pathDic.ContainsKey(parentValue.ParentFileReferenceNumber.Value))
                    {
                        currentValue = parentValue;

                        if (currentValue.ParentFileReferenceNumber.HasValue
                            && pathDic.ContainsKey(currentValue.ParentFileReferenceNumber.Value))
                        {
                            treeWalkStack.Push(key);
                            parentValue = pathDic[currentValue.ParentFileReferenceNumber.Value];
                        }
                        else
                        {
                            parentValue = null;
                            break;
                        }
                    }

                    if (parentValue != null)
                    {
                        currentValue.Path = BuildPath(currentValue, parentValue);

                        while (treeWalkStack.Count() > 0)
                        {
                            UInt64 walkedKey = treeWalkStack.Pop();

                            FrnFilePath walkedNode = pathDic[walkedKey];
                            FrnFilePath parentNode = pathDic[walkedNode.ParentFileReferenceNumber.Value];

                            walkedNode.Path = BuildPath(walkedNode, parentNode);
                        }
                    }
                }
            }

            var result = pathDic.Values.Where(p => !string.IsNullOrWhiteSpace(p.Path) && p.Path.StartsWith(drive.Name)).ToList();

            return result;
        }

        private static string BuildPath(FrnFilePath currentNode, FrnFilePath parentNode)
        {
            return string.Concat(new string[] { parentNode.Path, "\\", currentNode.FileName });
        }
    }
}
