using SharpPcap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.NetFlowMonitor
{
    //记录特定进程性能信息的类
    public class ProcessPerformanceInfo : IDisposable
    {
        public int ProcessID { get; set; }//进程ID
        public string ProcessName { get; set; }//进程名
        public float PrivateWorkingSet { get; set; }//私有工作集(KB)
        public float WorkingSet { get; set; }//工作集(KB)
        public float CpuTime { get; set; }//CPU占用率(%)
        public float IOOtherBytes { get; set; }//每秒IO操作（不包含控制操作）读写数据的字节数(KB)
        public int IOOtherOperations { get; set; }//每秒IO操作数（不包括读写）(个数)
        public long NetSendBytes { get; set; }//网络发送数据字节数
        public long NetRecvBytes { get; set; }//网络接收数据字节数
        public long NetTotalBytes { get; set; }//网络数据总字节数
        public List<ICaptureDevice> dev = new List<ICaptureDevice>();

        /// <summary>
        /// 实现IDisposable的方法
        /// </summary>
        public void Dispose()
        {
            foreach (ICaptureDevice d in dev)
            {
                d.StopCapture();
                d.Close();
            }
        }
    }
}
