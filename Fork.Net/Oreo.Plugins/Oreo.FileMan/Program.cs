using Oreo.FileMan.Commons;
using Oreo.FileMan.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Y.Utils.AppUtils;

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
                R.Services.FBS.Start();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
        }
    }
}
