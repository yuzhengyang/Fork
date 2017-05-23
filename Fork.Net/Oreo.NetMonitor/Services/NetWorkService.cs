using CapturePackage;
using Oreo.NetMonitor.Commons;
using Oreo.NetMonitor.Helpers;
using Oreo.NetMonitor.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Y.Utils.DataUtils.Collections;
using Y.Utils.DataUtils.JsonUtils;
using Y.Utils.NetUtils.NetInfoUtils;
using Y.Utils.WindowsUtils.InfoUtils;

namespace Oreo.NetMonitor.Services
{
    public class NetWorkService
    {
        #region 参数
        //CPU占用状态
        private static bool CpuLoadRun = false;
        public static bool CpuLoadLoop = false;
        //总流量监控状态
        private static bool NetFlowRun = false;
        public static bool NetFlowLoop = false;
        //抓包流量状态
        private static bool NetCaptureRun = false;
        public static bool NetCaptureLoop = false;
        //程序连接数任务状态
        private static bool ProConnRun = false;
        public static bool ProConnLoop = false;
        //开始时间
        public static DateTime BeginTime = DateTime.Now;
        //统计时间
        public static DateTime CalcTime = DateTime.Now;
        //当前流量、单位临时记录流量、单位时间流量、总流量
        public static double NowSent = 0, NowReceived = 0;
        public static double TempSent = 0, TempReceived = 0;
        public static double UnitSent = 0, UnitReceived = 0;
        public static double SentCount = 0, ReceivedCount = 0;
        //流量阈值（B）
        public static double FlowThreshold = 100 * 1024 * 1024;
        //达到阈值时间（分钟）
        public static int ThresholdTime = 5;
        //程序连接数阈值
        public static int MaxProConnect = 50;
        //记录程序IP访问记录周期
        public static int RecProConnect = 10;
        //包数
        public static long NowBag = 0, NowBadBag = 0, BagCount = 0;
        //进程列表
        public static List<NetProcess> netProcesses = new List<NetProcess>();
        //IP地址
        public static string IP = "192.168.3.56";
        //抓包对象
        public static NativeSocket2 NS;
        //CPU占用
        public static double CpuLoad = 0;
        //处理器信息
        public static PerformanceCounter Processor = new PerformanceCounter("Processor", "% Processor Time", "_Total");

        //网卡信息
        public static PerformanceCounterCategory performanceCounterCategory = new PerformanceCounterCategory("Network Interface");
        public static string[] instances = performanceCounterCategory.GetInstanceNames();
        public static PerformanceCounter[] pfSent = new PerformanceCounter[instances.Count()];
        public static PerformanceCounter[] pfReceived = new PerformanceCounter[instances.Count()];
        #endregion

