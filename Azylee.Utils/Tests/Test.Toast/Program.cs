using Azylee.Core.LogUtils.StatusLogUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test.Toast
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

            StatusLog.Instance.Start();//启动计算机状态日志记录
            StatusLog.Instance.SetCacheDays(10);//保存最近10天的状态日志信息

            Application.Run(new Form1());
        }
    }
}
