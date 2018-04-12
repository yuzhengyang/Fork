using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Azylee.Core.WindowsUtils.InfoUtils
{
    public class ComputerStatusTool
    {
        /// <summary>
        /// CPU占用率
        /// </summary>
        /// <returns></returns>
        public static double CpuUtilization()
        {
            double value = 0;
            PerformanceCounter processor = null;
            try
            {
                processor = new PerformanceCounter("Processor", "% Processor Time", "_Total");
                value = processor.NextValue();
            }
            catch { }
            finally { processor?.Dispose(); }
            return value;
        }
    }
}
