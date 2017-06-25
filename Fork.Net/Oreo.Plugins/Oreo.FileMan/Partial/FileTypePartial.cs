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

namespace Oreo.FileMan.Partial
{
    public partial class FileTypePartial : UserControl
    {
        int GetTypeFileCountInterval = 60 * 1000;
        int GetTypeFileCountDetailInterval = 1000;
        int GetFileToDatabaseInterval = 60 * 1000;

        int NewFileCount = 0;

        string[] TypeVideo = new string[] { ".mp4", ".rmvb", ".wma" };
        string[] TypeDoc = new string[] { ".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pptx", ".txt" };
        string[] TypePicture = new string[] { ".jpg", ".bmp", ".png", ".icon", ".ico" };
        string[] TypeMusic = new string[] { ".mp3", ".wma" };
        string[] TypeSetup = new string[] { ".apk", ".msi" };
        string[] TypeZip = new string[] { ".zip", ".rar", ".iso" };
        public FileTypePartial()
        {
            InitializeComponent();
        }

        private void FileTypePartial_Load(object sender, EventArgs e)
        {
            TaskOfGetFileToDatabase();//获取磁盘所有文件到文件索引数据库
        }

        private void TaskOfGetFileToDatabase()
        {
            Task.Factory.StartNew(() =>
            {
                while (!IsDisposed)
                {
                    GetFileToDatabase2();
                    GetTypeFileCount();
                    Thread.Sleep(GetFileToDatabaseInterval);
                }
            });
        }
        private void GetFileToDatabase()
        {
            var drives = FileQueryEngine.GetReadyNtfsDrives().OrderByDescending(x => x.Name);
            if (ListTool.HasElements(drives))
            {
                foreach (var drive in drives)
                {
                    var usnList = FileQueryEngine.GetAllFiles(drive);
                    if (ListTool.HasElements(usnList))
                    {
                        using (var db = new Muse())
                        {
                            //检测磁盘是否格式化，如果格式化则清空USN记录
                            DateTime dt1 = DriveTool.GetLastFormatTime(drive.Name);
                            var ds = db.Get<Drives>(x => x.Name == drive.Name, null);
                            if ((ds == null) || (ds != null && ds.LastFormatTime != dt1.ToString()))
                            {
                                var fs = db.Gets<Files>(x => x.Drive == drive.Name, null);
                                if (ListTool.HasElements(fs)) db.Dels(fs);

                                if (ds == null)
                                {
                                    db.Add(new Drives() { Name = drive.Name, LastFormatTime = dt1.ToString() });
                                }
                                else
                                {
                                    ds.LastFormatTime = dt1.ToString();
                                    db.Update(ds, true);
                                }
                            }

                            //查询上次读取到的位置并读取USN
                            if (db.Any<Files>(x => x.Drive == drive.Name, null))
                            {
                                long currentUsn = db.Do<Files>().Where(x => x.Drive == drive.Name).Max(x => x.Usn);
                                usnList = usnList.Where(x => x.Usn > currentUsn).ToList();
                            }
                            //将记录存储到数据库中
                            if (ListTool.HasElements(usnList))
                            {
                                //List<Files> temp = new List<Files>();
                                for (int i = 0; i < usnList.Count; i++)
                                {
                                    UISetFileCount(i + 1, usnList.Count());

                                    //temp.Add(new Files()
                                    //{
                                    //    Name = usnList[i].FileName,
                                    //    IsFolder = usnList[i].IsFolder,
                                    //    Number = usnList[i].FileReferenceNumber.ToString(),
                                    //    ParentNumber = usnList[i].ParentFileReferenceNumber.ToString(),
                                    //    Drive = drive.Name,
                                    //    Usn = usnList[i].Usn,
                                    //});
                                    //if (temp.Count > 100)
                                    //{
                                    //    db.Adds(temp);
                                    //    temp = new List<Files>();
                                    //    Thread.Sleep(100);
                                    //}
                                    db.Add(new Files()
                                    {
                                        Name = usnList[i].FileName,
                                        IsFolder = usnList[i].IsFolder,
                                        Number = usnList[i].FileReferenceNumber.ToString(),
                                        ParentNumber = usnList[i].ParentFileReferenceNumber.ToString(),
                                        Drive = drive.Name,
                                        Usn = usnList[i].Usn,
                                    });
                                }
                                //db.Adds(temp);
                            }
                        }
                    }
                }
            }
        }
        private void GetFileToDatabase2()
        {
            using (var db = new Muse())
            {
                var a = db.Get(x=>x.);
                //var a = db.Database.SqlQuery<Drives>("delete from drives where name = 'C:\\'", new SqlParameter("@name", @"C:\"));

            }

            var drives = FileQueryEngine.GetReadyNtfsDrives().OrderByDescending(x => x.Name);
            if (ListTool.HasElements(drives))
            {
                foreach (var drive in drives)
                {
                    NewFileCount = 0;
                    //if (drive.Name.Contains("C")) continue;//测试时跳过C盘
                    //if (drive.Name.Contains("D")) continue;//测试时跳过D盘

                    using (var db = new Muse())
                    {
                        //检测磁盘是否格式化，如果格式化则清空USN记录
                        DateTime dt1 = DriveTool.GetLastFormatTime(drive.Name);
                        var ds = db.Get<Drives>(x => x.Name == drive.Name, null);
                        if ((ds == null) || (ds != null && ds.LastFormatTime != dt1.ToString()))
                        {
                            var fs = db.Gets<Files>(x => x.Drive == drive.Name, null);
                            if (ListTool.HasElements(fs))
                            {
                                //db.Dels(fs);
                            }

                            if (ds == null)
                            {
                                db.Add(new Drives() { Name = drive.Name, LastFormatTime = dt1.ToString() });
                            }
                            else
                            {
                                ds.LastFormatTime = dt1.ToString();
                                db.Update(ds, true);
                            }
                        }

                        //查询上次读取到的位置
                        long currentUsn = 0;
                        if (db.Any<Files>(x => x.Drive == drive.Name, null))
                        {
                            currentUsn = db.Do<Files>().Where(x => x.Drive == drive.Name).Max(x => x.Usn) + 1;
                        }
                        //从上次Usn记录开始读取
                        var usnOperator = new UsnOperator(drive);
                        usnOperator.GetEntries(currentUsn, GetFileToDatabaseEvent, 1000);
                    }
                }
            }
        }
        private void GetFileToDatabaseEvent(DriveInfo drive, List<UsnEntry> data)
        {
            List<Files> temp = new List<Files>();
            if (ListTool.HasElements(data))
            {
                for (int i = 0; i < data.Count; i++)
                {
                    temp.Add(new Files()
                    {
                        Name = data[i].FileName,
                        IsFolder = data[i].IsFolder,
                        Number = data[i].FileReferenceNumber.ToString(),
                        ParentNumber = data[i].ParentFileReferenceNumber.ToString(),
                        Drive = drive.Name,
                        Usn = data[i].Usn,
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
            Thread.Sleep(GetTypeFileCountDetailInterval);
            int ctv = GetTypeFileCount(TypeVideo);
            UISetFileCount(LbVideoCount, ctv);
            //文档
            UISearchFileWaiting(LbDocCount);
            Thread.Sleep(GetTypeFileCountDetailInterval);
            int ctd = GetTypeFileCount(TypeDoc);
            UISetFileCount(LbDocCount, ctd);
            //图片
            UISearchFileWaiting(LbPictureCount);
            Thread.Sleep(GetTypeFileCountDetailInterval);
            int ctp = GetTypeFileCount(TypePicture);
            UISetFileCount(LbPictureCount, ctp);
            //音乐
            UISearchFileWaiting(LbMusicCount);
            Thread.Sleep(GetTypeFileCountDetailInterval);
            int ctm = GetTypeFileCount(TypeMusic);
            UISetFileCount(LbMusicCount, ctm);
            //安装包
            UISearchFileWaiting(LbSetupCount);
            Thread.Sleep(GetTypeFileCountDetailInterval);
            int cts = GetTypeFileCount(TypeSetup);
            UISetFileCount(LbSetupCount, cts);
            //压缩包
            UISearchFileWaiting(LbZipCount);
            Thread.Sleep(GetTypeFileCountDetailInterval);
            int ctz = GetTypeFileCount(TypeZip);
            UISetFileCount(LbZipCount, ctz);

            UISearchFileWaiting(LbZipCount, false);
            Thread.Sleep(GetTypeFileCountInterval);
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
                            var count = db.Do<Files>().Count(x => !x.IsFolder && x.Name.EndsWith(t));
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
