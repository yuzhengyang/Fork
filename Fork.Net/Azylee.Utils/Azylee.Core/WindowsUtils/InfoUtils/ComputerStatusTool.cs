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
        /// 获取 Processor（可获取CPU使用率）
        /// </summary>
        /// <returns></returns>
        public static PerformanceCounter Processor()
        {
            PerformanceCounter processor = null;
            try
            {
                processor = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            }
            catch { }
            return processor;
        }
    }
}
