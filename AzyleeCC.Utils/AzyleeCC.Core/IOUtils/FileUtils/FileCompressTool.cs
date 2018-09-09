//************************************************************************
//      author:     yuzhengyang
//      date:       2017.6.12 - 2017.6.12
//      desc:       文件压缩
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace AzyleeCC.Core.IOUtils.FileUtils
{
    /// <summary>
    /// 文件压缩
    /// </summary>
    public class FileCompressTool
    {
        /// <summary>
        /// 压缩
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static bool Compress(string file)
        {
            FileInfo fileInfo = null;
            if (File.Exists(file)) fileInfo = new FileInfo(file);
            if (fileInfo == null) return false;

            using (FileStream originalFileStream = fileInfo.OpenRead())
            {
                if ((File.GetAttributes(fileInfo.FullName) & FileAttributes.Hidden) != FileAttributes.Hidden & fileInfo.Extension != ".gz")
                {
                    using (FileStream compressedFileStream = File.Create(fileInfo.FullName + ".gz"))
                    {
                        using (GZipStream compressionStream = new GZipStream(compressedFileStream, CompressionMode.Compress))
                        {
                            originalFileStream.CopyTo(compressionStream);
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// 解压缩
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static bool Decompress(string file)
        {
            FileInfo fileInfo = null;
            if (File.Exists(file)) fileInfo = new FileInfo(file);
            if (fileInfo == null) return false;

            try
            {
                using (FileStream originalFileStream = fileInfo.OpenRead())
                {
                    string currentFileName = fileInfo.FullName;
                    string newFileName = currentFileName.Remove(currentFileName.Length - fileInfo.Extension.Length);

                    using (FileStream decompressedFileStream = File.Create(newFileName))
                    {
                        using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                        {
                            decompressionStream.CopyTo(decompressedFileStream);
                            return true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// 单文件压缩（生成的压缩包和第三方的解压软件兼容）
        /// </summary>
        /// <param name="sourceFilePath"></param>
        /// <returns></returns>
        public string CompressSingle(string sourceFilePath)
        {
            string zipFileName = sourceFilePath + ".gz";
            using (FileStream sourceFileStream = new FileInfo(sourceFilePath).OpenRead())
            {
                using (FileStream zipFileStream = File.Create(zipFileName))
                {
                    using (GZipStream zipStream = new GZipStream(zipFileStream, CompressionMode.Compress))
                    {
                        sourceFileStream.CopyTo(zipStream);
                    }
                }
            }
            return zipFileName;
        }
        /// <summary>
        /// 自定义多文件压缩（生成的压缩包和第三方的压缩文件解压不兼容）
        /// </summary>
        /// <param name="sourceFileList">文件列表</param>
        /// <param name="saveFullPath">压缩包全路径</param>
        public void CompressMulti(string[] sourceFileList, string saveFullPath)
        {
            MemoryStream ms = new MemoryStream();
            foreach (string filePath in sourceFileList)
            {
                Console.WriteLine(filePath);
                if (File.Exists(filePath))
                {
                    string fileName = Path.GetFileName(filePath);
                    byte[] fileNameBytes = Encoding.UTF8.GetBytes(fileName);
                    byte[] sizeBytes = BitConverter.GetBytes(fileNameBytes.Length);
                    ms.Write(sizeBytes, 0, sizeBytes.Length);
                    ms.Write(fileNameBytes, 0, fileNameBytes.Length);
                    byte[] fileContentBytes = File.ReadAllBytes(filePath);
                    ms.Write(BitConverter.GetBytes(fileContentBytes.Length), 0, 4);
                    ms.Write(fileContentBytes, 0, fileContentBytes.Length);
                }
            }
            ms.Flush();
            ms.Position = 0;
            using (FileStream zipFileStream = File.Create(saveFullPath))
            {
                using (GZipStream zipStream = new GZipStream(zipFileStream, CompressionMode.Compress))
                {
                    ms.Position = 0;
                    ms.CopyTo(zipStream);
                }
            }
            ms.Close();
        }
        /// <summary>
        /// 多文件压缩解压
        /// </summary>
        /// <param name="zipPath">压缩文件路径</param>
        /// <param name="targetPath">解压目录</param>
        public void DeCompressMulti(string zipPath, string targetPath)
        {
            byte[] fileSize = new byte[4];
            if (File.Exists(zipPath))
            {
                using (FileStream fStream = File.Open(zipPath, FileMode.Open))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (GZipStream zipStream = new GZipStream(fStream, CompressionMode.Decompress))
                        {
                            zipStream.CopyTo(ms);
                        }
                        ms.Position = 0;
                        while (ms.Position != ms.Length)
                        {
                            ms.Read(fileSize, 0, fileSize.Length);
                            int fileNameLength = BitConverter.ToInt32(fileSize, 0);
                            byte[] fileNameBytes = new byte[fileNameLength];
                            ms.Read(fileNameBytes, 0, fileNameBytes.Length);
                            string fileName = System.Text.Encoding.UTF8.GetString(fileNameBytes);
                            string fileFulleName = targetPath + fileName;
                            ms.Read(fileSize, 0, 4);
                            int fileContentLength = BitConverter.ToInt32(fileSize, 0);
                            byte[] fileContentBytes = new byte[fileContentLength];
                            ms.Read(fileContentBytes, 0, fileContentBytes.Length);
                            using (FileStream childFileStream = File.Create(fileFulleName))
                            {
                                childFileStream.Write(fileContentBytes, 0, fileContentBytes.Length);
                            }
                        }
                    }
                }
            }
        }
    }
}
