using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Y.Utils.IOUtils.LogUtils;

namespace Oreo.VersionBuilder.Commons
{
    public static class R
    {
        internal static string AppName = "Oreo.VersionBuilder";
        internal static DateTime StartTime = DateTime.Now;
        internal static string MachineName = Environment.MachineName;
        internal static Module Module = Assembly.GetExecutingAssembly().GetModules()[0];
        internal static Log Log { get; set; }
        internal static string AesKey = "yuzhengyangyuzhengyang0000000000";

        public static class Paths
        {
            public static string App = AppDomain.CurrentDomain.BaseDirectory;
            public static string VersionFile = App + "VersionFile\\";
        }
        public static class Files
        {
            public static string App = Application.ExecutablePath;
        }
    }
}
