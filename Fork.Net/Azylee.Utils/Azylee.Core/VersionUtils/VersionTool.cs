using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Azylee.Core.VersionUtils
{
    public class VersionTool
    {
        public static Version Format(string s)
        {
            //解析最新版本号
            Version version = null;
            try
            {
                version = new Version(s);
            }
            catch (Exception e) { }
            return version;
        }
        public static Version GetVersion(string appFile)
        {
            try
            {
                FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(appFile);
                return Format(fileVersionInfo.FileVersion);
            }
            catch
            {
                return null;
            }
        }
    }
}
