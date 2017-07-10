using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Y.Utils.DataUtils.Collections;
using System.Threading;
using Oreo.FileMan.Models;
using Oreo.FileMan.DatabaseEngine;
using Y.FileQueryEngine.QueryEngine;
using Y.FileQueryEngine.UsnOperation;
using System.IO;
using Y.Utils.IOUtils.DriveUtils;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;
using Y.Utils.AppUtils;
using Y.Utils.DataUtils.DateTimeUtils;
using Y.Utils.DataUtils.StringUtils;
using Oreo.FileMan.Commons;

namespace Oreo.FileMan.Partials
{
    public partial class FileTypePartial : UserControl
    {
        int GetFileToDatabaseInterval = 60 * 60 * 1000;
        int WaitingInterval = 1000;

        int NewFileCount = 0;

        string[] TypeVideo = new string[] { ".mp4", ".rmvb", ".mkv" };
        string[] TypeDoc = new string[] { ".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pptx" };
        string[] TypePicture = new string[] { ".jpg", ".bmp", ".png", ".psd" };
        string[] TypeMusic = new string[] { ".mp3", ".wav" };
        string[] TypeSetup = new string[] { ".apk", ".msi", "setup.exe" };
        string[] TypeZip = new string[] { ".zip", ".rar", ".iso" };
        public FileTypePartial()
        {
            InitializeComponent();
        }

        private void FileTypePartial_Load(object sender, EventArgs e)
        {
            if (PermissionTool.IsAdmin())
            {
                TaskOfGetFileToDatabase();//获取磁盘所有文件到文件索引数据库
            }
            else
            {
                LbFileCount.Text = "该功能需在管理员权限下运行";
            }
        }

