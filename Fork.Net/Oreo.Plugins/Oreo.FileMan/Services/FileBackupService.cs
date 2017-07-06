using Oreo.FileMan.Commons;
using Oreo.FileMan.DatabaseEngine;
using Oreo.FileMan.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Y.Utils.DataUtils.Collections;
using Y.Utils.DataUtils.DateTimeUtils;
using Y.Utils.IOUtils.FileManUtils;
using Y.Utils.IOUtils.FileUtils;
using Y.Utils.IOUtils.PathUtils;

namespace Oreo.FileMan.Services
{
    public class FileBackupService
    {
        public List<BackupPaths> Paths = new List<BackupPaths>();//要备份的文件夹
        private FileWatcher Watcher = new FileWatcher(null);//文件监视器
        private List<string> BackupFiles = new List<string>();//当前要备份的文件任务

        public bool IsStart = false;
        public bool StatusOfReadBackupPaths = false;

        public int FileCount { get { return _FileCount; } }
        private int _FileCount = 0;

        public void Start()
        {
            if (!IsStart)
            {
                IsStart = true;

                Watcher.EventHandler += WatcherChangedEvent;
                Watcher.Start();//启动文件变动监听

                Task.Factory.StartNew(() =>
                {
                    ReadBackupFileCount();//读取备份文件总数
                    ReadBackupPaths();//读取备份文件夹列表
                    StatusOfReadBackupPaths = true;

                    if (ListTool.HasElements(Paths))
                    {
                        foreach (var p in Paths)
                        {
                            DefaultBackupFile(p.Path);//常规检查备份
                        }
                    }

                    BackupFileTask();//开始定时备份任务
                });
            }
        }
        public void Stop()
        {
            if (IsStart)
            {
                IsStart = false;
            }
        }

        /// <summary>
        /// 文件发生变动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WatcherChangedEvent(object sender, FileWatcherEventArgs e)
        {
            AddToBackupFiles(e.FullPath);
        }
        /// <summary>
        /// 定时处理要备份的文件任务
        /// </summary>
        private void BackupFileTask()
        {
            while (IsStart)
            {
                if (ListTool.HasElements(BackupFiles))
                {
                    //获取要备份的文件列表并复制样本
                    List<string> temp;
                    lock (BackupFiles)
                    {
                        temp = BackupFiles;
                        BackupFiles = new List<string>();
                    }

                    foreach (var t in temp)
                    {
                        if (File.Exists(t))
                        {
                            string filepath = DirTool.GetFilePath(t);
                            BackupPaths path = Paths.FirstOrDefault(x => filepath.Contains(x.Path));
                            if (path != null)
                            {
                                string pathname = path.Path;
                                string pathalias = path.Alias;
                                string pathfile = t.Substring(pathname.Length, t.Length - pathname.Length);
                                string fileext = DateTimeConvert.CompactString(DateTime.Now);
                                string fullpath = DirTool.Combine(R.Settings.FileBackup.FileManBackup, pathalias, pathfile + "." + fileext);

                                //删除冗余
                                DeleteExcess(t);
                                //备份文件
                                BackupFile(t, fullpath);
                                _FileCount++;
                            }
                        }
                    }
                }
                Thread.Sleep(R.Settings.FileBackup.BACK_UP_INTERVAL);
            }
        }

        /// <summary>
        /// 读取备份文件总数
        /// </summary>
        private void ReadBackupFileCount()
        {
            //统计备份文件总数
            using (var db = new Muse())
            {
                _FileCount = db.Do<BackupFiles>().Count();
            }
        }
        /// <summary>
        /// 读取备份文件夹列表
        /// </summary>
        private void ReadBackupPaths()
        {
            //读取要备份的文件路径列表
            using (var db = new Muse())
            {
                Paths = db.GetAll<BackupPaths>(null, false).ToList();
                if (ListTool.HasElements(Paths))
                {
                    foreach (var p in Paths)
                    {
                        AddToWatcherPath(p.Path);
                    }
                }
            }
        }
        /// <summary>
        /// 初始读取文件并备份
        /// </summary>
        public void DefaultBackupFile(string path)
        {
            //读取本地文件夹中的所有文件列表
            List<string> files = FileTool.GetAllFile(path);
            if (ListTool.HasElements(files))
            {
                foreach (var file in files)
                {
                    try
                    {
                        string lastwritetime = DateTimeConvert.StandardString(File.GetLastWriteTime(file));
                        using (var db = new Muse())
                        {
                            BackupFiles backfile = db.Get<BackupFiles>(x => x.FullPath == file && x.LastWriteTime == lastwritetime, null);
                            if (backfile == null) AddToBackupFiles(file);

                        }
                    }
                    catch (Exception e) { }
                }
            }
        }
        /// <summary>
        /// 添加要备份的文件到备份计划列表
        /// </summary>
        /// <param name="fullpath"></param>
        private void AddToBackupFiles(string fullpath)
        {
            if (Paths.Any(x => fullpath.Contains(x.Path)))
            {
                //变动的是文件且文件存在
                if (FileTool.IsFile(fullpath))
                {
                    //添加到备份列表
                    if (!BackupFiles.Contains(fullpath)) BackupFiles.Add(fullpath);
                    //UIDgvFileAdd(e.Name, e.FullPath, e.ChangeType.ToString());
                }
            }
        }
        /// <summary>
        /// 添加要备份的文件夹
        /// </summary>
        /// <param name="path"></param>
        public void AddToWatcherPath(string path)
        {
            Watcher.AddPath(path);//添加要备份的文件夹
            DefaultBackupFile(path);//常规检查备份文件夹
        }
        /// <summary>
        /// 删除超过备份最大次数的项
        /// </summary>
        private void DeleteExcess(string path)
        {
            using (var db = new Muse())
            {
                int count = db.Do<BackupFiles>().Count(x => x.FullPath == path);
                if (count >= R.Settings.FileBackup.BACK_UP_COUNT)
                {
                    var fs = db.Gets<BackupFiles>(x => x.FullPath == path, null).OrderBy(x => x.Id).ToList();
                    if (ListTool.HasElements(fs))
                    {
                        for (int i = 0; i <= count - R.Settings.FileBackup.BACK_UP_COUNT; i++)
                        {
                            try
                            {
                                File.Delete(fs[i].BackupFullPath);
                                db.Del(fs[i], true);
                            }
                            catch (Exception e) { }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 备份文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="newpath"></param>
        private void BackupFile(string path, string newpath)
        {
            using (var db = new Muse())
            {
                try
                {
                    if (DirTool.Create(DirTool.GetFilePath(newpath)))
                    {
                        string lastwritetime = DateTimeConvert.StandardString(File.GetLastWriteTime(path));
                        File.Copy(path, newpath, true);
                        db.Add(new BackupFiles()
                        {
                            FullPath = path,
                            BackupFullPath = newpath,
                            Size = FileTool.Size(path),
                            BackupTime = DateTimeConvert.StandardString(DateTime.Now),
                            LastWriteTime = lastwritetime,
                        });
                    }
                }
                catch (Exception e) { }
            }
        }
    }
}
