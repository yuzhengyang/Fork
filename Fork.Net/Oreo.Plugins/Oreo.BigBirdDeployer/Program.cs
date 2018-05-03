using Azylee.Core.AppUtils;
using Azylee.Core.ProcessUtils;
using Oreo.BigBirdDeployer.Utils;
using Oreo.BigBirdDeployer.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace Oreo.BigBirdDeployer
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
