using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Y.Utils.DataUtils.Collections;
using Y.Utils.IOUtils.FileUtils;
using System.Threading;
using Y.Utils.IOUtils.PathUtils;
using Oreo.FileMan.Models;
using Oreo.FileMan.DatabaseEngine;
using Oreo.FileMan.Helpers;
using Y.FileQueryEngine.QueryEngine;

namespace Oreo.FileMan.Partial
{
    public partial class FileTypePartial : UserControl
    {
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
            Start();
        }

        void Start()
        {
            Task.Factory.StartNew(() => { GetAllFileToDb(); });

            Task.Factory.StartNew(() =>
            {
                while (!IsDisposed)
                {
                    Thread.Sleep(30 * 1000);

                    //视频
                    UISearchFileWaiting(LbVideoCount);
                    Thread.Sleep(2000);
                    int ctv = GetTypeFileCount(TypeVideo);
                    UISetFileCount(LbVideoCount, ctv);
                    //文档
                    UISearchFileWaiting(LbDocCount);
                    Thread.Sleep(2000);
                    int ctd = GetTypeFileCount(TypeDoc);
                    UISetFileCount(LbDocCount, ctd);
                    //图片
                    UISearchFileWaiting(LbPictureCount);
                    Thread.Sleep(2000);
                    int ctp = GetTypeFileCount(TypePicture);
                    UISetFileCount(LbPictureCount, ctp);
                    //音乐
                    UISearchFileWaiting(LbMusicCount);
                    Thread.Sleep(2000);
                    int ctm = GetTypeFileCount(TypeMusic);
                    UISetFileCount(LbMusicCount, ctm);
                    //安装包
                    UISearchFileWaiting(LbSetupCount);
                    Thread.Sleep(2000);
                    int cts = GetTypeFileCount(TypeSetup);
                    UISetFileCount(LbSetupCount, cts);
                    //压缩包
                    UISearchFileWaiting(LbZipCount);
                    Thread.Sleep(2000);
                    int ctz = GetTypeFileCount(TypeZip);
                    UISetFileCount(LbZipCount, ctz);

                    UISearchFileWaiting(LbZipCount, false);
                }
            });
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
                            result += db.Set<Files>().Count(x => x.ExtName == t);
                        }
                    }
                }
            }
            catch (Exception e) { }
            return result;
        }

        private void GetAllFileToDb()
        {
            var drives = FileQueryEngine.GetReadyNtfsDrives().OrderByDescending(x => x.Name);
            if (ListTool.HasElements(drives))
            {
                foreach (var drive in drives)
                {
                    var allFiles = FileQueryEngine.GetAllFiles(drive);
                    int current = 0, total = allFiles.Count();
                    using (var db = new Muse())
                    {
                        List<Files> temp = new List<Files>();
                        while (ListTool.HasElements(allFiles))
                        {
                            //if (!db.Set<Files>().Any(x => x.FullPath == file))

                            temp.Add(new Files()
                            {
                                FullPath = allFiles[0],
                                FileName = Path.GetFileName(allFiles[0]),
                                ExtName = Path.GetExtension(allFiles[0]),
                                Size = FileTool.Size(allFiles[0]),
                            });
                            allFiles.RemoveAt(0);

                            if (temp.Count() % 100 == 0)
                            {
                                UISetFileCount(current, total);
                            }
                            current++;
                        }
                        UISetFileCount(current, total);
                        db.Set<Files>().AddRange(temp);
                        int count = db.SaveChanges();
                        UISetFileCount(count, total);
                    }
                }
            }
        }

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
                LbFileCount.Text = string.Format("{0} / {1}", current, total);
            }));
        }
    }
}
