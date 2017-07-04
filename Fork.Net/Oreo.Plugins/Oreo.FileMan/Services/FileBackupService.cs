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
        public FileWatcher Watcher = new FileWatcher(null);
        public string FileManBackup = @"G:\FileManBackup\";
        public List<BackupPaths> Paths = new List<BackupPaths>();

        List<string> BackupFiles = new List<string>();
        int BACK_UP_INTERVAL = 5 * 1000;
        int BACK_UP_COUNT = 5;
        bool IsStart = false;

        public void Start()
        {
            if (!IsStart)
            {
                IsStart = true;

                Watcher.eventHandler += WatcherChangedEvent;
                Watcher.Start();//启动文件变动监听

                Task.Factory.StartNew(() =>
                {
                    ReadBackupPaths();//读取备份文件夹列表
                    //常规检查备份
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
        private void WatcherChangedEvent(object sender, FileWatcherEventArgs e)
        {
            if (Paths.Any(x => e.FullPath.Contains(x.Path)))
            {
                //变动的是文件且文件存在
                if (FileTool.IsFile(e.FullPath))
                {
                    //添加到备份列表
                    if (!BackupFiles.Contains(e.FullPath)) BackupFiles.Add(e.FullPath);
                    //UIDgvFileAdd(e.Name, e.FullPath, e.ChangeType.ToString());
                }
            }
        }
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
                                string fullpath = DirTool.Combine(FileManBackup, pathalias, pathfile + "." + fileext);

                                //删除冗余
                                DeleteExcess(t);
                                //备份文件
                                BackupFile(t, fullpath);
                            }
                        }
                    }
                }
                Thread.Sleep(BACK_UP_INTERVAL);
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
                        Watcher.AddPath(p.Path);
                    }
                }
            }
        }
        public void DefaultBackupFileTask()
        {
            if (ListTool.HasElements(Paths))
            {
                foreach (var p in Paths)
                {

                }
            }
        }
        /// <summary>
        /// 删除超过备份最大次数的项
        /// </summary>
        private void DeleteExcess(string path)
        {
            using (var db = new Muse())
            {
                int count = db.Do<BackupFiles>().Count(x => x.FullPath == path);
                if (count >= BACK_UP_COUNT)
                {
                    var fs = db.Gets<BackupFiles>(x => x.FullPath == path, null).OrderBy(x => x.Id).ToList();
                    if (ListTool.HasElements(fs))
                    {
                        for (int i = 0; i <= count - BACK_UP_COUNT; i++)
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
                        File.Copy(path, newpath, true);
                        db.Add(new BackupFiles()
                        {
                            FullPath = path,
                            BackupFullPath = newpath,
                            Size = FileTool.Size(path),
                            BackupTime = DateTimeConvert.StandardString(DateTime.Now),
                        });
                    }
                }
                catch (Exception e) { }
            }
        }
    }
}
