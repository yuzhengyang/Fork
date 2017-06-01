using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.Utils.IOUtils.LogUtils;
using Y.Utils.IOUtils.TxtUtils;

namespace Oreo.VersionUpdate.Commons
{
    public static class P
    {
        public static void Init()
        {
            InitSettings();

            InitLog();
        }
        static void InitSettings()
        {
            R.LogLevel = (LogLevel)IniTool.GetIntValue(R.Files.Settings, "Log", "Level");
        }
        static void InitLog()
        {
            R.Log.SetWriteFile(true, "Oreo.VersionUpdate.Log");
            R.Log.LogLevel = R.LogLevel;
        }
       
    }
}
