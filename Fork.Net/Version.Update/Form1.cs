using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Version.Update.Commons;
using Version.Update.Models;
using Y.Utils.DataUtils.Collections;
using Y.Utils.DataUtils.JsonUtils;
using Y.Utils.IOUtils.FileUtils;
using Y.Utils.IOUtils.PathUtils;
using Y.Utils.NetUtils.FTPUtils;
using Y.Utils.WindowsUtils.ProcessUtils;

namespace Version.Update
{
    public partial class Form1 : Form
    {
        string downloadPath = "";
        VersionModel version;
        int Step = 1, Error = 1;
        int SmallHeight = 146;
        int LargeHeight = 420;
        public Form1()
        {
            InitializeComponent();
            Height = SmallHeight;
            LbRetry.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateTask();
        }

        #region 更新功能
        /// <summary>
        /// 完整的更新任务
        /// </summary>
        void UpdateTask()
        {
            LbRetry.Visible = false;
            Step = 1;
            Error = 1;

            string folder = Guid.NewGuid().ToString();
            downloadPath = R.AppPath + @"Temp\Update\" + folder;

            Task.Factory.StartNew(() =>
            {
                UILbStatus("[准备] 正在读取版本文件...");
                if (GetVersion())
                {
                    UILbStatus("[准备] 正在读取版本文件...[完成]");
                    Thread.Sleep(R.cst.STEP_WAIT_TIME);

                    if (Step == 1)
                    {
                        UILbStatus("[1/5] 正在退出相关程序...");
                        BeginCloseProcess();
                        Thread.Sleep(R.cst.STEP_WAIT_TIME);
                        UILbStatus("[1/5] 正在退出相关程序...[完成]");
                        Thread.Sleep(R.cst.STEP_WAIT_TIME);
                    }
                    if (Step == 2)
                    {
                        UILbStatus("[2/5] 正在下载新版本的文件...");
                        DownloadFile(downloadPath);
                        Thread.Sleep(R.cst.STEP_WAIT_TIME);
                        UILbStatus("[2/5] 正在下载新版本的文件...[完成]");
                        Thread.Sleep(R.cst.STEP_WAIT_TIME);
                    }
                    if (Step == 3)
                    {
                        UILbStatus("[3/5] 正在更新文件...");
                        UpdateFile(downloadPath);
                        Thread.Sleep(R.cst.STEP_WAIT_TIME);
                        UILbStatus("[3/5] 正在更新文件...[完成]");
                        Thread.Sleep(R.cst.STEP_WAIT_TIME);
                    }
                    if (Step == 4)
                    {
                        UILbStatus("[4/5] 正在清理冗余文件...");
                        CleanFile();
                        Thread.Sleep(R.cst.STEP_WAIT_TIME);
                        UILbStatus("[4/5] 正在清理冗余文件...[完成]");
                        Thread.Sleep(R.cst.STEP_WAIT_TIME);
                    }
                    if (Step == 5)
                    {
                        UILbStatus("[5/5] 准备启动程序...");
                        EndRunProcess();
                        UILbStatus("[5/5] 准备启动程序...[完成]");
                        Thread.Sleep(R.cst.STEP_WAIT_TIME);
                    }

                    if (Error > 0)
                    {
                        UILbStatus("[更新成功 即将退出]");
                        Thread.Sleep(R.cst.STEP_WAIT_TIME);
                        UIClose();
                    }
                    else
                    {
                        UILbStatus("[更新异常 请检查并解决故障后 重新更新]");
                        UIShowRetry();
                    }
                }
                else
                {
                    UILbStatus("[结束] 未发现新版本...");
                    MessageBox.Show("您已经是最新版本了。", "完成");
                    UIClose();
                }
            });
        }

