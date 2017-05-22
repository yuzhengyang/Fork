using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Y.Utils.NetUtils.NetDiagnoseUtils
{
    public class NetflowTool
    {
        public static PerformanceCounterCategory performanceCounterCategory = new PerformanceCounterCategory("Network Interface");
        public static string[] instances = performanceCounterCategory.GetInstanceNames();
    }
}