        #region 私有构造（阻止new）
        private NetWorkService() { }
        #endregion
        #region 启动服务
        public static void Start()
        {
            //Task.Factory.StartNew(() =>
            //{
            //    InitNetCard();
            //    while (Enable)
            //    {
            //        GetCpuLoad();//读取CPU占用
            //        GetNetFlow();//获取总网速
            //        GetNetProcess();//获取联网进程
            //        NetBagToPro();//数据包整理到进程

            //        Thread.Sleep(1000);
            //        CalcBagFlow();//计算进程流量
            //    }
            //});
            ////获取实时数据包
            //GetIP();
            //GetNetBag();
        }
        public static void StartCpuLoad()
        {
            if (!CpuLoadRun)
            {
                CpuLoadRun = true;
                Task.Factory.StartNew(() =>
                {
                    try
                    {
                        while (CpuLoadLoop)
                        {
                            GetCpuLoad();//读取CPU占用
                            Thread.Sleep(1000);
                        }
                        CpuLoadRun = false;
                    }
                    catch (Exception ex)
                    {
                        R.Log.e("StartCpuLoad异常" + ex.Message);
                    }
                });
            }
        }
        public static void StartNetFlow()
        {
            if (!NetFlowRun)
            {
                NetFlowRun = true;
                Task.Factory.StartNew(() =>
                {
                    try
                    {
                        InitSettings();
                        InitNetCard();
                        while (NetFlowLoop)
                        {
                            GetNetFlow();//获取总网速
                            Thread.Sleep(1000);
                        }
                        NetFlowRun = false;
                    }
                    catch (Exception ex)
                    {
                        R.Log.e("StartNetFlow异常" + ex.Message);
                    }
                });
            }
        }
        public static void StartNetCapture()
        {
            int span = 0;
            if (!NetCaptureRun)
            {
                NetCaptureRun = true;
                Task.Factory.StartNew(() =>
                {
                    //获取实时数据包
                    #region 设置IP
                    var networkInfo = NetCardInfoTool.GetNetworkCardInfo();
                    if (!ListTool.IsNullOrEmpty(networkInfo))
                    {
                        IP = networkInfo[0].Item3;
                    }
                    #endregion
                    GetNetBag();
                    GetNetProcess();//获取联网进程

                    while (NetCaptureLoop)
                    {
                        //if (span >= 1)
                        //{
                        //    GetNetProcess();//获取联网进程
                        //    span = 0;
                        //}
                        Thread.Sleep(1000);
                        CalcBagFlow();//计算进程流量
                        span++;
                    }
                    NS.IsStart = false;
                    NetCaptureRun = false;
                });
            }
        }
        public static void StartConnectCheck()
        {
            if (!ProConnRun)
            {
                ProConnRun = true;
                Task.Factory.StartNew(() =>
                {
                    try
                    {
                        List<string> connInfo = GetProConnInfo2();
                        //LogHelper.writeLog(string.Format("y-connInfo web 访问记录信息条数：{0}", connInfo == null ? "null" : connInfo.Count().ToString()));
                        DateTime maxConnRunTime = DateTime.Now.AddMinutes(ThresholdTime);
                        DateTime recConnRunTime = DateTime.Now.AddSeconds(RecProConnect);
                        List<string> rcd = new List<string>();
                        while (ProConnLoop)
                        {
                            #region 发送连接数超限数据
                            if (DateTime.Now > maxConnRunTime)
                            {
                                try
                                {
                                    List<ProConnRecordBag> rec = GetNetConn();
                                    foreach (var r in rec)
                                    {
                                        if (r.Count > MaxProConnect)
                                        {
                                            SendProConnRecord(r);
                                            //LogHelper.writeLog("y-监控软件连接数超过上限");
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    R.Log.v(string.Format("y-监控软件连接数运行异常：{0}", ex.Message));
                                }
                                maxConnRunTime = DateTime.Now.AddMinutes(ThresholdTime);
                            }
                            #endregion
                            #region 发送访问记录
                            try
                            {
                                List<ProConnRecordBag> rec = GetNetConn();
                                if (connInfo != null && connInfo.Count() > 0)
                                {
                                    #region 统计本次访问记录
                                    //循环服务器IP列表
                                    foreach (var _info in connInfo)
                                    {
                                        //循环软件列表
                                        foreach (var r in rec)
                                        {
                                            //如果软件连接>0
                                            if (r.Count > 0)
                                            {
                                                //循环记录
                                                foreach (var _r in r.Record)
                                                {
                                                    //过滤 0. 和 127. 开头 ip
                                                    string tempr = "filter" + _r.RI;
                                                    if (!tempr.Contains("filter0.") && !tempr.Contains("filter127."))
                                                    {
                                                        //循环端口
                                                        foreach (var _p in _r.Conn)
                                                        {
                                                            //仅通过Established：连接成功
                                                            if (_p.Status == "Established")
                                                            {
                                                                #region 新访问记录处理方法
                                                                //把IP和端口号转换为组
                                                                List<string> ipnum = string.Format("{0}.{1}", _r.RI, _p.RP).Trim().Split('.').ToList();
                                                                List<string> infonum = _info.Trim().Replace(":", ".").Split('.').ToList();

                                                                if (ipnum != null && ipnum.Count() == 5 && infonum != null && infonum.Count() == 5)
                                                                {
                                                                    bool match = true;
                                                                    for (int i = 0; i < 5; i++)
                                                                    {
                                                                        if (infonum[i] == "*") continue;
                                                                        if (ipnum[i] == infonum[i]) continue;
                                                                        string[] numarr = infonum[i].Split('-');
                                                                        if (numarr != null && numarr.Count() == 2)
                                                                        {
                                                                            try
                                                                            {
                                                                                if (int.Parse(ipnum[i]) >= int.Parse(numarr[0]) &&
                                                                                    int.Parse(ipnum[i]) <= int.Parse(numarr[1]))
                                                                                    continue;
                                                                            }
                                                                            catch { }
                                                                        }
                                                                        match = false;
                                                                    }
                                                                    if (match && !rcd.Contains(string.Format("{0}:{1}", _r.RI, _p.RP).Trim()))
                                                                        rcd.Add(string.Format("{0}:{1}", _r.RI, _p.RP).Trim());
                                                                }
                                                                #endregion
                                                            }
                                                            #region 2016年10月17日（原有访问记录处理方法备份）
                                                            //string con = string.Format("{0}:{1}", _r.RI, _p.RP);
                                                            //if (_info == con)
                                                            //{
                                                            //    if (!rcd.Contains(_info))
                                                            //        rcd.Add(_info);
                                                            //}
                                                            #endregion
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    #endregion
                                    #region 周期发送记录
                                    if (DateTime.Now > recConnRunTime)
                                    {
                                        //组装结果字符串并发送回服务器
                                        if (rcd != null && rcd.Count() > 0)
                                        {
                                            string result = "";
                                            foreach (var _info in rcd)
                                            {
                                                result += _info + ",";
                                            }
                                            result = result.Substring(0, result.Length - 1);
                                            bool send_res = SendHelper.Send("46", result + "&");
                                            //LogHelper.writeLog(result + "&");
                                        }
                                        rcd = new List<string>();
                                        recConnRunTime = DateTime.Now.AddSeconds(RecProConnect);
                                    }
                                    #endregion
                                }
                                else
                                {
                                    if (DateTime.Now > recConnRunTime)
                                    {
                                        connInfo = GetProConnInfo2();
                                        //LogHelper.writeLog(string.Format("y-connInfo web 访问记录信息条数：{0}", connInfo == null ? "null" : connInfo.Count().ToString()));
                                        recConnRunTime = DateTime.Now.AddSeconds(RecProConnect);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                R.Log.e(string.Format("y-监控访问记录异常：{0}", ex.Message));
                            }
                            #endregion
                            Thread.Sleep(1000);
                        }
                        ProConnRun = false;
                    }
                    catch (Exception ex)
                    {
                        R.Log.e("StartConnectCheck发送连接数异常" + ex.Message);
                    }
                });
            }
        }
        #endregion

        #region 初始化流量记录配置
        public static void InitSettings()
        {
            BeginTime = DateTime.Now;//开始时间
            int _time = 0, _maxConn = 0, _recConn = 0;
            double _flow = 0;
            try
            {
                _time = R.Settings.ThresholdTime;
                _flow = R.Settings.FlowThreshold;
                _maxConn = R.Settings.MaxProConnect;
                _recConn = R.Settings.RecProConnect;
            }
            catch { }
            if (_flow > 0) FlowThreshold = _flow;
            if (_time > 0) ThresholdTime = _time;
            if (_maxConn > 0) MaxProConnect = _maxConn;
            if (_recConn > 0) RecProConnect = _recConn;

            CalcTime = DateTime.Now.AddMinutes(ThresholdTime);//统计时间
            //LogHelper.writeLog(string.Format("y-读取流量参数设置：FlowThreshold{0}-ThresholdTime{1}-MaxProConnect{2}-RecProConnect{3}", FlowThreshold, ThresholdTime, MaxProConnect, RecProConnect));
        }
        #endregion
        #region 初始化网卡适配器
        public static void InitNetCard()
        {
            for (int i = 0; i < instances.Count(); i++)
            {
                pfSent[i] = new PerformanceCounter("Network Interface", "Bytes Sent/sec", instances[i]);
                pfReceived[i] = new PerformanceCounter("Network Interface", "Bytes Received/sec", instances[i]);
            }
        }
        #endregion
        #region 获取网卡网络流量
        private static void GetNetFlow()
        {
            NowSent = 0;
            NowReceived = 0;
            try
            {
                for (int i = 0; i < instances.Count(); i++)
                {
                    NowSent += pfSent[i].NextValue();
                    NowReceived += pfReceived[i].NextValue();
                }
            }
            catch { }

            SentCount += NowSent;
            ReceivedCount += NowReceived;

            TempSent += NowSent;
            TempReceived += NowReceived;
            if (DateTime.Now >= CalcTime)
            {
                CalcTime = DateTime.Now.AddMinutes(ThresholdTime);
                UnitSent = TempSent;
                UnitReceived = TempReceived;
                TempSent = 0;
                TempReceived = 0;
            }
        }
        #endregion
        #region 获取联网进程列表
        private static void GetNetProcess()
        {
            lock (netProcesses)
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
        }
        private static void AddTCPNetProcess(TcpRow item)
        {
            try
            {
                var _netProcess = netProcesses.FirstOrDefault(x => x.ProcessID == item.owningPid);
                if (_netProcess == null)
                {
                    _netProcess = new NetProcess() { ProcessID = item.owningPid };
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
        private static void AddUDPNetProcess(UdpRow item)
        {
            try
            {
                var _netProcess = netProcesses.FirstOrDefault(x => x.ProcessID == item.owningPid);
                if (_netProcess == null)
                {
                    _netProcess = new NetProcess() { ProcessID = item.owningPid };
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
        private static ProcessPort GetTcpProcessPort(TcpRow tr)
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
        private static ProcessPort GetUDPProcessPort(UdpRow tr)
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
        #region 获取所有网络连接
        private static List<ProConnRecordBag> GetNetConn()
        {
            List<ProConnRecordBag> rec = new List<ProConnRecordBag>();
            TcpRow[] tlist = NetProcessAPI.GetAllTcpConnections();
            foreach (var item in tlist)
            {
                var pro = rec.FirstOrDefault(x => x.Name == item.owningPid.ToString());
                if (pro == null)
                {
                    pro = new ProConnRecordBag() { Name = item.owningPid.ToString(), Count = 0, Record = new List<ProConnRecord>() };
                    rec.Add(pro);
                }
                var ipConn = pro.Record.FirstOrDefault(x => x.LI == item.LocalAddress.ToString() && x.RI == item.RemoteAddress.ToString());
                if (ipConn == null)
                {
                    ipConn = new ProConnRecord() { LI = item.LocalAddress.ToString(), RI = item.RemoteAddress.ToString(), Conn = new List<ProConnPort>() };
                    pro.Record.Add(ipConn);
                }
                ipConn.Conn.Add(new ProConnPort() { LP = item.LocalPort, RP = item.RemotePort, TP = ProtocolType.TCPType.ToString().Replace("Type", ""), Status = item.state.ToString() });
                pro.Count++;
            }
            UdpRow[] ulist = NetProcessAPI.GetAllUdpConnections();
            foreach (var item in ulist)
            {
                var pro = rec.FirstOrDefault(x => x.Name == item.owningPid.ToString());
                if (pro == null)
                {
                    pro = new ProConnRecordBag() { Name = item.owningPid.ToString(), Count = 0, Record = new List<ProConnRecord>() };
                    rec.Add(pro);
                }
                var ipConn = pro.Record.FirstOrDefault(x => x.LI == item.LocalAddress.ToString());
                if (ipConn == null)
                {
                    ipConn = new ProConnRecord() { LI = item.LocalAddress.ToString(), Conn = new List<ProConnPort>() };
                    pro.Record.Add(ipConn);
                }
                ipConn.Conn.Add(new ProConnPort() { LP = item.LocalPort, TP = ProtocolType.TCPType.ToString().Replace("Type", "") });
                pro.Count++;
            }
            return rec;
        }
        #endregion
        #region 获取联网进程列表：新列表
        private static void GetNetPro(List<NetProcess> proList)
        {
            foreach (var item in NetProcessAPI.GetAllTcpConnections())
            {
                AddTCPNetPro(item, proList);
            }
            foreach (var item in NetProcessAPI.GetAllUdpConnections())
            {
                AddUDPNetPro(item, proList);
            }
        }
        private static void AddTCPNetPro(TcpRow item, List<NetProcess> proList)
        {
            try
            {
                var _netProcess = proList.FirstOrDefault(x => x.ProcessID == item.owningPid);
                if (_netProcess == null)
                {
                    _netProcess = new NetProcess() { ProcessID = item.owningPid, ProcessName = ProcessAPI.GetProcessNameByPID(item.owningPid) };
                    proList.Add(_netProcess);
                }
                if (_netProcess.Ports.FirstOrDefault(x => x.Port == item.LocalPort) == null)
                {
                    _netProcess.ProcessICon = ProcessAPI.GetIcon(item.owningPid, true);
                }
                _netProcess.Ports.Add(GetTcpProPort(item));
            }
            catch (Exception e)
            {

            }
        }
        private static void AddUDPNetPro(UdpRow item, List<NetProcess> proList)
        {
            try
            {
                var _netProcess = proList.FirstOrDefault(x => x.ProcessID == item.owningPid);
                if (_netProcess == null)
                {
                    _netProcess = new NetProcess() { ProcessID = item.owningPid, ProcessName = ProcessAPI.GetProcessNameByPID(item.owningPid) };
                    proList.Add(_netProcess);
                }
                if (_netProcess.Ports.FirstOrDefault(x => x.Port == item.LocalPort) == null)
                {
                    _netProcess.ProcessICon = ProcessAPI.GetIcon(item.owningPid, true);
                    _netProcess.Ports.Add(GetUDPProPort(item));
                }
            }
            catch (Exception e)
            {

            }
        }
        private static ProcessPort GetTcpProPort(TcpRow tr)
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
        private static ProcessPort GetUDPProPort(UdpRow tr)
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
        #region 获取网络数据包（间隔：实时）
        private static void GetNetBag()
        {
            NS = new NativeSocket2(IPAddress.Parse(IP));
            NS.IsStart = true;
            NS.OnIPPacketCapure = (IPPacket tp) =>
            {
                BagCount++;
                if (tp.SrcAddr.ToString() == IP)
                {
                    //源地址是本机-从本机发出
                    lock (netProcesses)
                    {
                        bool _in = false;
                        foreach (var item in netProcesses)
                        {
                            int inPort = item.Ports.Where(x => x.Port == tp.SrcPort).Count(); ;
                            if (inPort > 0)
                            {
                                item.UpBag++;
                                NowBag++;
                                _in = true;
                                //item.Upload += tp.DataLen;
                                //item.FlowCount += tp.DataLen;
                            }
                        }
                        if (!_in) NowBadBag++;
                    }
                }
                if (tp.DestAddr.ToString() == IP)
                {
                    //目标地址是本机-本机接收
                    lock (netProcesses)
                    {
                        bool _in = false;
                        foreach (var item in netProcesses)
                        {
                            int inPort = item.Ports.Where(x => x.Port == tp.DestPort).Count(); ;
                            if (inPort > 0)
                            {
                                item.DownBag++;
                                NowBag++;
                                _in = true;
                                //item.DownLoad += tp.DataLen;
                                //item.FlowCount += tp.DataLen;
                            }
                        }
                        if (!_in) NowBadBag++;
                    }
                }
            };
            Task.Factory.StartNew(() => { NS.Capture(); });
        }
        #endregion
        #region 矫正数据流量
        private static void CalcBagFlow()
        {
            lock (netProcesses)
            {
                foreach (var pro in netProcesses)
                {
                    long temp = pro.UpBag + pro.DownBag;
                    double rate = 0;
                    if (NowBag > 0 && temp > 0)
                        rate = (double)temp / (double)NowBag;
                    if (temp > 0 && temp != NowBag)
                    {
                        int i = 0;
                    }
                    pro.UpLoad = (long)(NowSent * rate);
                    pro.DownLoad = (long)(NowReceived * rate);
                    pro.UpLoadCount += pro.UpLoad;
                    pro.DownLoadCount += pro.DownLoad;
                    pro.UpBag = 0;
                    pro.DownBag = 0;
                }
            }
            NowBag = 0;
            NowBadBag = 0;
        }
        #endregion
        #region 读取CPU占用率
        private static void GetCpuLoad()
        {
            try { CpuLoad = Processor.NextValue(); } catch { }
        }
        #endregion

        #region 存储发送联网流量记录
        public static void WriteRecord(DateTime beginTime, DateTime endTime, List<NetProcess> netProcesses, string ip)
        {
            NetRecordBag rs = new NetRecordBag();
            rs.IP = ip;
            rs.Begin = beginTime.ToString("yyyy-MM-dd HH:mm:ss");
            rs.End = endTime.ToString("yyyy-MM-dd HH:mm:ss");
            if (netProcesses.Count() > 0)
            {
                rs.Record = new List<NetRecord>();
                NetRecord rcd;
                foreach (var pro in netProcesses)
                {
                    if (pro.UpLoadCount > 0 || pro.DownLoadCount > 0)
                    {
                        rcd = new NetRecord()
                        {
                            Name = pro.ProcessName,
                            Up = pro.UpLoadCount,
                            Down = pro.DownLoadCount,
                        };
                        rs.Record.Add(rcd);
                    }
                }
            }
            //判断只有有流量纪录数据时 向服务器发送数据
            if (rs != null && rs.Record != null && rs.Record.Count() > 0)
            {
                try
                {
                    string rsJson = JsonTool.ToStr(rs);
                    string path = R.Paths.BasePath + @"FlowRec";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    //Write(string.Format(path + @"\{0}.txt", DateTime.Now.ToString("yyyyMMddHHmmss")), rsJson);
                    SendHelper.Send("38", rsJson);
                }
                catch { }
            }
        }
        #endregion
        #region 存储发送程序连接数记录
        public static void SendProConnRecord(NetProcess pro)
        {
            ProConnRecordBag rs = new ProConnRecordBag();
            rs.Name = pro.ProcessName;
            rs.Count = pro.Ports.Count();
            rs.Record = new List<ProConnRecord>();
            foreach (var p in pro.Ports)
            {
                var r = rs.Record.FirstOrDefault(x => x.LI == p.LocalAddress && x.RI == p.RemoteAddress);
                if (r != null)
                {
                    r.Conn.Add(new ProConnPort()
                    {
                        LP = p.Port,
                        RP = p.RemotePort,
                        TP = p.Type.ToString().Replace("Type", ""),
                    });
                }
                else
                {
                    var rcd = new ProConnRecord()
                    {
                        LI = p.LocalAddress,
                        RI = p.RemoteAddress,
                        Conn = new List<ProConnPort>(),
                    };
                    rcd.Conn.Add(new ProConnPort()
                    {
                        LP = p.Port,
                        RP = p.RemotePort,
                        TP = p.Type.ToString().Replace("Type", ""),
                    });
                    rs.Record.Add(rcd);
                }
            }
            try
            {
                string rsJson = JsonTool.ToStr(rs);
                string path = R.Paths.BasePath + @"ProConnRec";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                //Write(string.Format(path + @"\{0}-{1}.txt", DateTime.Now.ToString("yyyyMMddHHmmss"), pro.ProcessName), rsJson);
                SendHelper.Send("43", rsJson);
            }
            catch { }
        }
        public static void SendProConnRecord(ProConnRecordBag rec)
        {
            try
            {
                rec.Name = ProcessAPI.GetProcessNameByPID(int.Parse(rec.Name));
                if (!string.IsNullOrWhiteSpace(rec.Name) && rec.Name.ToLower() != "idle")
                {
                    string rsJson = JsonTool.ToStr(rec);
                    string path = R.Paths.BasePath + @"ProConnRec";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    //Write(string.Format(path + @"\{0}-{1}.txt", DateTime.Now.ToString("yyyyMMddHHmmss"), rec.Name), rsJson);
                    SendHelper.Send("43", rsJson);
                }
            }
            catch { }
        }
        #endregion
        #region 存储文件
        private static bool Write(string file, string content)
        {
            bool rs = false;
            try
            {
                StreamWriter sw = new StreamWriter(file, false);
                sw.WriteLine(content);
                sw.Close();//写入
                rs = true;
            }
            catch (Exception e) { }
            return rs;
        }
        #endregion

        #region 获取联网记录的数据
        public List<string> GetProConnInfo()
        {
            //参数
            string WebIp = R.Servers.ConfigIP;
            int webPort = R.Servers.ConfigPort;
            string url = string.Format("http://{0}:{1}/noah/webservice/getApplication", WebIp, webPort);
            string pageHtml = "";
            //请求并转换模型
            try
            {
                WebClient MyWebClient = new WebClient();
                MyWebClient.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据
                Byte[] pageData = MyWebClient.DownloadData(url); //从指定网站下载数据
                //pageHtml = Encoding.Default.GetString(pageData);  //如果获取网站页面采用的是GB2312，则使用这句            
                pageHtml = Encoding.UTF8.GetString(pageData); //如果获取网站页面采用的是UTF-8，则使用这句
                if (!string.IsNullOrWhiteSpace(pageHtml))
                {
                    List<string> result = new List<string>();
                    string[] list = pageHtml.Split(';');
                    foreach (var item in list)
                    {
                        if (!string.IsNullOrWhiteSpace(item))
                        {
                            string ip = item.Replace("\r", "");
                            ip = ip.Replace("\n", "");
                            result.Add(ip.Trim());
                        }
                    }
                    return result;
                }
            }
            catch (Exception e)
            { }
            return null;
        }
        #endregion
        #region 获取联网记录的数据2
        public static List<string> GetProConnInfo2()
        {
            //参数
            string WebIp = R.Servers.ConfigIP;
            int webPort = R.Servers.ConfigPort;
            string url = string.Format("http://{0}:{1}/noah/webservice/getApplicationTwo", WebIp, webPort);
            string pageHtml = "";
            //请求并转换模型
            try
            {
                WebClient MyWebClient = new WebClient();
                MyWebClient.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据
                Byte[] pageData = MyWebClient.DownloadData(url); //从指定网站下载数据
                //pageHtml = Encoding.Default.GetString(pageData);  //如果获取网站页面采用的是GB2312，则使用这句            
                pageHtml = Encoding.UTF8.GetString(pageData); //如果获取网站页面采用的是UTF-8，则使用这句
                if (!string.IsNullOrWhiteSpace(pageHtml))
                {
                    List<string> result = new List<string>();
                    string[] list = pageHtml.Split(';');
                    foreach (var item in list)
                    {
                        string ip = item.Replace("\r", "").Replace("\n", "").Trim();
                        if (!string.IsNullOrWhiteSpace(ip))
                        {
                            result.Add(ip);
                        }
                    }
                    return result;
                }
            }
            catch (Exception e)
            { }
            return null;
        }
        #endregion
    }
    #region 程序联网记录
    public class NetRecord
    {
        public string Name { get; set; }
        public long Up { get; set; }
        public long Down { get; set; }
    }
    public class NetRecordBag
    {
        public string IP { get; set; }
        public string Begin { get; set; }
        public string End { get; set; }
        public List<NetRecord> Record { get; set; }
    }
    #endregion
    #region 联网进程连接数记录
    public class ProConnPort
    {
        public int LP { get; set; }
        public int RP { get; set; }
        //Type
        public string TP { get; set; }
        public string Status { get; set; }
    }
    public class ProConnRecord
    {
        //本地IP
        public string LI { get; set; }
        //远端IP
        public string RI { get; set; }
        public List<ProConnPort> Conn { get; set; }
    }
    public class ProConnRecordBag
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public List<ProConnRecord> Record { get; set; }
    }
    #endregion
}

