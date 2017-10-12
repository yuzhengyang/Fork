using System;
using System.Collections.Generic;
using Y.Utils.IOUtils.PathUtils;
using Y.Utils.WindowsUtils.FormUtils;

namespace Y.Test.Commons
{
    public static class R
    {
        public static class Paths
        {
            public static string Temp = @"D:\Temp\AppUpdate\Oreo.NetMan\Temp";
            //public static Dictionary<string, string> Relative = new Dictionary<string, string>()
            //{
            //    { "|AppRoot|",@"D:\Temp\AppUpdate\Oreo.NetMan"},
            //};
            public static string App = AppDomain.CurrentDomain.BaseDirectory;
            public static Dictionary<string, string> Relative = new Dictionary<string, string>()
            {
                { "|AppRoot|",DirTool.GetFilePath(App)},
            };
        }
        public static FormManTool Forms = new FormManTool();

    }
}
