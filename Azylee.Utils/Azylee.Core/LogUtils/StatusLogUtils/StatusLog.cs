//************************************************************************
//      author:     yuzhengyang
//      date:       2018.4.17 - 2018.4.27
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
        const string LOG_PATH = @"azylee.log";//存储路径
        const int Interval = 1000;//监测间隔时间
        const int WriteInterval = 60 * Interval;//写出间隔时间

        private int CACHE_DAYS = 30;//缓存天数
        private string LogPath = AppDomain.CurrentDomain.BaseDirectory + LOG_PATH;//存储路径
        private DateTime Time = DateTime.Now;//标记当前时间
        private Task Listener = null;//监测任务
        private Process AppProcess = Process.GetCurrentProcess();
        private CancellationTokenSource CancelToken = new CancellationTokenSource();//监测取消Token
        private PerformanceCounter ComputerProcessor = ComputerStatusTool.Processor();//电脑CPU监控
        #endregion

        public void SetLogPath(string path)
        {
            if (!string.IsNullOrWhiteSpace(path))
            {
                LogPath = DirTool.Combine(path, LOG_PATH);
            }
        }
        public void SetCacheDays(int days)
        {
            if (days >= 0) CACHE_DAYS = days;
        }

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
                        WriteConfig();
                        int runtime = 0;//运行时间（毫秒）
                        long afk = WindowsAPI.GetLastInputTime();//空闲时间缓存
                        TimeSpan pin = TimeSpan.Zero;//程序运行时间戳
                        StatusLogModel status = null;//运行状态信息模型
                        while (!CancelToken.IsCancellationRequested)
                        {
                            pin = AppProcess.TotalProcessorTime;//程序运行时间戳
                            runtime += Interval;//增加运行时间
                            Thread.Sleep(Interval);//等待间隔时间

                            //每秒钟都会执行的操作
                            CollectStatus(ref status, runtime, afk, pin);//收集数据
                            afk = WindowsAPI.GetLastInputTime();//空闲时间缓存

                            //每分钟进行汇总输出
                            if (runtime >= WriteInterval)
                            {
                                WriteStatus(status);//写出数据
                                runtime = 0;//重置运行时间
                                status = null;//重置数据
                            }
                        }
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
        /// <summary>
        /// 写出资源配置信息
        /// </summary>
        private void WriteConfig()
        {
            //记录固定资源信息
            string path = DirTool.Combine(LogPath, "resource");
            string file = DirTool.Combine(path, "computer.ini");
            //创建目录
            DirTool.Create(path);
            //写出信息
            IniTool.WriteValue(file, "system", "ram", ComputerInfoTool.TotalPhysicalMemory().ToString());
            IniTool.WriteValue(file, "system", "drive", ComputerInfoTool.GetSystemDriveTotalSize().ToString());
        }
        /// <summary>
        /// 收集数据
        /// </summary>
        /// <returns></returns>
        private bool CollectStatus(ref StatusLogModel status, int runtime, long afk, TimeSpan pin)
        {
            try
            {
                int count = runtime / Interval;//收集次数，用来帮助平均值计算

                if (status == null) status = new StatusLogModel() { Time = DateTime.Now };
                //固定值数据
                status.Long = runtime;//运行时长
                //累计值数据
                long afktemp = WindowsAPI.GetLastInputTime() - afk;
                if (afktemp > 0) status.AFK = status.AFK + afktemp;
                //计算平均值数据
                int cpu = 0;
                try { cpu = (int)ComputerProcessor.NextValue(); } catch { }//CPU占用
                long ram = (long)ComputerInfoTool.AvailablePhysicalMemory();//系统可用内存
                int appcpu = (int)AppInfoTool.CalcCpuRate(AppProcess, pin, Interval);//程序CPU占用
                long appram = AppInfoTool.RAM();//程序内存占用
                long sysdisk = ComputerInfoTool.GetSystemDriveAvailableSize();//系统盘可用空间

                status.CpuPer = ((count - 1) * status.CpuPer + cpu) / count;//CPU占用
                status.RamFree = ((count - 1) * status.RamFree + ram) / count;//系统可用内存
                status.AppCpuPer = ((count - 1) * status.AppCpuPer + appcpu) / count;//程序CPU占用
                status.AppRamUsed = ((count - 1) * status.AppRamUsed + appram) / count;//程序内存占用
                status.SysDriveFree = ((count - 1) * status.SysDriveFree + sysdisk) / count;//系统盘可用空间
                return true;
            }
            catch { return false; }
        }
        /// <summary>
        /// 写出运行时状态信息
        /// </summary>
        private void WriteStatus(StatusLogModel status)
        {
            try
            {
                if (status != null)
                {
                    //处理比率
                    status.Long = status.Long / 1000;
                    status.AFK = status.AFK / 1000;

                    //设置日志目录和日志文件
                    string path = DirTool.Combine(LogPath, "status");
                    string file = DirTool.Combine(path, DateTime.Now.ToString("yyyy-MM-dd") + ".txt");
                    //创建日志目录
                    DirTool.Create(path);
                    //写出日志
                    TxtTool.Append(file, status.ToString());
                }
                Cleaner();
            }
            catch { }
        }
        /// <summary>
        /// 清理过多的状态信息文件
        /// </summary>
        private void Cleaner()
        {
            string path = DirTool.Combine(LogPath, "status");
            List<string> files = FileTool.GetFile(path);
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
