using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Version.Update.Commons
{
    public static class R
    {
        public static bool Release = false;
        public static string AppName = "Version.Update";
        public static string AppPath = AppDomain.CurrentDomain.BaseDirectory;
        public static string AppFile = Process.GetCurrentProcess().MainModule.FileName;

        public static DateTime StartTime = DateTime.Now;
        public static string MachineName = Environment.MachineName;
        public static Module Module = Assembly.GetExecutingAssembly().GetModules()[0];

        public static string VersionFile = Path.Combine(AppPath, "update.version");
        public static string FtpIp = "192.168.3.56";
        public static string FtpAccount = "Administrator";
        public static string FtpPassword = "yuzhengyang";

        public static class cst
        {
            public const string FILE_SUCC = "√";
            public const string FILE_FAIL = "×";
            public const string FILE_JUMP = "-";
            public const int WAIT_TIME = 50;
            public const int STEP_WAIT_TIME = 1000;
        }
    }
}
