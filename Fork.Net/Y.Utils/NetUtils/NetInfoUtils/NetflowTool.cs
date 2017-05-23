using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Y.Utils.AppUtils;
using Y.Utils.DataUtils.Collections;

namespace Y.Utils.NetUtils.NetInfoUtils
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
        private bool DataMonitorSwitch = false;

        public delegate void MonitorEvent(NetFlowTool n);
        public MonitorEvent DataMonitorEvent;

        private bool Init()
        {
            string[] instances = NetCardInfoTool.GetInstanceNames();
            if (ListTool.HasElements(instances))
            {
                UploadCounter = new List<PerformanceCounter>();
                DownloadCounter = new List<PerformanceCounter>();
                for (int i = 0; i < instances.Count(); i++)
                {
                    try
                    {
                        // 添加 上行流量计数器
                        UploadCounter.Add(new PerformanceCounter("Network Interface", "Bytes Sent/sec", instances[i]));
                    }
                    catch { }
                    try
                    {
                        // 添加 下行流量计数器
                        DownloadCounter.Add(new PerformanceCounter("Network Interface", "Bytes Received/sec", instances[i]));
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
        public bool Start()
        {
            if (Init() && !DataMonitorSwitch)
            {
                DataMonitorSwitch = true;

                Task.Factory.StartNew(() =>
                {
                    while (DataMonitorSwitch)
                    {
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
                        catch { }
                        DataMonitorEvent?.Invoke(this);
                        Thread.Sleep(DataCounterInterval);
                    }
                });
                return true;
            }
            return false;
        }
        public void Stop()
        {
            DataMonitorSwitch = false;
            foreach (var uc in UploadCounter)
            {
                uc?.Close();
            }
            foreach (var dc in DownloadCounter)
            {
                dc?.Close();
            }
        }
        ~NetFlowTool()
        {
            Stop();
        }
    }
}