        /// <summary>
        /// 获取版本配置文件
        /// </summary>
        /// <returns></returns>
        bool GetVersion()
        {
            version = JsonTool.ToObjFromFile<VersionModel>(R.VersionFile);
            if (version != null)
            {
                try
                {
                    int num = 1;
                    foreach (var item in version.FileList)
                    {
                        UIDgvFileListAdd(new object[] { num++, Path.GetFileName(item.File) });
                        Thread.Sleep(R.cst.WAIT_TIME);
                    }
                    return true;
                }
                catch (Exception e) { }
            }
            return false;
        }
        /// <summary>
        /// 下载程序文件
        /// </summary>
        /// <returns></returns>
        bool DownloadFile(string downloadPath)
        {
            if (DirTool.Create(downloadPath))
            {
                FileCodeTool fcode = new FileCodeTool();
                for (int i = 0; i < version.FileList.Count; i++)
                {
                    string fileName = Path.GetFileName(version.FileList[i].File);
                    string sourceFile = version.ServerPath + version.FileList[i].File;
                    string destFile = downloadPath + version.FileList[i].File;
                    string destPath = destFile.Substring(0, destFile.Length - fileName.Length);
                    if (DirTool.Create(destPath))
                    {
                        if (File.Exists(R.AppPath + version.FileList[i].File) &&
                            version.FileList[i].MD5 == fcode.GetMD5(R.AppPath + version.FileList[i].File))
                        {
                            UIDgvFileListUpdate(i, "ColDown", R.cst.FILE_JUMP);
                        }
                        else
                        {
                            FtpHelper ftp = new FtpHelper(R.FtpIp, R.FtpAccount, R.FtpPassword);
                            if (!ftp.DownloadFile(sourceFile, destPath))
                                if (!ftp.DownloadFile(sourceFile, destPath))
                                    if (!ftp.DownloadFile(sourceFile, destPath))
                                    {
                                        MessageBox.Show("更新文件无法被下载，请检查网络重试，谢谢。", "网络故障");
                                        Step = 5;
                                        Error = -201;
                                        return false;
                                    }
                            UIDgvFileListUpdate(i, "ColDown", R.cst.FILE_SUCC);
                        }
                    }
                    else
                    {
                        UIDgvFileListUpdate(i, "ColDown", R.cst.FILE_FAIL);
                    }
                    Thread.Sleep(R.cst.WAIT_TIME);
                }
            }
            Step = 3;
            return true;
        }
        /// <summary>
        /// 更新程序文件
        /// </summary>
        /// <returns></returns>
        bool UpdateFile(string downloadPath)
        {
            for (int i = 0; i < version.FileList.Count; i++)
            {
                string fileName = Path.GetFileName(version.FileList[i].File);
                string sourceFile = downloadPath + version.FileList[i].File;
                string destFile = R.AppPath + version.FileList[i].File;
                string destPath = destFile.Substring(0, destFile.Length - fileName.Length);
                if (DirTool.Create(destPath))
                {
                    try
                    {
                        if (File.Exists(sourceFile))
                        {
                            File.Copy(sourceFile, destFile, true);
                            UIDgvFileListUpdate(i, "ColUpdate", R.cst.FILE_SUCC);
                        }
                        else
                        {
                            UIDgvFileListUpdate(i, "ColUpdate", R.cst.FILE_JUMP);
                        }
                    }
                    catch (Exception e)
                    {
                        UIDgvFileListUpdate(i, "ColUpdate", R.cst.FILE_FAIL);
                    }
                }
                else
                {
                    UIDgvFileListUpdate(i, "ColBack", R.cst.FILE_FAIL);
                }
                Thread.Sleep(R.cst.WAIT_TIME);
            }
            Step = 4;
            return false;
        }
        /// <summary>
        /// 清理之前版本遗留文件及空文件夹
        /// </summary>
        /// <returns></returns>
        void CleanFile()
        {
            UIPbStatus(0);
            #region 删除下载的更新文件和版本文件
            try
            {
                Directory.Delete(R.AppPath + @"Temp\Update\", true);
                File.Delete(R.VersionFile);
            }
            catch { }
            #endregion
            UIPbStatus(50);
            if (version.DoClean)
            {
                #region 删除非当前版本文件
                List<string> file = FileTool.GetAllFile(R.AppPath);
                if (!ListTool.IsNullOrEmpty(file))
                {
                    foreach (var f in file)
                    {
                        int c = version.FileList.Where(x => x.File == "\\" + f.Replace(R.AppPath, "")).Count();
                        if (c == 0)
                        {
                            try { File.Delete(f); } catch { }
                        }
                    }
                    Thread.Sleep(R.cst.WAIT_TIME);
                }
                #endregion
                #region 删除空文件夹
                List<string> path = DirTool.GetAllPath(R.AppPath);
                if (!ListTool.IsNullOrEmpty(path))
                {
                    path = path.OrderByDescending(x => x).ToList();
                    foreach (var p in path)
                    {
                        if (Directory.GetFiles(p).Length == 0 && Directory.GetDirectories(p).Length == 0)
                        {
                            if (Directory.Exists(p))
                            {
                                try { Directory.Delete(p); } catch { }
                            }
                        }
                        Thread.Sleep(R.cst.WAIT_TIME);
                    }
                }
                #endregion
            }
            UIPbStatus(100);
            Step = 5;
        }
        /// <summary>
        /// 更新开始结束程序
        /// </summary>
        void BeginCloseProcess()
        {
            int percent = 1;
            if (!ListTool.IsNullOrEmpty(version.BeginCloseProcess))
            {
                foreach (var p in version.BeginCloseProcess)
                {
                    Thread.Sleep(R.cst.WAIT_TIME);
                    UIPbStatus((int)((double)(percent++) / version.BeginCloseProcess.Count() * 100));
                    if (!string.IsNullOrWhiteSpace(p))
                        ProcessTool.KillProcess(p);
                }
            }
            Step = 2;
        }
        /// <summary>
        /// 更新结束启动程序
        /// </summary>
        void EndRunProcess()
        {
            int percent = 1;
            if (!ListTool.IsNullOrEmpty(version.EndRunProcess))
            {
                foreach (var p in version.EndRunProcess)
                {
                    Thread.Sleep(R.cst.WAIT_TIME);
                    UIPbStatus((int)((double)(percent++) / version.EndRunProcess.Count() * 100));
                    if (!string.IsNullOrWhiteSpace(p))
                        ProcessTool.StartProcess(Path.Combine(R.AppPath, p));
                }
            }
        }
        #endregion

        #region UI刷新
        /// <summary>
        /// 在DgvFileList中添加一条新纪录
        /// </summary>
        /// <param name="values"></param>
        void UIDgvFileListAdd(params object[] values)
        {
            this.BeginInvoke(new Action(() =>
            {
                if (values != null)
                {
                    DgvFileList.Rows.Add(values);
                    DgvFileList.FirstDisplayedScrollingRowIndex = DgvFileList.RowCount - 1;
                    UIPbStatus((int)((double)(int)(values[0]) / version.FileList.Count * 100));
                }
            }));
        }
        /// <summary>
        /// 更新DgvFileList控件中的记录
        /// </summary>
        /// <param name="row"></param>
        /// <param name="cell"></param>
        /// <param name="value"></param>
        void UIDgvFileListUpdate(int row, string cell, string value)
        {
            this.BeginInvoke(new Action(() =>
            {
                DgvFileList.Rows[row].Cells[cell].Value = value;
                if (version.FileList.Count > 5)
                    DgvFileList.FirstDisplayedScrollingRowIndex = (row - 5) > 0 ? (row - 5) : 0;
                UIPbStatus((int)((double)(row + 1) / version.FileList.Count * 100));
            }));
        }
        /// <summary>
        /// 设置ProgressBar的进度百分比
        /// </summary>
        /// <param name="percent"></param>
        void UIPbStatus(int percent)
        {
            Invoke(new Action(() =>
            {
                PbStatus.Value = percent;
            }));
        }
        /// <summary>
        /// 更新LbStatus状态信息文本
        /// </summary>
        /// <param name="msg"></param>
        void UILbStatus(string msg)
        {
            Invoke(new Action(() =>
            {
                LbStatus.Text = msg;
            }));
        }
        void UIClose()
        {
            Invoke(new Action(() =>
            {
                Close();
            }));
        }
        void UIShowRetry()
        {
            Invoke(new Action(() => { LbRetry.Visible = true; }));
        }
        #endregion

        #region 控件事件
        private void LbStatus_DoubleClick(object sender, EventArgs e)
        {
            if (Height < (SmallHeight + ((LargeHeight - SmallHeight) / 2)))
            {
                Height = LargeHeight;
            }
            else
            {
                Height = SmallHeight;
            }
        }
        private void LbRetry_Click(object sender, EventArgs e)
        {
            UpdateTask();
        } 
        #endregion
    }
}
