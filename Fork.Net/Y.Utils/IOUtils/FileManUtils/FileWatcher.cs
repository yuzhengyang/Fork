//************************************************************************
//      https://github.com/yuzhengyang
//      author:     yuzhengyang
//      date:       2017.6.28 - 2017.6.29
//      desc:       文件变更监测
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************

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
    public class FileWatcher : IDisposable
    {
        /// <summary>
        /// 接受文件监控信息的事件委托
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public delegate void FileWatcherEventHandler(object sender, FileWatcherEventArgs args);
        /// <summary>
        /// 获取文件监控信息
        /// </summary>
        public FileWatcherEventHandler eventHandler;

        private bool _IsStart = false, _IsDisposed = false;
        private List<FileSystemWatcher> Watchers = new List<FileSystemWatcher>();

        /// <summary>
        /// 当前运行状态
        /// </summary>
        public bool IsStart { get { return _IsStart; } }
        /// <summary>
        /// 初始化文件监测
        /// </summary>
        public FileWatcher()
        {
            DriveInfo[] drives = DriveInfo.GetDrives().Where(x => x.IsReady && (x.DriveType == DriveType.Fixed || x.DriveType == DriveType.Removable)).ToArray();
            if (ListTool.HasElements(drives))
            {
                foreach (var d in drives)
                {
                    //if (d.Name.Contains("C")) continue;
                    FileSystemWatcher fsw = new FileSystemWatcher(d.Name);
                    fsw.Created += CreatedEvent;//创建文件或目录
                    fsw.Changed += ChangedEvent;//更改文件或目录
                    fsw.Deleted += DeletedEvent;//删除文件或目录
                    fsw.Renamed += RenamedEvent;//重命名文件或目录
                    fsw.Error += ErrorEvent;
                    fsw.IncludeSubdirectories = true;
                    fsw.NotifyFilter = (NotifyFilters)383;
                    Watchers.Add(fsw);
                }
            }
        }
        /// <summary>
        /// 启动文件监测
        /// </summary>
        public void Start()
        {
            if (!_IsDisposed)
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
        }
        /// <summary>
        /// 停止文件监测
        /// </summary>
        public void Stop()
        {
            if (!_IsDisposed)
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
        }




        private void DriveMonitor()
        {
            //监测磁盘的插入拔出

        }


        private void CreatedEvent(object sender, FileSystemEventArgs e)
        {
            eventHandler?.Invoke(sender, new FileWatcherEventArgs(e.ChangeType, e.FullPath, Path.GetFileName(e.FullPath), null, null));
        }
        private void ChangedEvent(object sender, FileSystemEventArgs e)
        {
            eventHandler?.Invoke(sender, new FileWatcherEventArgs(e.ChangeType, e.FullPath, Path.GetFileName(e.FullPath), null, null));
        }
        private void DeletedEvent(object sender, FileSystemEventArgs e)
        {
            eventHandler?.Invoke(sender, new FileWatcherEventArgs(e.ChangeType, e.FullPath, Path.GetFileName(e.FullPath), null, null));
        }
        private void RenamedEvent(object sender, RenamedEventArgs e)
        {
            eventHandler?.Invoke(sender, new FileWatcherEventArgs(e.ChangeType, e.FullPath, Path.GetFileName(e.FullPath), e.OldFullPath, e.OldName));
        }
        private void ErrorEvent(object sender, ErrorEventArgs e)
        {
        }

        public void Dispose()
        {
            if (!_IsDisposed)
            {
                _IsStart = false;
                _IsDisposed = true;
                if (ListTool.HasElements(Watchers))
                {
                    foreach (var w in Watchers)
                    {
                        w.EnableRaisingEvents = false;
                        w.Dispose();
                    }
                }
            }
        }
    }
}
