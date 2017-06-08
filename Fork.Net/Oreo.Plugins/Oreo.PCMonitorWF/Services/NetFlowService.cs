using Oreo.PCMonitor.Commons;
using Oreo.PCMonitor.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using Y.Utils.AppUtils;
using Y.Utils.DataUtils.Collections;
using Y.Utils.NetUtils.NetInfoUtils;
using Y.Utils.WindowsUtils.ProcessUtils;

namespace Oreo.PCMonitor.Services
{
    public class NetFlowService
    {
        public bool IsNetFlowRun { get { return _IsNetFlowRun; } }
        private bool _IsNetFlowRun = false;
        public bool IsNetPacketRun { get { return _IsNetPacketRun; } }
        private bool _IsNetPacketRun = false;

        public List<NetProcessInfo> NetProcessInfoList = new List<NetProcessInfo>();
        public List<NetConnectionInfo> NetConnectionInfoList = new List<NetConnectionInfo>();

        public NetFlowTool NetFlow = new NetFlowTool();
        List<NetPacketTool> NetPacketList = new List<NetPacketTool>();

        NetProcessTool.TcpRow[] TcpConnection;
        NetProcessTool.UdpRow[] UdpConnection;
        Process[] NowProcess;
        List<string> AllIPv4Address = new List<string>();

        public long LostPacketCount { get; set; }

        public void Start()
        {
            #region 启动系统性能计数器统计
            try
            {
                NetFlow.Start();
                NetFlow.DataMonitorEvent += DataMonitorEvent;
                _IsNetFlowRun = true;
            }
            catch { }
            #endregion

            #region 启动Socket包统计
            if (PermissionTool.IsAdmin())
            {
                List<IPAddress> hosts = NetCardInfoTool.GetIPv4Address();
                AllIPv4Address = NetCardInfoTool.GetAllIPv4Address();
                foreach (var host in hosts)
                {
                    try
                    {
                        NetPacketTool p = new NetPacketTool(host);
                        p.NewPacket += new NewPacketEventHandler(NewPacketEvent);
                        p.Start();
                        NetPacketList.Add(p);
                    }
                    catch { }
                }
                if (ListTool.HasElements(NetPacketList)) _IsNetPacketRun = true;
            }
            #endregion
        }
        public void Stop()
        {
            if (_IsNetFlowRun)
            {
                NetFlow.Stop();
                _IsNetFlowRun = false;
            }

            if (_IsNetPacketRun)
            {
                NetPacketList.ForEach(x => { x.Stop(); });
                _IsNetPacketRun = false;
            }
        }

        public void DataMonitorEvent(NetFlowTool n)
        {
            NowProcess = Process.GetProcesses();
            GetConnection();
            SetNetProcess();
            CalcNetProcessInfo();

            CheckRestart();
            //#region 统计
            //p.Protocol == Protocol.Tcp
            //#endregion
        }
        private void NewPacketEvent(NetPacketTool tool, Packet packet)
        {
            bool isGather = false;
            #region 整理TCP包
            if (packet.Protocol == Protocol.Tcp && ListTool.HasElements(TcpConnection) && ListTool.HasElements(NowProcess))
            {
                lock (TcpConnection)
                {
                    // tcp 下载
                    if (TcpConnection.Any(x => x.RemoteIP.ToString() == packet.DestinationAddress.ToString() && x.RemotePort == packet.DestinationPort))
                    {
                        var tcpDownload = TcpConnection.FirstOrDefault(x => x.RemoteIP.ToString() == packet.DestinationAddress.ToString() && x.RemotePort == packet.DestinationPort);
                        var process = NowProcess.FirstOrDefault(x => x.Id == tcpDownload.ProcessId);
                        if (process != null)
                        {
                            var info = NetProcessInfoList.FirstOrDefault(x => x.ProcessName == process.ProcessName);
                            if (info != null)
                            {
                                isGather = true;
                                info.DownloadBag += packet.TotalLength;
                                info.DownloadBagCount += packet.TotalLength;
                            }
                        }
                    }
                    // tcp 上传
                    if (TcpConnection.Any(x => x.LocalIP.ToString() == packet.SourceAddress.ToString() && x.LocalPort == packet.SourcePort))
                    {
                        var tcUpload = TcpConnection.FirstOrDefault(x => x.LocalIP.ToString() == packet.SourceAddress.ToString() && x.LocalPort == packet.SourcePort);
                        var process = NowProcess.FirstOrDefault(x => x.Id == tcUpload.ProcessId);
                        if (process != null)
                        {
                            var info = NetProcessInfoList.FirstOrDefault(x => x.ProcessName == process.ProcessName);
                            if (info != null)
                            {
                                isGather = true;
                                info.UploadBag += packet.TotalLength;
                                info.UploadBagCount += packet.TotalLength;
                            }
                        }
                    }
                }
            }
            #endregion
            #region 整理UDP包
            if (packet.Protocol == Protocol.Udp && ListTool.HasElements(UdpConnection) && ListTool.HasElements(NowProcess))
            {
                lock (UdpConnection)
                {
                    // tcp 下载
                    if (UdpConnection.Any(x => x.LocalPort == packet.DestinationPort) && AllIPv4Address.Contains(packet.DestinationAddress.ToString()))
                    {
                        var udpDownload = UdpConnection.FirstOrDefault(x => AllIPv4Address.Contains(x.LocalIP.ToString()) && x.LocalPort == packet.DestinationPort);
                        var process = NowProcess.FirstOrDefault(x => x.Id == udpDownload.ProcessId);
                        if (process != null)
                        {
                            var info = NetProcessInfoList.FirstOrDefault(x => x.ProcessName == process.ProcessName);
                            if (info != null)
                            {
                                isGather = true;
                                info.DownloadBag += packet.TotalLength;
                                info.DownloadBagCount += packet.TotalLength;
                                if (info.ProcessName == "Idle")
                                {

                                }
                            }
                        }
                    }
                    // udp 上传
                    if (UdpConnection.Any(x => x.LocalPort == packet.SourcePort) && AllIPv4Address.Contains(packet.SourceAddress.ToString()))
                    {
                        var udpIp = AllIPv4Address.FirstOrDefault(x => x == packet.SourceAddress.ToString());
                        var ucUpload = UdpConnection.FirstOrDefault(x => AllIPv4Address.Contains(x.LocalIP.ToString()) && x.LocalPort == packet.SourcePort);
                        var process = NowProcess.FirstOrDefault(x => x.Id == ucUpload.ProcessId);
                        if (process != null)
                        {
                            var info = NetProcessInfoList.FirstOrDefault(x => x.ProcessName == process.ProcessName);
                            if (info != null)
                            {
                                isGather = true;
                                info.UploadBag += packet.TotalLength;
                                info.UploadBagCount += packet.TotalLength;
                                if (info.ProcessName == "Idle")
                                {

                                }
                            }
                        }
                    }
                }
            }
            #endregion
            if (!isGather)
            {
                LostPacketCount++;
            }
        }

