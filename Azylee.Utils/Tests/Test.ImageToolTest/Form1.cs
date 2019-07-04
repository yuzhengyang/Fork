using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.Core.DataUtils.GuidUtils;
using Azylee.Core.DrawingUtils.ImageUtils;
using Azylee.Core.IOUtils.DirUtils;
using Azylee.Core.NetUtils;
using Azylee.Core.WindowsUtils.APIUtils.WallpaperUtils;
using Azylee.Core.WindowsUtils.CMDUtils;
using Azylee.YeahWeb.HttpUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;
using static Azylee.Core.NetUtils.NetProcessTool;

namespace Test.ImageToolTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var p = Process.GetProcessById(9090);

            DateTime f1clock = DateTime.Now;
            List<TcpConnectionInformation> f1 = null;
            for (int i = 0; i < 10; i++)
            {
                f1 = Fun1();
            }
            Console.WriteLine("fun1,time: " + (DateTime.Now - f1clock).TotalMilliseconds);


            DateTime f2clock = DateTime.Now;
            List<Tuple<int, int>> f2 = null;
            for (int i = 0; i < 10; i++)
            {
                f2 = Fun2();
            }
            Console.WriteLine("fun2,time: " + (DateTime.Now - f2clock).TotalMilliseconds);

            DateTime f3clock = DateTime.Now;
            TcpRow[] f3 = null;
            for (int i = 0; i < 10; i++)
            {
                f3 = Fun3();
            }
            Console.WriteLine("fun3,time: " + (DateTime.Now - f3clock).TotalMilliseconds);

        }

        private List<TcpConnectionInformation> Fun1()
        {
            List<TcpConnectionInformation> list = new List<TcpConnectionInformation>();
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            TcpConnectionInformation[] connections = properties.GetActiveTcpConnections();
            foreach (TcpConnectionInformation t in connections)
            {
                list.Add(t);
            }
            return list;
        }
        private List<Tuple<int, int>> Fun2()
        {
            List<Tuple<int, int>> list = CMDNetstatTool.Find(".");
            return list;
        }
        private TcpRow[] Fun3()
        {
            TcpRow[] list = NetProcessTool.GetTcps();
            return list;
        }
    }
}
