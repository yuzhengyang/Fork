using Azylee.Core.AppUtils;
using Azylee.Core.WindowsUtils.APIUtils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace Test.RaiseOtherApp
{
    static class Program
    {
        public static AppUnique AppUnique = new AppUnique();
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //如果程序已启动
            if (!AppUnique.IsUnique("appppppppppp"))
            {
                //唤起已启动的程序窗口
                ApplicationAPI.Raise(Process.GetCurrentProcess());
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
