using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Version.Update.Models;
using Y.Utils.DataUtils.JsonUtils;
using Y.Utils.IOUtils.FileUtils;
using Y.Utils.IOUtils.PathUtils;
using Y.Utils.NetUtils.FTPUtils;

namespace Version.Update
{
    public partial class Form1 : Form
    {
        const string FILE_SUCC = "√";
        const string FILE_FAIL = "×";
        const string FILE_JUMP = "-";
        const int WAIT_TIME = 100;
        string AppDir = AppDomain.CurrentDomain.BaseDirectory;
        string folder = Guid.NewGuid().ToString();
        string downloadPath = "";
        string backupPath = "";
        VersionModel version;

        string VersionFile = @"D:\FTP\Application\version1.2.txt";
        string FtpIp = "192.168.3.56";
        string FtpAccount = "Administrator";
        string FtpPassword = "yuzhengyang";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            downloadPath = AppDir + @"Download\" + folder;
            backupPath = AppDir + @"Backup\" + folder;

            Task.Factory.StartNew(() =>
            {
                //获取配置文件 -> 下载文件
                if (GetVersion())
                {
                    //DownloadFile(downloadPath);
                    //BackupFile(backupPath);
                    //UpdateFile(downloadPath);
                    //RollBackFile(backupPath);

                    //Directory.Delete(downloadPath, true);
                    //Directory.Delete(backupPath, true);
                }

            });
        }

