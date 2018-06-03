//************************************************************************
//      author:     yuzhengyang
//      date:       2018.3.27 - 2018.6.3
//      desc:       工具描述
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************
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
            Thread.Sleep(s * 1000);
        }
        /// <summary>
        /// Sleep（单位：分）
        /// </summary>
        public static void Zm(short m = 1)
        {
            Thread.Sleep(m * 60 * 1000);
        }
    }
}
