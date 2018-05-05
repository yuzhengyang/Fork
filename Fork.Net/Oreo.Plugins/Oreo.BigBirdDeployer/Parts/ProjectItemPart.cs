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
using Oreo.BigBirdDeployer.Utils;
using Oreo.BigBirdDeployer.Commons;
using System.IO;
using Azylee.Core.IOUtils.FileUtils;
using Azylee.WinformSkin.FormUI.Toast;
using System.Collections;
using Azylee.Core.DataUtils.DateTimeUtils;
using Azylee.Core.Plus.DataUtils.JsonUtils;
using Azylee.Core.IOUtils.TxtUtils;

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
            //启动按钮默认不可用（Init初始化后变为可用）
            BTStartOrStop.Enabled = false;//禁止启动/关闭
            BTAddNew.Enabled = false;//禁止装载新版本
            CBVersion.Enabled = false;//禁止选择启动版本

            //持续监控端口及端口进程状态
            ProcessStatus();

            //加载项目资料（加载前检查是否存在）
            if (File.Exists(DirTool.Combine(R.Paths.Projects, Name)))
            {
                string txt = TxtTool.Read(DirTool.Combine(R.Paths.Projects, Name));
                var p = JsonTool.ToObjFromStr<ProjectModel>(txt);
                if (p != null) SetProject(p);
            }
        }


        #region 功能方法
        /// <summary>
        /// 设置/重置工程信息
        /// </summary>
        /// <param name="model"></param>
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
            LBProjectName.Text = Project.Name;//更新项目名称
            LBPort.Text = $"端口：{Project.Port}";//更新端口号信息

            //设置下拉框选择版本信息
            if (ListTool.HasElements(Project.Versions))
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt.TableName = "dt";
                    dt.Columns.Add("Code");
                    dt.Columns.Add("Name");
                    Project.Versions.OrderByDescending(x => x.Number).ToList().ForEach(x =>
                    {
                        DataRow row = dt.NewRow();
                        row["Code"] = x.Number.ToString();
                        row["Name"] = $"{x.Number}（{x.CreateTime.ToString("yyyy年MM月dd日 HH:mm")}）";
                        dt.Rows.Add(row);
                        if (x.Number > Project.CurrentVersion) Project.CurrentVersion = x.Number;
                    });
                    CBVersion.DataSource = dt;
                    CBVersion.DisplayMember = "Name";
                    CBVersion.ValueMember = "Code";
                }
                catch { }
            }
            else
            {
                DataTable dt = new DataTable();
                dt.TableName = "dt";
                dt.Columns.Add("Code");
                dt.Columns.Add("Name");
                DataRow row = dt.NewRow();
                row["Code"] = 0;
                row["Name"] = $"新建工程需要先加载工程";
                dt.Rows.Add(row);
                CBVersion.DataSource = dt;
                CBVersion.DisplayMember = "Name";
                CBVersion.ValueMember = "Code";
            }

            //保存工程信息到文件
            string str = JsonTool.ToStr(Project);
            TxtTool.Create(DirTool.Combine(R.Paths.Projects, Name), str);
        }
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
            if (ListTool.HasElements(Project.Versions) && Project.CurrentVersion != 0 && Project.LastVersion != 0)
            {
                //存在版本
                Task.Factory.StartNew(() =>
                {
                    StatusUI(WorkStatus.正在启动);
                    string cmd = $"java -jar {JarFileTool.PathGenerate(Project)}";
                    CMDProcessTool.StartExecute(cmd,
                        new Action<string>((s) =>
                        {
                            if (ConsoleCodeTool.IsLunchSuccess(s))
                            {
                                R.Log.i(s);
                                StatusUI(WorkStatus.启动成功);
                                ToastForm.Display("启动成功", $"启动 {Project.Name} 工程成功", 'i', 5000);
                                GetProcess();
                            }

                            string log = ConsoleCodeTool.GetLogInfo(s);
                            if (!string.IsNullOrWhiteSpace(log)) R.Log.v(log);
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
            else
            {
                //不存在版本或错误的版本（版本为0），不启动工程
                ToastForm.Display("启动失败", $"没有发现 {Project.Name} 工程的相关文件", 'e', 5000);
            }
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

        #region 事件方法
        /// <summary>
        /// 启动工程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// 设置工程信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTConfig_Click(object sender, EventArgs e)
        {
            new ProjectConfigForm(this, Project).ShowDialog();
        }
        /// <summary>
        /// 装载新版本工程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTAddNew_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Project.Folder) && !string.IsNullOrWhiteSpace(Project.JarFile))
            {
                //查询New仓库中，该工程的新版本
                string newPath = JarFileTool.GetNewPath(Project);
                if (Directory.Exists(newPath) && File.Exists(DirTool.Combine(newPath, Project.JarFile)))
                {
                    try
                    {
                        ToastForm.Display("装载中", $"正在装载 {Project.Name} 的新版本...", 'i', 5000);
                        //移动文件到发布仓库中
                        string aimPath = DirTool.Combine(R.Paths.PublishStorage, Project.Folder);//组合目标路径
                        DirTool.Create(aimPath);//创建目标路径
                        if (Directory.Exists(DirTool.Combine(aimPath, (Project.LastVersion + 1).ToString())))//如果存在目标文件夹
                            Directory.Delete(DirTool.Combine(aimPath, (Project.LastVersion + 1).ToString()), true);//删除目标文件夹（防止重复）
                        Directory.Move(newPath, DirTool.Combine(aimPath, (Project.LastVersion + 1).ToString()));//开始移动
                                                                                                                //添加新版本信息
                        Project.LastVersion++;
                        Project.CurrentVersion = Project.LastVersion;
                        VersionModel version = new VersionModel()
                        {
                            CreateTime = DateTime.Now,
                            Number = Project.LastVersion,
                        };
                        if (Project.Versions == null) Project.Versions = new List<VersionModel>();
                        Project.Versions.Add(version);
                        //重置项目信息
                        SetProject(Project);
                        ToastForm.Display("装载成功", $"成功装载 {Project.Name} 的新版本", 'i', 5000);
                    }
                    catch
                    {
                        ToastForm.Display("装载失败", $"装载 {Project.Name} 的新版本失败", 'e', 5000);
                    }
                }
                else
                {
                    //没有发现新版本，不做处理
                    ToastForm.Display("装载失败", $"没有发现 {Project.Name} 的新版本", 'w', 5000);
                }
            }
            else
            {
                //没有工程配置信息，不做处理
                ToastForm.Display("装载失败", $"没有发现工程的配置信息", 'e', 5000);
            }
        }
        /// <summary>
        /// 选择要启动的版本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CBVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(CBVersion.SelectedValue.ToString(), out int v))
            {
                Project.CurrentVersion = v;
            }
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
                            LBStatus.BackColor = Color.Green;
                            BTStartOrStop.Text = "启动";
                            BTStartOrStop.Enabled = true;//允许启动/关闭
                            BTAddNew.Enabled = true;//允许装载新版本
                            BTConfig.Enabled = true;//允许配置工程
                            CBVersion.Enabled = true;//允许选择启动版本
                            break;
                        case WorkStatus.启动成功:
                            LBStatus.BackColor = Color.MediumTurquoise;
                            BTStartOrStop.Text = "停止";
                            BTStartOrStop.Enabled = true;//允许启动/关闭
                            BTAddNew.Enabled = false;//禁止装载新版本
                            BTConfig.Enabled = false;//禁止配置工程
                            CBVersion.Enabled = false;//禁止选择启动版本
                            break;

                        case WorkStatus.正在启动:
                            LBStatus.BackColor = Color.Yellow;
                            BTStartOrStop.Text = "启动中.";
                            BTStartOrStop.Enabled = false;//禁止启动/关闭
                            BTAddNew.Enabled = false;//禁止装载新版本
                            BTConfig.Enabled = false;//禁止配置工程
                            CBVersion.Enabled = false;//禁止选择启动版本
                            break;
                        case WorkStatus.正在关闭:
                            LBStatus.BackColor = Color.Yellow;
                            BTStartOrStop.Text = "关闭中.";
                            BTStartOrStop.Enabled = false;//禁止启动/关闭
                            BTAddNew.Enabled = false;//禁止装载新版本
                            BTConfig.Enabled = false;//禁止配置工程
                            CBVersion.Enabled = false;//禁止选择启动版本
                            break;

                        case WorkStatus.端口占用:
                            LBStatus.BackColor = Color.Red;
                            BTStartOrStop.Text = "停止";
                            BTStartOrStop.Enabled = true;//允许启动/关闭
                            BTAddNew.Enabled = false;//禁止装载新版本
                            BTConfig.Enabled = false;//禁止配置工程
                            CBVersion.Enabled = false;//禁止选择启动版本
                            break;
                        case WorkStatus.启动失败:
                            LBStatus.BackColor = Color.Red;
                            BTStartOrStop.Text = "启动";
                            BTStartOrStop.Enabled = true;//允许启动/关闭
                            BTAddNew.Enabled = true;//允许装载新版本
                            BTConfig.Enabled = true;//允许配置工程
                            CBVersion.Enabled = true;//允许选择启动版本
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
                }));
            }
            catch { }
        }
        #endregion
    }
}
