using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Y.Utils.DataUtils.Collections;

namespace Y.Utils.IOUtils.FileManUtils
{
    /// <summary>
    /// 文件更改通知
    /// </summary>
    public class FileWatcher
    {
        private bool _IsStart = false;
        private List<FileSystemWatcher> Watchers = new List<FileSystemWatcher>();

        /// <summary>
        /// 当前运行状态
        /// </summary>
        public bool IsStart { get { return _IsStart; } }
        public delegate void FileWatcherEventHandler(object sender, FileWatcherEventArgs args);
        public FileWatcher()
        {
            DriveInfo[] drives = DriveInfo.GetDrives().Where(x => x.IsReady && (x.DriveType == DriveType.Fixed || x.DriveType == DriveType.Removable)).ToArray();
            if (ListTool.HasElements(drives))
            {
                foreach (var d in drives)
                {
                    FileSystemWatcher fsw = new FileSystemWatcher(d.Name);
                    fsw.Created += CreatedEvent;//创建文件或目录
                    fsw.Changed += ChangedEvent;//更改文件或目录
                    fsw.Deleted += DeletedEvent;//删除文件或目录
                    fsw.Renamed += RenamedEvent;//重命名文件或目录
                    fsw.IncludeSubdirectories = true;
                    fsw.NotifyFilter = (NotifyFilters)383;
                    Watchers.Add(fsw);
                }
            }
        }
        public void Start()
        {
            _IsStart = true;
            if (ListTool.HasElements(Watchers))
            {
                foreach (var w in Watchers)
                {
                    w.EnableRaisingEvents = true;
                }
            }
        }
        public void Stop()
        {
            _IsStart = false;
            if (ListTool.HasElements(Watchers))
            {
                foreach (var w in Watchers)
                {
                    w.EnableRaisingEvents = false;
                }
            }
        }


        private void CreatedEvent(object sender, FileSystemEventArgs e)
        {

        }
        private void ChangedEvent(object sender, FileSystemEventArgs e)
        {

        }
        private void DeletedEvent(object sender, FileSystemEventArgs e)
        {

        }
        private void RenamedEvent(object sender, RenamedEventArgs e)
        {

        }
    } 
}
