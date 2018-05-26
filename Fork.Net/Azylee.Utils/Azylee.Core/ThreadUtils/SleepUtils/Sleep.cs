using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.Core.ThreadUtils.SleepUtils
{
    public static class Sleep
    {
        /// <summary>
        /// Sleep（单位：秒）
        /// </summary>
        public static void S(short s)
        {
            SleepTool.Zs(s);
        }
        /// <summary>
        /// Sleep（单位：分）
        /// </summary>
        public static void M(short m)
        {
            SleepTool.Zm(m);
        }
    }
}
