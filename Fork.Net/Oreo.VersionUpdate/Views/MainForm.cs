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
using Y.Utils.DataUtils.Collections;
using Y.Utils.DataUtils.JsonUtils;
using Y.Utils.IOUtils.FileUtils;
using Y.Utils.IOUtils.PathUtils;
using Y.Utils.IOUtils.TxtUtils;
using Y.Utils.NetUtils.FTPUtils;
using Y.Utils.WindowsUtils.ProcessUtils;

namespace Oreo.VersionUpdate.Views
{
    public partial class MainForm : Form
    {
        const int DETAIL_SHOWTIME = 1000;

        string VersionNumber = "";
        string VersionDesc = "";
        string DownTemp = "DownTemp";
        string BackupTemp = "BackupTemp";

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
                R.Log.i("读取要更新的插件列表");
                List<PluginModel> pluginList = DataHelper.GetPluginList();
                if (ListTool.HasElements(pluginList))
                {
                    R.Log.i("共读取到 " + pluginList.Count + " 个插件");
                    pluginList.ForEach(x =>
                    {
                        R.Log.i("请求 " + x.Name + " / " + x.Version + " 插件的更新");
                        VersionModel pluginNewVersion = DataHelper.GetPluginNewVersion(x);
                        if (pluginNewVersion != null)
                        {
                            R.Log.i("准备更新 " + x.Name);
                            BeforeUpdate(pluginNewVersion);//更新前操作
                            bool flag = Update(pluginNewVersion);
                            AfterUpdate(pluginNewVersion);//更新后操作
                            if (flag)
                            {
                                R.Log.i(x.Name + " 更新成功，当前版本" + pluginNewVersion.VersionNumber);
                            }
                            else
                            {
                                R.Log.w(x.Name + " 更新失败");
                            }
                        }
                        else
                        {
                            R.Log.i("更新配置请求失败，跳过当前更新");
                        }
                    });
                }
                else
                {
                    R.Log.w("更新插件列表为空");
                }
                R.Log.i("本地插件更新操作结束");
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
                R.Log.i("创建临时下载目录 " + R.Paths.Temp + DownTemp);
                R.Log.i("创建临时备份目录 " + R.Paths.Temp + BackupTemp);

                R.Log.i("将版本信息显示到 UI");
                UILoadVersion(vm);

                if (UpdateDownload(vm))
                {
                    R.Log.i("文件已全部下载成功");
                    if (UpdateInsteadAndBackup(vm))
                    {
                        R.Log.i("文件已替换，准备执行清理任务");
                        FileHelper.Clean(vm);
                        R.Log.i("准备更新配置信息");
                        DataHelper.UpdatePluginConfig(vm);
                        DataHelper.UpdateWhatsnew(vm);
                        UIUpdateDetail("添加新版本特性说明 Whatsnew.txt");
                        return true;
                    }
                    else
                    {
                        UpdateRollback(vm);
                        R.Log.w("文件替换失败，当前更新失败，准备回滚备份的文件");
                    }
                }
                else
                {
                    R.Log.w("文件下载失败，当前更新失败");
                }
            }
            else
            {
                R.Log.i("创建临时存放文件目录 " + R.Paths.Temp + DownTemp + " 失败，中止更新");
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
        private void AfterUpdate(VersionModel vm)
        {
            ProcessHelper.AfterUpdate(vm);
            UIUpdateDetail("当前更新完成");
        }
        /// <summary>
        /// 下载要更新的文件
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        private bool UpdateDownload(VersionModel vm)
        {
            FileCodeTool fcode = new FileCodeTool();
            var downFile = vm.FileList.Where(x => x.IsClean == false);
            if (vm != null && ListTool.HasElements(downFile))
            {
                foreach (var file in downFile)
                {
                    R.Log.v("当前下载文件：" + file.ServerFile);
                    string serverFile = DirTool.Combine(vm.ServerPath, file.ServerFile);
                    string tempFile = DirTool.Combine(R.Paths.Temp, DownTemp, file.ServerFile);//下载到目标位置（带文件名）
                    string localFile = DirTool.IsDriver(file.LocalFile) ? file.LocalFile : DirTool.Combine(R.Paths.ProjectRoot, file.LocalFile);//旧文件位置
                    if (fcode.GetMD5(localFile) != file.FileMD5)
                    {
                        UIUpdateDetail("正在下载：" + Path.GetFileName(file.ServerFile));
                        R.Log.v("MD5码不相同，准备下载");
                        FtpHelper ftp = new FtpHelper(R.Settings.FTP.Address, R.Settings.FTP.Account, R.Settings.FTP.Password);
                        if (!ftp.Download(serverFile, tempFile))
                            if (!ftp.Download(serverFile, tempFile))
                                if (!ftp.Download(serverFile, tempFile))
                                {
                                    R.Log.v("更新文件无法被下载，请检查网络重试");
                                    return false;
                                }
                    }
                    else
                    {
                        UIUpdateDetail("文件已存在：" + Path.GetFileName(file.ServerFile));
                    }
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
                        UIUpdateDetail("正在更新：" + file.LocalFile);
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
                        UIUpdateDetail("正在还原备份文件：" + file.LocalFile);
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
        /// 读取当前要更新的信息
        /// </summary>
        /// <param name="vm"></param>
        void UILoadVersion(VersionModel vm)
        {
            Invoke(new Action(() =>
            {
                LbCodeName.Text = vm.CodeName;
                LbPluginName.Text = vm.PluginName;
                LbVersionNumber.Text = vm.VersionNumber;
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
        private void LbVersionNumber_Click(object sender, EventArgs e)
        {
            MessageBox.Show(VersionDesc, VersionNumber + " 新特性");
        }
        #endregion
    }
}
