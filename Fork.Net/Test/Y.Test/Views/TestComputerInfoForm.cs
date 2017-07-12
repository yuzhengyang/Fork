using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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
            Print("UserName： " + Environment.UserName);
            Print("UserDomainName： " + Environment.UserDomainName);
            Print("TickCount： " + Environment.TickCount);
            Print("ProcessorCount： " + Environment.ProcessorCount);
            Print("OSVersion： " + Environment.OSVersion);
            Print("MachineName： " + Environment.MachineName);
            Print("Is64BitOperatingSystem： " + Environment.Is64BitOperatingSystem);
            Print("-------------------------");
            Print("CPUID： " + ComputerInfoTool.CPUID());
            Print("CPU信息： " + ComputerInfoTool.CPUModel());
            Print("显卡信息： " + string.Join(",", ComputerInfoTool.GraphicsCardModel()));
            Print("声卡信息： " + string.Join(",", ComputerInfoTool.SoundCardModel()));
            Print("内存： " + ComputerInfoTool.AvailablePhysicalMemory() + " / " + ComputerInfoTool.TotalPhysicalMemory());
            Print("硬盘ID： " + ComputerInfoTool.GetHDiskID("C"));
            Print("硬盘信息： " + string.Join(",", ComputerInfoTool.HardDiskModel()));
            Print("操作系统： " + ComputerInfoTool.GetOS());
            Print("系统类型： " + ComputerInfoTool.GetSystemType());
            Print("系统安装日期： " + ComputerInfoTool.GetSystemInstallDate());
            Print("登录用户名： " + ComputerInfoTool.GetLoginUserName());
            Print("计算机名： " + ComputerInfoTool.GetComputerName());
            Print("系统所有用户名： " + string.Join(",", ComputerInfoTool.GetSysUserNames()));
            Print("主板： " + ComputerInfoTool.GetBoardManufacturer());
            Print("主板： " + ComputerInfoTool.GetBoardProduct());
            Print("主板序列号： " + ComputerInfoTool.GetBoardSerialNumber());
        }
        private void Print(string s)
        {
            textBox1.AppendText(s);
            textBox1.AppendText(Environment.NewLine);
        }
    }
}
