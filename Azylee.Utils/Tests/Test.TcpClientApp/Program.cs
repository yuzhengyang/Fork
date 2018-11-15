using Azylee.Core.WindowsUtils.CMDUtils;
using Azylee.Jsons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test.TcpClientApp
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            byte[] bt = Json.Object2Byte("测试 Json Byte 转换");
            string __bt = Json.Byte2Object<string>(bt);

            byte[] a = Encoding.UTF8.GetBytes("张无忌");
            string __a = Encoding.UTF8.GetString(a);
            byte[] b = Encoding.Unicode.GetBytes("张无忌");
            string __b = Encoding.Unicode.GetString(b);

            byte[] c = Encoding.UTF8.GetBytes("ぬゆまほㅙㅚЪЖ");
            string __c = Encoding.UTF8.GetString(c);
            byte[] d = Encoding.Unicode.GetBytes("ぬゆまほㅙㅚЪЖ");
            string __d = Encoding.Unicode.GetString(d);


            List<int> ports = CMDNetstatTool.GetAvailablePorts(10);


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
