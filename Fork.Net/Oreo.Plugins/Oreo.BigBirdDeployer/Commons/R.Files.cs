using Azylee.Core.IOUtils.DirUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oreo.BigBirdDeployer.Commons
{
    public static partial class R
    {
        public static class Files
        {
            public static string Settings = DirTool.Combine(Paths.Settings, "Settings.ini");
        }
    }
}
