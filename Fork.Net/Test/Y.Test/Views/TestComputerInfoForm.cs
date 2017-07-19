using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Y.Utils.DataUtils.Collections;
using Y.Utils.DataUtils.UnitConvertUtils;
using Y.Utils.SoftwareUtils;
using Y.Utils.WindowsUtils.InfoUtils;

namespace Y.Test.Views
{
    public partial class TestComputerInfoForm : Form
    {
        public TestComputerInfoForm()
        {
            InitializeComponent();
        }
        private void TestComputerInfoForm_Load(object sender, EventArgs e)
        {
            var softwareinfos = Utils.SoftwareUtils.SoftwareTool.GetControlList();
            if (ListTool.HasElements(softwareinfos))
            {
                softwareinfos.ForEach(x =>
                {
                    if (x.Name != "")
                        Print(string.Format("{0} / 【{1}】 / {2} / {3} 【{4}】",
                            x.Name, x.InstallDate, x.Publisher, x.Version,
                            ByteConvertTool.Fmt(x.EstimatedSize * 1024)));
                });
            }
        }
        private void Print(string s)
        {
            textBox1.AppendText(s);
            textBox1.AppendText(Environment.NewLine);
        }

        private void GetHardInfo()
        {
            Print("UserName： " + ComputerInfoTool.UserName());
            Print("登录用户名： " + ComputerInfoTool.UserName2());

            Print("UserDomainName： " + ComputerInfoTool.UserDomainName());
            Print("TickCount： " + ComputerInfoTool.TickCount());
            Print("ProcessorCount： " + ComputerInfoTool.ProcessorCount());
            Print("OSVersion： " + ComputerInfoTool.OSVersion());
            Print("Is64BitOperatingSystem： " + ComputerInfoTool.Is64BitOperatingSystem());

            Tuple<string, string> cpuinfo = ComputerInfoTool.CpuInfo();
            Print("CPU 序列号 " + cpuinfo.Item1 + " 型号 " + cpuinfo.Item2);
            Print("显卡信息： " + string.Join(",", ComputerInfoTool.GraphicsCardInfo()));
            Print("声卡信息： " + string.Join(",", ComputerInfoTool.SoundCardModel()));
            Print("内存： " + ComputerInfoTool.AvailablePhysicalMemory() + " / " + ComputerInfoTool.TotalPhysicalMemory());
            List<Tuple<string, string>> harddiskinfo = ComputerInfoTool.HardDiskInfo();
            harddiskinfo.ForEach(x =>
            {
                Print("硬盘 序列号 " + x.Item1 + " 型号 " + x.Item2);
            });
            var osinfo = ComputerInfoTool.OsInfo();
            Print("操作系统： " + osinfo.Item1 + " " + osinfo.Item2 + " " + osinfo.Item3);
            Print("系统类型： " + ComputerInfoTool.SystemType());
            Print("计算机名： " + ComputerInfoTool.MachineName());
            Print("系统所有用户名： " + string.Join(",", ComputerInfoTool.UserNames()));
            var boardinfo = ComputerInfoTool.BoardInfo();
            Print("主板 制造商 " + boardinfo.Item1 + " 型号 " + boardinfo.Item2 + " 序列号 " + boardinfo.Item3);
        }

    }
}
