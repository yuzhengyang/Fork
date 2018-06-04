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

        public static bool TryGetNextValue(PerformanceCounter p, out float value)
        {
            value = 0;
            try
            {
                if (p != null)
                {
                    value = p.NextValue();
                    return true;
                }
                return false;//性能计数器为空，返回失败
            }
            catch
            {
                return false;//异常，返回失败
            }
        }
    }
}
