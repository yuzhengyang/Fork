using Oreo.VersionUpdate.Commons;
using Oreo.VersionUpdate.Helpers;
using Oreo.VersionUpdate.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Y.Skin.YoForm.Irregular;
using Y.Utils.DataUtils.Collections;
using Y.Utils.DataUtils.JsonUtils;
using Y.Utils.IOUtils.FileUtils;
using Y.Utils.IOUtils.PathUtils;
using Y.Utils.IOUtils.TxtUtils;
using Y.Utils.NetUtils.FTPUtils;
using Y.Utils.WindowsUtils.ProcessUtils;

namespace Oreo.VersionUpdate.Views
{
    public partial class MainForm : IrregularForm
    {
        const int DETAIL_SHOWTIME = 10000;

        string VersionNumber = "";
        string VersionDesc = "";
        string DownTemp = "DownTemp";
        string BackupTemp = "BackupTemp";
        List<VersionModel> VersionModelList = new List<VersionModel>();

        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            StartUpdate();
        }
        private void StartUpdate()
        {
            Task.Factory.StartNew(() =>
            {
                List<PluginModel> pluginList = DataHelper.GetPluginList();
                if (ListTool.HasElements(pluginList))
                {
                    R.Log.i(string.Format("本次更新共有：{0} 个插件需要更新", pluginList.Count));
                    pluginList.ForEach(x =>
                    {
                        VersionModel pluginNewVersion = DataHelper.GetPluginNewVersion(x);
                        if (pluginNewVersion != null)
                        {
                            R.Log.i(string.Format("当前更新插件：{0} [{1} => {2}]", x.Name, x.Version, pluginNewVersion.VersionNumber));
                            BeforeUpdate(pluginNewVersion);//更新前操作
                            bool flag = Update(pluginNewVersion);
                            if (flag)
                            {
                                VersionModelList.Add(pluginNewVersion);
                                R.Log.i(string.Format("{0} 已更新至最新版本 {1}", x.Name, pluginNewVersion.VersionNumber));
                                UIUpdateDetail(x.Name + " 更新成功，当前版本" + pluginNewVersion.VersionNumber);
                            }
                            else
                            {
                                R.Log.w(string.Format("{0} 更新失败，当前版本 {1}，新版本 {2}，期待下次更新", x.Name, x.Version, pluginNewVersion.VersionNumber));
                                UIUpdateDetail(x.Name + " 更新失败");
                            }
                        }
                        else
                        {
                            R.Log.w(string.Format("插件：{0}[{1}] 的更新配置请求失败，无法完成此更新", x.Name, x.Version));
                        }
                    });
                    AfterUpdate();//更新后操作
                    R.Log.i(string.Format("本次更新结束，共完成 {0} 个插件的更新", VersionModelList.Count()));
                }
                else
                {
                    R.Log.w("需要更新的插件列表为空，退出更新功能");
                }

                //退出程序前启动进程（用来保证主程序启动）
                Thread.Sleep(10000);
                ProcessTool.StartProcess(R.Files.CloseAndStart);
                UIClose();
            });
        }