        private void TaskOfGetFileToDatabase()
        {
            Task.Factory.StartNew(() =>
            {
                while (!IsDisposed)
                {
                    GetFileToDatabase();
                    GetTypeFileCount();
                    Thread.Sleep(GetFileToDatabaseInterval);
                }
            });
        }
        private void GetFileToDatabase()
        {
            var drives = FileQueryEngine.GetReadyNtfsDrives().OrderBy(x => x.Name);
            if (ListTool.HasElements(drives))
            {
                foreach (var drive in drives)
                {
                    NewFileCount = 0;
                    //if (!drive.Name.Contains("J")) continue;//测试只读取D盘
                    //if (drive.Name.Contains("D")) continue;//测试时跳过D盘
                    //if (drive.Name.Contains("F")) continue;//测试时跳过F盘

                    using (var db = new Muse())
                    {
                        //检测磁盘是否格式化，如果格式化则清空USN记录
                        DateTime dt1 = DriveTool.GetLastFormatTime(drive.Name);
                        var ds = db.Get<UsnDrives>(x => x.Name == drive.Name, null);
                        if ((ds == null) || (ds != null && ds.LastFormatTime != dt1.ToString()))
                        {
                            var deleteSql = db.Context.Database.ExecuteSqlCommand("DELETE FROM usnfiles WHERE drive = @p0;", drive.Name);

                            if (ds == null)
                            {
                                db.Add(new UsnDrives() { Name = drive.Name, LastFormatTime = dt1.ToString() });
                            }
                            else
                            {
                                ds.LastFormatTime = dt1.ToString();
                                db.Update(ds, true);
                            }
                        }

                        //查询上次读取到的位置（最后一条记录）
                        ulong filenumber = 0;
                        long usn = 0;
                        if (db.Any<UsnFiles>(x => x.Drive == drive.Name, null))
                        {
                            int lastId = db.Do<UsnFiles>().Where(x => x.Drive == drive.Name).Max(x => x.Id);
                            UsnFiles lastRec = db.Get<UsnFiles>(x => x.Id == lastId, null);

                            usn = lastRec.Usn;
                            filenumber = NumberStringTool.ToUlong(lastRec.Number);

                            //usn = db.Do<UsnFiles>().Where(x => x.Drive == drive.Name).Max(x => x.Usn);
                            //string filenumberstr = db.Do<UsnFiles>().Where(x => x.Drive == drive.Name).Max(x => x.Number);
                            //filenumber = NumberStringTool.ToUlong(filenumberstr);
                        }
                        //从上次FileNumber记录开始读取
                        var usnOperator = new UsnOperator(drive);
                        usnOperator.GetEntries(usn, filenumber, GetFileToDatabaseEvent, 1000);
                    }
                }
            }
        }
        private void GetFileToDatabaseEvent(DriveInfo drive, List<UsnEntry> data)
        {
            List<UsnFiles> temp = new List<UsnFiles>();
            if (ListTool.HasElements(data))
            {
                for (int i = 0; i < data.Count; i++)
                {
                    temp.Add(new UsnFiles()
                    {
                        Name = data[i].FileName,
                        IsFolder = data[i].IsFolder,
                        Number = NumberStringTool.ToString(data[i].FileReferenceNumber),
                        ParentNumber = NumberStringTool.ToString(data[i].ParentFileReferenceNumber),
                        Drive = drive.Name,
                        Usn = data[i].Usn,
                        CreateTime = DateTimeConvert.DetailString(DateTime.Now)
                    });
                    NewFileCount++;
                }
            }
            using (var db = new Muse())
            {
                db.Adds(temp);
            }
            UISetFileCount(drive.Name, NewFileCount);
        }
        private void GetTypeFileCount()
        {
            //视频
            UISearchFileWaiting(LbVideoCount);
            Thread.Sleep(WaitingInterval);
            int ctv = GetTypeFileCount(TypeVideo);
            UISetFileCount(LbVideoCount, ctv);
            //文档
            UISearchFileWaiting(LbDocCount);
            Thread.Sleep(WaitingInterval);
            int ctd = GetTypeFileCount(TypeDoc);
            UISetFileCount(LbDocCount, ctd);
            //图片
            UISearchFileWaiting(LbPictureCount);
            Thread.Sleep(WaitingInterval);
            int ctp = GetTypeFileCount(TypePicture);
            UISetFileCount(LbPictureCount, ctp);
            //音乐
            UISearchFileWaiting(LbMusicCount);
            Thread.Sleep(WaitingInterval);
            int ctm = GetTypeFileCount(TypeMusic);
            UISetFileCount(LbMusicCount, ctm);
            //安装包
            UISearchFileWaiting(LbSetupCount);
            Thread.Sleep(WaitingInterval);
            int cts = GetTypeFileCount(TypeSetup);
            UISetFileCount(LbSetupCount, cts);
            //压缩包
            UISearchFileWaiting(LbZipCount);
            Thread.Sleep(WaitingInterval);
            int ctz = GetTypeFileCount(TypeZip);
            UISetFileCount(LbZipCount, ctz);

            UISearchFileWaiting(LbZipCount, false);
        }
        private int GetTypeFileCount(string[] type)
        {
            int result = 0;
            try
            {
                using (var db = new Muse())
                {
                    if (ListTool.HasElements(type))
                    {
                        foreach (var t in type)
                        {
                            var count = db.Do<UsnFiles>().Count(x => !x.IsFolder && x.Name.EndsWith(t));
                            result += count;
                            //foreach (var l in list)
                            //{
                            //    bool flag = FileQueryEngine.FileIsExist(l.Drive, l.Usn);
                            //    if (flag) { result++; }
                            //    else
                            //    {
                            //        db.Del(l, true);
                            //    }
                            //}
                        }
                    }
                }
            }
            catch (Exception e) { }
            return result;
        }


        #region UI操作
        /// <summary>
        /// 读取文件分类的加载动画
        /// </summary>
        /// <param name="lb"></param>
        /// <param name="visible"></param>
        void UISearchFileWaiting(Label lb, bool visible = true)
        {
            BeginInvoke(new Action(() =>
            {
                if (visible)
                {
                    PbWaiting.Visible = visible;
                    PbWaiting.Top = lb.Top;
                    PbWaiting.Left = lb.Left;
                }
                else
                {
                    PbWaiting.Visible = visible;
                }
            }));
        }
        /// <summary>
        /// 设置文件个数
        /// </summary>
        /// <param name="lb"></param>
        /// <param name="count"></param>
        void UISetFileCount(Label lb, int count)
        {
            BeginInvoke(new Action(() =>
            {
                lb.Text = count + "项";
            }));
        }
        void UISetFileCount(int current, int total)
        {
            BeginInvoke(new Action(() =>
            {
                LbFileCount.Text = string.Format("已处理 {0} / 新增 {1} 项", current, total);
            }));
        }
        void UISetFileCount(string drive, int number)
        {
            BeginInvoke(new Action(() =>
            {
                LbFileCount.Text = string.Format("磁盘 {0} 新增 {1} 项", drive, number);
            }));
        }
        #endregion
    }
}
