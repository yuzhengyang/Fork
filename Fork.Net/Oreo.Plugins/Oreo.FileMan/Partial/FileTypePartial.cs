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

namespace Oreo.FileMan.Partial
{
    public partial class FileTypePartial : UserControl
    {
        string[] TypeVideo = new string[] { "*.mp4", "*.rmvb" };
        string[] TypeDoc = new string[] { "*.doc", "*.xls" };
        string[] TypePicture = new string[] { "*.jpg", "*.bmp" };
        string[] TypeMusic = new string[] { "*.mp3", "*.wma" };
        string[] TypeSetup = new string[] { "*.apk", "*.msi" };
        string[] TypeZip = new string[] { "*.zip", "*.rar" };
        public FileTypePartial()
        {
            InitializeComponent();
        }

        private void FileTypePartial_Load(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                //视频
                Thread.Sleep(2000);
                UISearchFileWaiting(LbVideoCount);
                int ctv = GetTypeFileCount(TypeVideo);
                UISetFileCount(LbVideoCount, ctv);
                //文档
                Thread.Sleep(2000);
                UISearchFileWaiting(LbDocCount);
                int ctd = GetTypeFileCount(TypeDoc);
                UISetFileCount(LbDocCount, ctd);
                //图片
                Thread.Sleep(2000);
                UISearchFileWaiting(LbPictureCount);
                int ctp = GetTypeFileCount(TypePicture);
                UISetFileCount(LbPictureCount, ctp);
                //音乐
                Thread.Sleep(2000);
                UISearchFileWaiting(LbMusicCount);
                int ctm = GetTypeFileCount(TypeMusic);
                UISetFileCount(LbMusicCount, ctm);
                //安装包
                Thread.Sleep(2000);
                UISearchFileWaiting(LbSetupCount);
                int cts = GetTypeFileCount(TypeSetup);
                UISetFileCount(LbSetupCount, cts);
                //压缩包
                Thread.Sleep(2000);
                UISearchFileWaiting(LbZipCount);
                int ctz = GetTypeFileCount(TypeZip);
                UISetFileCount(LbZipCount, ctz);

                UISearchFileWaiting(LbZipCount, false);
            });
        }

        private int GetTypeFileCount(string[] type)
        {
            int result = 0;
            try
            {
                //DriveInfo[] allDirves = DriveInfo.GetDrives();
                //if (ListTool.HasElements(allDirves))
                //{
                //    foreach (var item in allDirves)
                //    {
                //        if (item.IsReady)
                //        {
                List<string> files = FileTool.GetAllFile("D:\\", type);
                if (ListTool.HasElements(files))
                {
                    result += files.Count();
                    using (var db = new Muse())
                    {
                        files.ForEach(x =>
                        {
                            var a = db.Set<Files>().Add(new Files() { FullPath = x, FileName = Path.GetFileName(x), ExtName = Path.GetExtension(x) });
                        });
                        int count = db.SaveChanges();
                    }
                }
                //        }
                //    }
                //}
            }
            catch (Exception e) { }
            return result;
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
        void UISetFileCount(Label lb, int count)
        {
            BeginInvoke(new Action(() =>
            {
                lb.Text = count + "项";
            }));
        }
    }
}
