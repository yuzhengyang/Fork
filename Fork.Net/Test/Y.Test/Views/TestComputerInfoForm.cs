using Microsoft.Win32;
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

        private void GetSoftInfo()
        {
            string temp = null, tempType = null;
            object displayName = null, uninstallString = null, releaseType = null;
            RegistryKey currentKey = null;
            int softNum = 0;
            RegistryKey pregkey = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall");//获取指定路径下的键
            try
            {
                foreach (string item in pregkey.GetSubKeyNames())               //循环所有子键
                {
                    currentKey = pregkey.OpenSubKey(item);
                    displayName = currentKey.GetValue("DisplayName");           //获取显示名称
                    uninstallString = currentKey.GetValue("UninstallString");   //获取卸载字符串路径
                    releaseType = currentKey.GetValue("ReleaseType");           //发行类型,值是Security Update为安全更新,Update为更新
                    bool isSecurityUpdate = false;
                    if (releaseType != null)
                    {
                        tempType = releaseType.ToString();
                        if (tempType == "Security Update" || tempType == "Update")
                            isSecurityUpdate = true;
                    }
                    if (!isSecurityUpdate && displayName != null && uninstallString != null)
                    {
                        softNum++;
                        temp += displayName.ToString() + Environment.NewLine;
                    }
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message.ToString());
            }
            richTextBox1.Text = "您本机安装了" + softNum.ToString() + "个" + Environment.NewLine + temp;
            pregkey.Close();
        }
    }
}
