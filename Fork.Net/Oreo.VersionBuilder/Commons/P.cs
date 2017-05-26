
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.Utils.IOUtils.LogUtils;

namespace Oreo.VersionBuilder.Commons
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
            R.Log.SetWriteFile(true, "Oreo.CleverDog.Log");
            R.Log.LogLevel = LogLevel.All;
        }
    }
}
