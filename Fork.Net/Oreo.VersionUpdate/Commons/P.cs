using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.Utils.IOUtils.LogUtils;

namespace Oreo.VersionUpdate.Commons
{
    public static class P
    {
        public static void Init()
        {
            InitLog();
        }

        static void InitLog()
        { 
            R.Log.SetWriteFile(true, "Oreo.CleverDog.Log");
            R.Log.LogLevel = LogLevel.All;
        }
    }
}
