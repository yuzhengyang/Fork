using Oreo.NetMonitor.Commons;
using Oreo.NetMonitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Y.Utils.AppUtils;
using Y.Utils.DataUtils.Collections;
using Y.Utils.DataUtils.UnitConvertUtils;
using Y.Utils.NetUtils.NetInfoUtils;

namespace Oreo.NetMonitor.Services
{
    public class NetFlowService
    {
        public bool IsNetFlowRun { get { return _IsNetFlowRun; } }
        private bool _IsNetFlowRun = false;
        public bool IsNetPacketRun { get { return _IsNetPacketRun; } }
        private bool _IsNetPacketRun = false;

        List<ProcessPacket> ProcessPacketList = new List<ProcessPacket>();
        NetFlowTool NetFlow = new NetFlowTool();
        List<NetPacketTool> NetPacketList = new List<NetPacketTool>();

        NetProcessTool.TcpRow[] TcpConnection;
        NetProcessTool.UdpRow[] UdpConnection;

        private long LostPacketCount { get; set; }

        public void Start()
        {
            GetConnection();

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
            //GetConnection();
            //#region 统计
            //p.Protocol == Protocol.Tcp
            //#endregion
        }
        private void NewPacketEvent(NetPacketTool pm, Packet p)
        {
            // 给数据包归类，并添加至列表
            bool isGather = false;
            lock (TcpConnection)
            {
                if (ListTool.HasElements(TcpConnection))
                {
                    var tr = TcpConnection.First(x => x.LocalIP == p.SourceAddress && x.LocalPort == p.SourcePort);
                    //if (tr != null)
                    {
                        var np = ProcessPacketList.First(x => x.ProcessID == tr.ProcessId);
                        if (np != null)
                        {
                            np.UploadBag += p.TotalLength;
                        }
                    }
                }
            }
            lock (UdpConnection)
            {
                if (ListTool.HasElements(UdpConnection))
                {
                    NetProcessTool.UdpRow ur = UdpConnection.First(x => x.LocalIP == p.SourceAddress && x.LocalPort == p.SourcePort);

                }
            }
            if (!isGather) LostPacketCount++;
        }

        #region 获取当前连接
        public void GetConnection()
        {
            TcpConnection = NetProcessTool.GetTcpConnection();
            UdpConnection = NetProcessTool.GetUdpConnection();
        }
        #endregion
    }
}