        #region 获取当前程序的所有连接
        void GetConnection()
        {
            TcpConnection = NetProcessTool.GetTcpConnection();
            UdpConnection = NetProcessTool.GetUdpConnection();
        }
        #endregion
        #region 设置程序流量及连接数统计列表
        void SetNetProcess()
        {
            // 清空已有连接数
            if (ListTool.HasElements(NetProcessInfoList))
                NetProcessInfoList.ForEach(x =>
                {
                    x.ConnectCount = 0;
                });

            // 统计TCP连接数
            if (ListTool.HasElements(TcpConnection))
            {
                foreach (var t in TcpConnection)
                {
                    SetNetProcessConnection(t.ProcessId);
                }
            }
            // 统计UDP连接数
            if (ListTool.HasElements(UdpConnection))
            {
                foreach (var u in UdpConnection)
                {
                    SetNetProcessConnection(u.ProcessId);
                }
            }
        }
        void SetNetProcessConnection(int pid)
        {
            try
            {
                Process p = NowProcess.FirstOrDefault(x => x.Id == pid);
                if (p != null)
                {
                    var ppl = NetProcessInfoList.FirstOrDefault(x => x.ProcessName == p.ProcessName);
                    if (ppl == null)
                    {
                        NetProcessInfoList.Add(
                            new NetProcessInfo()
                            {
                                ProcessIcon = ProcessInfoTool.GetIcon(p, false),
                                ProcessName = p.ProcessName,
                                ConnectCount = 1,
                                LastUpdateTime = DateTime.Now,
                            });
                    }
                    else
                    {
                        ppl.ConnectCount++;
                        ppl.LastUpdateTime = DateTime.Now;
                    }
                }
            }
            catch (Exception e)
            {
                R.Log.e("对程序列表和网络连接列表整理时发生错误");
                R.Log.e(e.Message);
            }
        }
        #endregion
        #region 整理程序流量汇总信息
        void CalcNetProcessInfo()
        {
            if (ListTool.HasElements(NetProcessInfoList))
            {
                NetProcessInfoList.ForEach(p =>
                {
                    p.UploadDataCount += p.UploadData;
                    p.DownloadDataCount += p.DownloadData;
                });

                int allupbag = NetProcessInfoList.Sum(x => x.UploadBag);
                int alldownbag = NetProcessInfoList.Sum(x => x.DownloadBag);

                NetProcessInfoList.ForEach(p =>
                {
                    if (allupbag > 0 && NetFlow.UploadData > 0)
                    {
                        float uprate = (float)p.UploadBag / allupbag;
                        p.UploadData = (int)(uprate * NetFlow.UploadData);
                    }
                    if (alldownbag > 0 && NetFlow.DownloadData > 0)
                    {
                        float downrate = (float)p.DownloadBag / alldownbag;
                        p.DownloadData = (int)(downrate * NetFlow.DownloadData);
                    }

                    p.UploadBag = 0;
                    p.DownloadBag = 0;
                    p.LastUpdateTime = DateTime.Now;
                });
            }
        }
        #endregion
        #region 联网断网重启计划
        private void CheckRestart()
        {
            bool rest = false;

            string[] ints = NetCardInfoTool.GetInstanceNames();
            if (ListTool.IsNullOrEmpty(NetFlow.Instances) && ListTool.HasElements(ints))
            {
                rest = true;
            }
            if (ListTool.HasElements(NetFlow.Instances) && ListTool.HasElements(ints) &&
                string.Join("-", NetFlow.Instances) != string.Join("-", ints))
            {
                rest = true;
            }

            if (rest)
            {
                //重启 系统性能计数器
                NetFlow.Restart();
                //重启 抓包监听
                List<IPAddress> hosts = NetCardInfoTool.GetIPv4Address();
                AllIPv4Address = NetCardInfoTool.GetAllIPv4Address();
                foreach (var host in hosts)
                {
                    try
                    {
                        if (!NetPacketList.Any(x => x.IP.ToString() == host.ToString()))
                        {
                            NetPacketTool p = new NetPacketTool(host);
                            p.NewPacket += new NewPacketEventHandler(NewPacketEvent);
                            p.Start();
                            NetPacketList.Add(p);
                        }
                    }
                    catch { }
                }
            }
        }
        #endregion
    }
}
