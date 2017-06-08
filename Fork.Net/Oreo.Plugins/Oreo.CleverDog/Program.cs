using Oreo.CleverDog.Commons;
using Oreo.CleverDog.Helpers;
using Oreo.CleverDog.Models;
using Oreo.CleverDog.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Y.Utils.AppUtils;
using Y.Utils.DataUtils.EncryptUtils;
using Y.Utils.DataUtils.JsonUtils;
using Y.Utils.IOUtils.TxtUtils;
using Y.Utils.NetUtils.HttpUtils;
using Y.Utils.WindowsUtils.ProcessUtils;

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
            if (AppUnique.IsUnique("Oreo.CleverDog"))
            {
                P.Init();
                Settings.Init();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //Application.Run(new MainForm());
                Thread.Sleep(1000);
                FrisbeeHelper.Fire();
            }
        }
    }
}
