using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oreo.NetMonitor.Models
{
    /// <summary>
    /// 联网进程
    /// </summary>
    public class NetProcess
    {

        public NetProcess()
        {
            Ports = new List<ProcessPort>();
        }
        /// <summary>
        /// 当前进程
        /// </summary>
        public Process CurrentProcess
        {
            get
            {
                return Process.GetProcessById(ProcessID);
            }
        }

        /// <summary>
        /// 联网端口列表
        /// </summary>
        public List<ProcessPort> Ports { get; set; }
        public long UpBag { get; set; }
        public long DownBag { get; set; }
        /// <summary>
        /// 上传
        /// </summary>
        public long UpLoad { get; set; }

        /// <summary>
        /// 下载
        /// </summary>
        public long DownLoad { get; set; }
        public long UpLoadCount { get; set; }
        public long DownLoadCount { get; set; }
        public long FlowCount { get; set; }
        /// <summary>
        /// 应用图标
        /// </summary>
        public Icon ProcessICon { get; set; }

        public int ProcessID { get; set; }
        public string ProcessName { get; set; }
        /// <summary>
        /// 添加流量
        /// </summary>
        /// <param name="currentFlowCount">当前瞬时流量</param>
        /// <param name="port"></param>
        /// <returns></returns>
        public bool AddFlow(long currentFlowCount, int port, bool isUpload)
        {
            if (Ports != null && Ports.Count > 0)
            {
                ProcessPort _pp = Ports.FirstOrDefault(x => x.Port == port);
                if (_pp != null)
                {
                    if (isUpload)
                    {
                        UpLoad += currentFlowCount;
                    }
                    else
                    {
                        DownLoad += currentFlowCount;
                    }
                    return true;
                }
            }
            return false;
        }

    }
}
