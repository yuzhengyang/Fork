using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.Core.DataUtils.StringUtils;
using Azylee.Core.IOUtils.DirUtils;
using Azylee.Core.IOUtils.FileUtils;
using Azylee.Core.IOUtils.TxtUtils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Azylee.Core.LogUtils.FormActiveLogUtils
{
    public sealed class FormActiveLog
    {
        #region 单例模式
        private static FormActiveLog _inst;
        private static readonly object syncObject = new object();
        private FormActiveLog() { }
        public static FormActiveLog Instance
        {
            get
            {
                if (_inst == null)
                    lock (syncObject)
                        if (_inst == null)
                            _inst = new FormActiveLog();
                return _inst;
            }
        }
        #endregion

        #region 基础属性
        const string LOG_PATH = @"azylee.log";//存储路径
        const int Interval = 1000;//监测间隔时间

        private int CACHE_DAYS = 30;//缓存天数
        private string LogPath = AppDomain.CurrentDomain.BaseDirectory + LOG_PATH;//存储路径
        private DateTime Time = DateTime.Now;//标记当前时间
        private Task Listener = null;//监测任务
        private Process AppProcess = Process.GetCurrentProcess();
        private CancellationTokenSource CancelToken = new CancellationTokenSource();//监测取消Token
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
                        FormActiveLogModel active = new FormActiveLogModel();
                        while (!CancelToken.IsCancellationRequested)
                        {
                            active.EndTime = DateTime.Now;

                            Form form = Form.ActiveForm;
                            if ((form?.Name ?? "") != active.FormName)
                            {
                                WriteStatus(active);//写出数据
                                active.FormName = form?.Name ?? "";
                                active.FormText = form?.Text ?? "";
                                active.BeginTime = DateTime.Now;
                            }

                            Thread.Sleep(Interval);//等待间隔时间
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
        /// 写出运行时状态信息
        /// </summary>
        private void WriteStatus(FormActiveLogModel status)
        {
            try
            {
                if (status != null)// && Str.Ok(status.FormName, status.FormText))// && status.Duration > 0
                {
                    //设置日志目录和日志文件
                    string path = DirTool.Combine(LogPath, "form_active");
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
            string path = DirTool.Combine(LogPath, "form_active");
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
