using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Oreo.BigBirdDeployer.Models;
using Azylee.Core.WindowsUtils.CMDUtils;
using Azylee.Core.DataUtils.CollectionUtils;
using System.Threading.Tasks;
using System.Threading;
using Oreo.BigBirdDeployer.Views;
using Azylee.Core.AppUtils;
using Azylee.Core.IOUtils.DirUtils;
using Azylee.Core.ProcessUtils;

namespace Oreo.BigBirdDeployer.Parts
{
    public partial class ProjectItemPart : UserControl
    {
        const int STATUS_INTERVAL = 1000;//刷新状态时间间隔
        private WorkStatus Status { get; set; }
        private ProjectModel Project { get; set; }
        private Process Process { get; set; }
        public ProjectItemPart()
        {
            InitializeComponent();
            Project = new ProjectModel();
        }
        private void ProjectItemPart_Load(object sender, EventArgs e)
        {
            //加载启动按钮默认不可用（Init初始化后变为可用）
            BTStartOrStop.Enabled = false;
        }
        public void SetProject(ProjectModel model)
        {
            //初始化设置项目
            Project = model;
            //获取当前端口进程
            if (GetProcess())
            {
                //初始化时有进程占用端口号
                StatusUI(WorkStatus.端口占用);
            }
            else
            {
                //没有进程占用端口号
                StatusUI(WorkStatus.准备就绪);
            }
            //为控件更新显示
            LBProjectName.Text = Project.Name;
            BTStartOrStop.Enabled = true;

            //持续监控端口及端口进程状态
            ProcessStatus();
        }
        private void BTStartOrStop_Click(object sender, EventArgs e)
        {
            //没有端口占用则正常启动
            if (!GetProcess())
            {
                Start();
            }
            else
            {
                Stop();
            }
        }

        private void BTConfig_Click(object sender, EventArgs e)
        {
            new ProjectConfigForm(this, Project).Show();
        }

        #region 功能方法
        /// <summary>
        /// 通过设置的工程端口号获取进程
        /// </summary>
        /// <returns></returns>
        private bool GetProcess()
        {
            try
            {
                var pid = CMDNetstatTool.FindByPort(Project.Port, false);
                if (ListTool.HasElements(pid))
                {
                    var p = Process.GetProcessById(pid.First().Item2);
                    if (p != null)
                    {
                        Process = p;
                        return true;
                    }
                }
            }
            catch { }
            return false;
        }
        /// <summary>
        /// 根据工程设置启动服务
        /// </summary>
        /// <returns></returns>
        private void Start()
        {
            Task.Factory.StartNew(() =>
            {
                StatusUI(WorkStatus.正在启动);
                CMDProcessTool.StartExecute($"java -jar {DirTool.Combine(Project.Folder, Project.JarFile)}",
                    new Action<string>((s) =>
                    {
                        //ConsoleUI(s);
                        if (s.Contains("*****************************"))
                        {
                            StatusUI(WorkStatus.启动成功);
                            GetProcess();
                        }
                    }));

                if (Status == WorkStatus.启动成功 || Status == WorkStatus.端口占用)
                {
                    StatusUI(WorkStatus.正在关闭);
                    Stop();
                }
                else
                {
                    StatusUI(WorkStatus.启动失败);
                }
            });
        }
        /// <summary>
        /// 关闭工程服务
        /// </summary>
        /// <returns></returns>
        private void Stop()
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    //如果能获取到端口的进程
                    while (GetProcess())
                    {
                        //停止进程
                        Process?.Kill();
                        Thread.Sleep(1000);
                    }
                    StatusUI(WorkStatus.准备就绪);
                }
                catch { StatusUI(WorkStatus.端口占用); }
            });
        }
        private void ProcessStatus()
        {
            Task.Factory.StartNew(() =>
            {
                TimeSpan pin = TimeSpan.Zero;
                while (!IsDisposed)
                {
                    try
                    {
                        if (Process != null && !Process.HasExited)
                        {
                            BeginInvoke(new Action(() =>
                            {
                                double cpu = AppInfoTool.CalcCpuRate(Process, pin, STATUS_INTERVAL);
                                pin = Process.TotalProcessorTime;

                                LBProcessName.Text = Process.ProcessName;
                                LBCpu.Text = $"CPU：{Math.Round(cpu, 1)} %";
                                LBRam.Text = $"内存：{AppInfoTool.RAM(Process.Id) / 1024} MB";


                            }));
                        }
                        else
                        {
                            BeginInvoke(new Action(() =>
                            {
                                LBCpu.Text = $"CPU：0 %";
                                LBRam.Text = $"内存：0 MB";
                            }));
                            GetProcess();
                        }
                    }
                    catch { }
                    Thread.Sleep(STATUS_INTERVAL);
                }
            });
        }
        #endregion
        #region UI操作
        private void StatusUI(WorkStatus status)
        {
            Status = status;
            try
            {
                BeginInvoke(new Action(() =>
                {
                    LBStatus.Text = status.ToString();
                    switch (status)
                    {
                        case WorkStatus.准备就绪:
                            BTStartOrStop.Text = "启动";
                            BTStartOrStop.Enabled = true;
                            break;
                        case WorkStatus.启动成功:
                            BTStartOrStop.Text = "停止";
                            BTStartOrStop.Enabled = true;
                            break;

                        case WorkStatus.正在启动:
                            BTStartOrStop.Text = "启动中.";
                            BTStartOrStop.Enabled = false;
                            break;
                        case WorkStatus.正在关闭:
                            BTStartOrStop.Text = "关闭中.";
                            BTStartOrStop.Enabled = false;
                            break;

                        case WorkStatus.端口占用:
                            BTStartOrStop.Text = "停止";
                            BTStartOrStop.Enabled = true;
                            break;
                        case WorkStatus.启动失败:
                            BTStartOrStop.Text = "启动";
                            BTStartOrStop.Enabled = true;
                            break;
                    }
                }));
            }
            catch { }
        }
        private void ConsoleUI(string s)
        {
            try
            {
                BeginInvoke(new Action(() =>
                {
                    TBConsole.AppendText(s);
                }));
            }
            catch { }
        }

        #endregion


    }
}
