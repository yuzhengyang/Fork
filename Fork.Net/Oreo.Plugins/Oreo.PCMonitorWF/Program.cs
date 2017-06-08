using Oreo.PCMonitor.Commons;
using Oreo.PCMonitor.Views;
using System;
using System.Windows.Forms;
using Y.Utils.AppUtils;

namespace Oreo.PCMonitor
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (AppUnique.IsUnique("Oreo.PCMonitor"))
            {
                //Settings.Init();
                P.Init();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            } 
        }
    }
}
