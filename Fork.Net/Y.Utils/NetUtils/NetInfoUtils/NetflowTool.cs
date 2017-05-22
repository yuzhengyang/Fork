using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Y.Utils.NetUtils.NetInfoUtils
{
    public class NetflowTool
    {

        /// <summary>
        /// 网卡名称
        /// </summary>
        public string NetcardName { get { return _NetcardName; } }
        private string _NetcardName;

        /// <summary>
        /// 上行数据流量
        /// </summary>
        public int UploadData { get { return _UploadData; } }
        private int _UploadData;

        /// <summary>
        /// 上行数据包数
        /// </summary>
        public int UploadBag { get { return _UploadBag; } }
        private int _UploadBag;

        /// <summary>
        /// 上行数据总流量
        /// </summary>
        public long UploadDataCount { get { return _UploadDataCount; } }
        private long _UploadDataCount;

        /// <summary>
        /// 上行数据包总数
        /// </summary>
        public long UploadBagCount { get { return _UploadBagCount; } }
        private long _UploadBagCount;

        /// <summary>
        /// 下行数据流量
        /// </summary>
        public int DownloadData { get { return _DownloadData; } }
        private int _DownloadData;

        /// <summary>
        /// 下行数据包数
        /// </summary>
        public int DownloadBag { get { return _DownloadBag; } }
        private int _DownloadBag;

        /// <summary>
        /// 下行数据总流量
        /// </summary>
        public long DownloadDataCount { get { return _DownloadDataCount; } }
        private long _DownloadDataCount;

        /// <summary>
        /// 下行数据包总数
        /// </summary>
        public long DownloadBagCount { get { return _DownloadBagCount; } }
        private long _DownloadBagCount;

        private PerformanceCounter UploadCounter;//上行流量计数器
        private PerformanceCounter DownloadCounter;//下行流量计数器
        private int DataCounterInterval = 1000;//数据流量计数器计数周期
        private int BagCounterInterval = 1000;//数据包计数器计数周期
        private bool DataMonitorStarted = false;
        private bool BagMonitorStarted = false;

        /// <summary>
        /// 初始化网卡
        /// </summary>
        public void InitNetcard(string name)
        {
            UploadCounter = new PerformanceCounter("Network Interface", "Bytes Sent/sec", name);
            DownloadCounter = new PerformanceCounter("Network Interface", "Bytes Received/sec", name);
        }

        /// <summary>
        /// 初始化配置
        /// </summary>
        /// <param name="dataItv">数据流量计数器计数周期</param>
        /// <param name="bagItv">数据包计数器计数周期</param>
        public void InitSettings(int dataItv, int bagItv)
        {
            DataCounterInterval = dataItv;
            BagCounterInterval = bagItv;
        }

        public bool StartDataMonitor()
        {
            if (!DataMonitorStarted)
            {
                DataMonitorStarted = true;

                Task.Factory.StartNew(() =>
                {
                    while (DataMonitorStarted)
                    {
                        try
                        {
                            _UploadDataCount += _UploadData;
                            float x1 = UploadCounter.NextValue();
                            _UploadData = (int)x1;

                            _DownloadDataCount += _DownloadData;
                            float x2 = DownloadCounter.NextValue();
                            _DownloadData = (int)x2;
                        }
                        catch { }
                        Thread.Sleep(DataCounterInterval);
                    }
                });
                return true;
            }
            return false;
        }
    }
}