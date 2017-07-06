using Oreo.FileMan.Commons;
using Oreo.FileMan.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Y.Utils.AppUtils;
using Y.Utils.IOUtils.LogUtils;

namespace Oreo.FileMan
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (AppUnique.IsUnique("Oreo.FileMan"))
            {
                R.Log = new Log(true, "Oreo.FileMan.Log");
                Log.AllocConsole();

                R.Services.FBS.Start();

                R.Log.i("App is Runing...");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
        }
    }
}
