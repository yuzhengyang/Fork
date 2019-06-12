using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.Core.DataUtils.GuidUtils;
using Azylee.Core.DrawingUtils.ImageUtils;
using Azylee.Core.IOUtils.DirUtils;
using Azylee.Core.WindowsUtils.APIUtils.WallpaperUtils;
using Azylee.YeahWeb.HttpUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test.ImageToolTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Azylee.YeahWeb.ExtWebAPI.BingWebAPI.WallpaperUtils.WallpaperTool.GetLast10Days();

           List<string> file_list = new List<string>();
            var md = Azylee.YeahWeb.ExtWebAPI.BingWebAPI.WallpaperUtils.WallpaperTool.GetToday();
            var md2 = Azylee.YeahWeb.ExtWebAPI.BingWebAPI.WallpaperUtils.WallpaperTool.GetYesterday();

            if (md != null && Ls.Ok(md.images))
            {
                foreach (var item in md.images)
                {
                    string image_url = item.GetImageUrl();
                    string file_path = DirTool.Combine(@"F:\imgs", item.hsh + ".jpg");
                    bool down_result = HttpTool.Download(image_url, file_path);
                    if (down_result) file_list.Add(file_path);
                }
            }
            //string a = WallpaperTool.Get();

            //bool b = WallpaperTool.Set(@"C:\Users\yuzhengyang\Pictures\\cc.jpg");

            //Bitmap b1 = new Bitmap(@"F:\图片压缩测试\未标题-1.jpg");
            //byte[] b1_byte = IMG.Compression(b1, 30);
            //File.WriteAllBytes(@"F:\图片压缩测试\未标题-1（Compression）.jpg", b1_byte);
        }
    }
}
