using Azylee.Core.LogUtils.SimpleLogUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Oreo.BigBirdDeployer.Commons
{
    public static partial class R
    {
        internal static string AppName = "Oreo.BigBirdDeployer";
        internal static DateTime StartTime = DateTime.Now;
        internal static string MachineName = Environment.MachineName;
        internal static Module Module = Assembly.GetExecutingAssembly().GetModules()[0];
        internal static Log Log { get; set; }
        internal static string AesKey = "12345678901234567890123456789012";
    }
}
