using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Y.Test.Commons;
using Y.Test.Models;
using Y.Test.Views;
using Y.Utils.IOUtils.FileUtils;
using Y.Utils.IOUtils.PathUtils;
using Y.Utils.NetUtils.HttpUtils;

namespace Y.Test
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            string param = string.Format("id={0}&text={1}", "123123123", "123123123");
            //string rs = HttpTool.Post("http://localhost:20001/Data/Post", param);
            WebAPIMessageModel rs = HttpTool.Post<WebAPIMessageModel>("http://localhost:20001/Data/Post", param);

            //var a = DirTool.Parent(@"D:\Temp\流量测试\");
            //var b = DirTool.Parent(@"D:\Temp");
            //var c = DirTool.Parent(@"D:\");
            //var d = DirTool.Parent(@"\\\\");
            //FilePackageTool.Pack(@"D:\Temp\流量测试\Oreo.NetMan", @"D:\Temp\流量测试\bag.bag");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
