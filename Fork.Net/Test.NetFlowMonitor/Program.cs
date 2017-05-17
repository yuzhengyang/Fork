using SharpPcap;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Test.NetFlowMonitor
{
    class Program
    {
        public static ProcessPerformanceInfo ProcInfo { get; set; }
        static void Main(string[] args)
        {
            #region 第一步 获取指定进程使用的所有端口号
            Process p = Process.GetProcessesByName("Firefox")[0];
            ProcInfo = new ProcessPerformanceInfo();
            ProcInfo.ProcessID = p.Id;
            ProcInfo.ProcessName = p.ProcessName;
            //进程id
            int pid = ProcInfo.ProcessID;
            //存放进程使用的端口号链表
            List<int> ports = new List<int>();

            #region 获取指定进程对应端口号
            Process pro = new Process();
            pro.StartInfo.FileName = "cmd.exe";
            pro.StartInfo.UseShellExecute = false;
            pro.StartInfo.RedirectStandardInput = true;
            pro.StartInfo.RedirectStandardOutput = true;
            pro.StartInfo.RedirectStandardError = true;
            pro.StartInfo.CreateNoWindow = true;
            pro.Start();
            pro.StandardInput.WriteLine("netstat -ano");
            pro.StandardInput.WriteLine("exit");
            Regex reg = new Regex("\\s+", RegexOptions.Compiled);
            string line = null;
            ports.Clear();
            while ((line = pro.StandardOutput.ReadLine()) != null)
            {
                line = line.Trim();
                if (line.StartsWith("TCP", StringComparison.OrdinalIgnoreCase))
                {
                    line = reg.Replace(line, ",");
                    string[] arr = line.Split(',');
                    if (arr[4] == pid.ToString())
                    {
                        string soc = arr[1];
                        int pos = soc.LastIndexOf(':');
                        int pot = int.Parse(soc.Substring(pos + 1));
                        ports.Add(pot);
                    }
                }
                else if (line.StartsWith("UDP", StringComparison.OrdinalIgnoreCase))
                {
                    line = reg.Replace(line, ",");
                    string[] arr = line.Split(',');
                    if (arr[3] == pid.ToString())
                    {
                        string soc = arr[1];
                        int pos = soc.LastIndexOf(':');
                        int pot = int.Parse(soc.Substring(pos + 1));
                        ports.Add(pot);
                    }
                }
            }
            pro.Close();
            #endregion
            #endregion
            #region 第二步 获取本机IP地址和本机网络设备（即网卡）
            //获取本机IP地址
            IPAddress[] addrList = Dns.GetHostByName(Dns.GetHostName()).AddressList;
            string IP = addrList[0].ToString();
            //获取本机网络设备
            var devices = CaptureDeviceList.Instance;
            int count = devices.Count;
            if (count < 1)
            {
                Console.WriteLine("No device found on this machine");
                return;
            }
            #endregion
            #region 第三步 开始抓包
            //开始抓包
            for (int i = 0; i < count; ++i)
            {
                for (int j = 0; j < ports.Count; ++j)
                {
                    CaptureFlowRecv(IP, ports[j], i);
                    CaptureFlowSend(IP, ports[j], i);
                }
            }
            #endregion

            while (true)
            {
                Console.WriteLine("proc NetTotalBytes : " + ProcInfo.NetTotalBytes);
                Console.WriteLine("proc NetSendBytes : " + ProcInfo.NetSendBytes);
                Console.WriteLine("proc NetRecvBytes : " + ProcInfo.NetRecvBytes);

                //每隔1s调用刷新函数对性能参数进行刷新
                RefershInfo();
            }
            //最后要记得调用Dispose方法停止抓包并关闭设备
            ProcInfo.Dispose();
        }

        public static void CaptureFlowSend(string IP, int portID, int deviceID)
        {
            ICaptureDevice device = (ICaptureDevice)CaptureDeviceList.New()[deviceID];

            device.OnPacketArrival += new PacketArrivalEventHandler(device_OnPacketArrivalSend);

            int readTimeoutMilliseconds = 1000;
            device.Open(DeviceMode.Promiscuous, readTimeoutMilliseconds);

            string filter = "src host " + IP + " and src port " + portID;
            device.Filter = filter;
            device.StartCapture();
            ProcInfo.dev.Add(device);
        }

        public static void CaptureFlowRecv(string IP, int portID, int deviceID)
        {
            ICaptureDevice device = CaptureDeviceList.New()[deviceID];
            device.OnPacketArrival += new PacketArrivalEventHandler(device_OnPacketArrivalRecv);

            int readTimeoutMilliseconds = 1000;
            device.Open(DeviceMode.Promiscuous, readTimeoutMilliseconds);

            //string filter = "dst host " + IP + " and dst port " + portID;
            //device.Filter = filter;
            device.StartCapture();
            ProcInfo.dev.Add(device);
        }
        private static void device_OnPacketArrivalSend(object sender, CaptureEventArgs e)
        {
            var len = e.Packet.Data.Length;
            ProcInfo.NetSendBytes += len;

            Console.WriteLine("NowUp={0} Up: {1}KB  Down: {2}KB", e.Packet.Data.Length, ProcInfo.NetSendBytes / 1024, ProcInfo.NetRecvBytes / 1024);
        }

        private static void device_OnPacketArrivalRecv(object sender, CaptureEventArgs e)
        {
            var len = e.Packet.Data.Length;
            ProcInfo.NetRecvBytes += len;
            Console.WriteLine("NowDown={0} Up: {1}KB  Down: {2}KB", e.Packet.Data.Length, ProcInfo.NetSendBytes / 1024, ProcInfo.NetRecvBytes / 1024);
        }
        /// <summary>
        /// 实时刷新性能参数
        /// </summary>
        public static void RefershInfo()
        {
            ProcInfo.NetRecvBytes = 0;
            ProcInfo.NetSendBytes = 0;
            ProcInfo.NetTotalBytes = 0;
            Thread.Sleep(1000);
            ProcInfo.NetTotalBytes = ProcInfo.NetRecvBytes + ProcInfo.NetSendBytes;
        }
    }
}
