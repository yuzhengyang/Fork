using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Y.Utils.IOUtils.LogUtils;

namespace Oreo.VersionUpdate.Commons
{
    public class R
    {
        internal static string AppName = "Oreo.VersionUpdate";
        internal static DateTime StartTime = DateTime.Now;
        internal static string MachineName = Environment.MachineName;
        internal static Module Module = Assembly.GetExecutingAssembly().GetModules()[0];
        internal static string AesKey = "12345678901234567890123456789012";
        public static Log Log = new Log();
        public static LogLevel LogLevel = LogLevel.None;

        public static class Paths
        {
            public static string App = AppDomain.CurrentDomain.BaseDirectory;
            public static string ProjectRoot = @"C:\Noah\NoahSafe\\";
            public static string Temp = ProjectRoot + "Temp\\Update\\";
        }
        public static class Files
        {
            public static string App = Application.ExecutablePath;
            public static string Settings = Paths.App + "\\upd.ini";
            public static string Whatsnew = Paths.ProjectRoot + "\\Whatsnew.txt";
            public static string Plugins = Paths.ProjectRoot + @"Plugins.xml";
        }
        public static class Settings
        {
            public static class FTP
            {
                public static string Address = "192.168.3.56";
                public static string Account = "Administrator";
                public static string Password = "yuzhengyang";
            }
        }
    }
}
