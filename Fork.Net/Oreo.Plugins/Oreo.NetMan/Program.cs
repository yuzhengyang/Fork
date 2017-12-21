using Oreo.NetMan.Commons;
using Oreo.NetMan.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Y.Utils.AppUtils;

namespace Oreo.NetMan
{
    static class Program
    {
        static AppUnique AppUnique = new AppUnique();
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        { 
            if (AppUnique.IsUnique("Oreo.NetMan"))
            {
                P.Init();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new NetDetailForm());
            }
        }
    }
}
