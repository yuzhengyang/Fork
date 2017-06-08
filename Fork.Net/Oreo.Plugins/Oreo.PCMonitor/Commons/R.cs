using Oreo.PCMonitor.Services;
using System;
using Y.Utils.IOUtils.LogUtils;

namespace Oreo.PCMonitor.Commons
{
    public static class R
    {
        public static Log Log { get; set; }
        public static NetFlowService NFS { get; set; }

        public static class Files { }
        public static class Paths
        {
            public static string BasePath = AppDomain.CurrentDomain.BaseDirectory;
        }
        public static class Servers
        {
            public static string ConfigIP = "192.168.3.52";
            public static int ConfigPort = 8080;
        }
    }
}
