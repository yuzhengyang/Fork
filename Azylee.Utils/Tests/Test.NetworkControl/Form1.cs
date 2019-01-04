using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.Core.IOUtils.DirUtils;
using Azylee.Core.IOUtils.TxtUtils;
using Azylee.Core.LogUtils.SimpleLogUtils;
using Azylee.Core.NetUtils;
using Azylee.Core.ThreadUtils.SleepUtils;
using Azylee.Core.WindowsUtils.InfoUtils;
using Azylee.Ext.NetworkX.NetConLibUtils;
using NETCONLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test.NetworkControl
{
    public partial class Form1 : Form
    {
        Log log = new Log();
        List<Tuple<string, string, string, string, string>> MacList = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<string> list111 = NetcardControlTool.GetList();
            MacList = NetCardInfoTool.GetNetworkCardInfo();
            if (Ls.Ok(MacList))
            {
                LbxNetworkList.Items.Clear();
                foreach (var item in MacList) LbxNetworkList.Items.Add(item.Item2);
            }
        }
        private void BtnLoad_Click(object sender, EventArgs e)
        {
            List<string> list111 = NetcardControlTool.GetList();
            MacList = NetCardInfoTool.GetNetworkCardInfo();
            if (Ls.Ok(MacList))
            {
                LbxNetworkList.Items.Clear();
                foreach (var item in MacList) LbxNetworkList.Items.Add(item.Item2);
            }
        }

        private void BtnEnable_Click(object sender, EventArgs e)
        {
            //var key = GetNetworkName();
            //ManagementObject network = NetcardControlTool.GetNetWorkByConnectId(key);
            //if (network != null)
            //{
            //    if (NetcardControlTool.Enable(network))
            //    {
            //        SetResult("成功");
            //    }
            //    else
            //    {
            //        SetResult("失败");
            //    }
            //}
            NetConLibTool.Connect();
        }

        private void BtnDisable_Click(object sender, EventArgs e)
        {
            //var key = GetNetworkName();
            //ManagementObject network = NetcardControlTool.GetNetWorkByConnectId(key);
            //if (network != null)
            //{
            //    if (NetcardControlTool.Disable(network))
            //    {
            //        SetResult("成功");
            //    }
            //    else
            //    {
            //        SetResult("失败");
            //    }
            //}
            NetConLibTool.Disconnect();
        }
        private string GetNetworkName()
        {
            int idx = LbxNetworkList.SelectedIndex;
            if (idx >= 0 && MacList.Count > idx)
            {
                return MacList[idx].Item1;
            }
            return "";
        }
        private void SetResult(string s)
        {
            Invoke(new Action(() =>
            {
                LbResult.Text = s + Environment.NewLine + DateTime.Now;
            }));
        }
        private void BtnTest_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    string manage = "SELECT * From Win32_NetworkAdapter";
                    ManagementObjectSearcher searcher = new ManagementObjectSearcher(manage);
                    ManagementObjectCollection collection = searcher.Get();
                    foreach (ManagementObject obj in collection)
                    {
                        foreach (var item in obj.Properties)
                        {
                            log.i("   :::   " + item.Name + "   :::   " + item.Value);
                        }
                        log.i("==============================");
                        log.i("==============================");
                    }
                }
                catch { }
                //====================================
                log.v("STEP 1：获取网卡列表");
                var list = NetCardInfoTool.GetNetworkCardInfoId();
                if (Ls.ok(list))
                {
                    foreach (var item in list)
                    {
                        log.v($"{item.Item1} | {item.Item2} | {item.Item3} | {item.Item4} | {item.Item5}");
                    }
                }
                //====================================
                log.v("STEP 2：检查网卡状态");
                if (Ls.ok(list))
                {
                    foreach (var item in list)
                    {
                        var status = NetCardInfoTool.GetOpStatus(item.Item3);
                        log.v($"{item.Item1} | {item.Item2} | {item.Item3} | {status.ToString()}");
                    }
                }
                //====================================
                log.v("STEP 3：Ping 10.49.129.7");
                bool pingflag1 = PingTool.Ping("10.49.129.7");
                if (pingflag1) log.v("Ping 正常");
                else log.v("Ping 异常");
                //====================================
                log.v("STEP 4：禁用网卡");
                NetConLibTool.Disconnect();
                //if (Ls.ok(list))
                //{
                //    foreach (var item in list)
                //    {
                //        ManagementObject network = NetcardControlTool.GetNetWorkByConnectId(item.Item1);
                //        if (network != null)
                //        {
                //            bool disflag = NetcardControlTool.Disable(network);
                //            log.v($"{item.Item1} | {item.Item2} | {item.Item3} | 禁用： {(disflag ? "成功" : "失败")}");
                //        }
                //    }
                //}
                //====================================
                log.v("STEP 5：检查网卡状态");
                if (Ls.ok(list))
                {
                    foreach (var item in list)
                    {
                        var status = NetCardInfoTool.GetOpStatus(item.Item3);
                        log.v($"{item.Item1} | {item.Item2} | {item.Item3} | {status.ToString()}");
                    }
                }
                //====================================
                log.v("STEP 6：Ping 10.49.129.7");
                bool pingflag2 = PingTool.Ping("10.49.129.7");
                if (pingflag2) log.v("Ping 正常");
                else log.v("Ping 异常");
                //====================================
                log.v("STEP 7：遍历启用网卡");
                NetConLibTool.Connect();
                //if (Ls.ok(list))
                //{
                //    foreach (var item in list)
                //    {
                //        ManagementObject network = NetcardControlTool.GetNetWorkByConnectId(item.Item1);
                //        if (network != null)
                //        {
                //            bool disflag = NetcardControlTool.Enable(network);
                //            log.v($"{item.Item1} | {item.Item2} | {item.Item3} | 启用： {(disflag ? "成功" : "失败")}");
                //        }
                //    }
                //}
                //====================================
                log.v("STEP 8：等待一下");
                Sleep.S(20);
                //====================================
                log.v("STEP 9：检查网卡状态");
                if (Ls.ok(list))
                {
                    foreach (var item in list)
                    {
                        var status = NetCardInfoTool.GetOpStatus(item.Item3);
                        log.v($"{item.Item1} | {item.Item2} | {item.Item3} | {status.ToString()}");
                    }
                }
                //====================================
                log.v("STEP 10：Ping 10.49.129.7");
                bool pingflag3 = PingTool.Ping("10.49.129.7");
                if (pingflag3) log.v("Ping 正常");
                else log.v("Ping 异常");
                //====================================

                SetResult("测试结束，已生成测试报告");
            });
        }

    }
}
