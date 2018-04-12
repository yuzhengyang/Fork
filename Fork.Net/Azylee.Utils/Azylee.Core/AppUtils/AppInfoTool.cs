using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Azylee.Core.AppUtils
{
    public class AppInfoTool
    {
        /// <summary>
        /// 读取APP占用CPU
        /// </summary>
        /// <returns></returns>
        public static double CPU()
        {
            double value = 0;
            Process p = null;
            PerformanceCounter processor = null;
            try
            {
                p = Process.GetCurrentProcess();
                processor = new PerformanceCounter("Process", "% Processor Time", p.ProcessName);
                value = processor.NextValue();
            }
            catch { }
            finally
            {
                processor?.Dispose();
                p?.Dispose();
            }
            return value;
        }
        /// <summary>
        /// 读取APP占用内存
        /// </summary>
        /// <returns></returns>
        public static long RAM()
        {
            long value = 0;
            Process p = null;
            try
            {
                p = Process.GetCurrentProcess();
                value = p.WorkingSet64;
            }
            catch { }
            finally { p?.Dispose(); }
            return value;
        }
    }
}
