using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace Azylee.Core.ThreadUtils.SleepUtils
{
    public static class SleepTool
    {
        /// <summary>
        /// Sleep（单位：秒）
        /// </summary>
        public static void Zs(short s = 1)
        {
            try { Thread.Sleep(s * 1000); } catch { }
        }
        /// <summary>
        /// Sleep（单位：分）
        /// </summary>
        public static void Zm(short m = 1)
        {
            try { Thread.Sleep(m * 60 * 1000); } catch { }
        }
    }
}
