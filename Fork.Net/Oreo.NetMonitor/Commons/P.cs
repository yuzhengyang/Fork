using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.Utils.IOUtils.LogUtils;

namespace Oreo.NetMonitor.Commons
{
    public static class P
    {
        public static void Init()
        {
            InitLog();
        }

        static void InitLog()
        {
            R.Log = new Log();
            R.Log.IsWriteFile = true;
            R.Log.LogLevel = LogLevel.All;
            Log.AllocConsole();
        }
    }
}
