using CapturePackage;
using Oreo.NetMonitor.Models;
using Oreo.NetMonitor.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Y.Utils.DataUtils.UnitConvertUtils;

namespace Oreo.NetMonitor.Views
{
    public partial class NetReportForm : Form
    {

        NativeSocket2 _rs;
        long NowBag = 0;
        //string IP = "10.49.138.175";
        string IP = "";
        List<NetProcess> netProcesses = new List<NetProcess>();
        DateTime BeginTime = DateTime.Now;
        DateTime MaxTime = DateTime.Now.AddMinutes(NetWorkService.ThresholdTime * 2);

        public NetReportForm()
        {
            InitializeComponent();
        }
        private void NetReportForm_Load(object sender, EventArgs e)
        {
            #region 启动功能
            this.ShowInTaskbar = false;
            this.Hide();
            IP = GetIP();
            Task.Factory.StartNew(() =>
            {
                try
                {
                    while (!this.IsDisposed)
                    {
                        GetNetProcess();
                        CalcBagFlow();
                        this.Invoke(new Action(() =>
                        {
                            status.Text = string.Format("信息：IP：{0}，上传流量：{1}，下载流量：{2}",
                                IP, ByteConvertTool.Fmt(NetWorkService.NowSent), ByteConvertTool.Fmt(NetWorkService.NowReceived));
                            status.Text += string.Format("\n单位时间：{0}分钟，上传流量：{1}，下载流量：{2}",
                                NetWorkService.ThresholdTime, ByteConvertTool.Fmt(NetWorkService.UnitSent), ByteConvertTool.Fmt(NetWorkService.UnitReceived));
                            status.Text += string.Format("\n当前时间：{0}，下次刷新时间：{1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), NetWorkService.CalcTime.ToString("yyyy-MM-dd HH:mm:ss"));

                            if ((NetWorkService.UnitSent + NetWorkService.UnitReceived) < NetWorkService.FlowThreshold || DateTime.Now > MaxTime)
                            {
                                NetWorkService.WriteRecord(BeginTime, DateTime.Now, netProcesses, IP);
                                this.Dispose();
                            }
                        }));
                        Thread.Sleep(1000);
                    }
                }
                catch { }
            });
            CaptureInit();
            Task.Factory.StartNew(() => { try { _rs.Capture(); } catch { } });
            #endregion
        }

        #region 抓包过程
        private void CaptureInit()
        {
            _rs = new NativeSocket2(IPAddress.Parse(IP));
            _rs.IsStart = true;
            _rs.OnIPPacketCapure = (IPPacket tp) =>
            {
                this.Invoke(new Action(() =>
                {
                    try
                    {
                        if (tp.SrcAddr.ToString() == IP)
                        {
                            //源地址是本机-从本机发出
                            lock (netProcesses)
                            {
                                foreach (var item in netProcesses)
                                {
                                    int inPort = item.Ports.Where(x => x.Port == tp.SrcPort).Count(); ;
                                    if (inPort > 0)
                                    {
                                        item.UpBag++;
                                        if (item.UpBag > 1000) item.UpBag = 0;
                                        NowBag++;
                                    }
                                }
                            }
                        }
                        if (tp.DestAddr.ToString() == IP)
                        {
                            //目标地址是本机-本机接收
                            lock (netProcesses)
                            {
                                foreach (var item in netProcesses)
                                {
                                    int inPort = item.Ports.Where(x => x.Port == tp.DestPort).Count(); ;
                                    if (inPort > 0)
                                    {
                                        item.DownBag++;
                                        if (item.DownBag > 1000) item.DownBag = 0;
                                        NowBag++;
                                    }
                                }
                            }
                        }
                    }
                    catch { }
                }));

            };
        }
        #endregion
        #region 联网进程
        private void GetNetProcess()
        {
            foreach (var item in NetProcessAPI.GetAllTcpConnections())
            {
                AddTCPNetProcess(item);
            }
            foreach (var item in NetProcessAPI.GetAllUdpConnections())
            {
                AddUDPNetProcess(item);
            }
        }
        private void AddTCPNetProcess(TcpRow item)
        {
            try
            {
                var _netProcess = netProcesses.FirstOrDefault(x => x.ProcessID == item.owningPid);
                if (_netProcess == null)
                {
                    _netProcess = new NetProcess() { ProcessID = item.owningPid, ProcessName = ProcessAPI.GetProcessNameByPID(item.owningPid) };
                    netProcesses.Add(_netProcess);
                }
                if (_netProcess.Ports.FirstOrDefault(x => x.Port == item.LocalPort) == null)
                {
                    _netProcess.ProcessICon = ProcessAPI.GetIcon(item.owningPid, true);
                }
                _netProcess.Ports.Add(GetTcpProcessPort(item));
            }
            catch (Exception e)
            {

            }
        }
        private void AddUDPNetProcess(UdpRow item)
        {
            try
            {
                var _netProcess = netProcesses.FirstOrDefault(x => x.ProcessID == item.owningPid);
                if (_netProcess == null)
                {
                    _netProcess = new NetProcess() { ProcessID = item.owningPid, ProcessName = ProcessAPI.GetProcessNameByPID(item.owningPid) };
                    netProcesses.Add(_netProcess);
                }
                if (_netProcess.Ports.FirstOrDefault(x => x.Port == item.LocalPort) == null)
                {
                    _netProcess.ProcessICon = ProcessAPI.GetIcon(item.owningPid, true);
                    _netProcess.Ports.Add(GetUDPProcessPort(item));
                }
            }
            catch (Exception e)
            {

            }
        }
        private ProcessPort GetTcpProcessPort(TcpRow tr)
        {
            ProcessPort _pp = new ProcessPort()
            {
                LocalAddress = tr.LocalAddress.ToString(),
                Port = tr.LocalPort,
                RemoteAddress = tr.RemoteAddress.ToString(),
                Type = ProtocolType.TCPType,
                RemotePort = tr.RemotePort,

            };
            return _pp;
        }
        private ProcessPort GetUDPProcessPort(UdpRow tr)
        {
            ProcessPort _pp = new ProcessPort()
            {
                LocalAddress = tr.LocalAddress.ToString(),
                Port = tr.LocalPort,
                RemoteAddress = "",
                Type = ProtocolType.UDPType,
                RemotePort = 0,

            };
            return _pp;
        }
        #endregion
        #region 矫正流量
        private void CalcBagFlow()
        {
            lock (netProcesses)
            {
                foreach (var pro in netProcesses)
                {
                    long temp = pro.UpBag + pro.DownBag;
                    double rate = 0;
                    if (NowBag > 0 && temp > 0)
                        rate = (double)temp / (double)NowBag;
                    pro.UpLoad = (long)(NetWorkService.NowSent * rate);
                    pro.DownLoad = (long)(NetWorkService.NowReceived * rate);
                    pro.UpLoadCount += pro.UpLoad;
                    pro.DownLoadCount += pro.DownLoad;
                    pro.UpBag = 0;
                    pro.DownBag = 0;
                }
            }
            NowBag = 0;
        }
        #endregion
        #region 获取IP
        public string GetIP()
        {
            IPHostEntry myEntry = Dns.GetHostEntry(Dns.GetHostName());
            return myEntry.AddressList.FirstOrDefault<IPAddress>(e => e.AddressFamily.ToString().Equals("InterNetwork")).ToString();
        }
        #endregion


    }
}
