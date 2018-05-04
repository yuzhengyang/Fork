using Azylee.Core.IOUtils.DirUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oreo.BigBirdDeployer.Commons
{
    public static partial class R
    {
        public static class Paths
        {
            public static string App = AppDomain.CurrentDomain.BaseDirectory;
            public static string Storage = DirTool.Combine(App, "Storage");
            public static string Temp = DirTool.Combine(App, "Temp");
        }
    }
}
