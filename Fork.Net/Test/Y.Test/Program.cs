using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Y.Test.Commons;
using Y.Test.Views;
using Y.Utils.IOUtils.FileUtils;
using Y.Utils.IOUtils.PathUtils;

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
