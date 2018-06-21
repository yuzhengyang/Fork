using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.Core.WindowsUtils.InfoUtils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Azylee.Core.NetUtils
{
    public class NetFlowTool
    {
        /// <summary>
        /// 上行数据流量
        /// </summary>
        public int UploadData { get { return _UploadData; } }
        private int _UploadData;

        /// <summary>
        /// 上行数据总流量
        /// </summary>
        public long UploadDataCount { get { return _UploadDataCount; } }
        private long _UploadDataCount;

        /// <summary>
        /// 下行数据流量
        /// </summary>
        public int DownloadData { get { return _DownloadData; } }
        private int _DownloadData;

        /// <summary>
        /// 下行数据总流量
        /// </summary>
        public long DownloadDataCount { get { return _DownloadDataCount; } }
        private long _DownloadDataCount;

        private List<PerformanceCounter> UploadCounter, DownloadCounter;//上行、下行流量计数器
        private int DataCounterInterval = 1000;//数据流量计数器计数周期
        private bool IsStart = false;

        public delegate void MonitorEvent(NetFlowTool n);
        public MonitorEvent DataMonitorEvent;

        public string[] Instances { get { return _Instances; } }
        private string[] _Instances;

        private bool Init()
        {
            _Instances = NetCardInfoTool.GetInstanceNames();
            if (ListTool.HasElements(_Instances))
            {
                UploadCounter = new List<PerformanceCounter>();
                DownloadCounter = new List<PerformanceCounter>();
                for (int i = 0; i < _Instances.Count(); i++)
                {
                    try
                    {
                        // 添加 上行流量计数器
                        UploadCounter.Add(new PerformanceCounter("Network Interface", "Bytes Sent/sec", _Instances[i]));
                    }
                    catch { }
                    try
                    {
                        // 添加 下行流量计数器
                        DownloadCounter.Add(new PerformanceCounter("Network Interface", "Bytes Received/sec", _Instances[i]));
                    }
                    catch { }
                }
            }

            if (ListTool.HasElements(UploadCounter) && ListTool.HasElements(DownloadCounter))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 启动流量监测
        /// </summary>
        /// <param name="interval"></param>
        /// <returns></returns>
        public bool Start(int interval = 1000)
        {
            if (Init() && !IsStart)
            {
                DataCounterInterval = interval;
                IsStart = true;

                Task.Factory.StartNew(() =>
                {
                    while (IsStart)
                    {
                        DataMonitorEvent?.Invoke(this);
                        try
                        {
                            _UploadDataCount += _UploadData;
                            _UploadData = 0;
                            foreach (var uc in UploadCounter)
                            {
                                _UploadData += (int)uc?.NextValue();
                            }
                            _DownloadDataCount += _DownloadData;
                            _DownloadData = 0;
                            foreach (var dc in DownloadCounter)
                            {
                                _DownloadData += (int)dc?.NextValue();
                            }
                        }
                        catch (Exception e)
                        {

                        }
                        Thread.Sleep(DataCounterInterval);
                    }
                });
                return true;
            }
            return false;
        }
        /// <summary>
        /// 重启流量计数器
        /// </summary>
        public void Restart()
        {
            if (IsStart)
            {
                foreach (var uc in UploadCounter)
                {
                    uc?.Close();
                }
                foreach (var dc in DownloadCounter)
                {
                    dc?.Close();
                }
            }

            Init();
        }
        /// <summary>
        /// 重置流量表数
        /// </summary>
        public void Reset()
        {
            _UploadData = 0;
            _UploadDataCount = 0;
            _DownloadData = 0;
            _DownloadDataCount = 0;
        }
        /// <summary>
        /// 停止流量监测
        /// </summary>
        public void Stop()
        {
            if (IsStart)
            {
                IsStart = false;
                foreach (var uc in UploadCounter)
                {
                    uc?.Close();
                }
                foreach (var dc in DownloadCounter)
                {
                    dc?.Close();
                }
            }
        }
        /// <summary>
        /// 终结器
        /// </summary>
        ~NetFlowTool()
        {
            Stop();
        }
    }
}