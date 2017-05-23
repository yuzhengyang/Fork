using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.Utils.IOUtils.LogUtils;

namespace Oreo.NetMonitor.Commons
{
    public static class R
    {
        public static Log Log { get; set; }
        public static class Files { }
        public static class Paths
        {
            public static string BasePath = AppDomain.CurrentDomain.BaseDirectory;
        }
        public static class Settings
        {
            public static double FlowThreshold { get; set; }
            public static int ThresholdTime { get; set; }
            public static int MaxProConnect { get; set; }
            public static int RecProConnect { get; set; }
        }
        public static class Servers
        {
            public static string ConfigIP = "192.168.3.52";
            public static int ConfigPort = 8080;
        }
    }
}
