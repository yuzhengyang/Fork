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
            int level = IniTool.GetIntValue(R.Files.Settings, "Log", "Level");
            R.LogLevel = (LogLevel)level;
        }
        static void InitLog()
        {
            R.Log.SetWriteFile(true, "Oreo.VersionUpdate.Log");
            R.Log.LogLevel = R.LogLevel;
        }

    }
}
