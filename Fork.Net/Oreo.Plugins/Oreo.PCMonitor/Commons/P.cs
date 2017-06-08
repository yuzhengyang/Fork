using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.Utils.IOUtils.LogUtils;

namespace Oreo.PCMonitor.Commons
{
    public static class P
    {
        public static void Init()
        {
            InitLog();
            InitNFS();
        }

        static void InitLog()
        {
            R.Log = new Log();
            R.Log.SetWriteFile(true, "Oreo.PCMonitor.Log");
            R.Log.LogLevel = LogLevel.All;
            //Log.AllocConsole();
        }
        static void InitNFS()
        {
            R.NFS = new Services.NetFlowService();
            R.NFS.Start();
        }
    }
}
