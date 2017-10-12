using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Y.Utils.AppUtils;
using Y.Utils.IOUtils.PathUtils;

namespace AppSettle.Test
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //string path = DirTool.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "AppSettle.Test");
            //Dictionary<string, string> list = new Dictionary<string, string>();
            //list.Add(Application.ExecutablePath, DirTool.Combine(path, Path.GetFileName(Application.ExecutablePath)));
            //bool flag = AppSettleTool.Settle(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), list);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
