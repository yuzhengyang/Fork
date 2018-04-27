using Azylee.Core.AppUtils;
using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.Core.ProcessUtils;
using Azylee.Core.WindowsUtils.CMDUtils;
using Azylee.Core.WindowsUtils.InfoUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test.CmdTool
{
    public partial class Form1 : Form
    {
        private PerformanceCounter ComCpu = ComputerStatusTool.Processor();//电脑CPU监控
        private PerformanceCounter AppCpu = AppInfoTool.Processor();//程序CPU监控
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BTFindPort_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TBPort.Text))
            {
                var list = CMDNetstatTool.FindByPort(int.Parse(TBPort.Text));
                if (ListTool.HasElements(list))
                {
                    list.ForEach(x =>
                    {
                        string name = "-";
                        string file = "-";
                        try
                        {
                            Process p = Process.GetProcessById(x.Item2);
                            name = p?.ProcessName;
                            file = p?.MainModule.FileName;
                        }
                        catch { }
                        TBRs.AppendText($"{x.Item1}, {x.Item2}, {name}, {file}");
                        TBRs.AppendText(Environment.NewLine);
                    });
                }
            }
        }

        private void BTStart_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                CMDProcessTool.StartExecute(@"java -jar D:\CoCo\Work\supplyPlatform\out\artifacts\noah_cloud_supply_platform_jar\noah-cloud-supply-platform.jar");
            });
        }

        private void BTKillApp_Click(object sender, EventArgs e)
        {
            var list = CMDNetstatTool.FindByPort(int.Parse(TBPort.Text), false);
            if (ListTool.HasElements(list) && list.Count == 1)
            {
                try
                {
                    Process p = Process.GetProcessById(list.First().Item2);
                    p.Kill();
                }
                catch { }
            }
        }

        private void TMStatus_Tick(object sender, EventArgs e)
        {
            LBStatus.Text = $"comcpu:{(int)ComCpu.NextValue()}, appcpu:{(int)AppCpu.NextValue()}, appram:{AppInfoTool.RAM()/1024}";
        }
    }
}
