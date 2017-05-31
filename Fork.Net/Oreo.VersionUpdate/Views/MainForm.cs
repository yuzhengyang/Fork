using Oreo.VersionUpdate.Commons;
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
        string TempFile = "Temp";

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
                //读取标准更新最新版本号 获取需要标准更新的配置
                StartUpdateStandard();

                //使用本地插件名称和版本号 获取需要更新插件的配置
                StartUpdatePlugin();
            });
        }
        private void StartUpdateStandard()
        {
            R.Log.i("读取本地标准更新版本号");
            string versionNumber = GetStandardVersionNumber();
            R.Log.i("读取当前标准版本 " + versionNumber + "，准备请求服务器新版本");
            VersionModel standardNewVersion = GetStandardNewVersion(versionNumber);
            if (standardNewVersion != null)
            {
                R.Log.i("有新的更新，版本号 " + standardNewVersion.VersionNumber);
                bool flag = Update(standardNewVersion);
                if (flag)
                {
                    R.Log.i(versionNumber + " 更新成功，当前版本" + standardNewVersion.VersionNumber);
                }
                else
                {
                    R.Log.w(versionNumber + " 更新失败");
                }
            }
            else
            {
                R.Log.i("当前标准版本为最新，不需要更新");
            }
        }
        private void StartUpdatePlugin()
        {
            R.Log.i("读取本地插件列表（名称、版本号）");
            List<PluginModel> pluginList = GetPluginList();
            if (ListTool.HasElements(pluginList))
            {
                R.Log.i("共读取到 " + pluginList.Count + " 个插件");
                pluginList.ForEach(x =>
                {
                    R.Log.i("请求 " + x.Name + " / " + x.Version + " 插件的更新");
                    VersionModel pluginNewVersion = GetPluginNewVersion(x);
                    if (pluginNewVersion != null)
                    {
                        R.Log.i(x.Name + " / " + x.Version + " 插件有新版本 " + pluginNewVersion.VersionNumber + " 需要更新，准备更新");
                        bool flag = Update(pluginNewVersion);
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
                        R.Log.i("当前插件版本为最新版本，不需要更新");
                    }
                });
            }
            else
            {
                R.Log.w("本地插件列表为空");
            }
            R.Log.i("本地插件更新操作结束");
        }
        #region 读取本地数据操作
        private List<PluginModel> GetPluginList()
        {
            List<PluginModel> rs = null;
            return rs;
        }
        private string GetStandardVersionNumber()
        {
            string rs = R.Settings.Version.Number;
            return rs;
        }
        #endregion
        #region 读取网络数据操作
        private VersionModel GetStandardNewVersion(string vn)
        {
            VersionModel rs = JsonTool.ToObjFromFile<VersionModel>(@"D:\CoCo\GitHub\Fork\Fork.Net\Oreo.VersionBuilder\bin\Debug\VersionFile\0527112916.version");
            return rs;
        }
        private VersionModel GetPluginNewVersion(PluginModel pm)
        {
            VersionModel rs = JsonTool.ToObjFromFile<VersionModel>(@"D:\CoCo\GitHub\Fork\Fork.Net\Oreo.VersionBuilder\bin\Debug\VersionFile\0527112916.version");
            return rs;
        }
        #endregion
        #region 更新操作
        private bool Update(VersionModel vm)
        {
            VersionNumber = vm.VersionNumber;
            VersionDesc = vm.VersionDesc;
            TempFile = Guid.NewGuid().ToString();
            if (DirTool.Create(R.Paths.Temp + TempFile))
            {
                R.Log.i("创建临时存放文件目录 " + R.Paths.Temp + TempFile);

                R.Log.i("将版本信息显示到 UI");
                UILoadVersion(vm);
                UpdateBefore(vm);

                if (UpdateDownload(vm))
                {
                    R.Log.i("文件已下载成功");
                    if (UpdateInstead(vm))
                    {
                        R.Log.i("文件已替换，准备执行清理任务");
                        UpdateClean(vm);


                        R.Log.i("配置文件信息更新完毕，准备写入新版本配置和描述信息");
                        UpdateConfig(vm);
                        UpdateWhatsnew(vm);
                        UpdateAfter(vm);
                        return true;
                    }
                    else
                    {
                        R.Log.w("文件替换失败，当前更新失败");
                    }
                }
                else
                {
                    R.Log.w("文件下载失败，当前更新失败");
                }
            }
            else
            {
                R.Log.i("创建临时存放文件目录 " + R.Paths.Temp + TempFile + " 失败，中止更新");
            }
            return false;
        }
        private void UpdateBefore(VersionModel vm)
        {
            if (ListTool.HasElements(vm.BeforeUpdateKillProcess))
            {
                foreach (var p in vm.BeforeUpdateKillProcess)
                {
                    if (!string.IsNullOrWhiteSpace(p))
                        ProcessTool.KillProcess(p);
                }
            }
            if (ListTool.HasElements(vm.BeforeUpdateStartProcess))
            {
                foreach (var p in vm.BeforeUpdateStartProcess)
                {
                    if (!string.IsNullOrWhiteSpace(p))
                        ProcessTool.StartProcess(p);
                }
            }
        }
        private bool UpdateDownload(VersionModel vm)
        {
            FileCodeTool fcode = new FileCodeTool();
            var downFile = vm.FileList.Where(x => x.IsClean == false);
            if (vm != null && ListTool.HasElements(downFile))
            {
                foreach (var file in vm.FileList)
                {
                    R.Log.v("当前处理文件：" + file.ServerFile);
                    string serverFile = DirTool.Combine(vm.ServerPath, file.ServerFile);
                    string tempFile = DirTool.Combine(R.Paths.Temp, TempFile, file.ServerFile);//下载到目标位置（带文件名）
                    string localFile = DirTool.IsDriver(file.LocalFile) ? file.LocalFile : DirTool.Combine(R.Paths.App, file.LocalFile);//旧文件位置
                    if (fcode.GetMD5(localFile) != file.FileMD5)
                    {
                        UIUpdateDetail("准备下载：" + Path.GetFileName(file.ServerFile));
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
        private bool UpdateInstead(VersionModel vm)
        {
            var insteadFile = vm.FileList.Where(x => x.IsClean == false);
            foreach (var file in insteadFile)
            {
                string tempFile = DirTool.Combine(R.Paths.Temp, TempFile, file.ServerFile);//下载到目标位置（带文件名）
                string localFile = DirTool.IsDriver(file.LocalFile) ? file.LocalFile : DirTool.Combine(R.Paths.App, file.LocalFile);//旧文件位置

                if (File.Exists(tempFile))
                {
                    try
                    {
                        DirTool.Create(DirTool.GetFilePath(localFile));
                        File.Copy(tempFile, localFile, true);
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
        private void UpdateClean(VersionModel vm)
        {
            //清理临时文件夹
            if (Directory.Exists(R.Paths.Temp))
            {
                try { Directory.Delete(R.Paths.Temp, true); } catch { }
                UIUpdateDetail("正在清理临时文件夹：Temp");
            }
            //清理指定文件
            var cleanFile = vm.FileList.Where(x => x.IsClean == true);
            foreach (var file in cleanFile)
            {
                string fff = DirTool.IsDriver(file.LocalFile) ? file.LocalFile : R.Paths.App + file.LocalFile;
                if (File.Exists(fff))
                {
                    try { File.Delete(fff); } catch { }
                    UIUpdateDetail("正在清理指定位置文件：" + fff);
                }
            }
        }
        private void UpdateConfig(VersionModel vm)
        {
            if (string.IsNullOrWhiteSpace(vm.PluginName) || string.IsNullOrWhiteSpace(vm.PluginEntry))
            {
                //标准版本更改设置
                IniTool.WriteValue(R.Files.Settings, "Version", "Number", vm.VersionNumber);
                UIUpdateDetail("修改主版本号：" + vm.VersionNumber);
            }
            else
            {
                //插件版本更改设置
                UIUpdateDetail("修改插件版本号：" + vm.PluginName + " " + vm.VersionNumber);
            }
        }
        private void UpdateWhatsnew(VersionModel vm)
        {
            TxtTool.Append(R.Files.Whatsnew, string.Format("{0} {1} {2}",
                    vm.CodeName, vm.VersionNumber, (vm.PluginName == "" ? "" : "For:" + vm.PluginName)));
            TxtTool.Append(R.Files.Whatsnew, vm.VersionDesc);
            TxtTool.Append(R.Files.Whatsnew, new string('=', 50));
            UIUpdateDetail("添加新版本特性说明 Whatsnew.txt");
        }
        private void UpdateAfter(VersionModel vm)
        {
            if (ListTool.HasElements(vm.AfterUpdateKillProcess))
            {
                foreach (var p in vm.AfterUpdateKillProcess)
                {
                    if (!string.IsNullOrWhiteSpace(p))
                        ProcessTool.KillProcess(p);
                }
            }
            if (ListTool.HasElements(vm.AfterUpdateStartProcess))
            {
                foreach (var p in vm.AfterUpdateStartProcess)
                {
                    if (!string.IsNullOrWhiteSpace(p))
                        ProcessTool.StartProcess(p);
                }
            }
            UIUpdateDetail("当前更新完成");
        }
        #endregion
        #region UI操作
        void UIUpdateDetail(string s)
        {
            Invoke(new Action(() =>
            {
                LbUpdateDetail.Text = s;
            }));
            Thread.Sleep(DETAIL_SHOWTIME);
        }
        void UILoadVersion(VersionModel vm)
        {
            Invoke(new Action(() =>
            {
                LbCodeName.Text = vm.CodeName;
                LbPluginName.Text = vm.PluginName;
                LbUpdateDetail.Text = "配置已加载，准备更新……";
            }));
        }
        void UIClose()
        {
            Invoke(new Action(() =>
            {
                Close();
            }));
        }
        #endregion

        #region 控件事件
        private void LbVersionNumber_Click(object sender, EventArgs e)
        {
            MessageBox.Show(VersionDesc, VersionNumber + " 新特性");
        }
        #endregion
    }
}
