//************************************************************************
//      https://github.com/yuzhengyang
//      author:     yuzhengyang
//      date:       2018.4.17 - 2018.4.17
//      desc:       程序运行状态日志
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************
using Azylee.Core.AppUtils;
using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.Core.IOUtils.DirUtils;
using Azylee.Core.IOUtils.FileUtils;
using Azylee.Core.IOUtils.TxtUtils;
using Azylee.Core.WindowsUtils.APIUtils;
using Azylee.Core.WindowsUtils.InfoUtils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azylee.Core.LogUtils.StatusLogUtils
{
    public sealed class StatusLog
    {
        #region 单例模式
        private static StatusLog _StatusLog;
        private static readonly object syncObject = new object();
        private StatusLog() { }
        public static StatusLog Instance
        {
            get
            {
                if (_StatusLog == null)
                    lock (syncObject)
                        if (_StatusLog == null)
                            _StatusLog = new StatusLog();
                return _StatusLog;
            }
        }
        #endregion

        #region 基础属性
        const string LOG_PATH = "StatusLog";//存储路径
        const int CACHE_DAYS = 30;//缓存天数

        public string LogPath = LOG_PATH;//存储路径

        DateTime Time = DateTime.Now;//标记当前时间
        int Interval = 60 * 1000;//监测间隔时间

        Task Listener = null;//监测任务
        CancellationTokenSource CancelToken = new CancellationTokenSource();//监测取消Token
        PerformanceCounter ComputerProcessor = ComputerStatusTool.Processor();//电脑CPU监控
        PerformanceCounter AppProcessor = AppInfoTool.Processor();//程序CPU监控
        #endregion

        public bool Start()
        {
            //如果任务停止运行，则重新创建Token，并释放上次任务
            if (Listener != null && Listener.Status != TaskStatus.Running)
            {
                try
                {
                    CancelToken = new CancellationTokenSource();
                    Listener.Dispose();
                }
                catch { }
            }
            //如果任务没取消，并且没有运行任务，则运行任务
            if (!CancelToken.IsCancellationRequested && (Listener == null || Listener.Status != TaskStatus.Running))
            {
                Listener = Task.Factory.StartNew(() =>
                {
                    try
                    {
                        //using (Muse db = new Muse())
                        //{
                        //    CollectData(db);
                        while (!CancelToken.IsCancellationRequested)
                        {
                            Time = DateTime.Now;
                            Thread.Sleep(Interval);
                            CollectData();
                        }
                        //}
                    }
                    catch { }
                }, CancelToken.Token);
                return true;
            }
            return false;
        }
        public bool Stop()
        {
            try
            {
                if (!CancelToken.IsCancellationRequested)
                {
                    CancelToken.Cancel();
                }
                return true;
            }
            catch { return false; }
        }
        private void CollectData()
        {
            try
            {
                StatusLogModel status = new StatusLogModel()
                {
                    Time = Time,
                    Long = Interval,
                    AFK = WindowsAPI.GetLastInputTime(),
                    CpuPer = (int)ComputerProcessor.NextValue(),
                    RamSize = (long)ComputerInfoTool.TotalPhysicalMemory(),
                    RamFree = (long)ComputerInfoTool.AvailablePhysicalMemory(),
                    SysDriveSize = ComputerInfoTool.GetSystemDriveTotalSize(),
                    SysDriveFree = ComputerInfoTool.GetSystemDriveAvailableSize(),
                    AppCpuPer = (int)AppProcessor.NextValue(),
                    AppRamUsed = AppInfoTool.RAM(),
                };

                WriteFile(status);
                Cleaner();
            }
            catch { }
        }
        private void WriteFile(StatusLogModel status)
        {
            //设置日志目录
            string logPath = AppDomain.CurrentDomain.BaseDirectory + LogPath;
            string file = string.Format(@"{0}\{1}.txt", logPath, DateTime.Now.ToString("yyyy-MM-dd"));
            //创建日志目录
            DirTool.Create(logPath);
            //写出日志
            TxtTool.Append(file, status.ToString());
        }
        private void Cleaner()
        {
            List<string> files = FileTool.GetFile(AppDomain.CurrentDomain.BaseDirectory + LogPath);
            if (ListTool.HasElements(files))
            {
                files.ForEach(f =>
                {
                    try
                    {
                        string filename = Path.GetFileNameWithoutExtension(f);
                        if (filename.Length == 10)
                        {
                            DateTime date = DateTime.Parse(filename);
                            if (date < Time.AddDays(-CACHE_DAYS - 1)) FileTool.Delete(f);
                        }
                        else { FileTool.Delete(f); }
                    }
                    catch { FileTool.Delete(f); }
                });
            }
        }
    }
}
