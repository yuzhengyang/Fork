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
        /// 伪精准Sleep（单位：秒）
        /// </summary>
        public static void Z(int second)
        {
            if (second > 0)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                int ms = second * 900;
                Thread.Sleep(ms);
                sw.Stop();

                ms = second * 100;
                Thread.Sleep(ms);
            }
            else
            {
                Thread.Sleep(1000);
            }
        }
    }
}
