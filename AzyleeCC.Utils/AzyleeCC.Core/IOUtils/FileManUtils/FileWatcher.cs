using AzyleeCC.Core.DataUtils.CollectionUtils;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AzyleeCC.Core.IOUtils.FileManUtils
{
    /// <summary>
    /// 文件更改通知
    /// </summary>
    public class FileWatcher
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
        public FileWatcherEventHandler EventHandler;

        private int Interval = 10 * 1000;
        private bool _IsWatching = false;
        private ConcurrentDictionary<string, FileSystemWatcher> Watchers = new ConcurrentDictionary<string, FileSystemWatcher>();

        /// <summary>
        /// 文件更改监控已启动
        /// </summary>
        public bool IsWatching { get { return _IsWatching; } }

        /// <summary>
        /// 创建文件监控类
        /// </summary>
        /// <param name="paths"></param>
        public FileWatcher(string[] paths)
        {
            if (ListTool.HasElements(paths))
            {
                foreach (var p in paths)
                {
                    if (Directory.Exists(p) && !Watchers.ContainsKey(p))
                        Watchers.TryAdd(p, null);
                }
            }
        }

        public bool AddPath(string path)
        {
            if (Directory.Exists(path) && !Watchers.ContainsKey(path))
                return Watchers.TryAdd(path, null);
            return false;
        }
        public bool DelPath(string path)
        {
            if (Watchers.ContainsKey(path))
            {
                FileSystemWatcher temp;
                if (Watchers.TryRemove(path, out temp) && temp != null)
                {
                    temp.EnableRaisingEvents = false;
                    temp.Dispose();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 启动文件监测
        /// </summary>
        public void Start()
        {
            if (!_IsWatching)
            {
                _IsWatching = true;
                Task.Factory.StartNew(() =>
                {
                    while (_IsWatching)
                    {
                        foreach (var item in Watchers)
                        {
                            if (item.Value == null)
                            {
                                if (Directory.Exists(item.Key))
                                {
                                    Watchers.TryUpdate(item.Key, CreateWatcher(item.Key), null);
                                }
                            }
                            else
                            {
                                if (!Directory.Exists(item.Key))
                                {
                                    item.Value.EnableRaisingEvents = false;
                                    item.Value.Dispose();
                                    Watchers.TryUpdate(item.Key, null, item.Value);
                                }
                            }
                        }

                        Thread.Sleep(Interval);
                    }
                    _IsWatching = false;
                });
            }
        }
        /// <summary>
        /// 停止文件监测
        /// </summary>
        public void Stop()
        {
            _IsWatching = false;
            foreach (var item in Watchers.Keys)
            {
                if (Watchers.ContainsKey(item))
                {
                    if (Watchers[item] != null) Watchers[item].EnableRaisingEvents = false;

                    FileSystemWatcher temp;
                    if (Watchers.TryRemove(item, out temp) && temp != null)
                    {
                        temp.EnableRaisingEvents = false;
                        temp.Dispose();
                    }
                }
            }
        }

        private FileSystemWatcher CreateWatcher(string path)
        {
            FileSystemWatcher fsw = new FileSystemWatcher(path);
            fsw.Created += CreatedEvent;//创建文件或目录
            fsw.Changed += ChangedEvent;//更改文件或目录
            fsw.Deleted += DeletedEvent;//删除文件或目录
            fsw.Renamed += RenamedEvent;//重命名文件或目录
            fsw.Error += ErrorEvent;
            fsw.IncludeSubdirectories = true;
            fsw.NotifyFilter = (NotifyFilters)383;
            fsw.EnableRaisingEvents = true;
            return fsw;
        }
        private void CreatedEvent(object sender, FileSystemEventArgs e)
        {
            EventHandler?.Invoke(sender, new FileWatcherEventArgs(e.ChangeType, e.FullPath, Path.GetFileName(e.FullPath), null, null));
        }
        private void ChangedEvent(object sender, FileSystemEventArgs e)
        {
            EventHandler?.Invoke(sender, new FileWatcherEventArgs(e.ChangeType, e.FullPath, Path.GetFileName(e.FullPath), null, null));
        }
        private void DeletedEvent(object sender, FileSystemEventArgs e)
        {
            EventHandler?.Invoke(sender, new FileWatcherEventArgs(e.ChangeType, e.FullPath, Path.GetFileName(e.FullPath), null, null));
        }
        private void RenamedEvent(object sender, RenamedEventArgs e)
        {
            EventHandler?.Invoke(sender, new FileWatcherEventArgs(e.ChangeType, e.FullPath, Path.GetFileName(e.FullPath), e.OldFullPath, e.OldName));
        }
        private void ErrorEvent(object sender, ErrorEventArgs e)
        { }
    }
}
