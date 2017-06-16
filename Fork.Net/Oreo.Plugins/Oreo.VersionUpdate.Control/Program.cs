using Oreo.VersionUpdate.Commons;
using Oreo.VersionUpdate.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Y.Utils.DataUtils.Collections;

namespace Oreo.VersionUpdate
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (ListTool.HasElements(args))
            {
                if (args.Length > 0) R.Paths.ProjectRoot = args[0];
                if (args.Length > 1) R.Files.Plugins = args[1];
                if (args.Length > 2) R.Files.CloseAndStart = args[2];
            }
            P.Init();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