        #region 更新功能
        /// <summary>
        /// 获取版本配置文件
        /// </summary>
        /// <returns></returns>
        bool GetVersion()
        {
            version = JsonTool.ToObjFromFile<VersionModel>(VersionFile);
            if (version != null)
            {
                try
                {
                    int num = 1;
                    foreach (var item in version.FileList)
                    {
                        this.BeginInvoke(new Action(() => { UIDgvFileListAdd(new object[] { num++, Path.GetFileName(item.File) }); }));
                        Thread.Sleep(WAIT_TIME);
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
                    string sourceFile = version.Path + version.FileList[i].File;
                    string destFile = downloadPath + version.FileList[i].File;
                    string destPath = destFile.Substring(0, destFile.Length - fileName.Length);
                    if (DirTool.Create(destPath))
                    {
                        try
                        {
                            if (File.Exists(AppDir + version.FileList[i].File) &&
                                version.FileList[i].MD5 == fcode.GetMD5(AppDir + version.FileList[i].File))
                            {
                                this.BeginInvoke(new Action(() => { UIDgvFileListUpdate(i, "ColDown", FILE_JUMP); }));
                            }
                            else
                            {
                                //File.Copy(sourceFile, destFile);
                                FtpHelper ftp = new FtpHelper(FtpIp, FtpAccount, FtpPassword);
                                ftp.DownloadFile(sourceFile, destPath);
                                this.BeginInvoke(new Action(() => { UIDgvFileListUpdate(i, "ColDown", FILE_SUCC); }));
                            }
                        }
                        catch (Exception e)
                        {
                            this.BeginInvoke(new Action(() => { UIDgvFileListUpdate(i, "ColDown", FILE_FAIL); }));
                        }
                    }
                    else
                    {
                        this.BeginInvoke(new Action(() => { UIDgvFileListUpdate(i, "ColDown", FILE_FAIL); }));
                    }
                    Thread.Sleep(WAIT_TIME);
                }
            }
            return false;
        }
        /// <summary>
        /// 备份程序文件
        /// </summary>
        /// <returns></returns>
        bool BackupFile(string backupPath, string downloadPath)
        {
            if (DirTool.Create(backupPath))
            {
                FileCodeTool fcode = new FileCodeTool();
                for (int i = 0; i < version.FileList.Count; i++)
                {
                    string fileName = Path.GetFileName(version.FileList[i].File);
                    string sourceFile = AppDir + version.FileList[i].File;
                    string destFile = backupPath + version.FileList[i].File;
                    string destPath = destFile.Substring(0, destFile.Length - fileName.Length);
                    string downloadFile = downloadPath + version.FileList[i].File;
                    if (DirTool.Create(destPath))
                    {
                        try
                        {
                            if (File.Exists(sourceFile) && File.Exists(downloadFile) && version.FileList[i].MD5 != fcode.GetMD5(AppDir + version.FileList[i].File))
                            {
                                File.Copy(sourceFile, destFile);
                                this.BeginInvoke(new Action(() => { UIDgvFileListUpdate(i, "ColBack", FILE_SUCC); }));
                            }
                            else
                            {
                                this.BeginInvoke(new Action(() => { UIDgvFileListUpdate(i, "ColBack", FILE_JUMP); }));
                            }
                        }
                        catch (Exception e)
                        {
                            this.BeginInvoke(new Action(() => { UIDgvFileListUpdate(i, "ColBack", FILE_FAIL); }));
                        }
                    }
                    else
                    {
                        this.BeginInvoke(new Action(() => { UIDgvFileListUpdate(i, "ColBack", FILE_FAIL); }));
                    }
                    Thread.Sleep(WAIT_TIME);
                }
            }
            return false;
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
                string destFile = AppDir + version.FileList[i].File;
                string destPath = destFile.Substring(0, destFile.Length - fileName.Length);
                if (DirTool.Create(destPath))
                {
                    try
                    {
                        if (File.Exists(sourceFile))
                        {
                            File.Copy(sourceFile, destFile, true);
                            this.BeginInvoke(new Action(() => { UIDgvFileListUpdate(i, "ColUpdate", FILE_SUCC); }));
                        }
                        else
                        {
                            this.BeginInvoke(new Action(() => { UIDgvFileListUpdate(i, "ColUpdate", FILE_JUMP); }));
                        }
                    }
                    catch (Exception e)
                    {
                        this.BeginInvoke(new Action(() => { UIDgvFileListUpdate(i, "ColUpdate", FILE_FAIL); }));
                    }
                }
                else
                {
                    this.BeginInvoke(new Action(() => { UIDgvFileListUpdate(i, "ColBack", FILE_FAIL); }));
                }
                Thread.Sleep(WAIT_TIME);
            }
            return false;
        }
        /// <summary>
        /// 还原程序文件
        /// </summary>
        /// <returns></returns>
        bool RollBackFile(string backupPath)
        {
            for (int i = 0; i < version.FileList.Count; i++)
            {
                string fileName = Path.GetFileName(version.FileList[i].File);
                string sourceFile = backupPath + version.FileList[i].File;
                string destFile = AppDir + version.FileList[i].File;
                string destPath = destFile.Substring(0, destFile.Length - fileName.Length);
                if (DirTool.Create(destPath))
                {
                    try
                    {
                        if (File.Exists(sourceFile))
                        {
                            File.Copy(sourceFile, destFile, true);
                            this.BeginInvoke(new Action(() => { UIDgvFileListUpdate(i, "ColRoll", FILE_SUCC); }));
                        }
                        else
                        {
                            this.BeginInvoke(new Action(() => { UIDgvFileListUpdate(i, "ColRoll", FILE_JUMP); }));
                        }
                    }
                    catch (Exception e)
                    {
                        this.BeginInvoke(new Action(() => { UIDgvFileListUpdate(i, "ColRoll", FILE_FAIL); }));
                    }
                }
                else
                {
                    this.BeginInvoke(new Action(() => { UIDgvFileListUpdate(i, "ColRoll", FILE_FAIL); }));
                }
                Thread.Sleep(WAIT_TIME);
            }
            return false;
        }
        #endregion
        #region UI刷新
        /// <summary>
        /// 在DgvFileList中添加一条新纪录
        /// </summary>
        /// <param name="values"></param>
        void UIDgvFileListAdd(params object[] values)
        {
            if (values != null)
            {
                DgvFileList.Rows.Add(values);
            }
        }
        void UIDgvFileListUpdate(int row, string cell, string value)
        {
            DgvFileList.Rows[row].Cells[cell].Value = value;
        }
        #endregion

        private void BtDownload_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() => { DownloadFile(downloadPath); });
        }

        private void BtBackup_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() => { BackupFile(backupPath, downloadPath); });
        }

        private void BtUpdate_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() => { UpdateFile(downloadPath); });
        }

        private void BtRollback_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() => { RollBackFile(backupPath); });
        }
    }
}
