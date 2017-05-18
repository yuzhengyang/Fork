using Oreo.CleverDog.Commons;
using Oreo.CleverDog.Helpers;
using Oreo.CleverDog.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Y.Utils.AppUtils;
using Y.Utils.DataUtils.EncryptUtils;

namespace Oreo.CleverDog
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (AppUnique.IsUnique("Oreo.NetMonitor"))
            {
                if (File.Exists(R.Files.Frisbee))
                {
                    Settings.Init();
                    P.Init();
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new MainForm());
                }
            }
        }
    }
}