        #region 更新操作
        /// <summary>
        /// 更新的完整流程
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        private bool Update(VersionModel vm)
        {
            VersionNumber = vm.VersionNumber;
            VersionDesc = vm.VersionDesc;
            DownTemp = Guid.NewGuid().ToString();
            BackupTemp = Guid.NewGuid().ToString();
            if (DirTool.Create(R.Paths.Temp + DownTemp))
            {
                R.Log.i(string.Format("临时下载目录：{0}，临时备份目录：{1}，创建成功，准备更新", DownTemp, BackupTemp));
                UILoadVersion(vm);

                if (UpdateDownload(vm))
                {
                    R.Log.i("需要更新的文件已全部下载成功");
                    if (UpdateInsteadAndBackup(vm))
                    {
                        FileHelper.Clean(vm);
                        R.Log.i("更新文件已完成替换，清理列表和临时文件清理完成");
                        DataHelper.UpdatePluginConfig(vm);
                        DataHelper.UpdateWhatsnew(vm);
                        R.Log.i("更新插件配置信息，添加新版本特性说明完成");
                        UIUpdateDetail("添加新版本特性说明 Whatsnew.txt");
                        return true;
                    }
                    else
                    {
                        UpdateRollback(vm);
                        R.Log.w("文件替换失败，当前更新失败，回滚备份的文件到该插件原始版本");
                    }
                }
                else
                {
                    R.Log.w("文件下载失败，当前更新失败");
                }
            }
            else
            {
                R.Log.i(string.Format("临时下载目录：{0}，临时备份目录：{1}，创建失败，取消本次更新", DownTemp, BackupTemp));
            }
            return false;
        }
        /// <summary>
        /// 更新前操作（启动或关闭进程）
        /// </summary>
        /// <param name="vm"></param>
        private void BeforeUpdate(VersionModel vm)
        {
            ProcessHelper.BeforeUpdate(vm);
        }
        /// <summary>
        /// 更新后操作（启动或关闭进程）
        /// </summary>
        /// <param name="vm"></param>
        private void AfterUpdate()
        {
            List<string> kill = new List<string>();
            List<string> start = new List<string>();
            VersionModelList?.ForEach(x =>
            {
                if (ListTool.HasElements(x.AfterUpdateKillProcess))
                    foreach (var item in x.AfterUpdateKillProcess)
                        if (!kill.Contains(item))
                            kill.Add(item);

                if (ListTool.HasElements(x.AfterUpdateStartProcess))
                    foreach (var item in x.AfterUpdateStartProcess)
                        if (!start.Contains(item))
                            start.Add(item);
            });
            ProcessHelper.AfterUpdate(kill, start);
        }
        /// <summary>
        /// 下载要更新的文件
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        private bool UpdateDownload(VersionModel vm)
        {
            FileCodeTool fcode = new FileCodeTool();
            var downFile = vm.FileList.Where(x => x.IsClean == false).ToList();
            if (vm != null && ListTool.HasElements(downFile))
            {
                for (int i = 0; i < downFile.Count(); i++)
                {
                    VersionFile file = downFile[i];
                    string serverFile = DirTool.Combine(vm.ServerPath, file.ServerFile);
                    string tempFile = DirTool.Combine(R.Paths.Temp, DownTemp, file.ServerFile);//下载到目标位置（带文件名）
                    string localFile = DirTool.IsDriver(file.LocalFile) ? file.LocalFile : DirTool.Combine(R.Paths.ProjectRoot, file.LocalFile);//旧文件位置
                    if (fcode.GetMD5(localFile) != file.FileMD5)
                    {
                        UIUpdateDetail("正在下载：" + Path.GetFileName(file.ServerFile));
                        R.Log.v(string.Format("{0} 文件有更新，正在下载文件", Path.GetFileName(file.ServerFile)));
                        FtpTool ftp = new FtpTool(R.Settings.FTP.Address, R.Settings.FTP.Account, R.Settings.FTP.Password);
                        if (!ftp.Download(serverFile, tempFile))
                            if (!ftp.Download(serverFile, tempFile))
                                if (!ftp.Download(serverFile, tempFile))
                                {
                                    R.Log.w(string.Format("{0} 文件下载失败", Path.GetFileName(file.ServerFile)));
                                    return false;
                                }
                    }
                    else
                    {
                        UIUpdateDetail("文件已存在：" + Path.GetFileName(file.ServerFile));
                        R.Log.v(string.Format("{0} 文件不需要更新，已跳过该文件", Path.GetFileName(file.ServerFile)));
                    }
                    UIProgress(i + 1, downFile.Count());
                }
                return true;
            }
            return false;
        }
        /// <summary>
        /// 备份并替换文件
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        private bool UpdateInsteadAndBackup(VersionModel vm)
        {
            var insteadFile = vm.FileList.Where(x => x.IsClean == false);
            foreach (var file in insteadFile)
            {
                string tempDown = DirTool.Combine(R.Paths.Temp, DownTemp, file.ServerFile);//下载到目标位置（带文件名）
                string tempBack = DirTool.Combine(R.Paths.Temp, BackupTemp, file.ServerFile);//备份到目标位置（带文件名）
                string localFile = DirTool.IsDriver(file.LocalFile) ? file.LocalFile : DirTool.Combine(R.Paths.ProjectRoot, file.LocalFile);//旧文件位置

                //备份文件
                if (File.Exists(localFile) && File.Exists(tempDown))
                {
                    try
                    {
                        DirTool.Create(DirTool.GetFilePath(tempBack));
                        File.Copy(localFile, tempBack, true);
                        UIUpdateDetail("正在备份：" + Path.GetFileName(tempBack));
                    }
                    catch (Exception e) { }
                }
                //替换文件
                if (File.Exists(tempDown))
                {
                    try
                    {
                        DirTool.Create(DirTool.GetFilePath(localFile));
                        File.Copy(tempDown, localFile, true);
                        UIUpdateDetail("正在更新：" + Path.GetFileName(file.LocalFile));
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                }

            }
            return true;
        }
        /// <summary>
        /// 更新回滚
        /// </summary>
        /// <param name="vm"></param>
        private void UpdateRollback(VersionModel vm)
        {
            var backFile = vm.FileList.Where(x => x.IsClean == false);
            foreach (var file in backFile)
            {
                string tempBack = DirTool.Combine(R.Paths.Temp, BackupTemp, file.ServerFile);//备份到目标位置（带文件名）
                string localFile = DirTool.IsDriver(file.LocalFile) ? file.LocalFile : DirTool.Combine(R.Paths.ProjectRoot, file.LocalFile);//旧文件位置

                //还原备份文件
                if (File.Exists(tempBack))
                {
                    try
                    {
                        DirTool.Create(DirTool.GetFilePath(localFile));
                        File.Copy(tempBack, localFile, true);
                        UIUpdateDetail("正在还原备份文件：" + Path.GetFileName(file.LocalFile));
                    }
                    catch (Exception e) { }
                }
            }
        }
        #endregion
        #region UI操作
        /// <summary>
        /// 显示更新详情
        /// </summary>
        /// <param name="s"></param>
        void UIUpdateDetail(string s)
        {
            Invoke(new Action(() =>
            {
                LbUpdateDetail.Text = s;
            }));
            Thread.Sleep(DETAIL_SHOWTIME);
        }
        /// <summary>
        /// 设置进度条进度
        /// </summary>
        /// <param name="value"></param>
        void UIProgress(int value, int max)
        {
            Invoke(new Action(() =>
            {
                LbProgress.Text = Math.Round(((float)value / max) * 100).ToString() + "%";
            }));
        }
        /// <summary>
        /// 读取当前要更新的信息
        /// </summary>
        /// <param name="vm"></param>
        void UILoadVersion(VersionModel vm)
        {
            Invoke(new Action(() =>
            {
                LbCodeName.Text = vm.CodeName;
                LbPluginName.Text = string.Format("{0} [{1}] 了解详情", vm.PluginName, vm.VersionNumber);
                NiMini.Text = "正在更新：" + vm.PluginName + " ~";
                LbUpdateDetail.Text = "配置已加载，准备更新……";
            }));
        }
        /// <summary>
        /// 退出程序
        /// </summary>
        void UIClose()
        {
            Invoke(new Action(() =>
            {
                Close();
            }));
        }
        #endregion

        #region 控件事件
        /// <summary>
        /// 点击版本号 显示版本特性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LbPluginName_Click(object sender, EventArgs e)
        {
            MessageBox.Show(VersionDesc, VersionNumber + " 新特性");
        }
        #endregion
    }
}
