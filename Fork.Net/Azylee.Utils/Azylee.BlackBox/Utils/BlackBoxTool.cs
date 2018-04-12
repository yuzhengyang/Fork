using Azylee.BlackBox.Models;
using Azylee.Core.AppUtils;
using Azylee.Core.IOUtils.DirUtils;
using Azylee.Core.IOUtils.TxtUtils;
using Azylee.Core.Plus.DataUtils.JsonUtils;
using Azylee.Core.WindowsUtils.APIUtils;
using Azylee.Core.WindowsUtils.InfoUtils;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azylee.BlackBox.Utils
{
    public sealed class BlackBoxTool
    {
        #region 单例模式
        private static BlackBoxTool _BlackBoxTool;
        private static readonly object syncObject = new object();
        private BlackBoxTool() { }
        public static BlackBoxTool Instance
        {
            get
            {
                if (_BlackBoxTool == null)
                    lock (syncObject)
                        if (_BlackBoxTool == null)
                            _BlackBoxTool = new BlackBoxTool();
                return _BlackBoxTool;
            }
        }
        #endregion
        DateTime Time = DateTime.Now;
        int Interval = 1 * 1000;
        Task Listener = null;
        CancellationTokenSource CancelToken = new CancellationTokenSource();
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
                RunningStatus status = new RunningStatus()
                {
                    Time = Time,
                    Long = Interval,
                    AFK = WindowsAPI.GetLastInputTime(),
                    CpuPer = ComputerStatusTool.CpuUtilization(),
                    RamSize = (long)ComputerInfoTool.TotalPhysicalMemory(),
                    RamFree = (long)ComputerInfoTool.AvailablePhysicalMemory(),
                    SysDriveSize = ComputerInfoTool.GetSystemDriveTotalSize(),
                    SysDriveFree = ComputerInfoTool.GetSystemDriveAvailableSize(),
                    AppCpuPer = AppInfoTool.CPU(),
                    AppRamUsed = AppInfoTool.RAM(),
                };
                TxtTool.Append(
                    DirTool.Combine(AppDomain.CurrentDomain.BaseDirectory, "BlackBox-Status.txt"),
                    JsonTool.ToStr(status));
            }
            catch { }
        }
    }
}
