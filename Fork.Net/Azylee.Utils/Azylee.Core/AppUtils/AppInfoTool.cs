//************************************************************************
//      author:     yuzhengyang
//      date:       2018.3.27 - 2018.6.3
//      desc:       工具描述
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************
using Azylee.Core.ProcessUtils;
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
        /// 读取APP Processor（可读取App的CPU使用率）
        /// </summary>
        /// <returns></returns>
        [Obsolete]
        public static PerformanceCounter Processor()
        {
            Process p = null;
            PerformanceCounter processor = null;
            try
            {
                p = Process.GetCurrentProcess();
                processor = new PerformanceCounter("Process", "% Processor Time", p.ProcessName);
            }
            catch { }
            return processor;
        }
        /// <summary>
        /// 读取进程CPU使用率（同名进程无法支持）
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [Obsolete]
        public static PerformanceCounter Processor(Process p)
        {
            PerformanceCounter processor = null;
            try
            {
                string name = ProcessTool.GetInstanceNameById(p.Id);
                if (!string.IsNullOrWhiteSpace(name))
                {
                    processor = new PerformanceCounter("Process", "% Processor Time", name);
                }
            }
            catch { }
            return processor;
        }
        /// <summary>
        /// 计算CPU占用率
        /// </summary>
        /// <param name="process"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="interval"></param>
        /// <returns></returns>
        [Obsolete]
        public static double CalcCpuRate(Process process, TimeSpan begin, int interval)
        {
            double value = 0;
            try
            {
                //当前时间
                var current = process.TotalProcessorTime;
                //间隔时间内的CPU运行时间除以逻辑CPU数量
                var minus = current - begin;
                value = minus.TotalMilliseconds / Environment.ProcessorCount / interval * 100;
            }
            catch { }

            if (value < 0) return 0;
            if (100 < value) return 100;
            return value;
        }
        /// <summary>
        /// 计算CPU占用率（自动刷新TimeSpan）
        /// </summary>
        /// <param name="process"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="interval"></param>
        /// <returns></returns>
        public static double CalcCpuRate(Process process, ref TimeSpan begin, int interval)
        {
            double value = 0;
            try
            {
                //当前时间
                var current = process.TotalProcessorTime;
                //间隔时间内的CPU运行时间除以逻辑CPU数量
                var minus = current - begin;
                value = minus.TotalMilliseconds / Environment.ProcessorCount / interval * 100;

                begin = process.TotalProcessorTime;
            }
            catch { }

            if (value < 0) return 0;
            if (100 < value) return 100;
            return value;
        }
        /// <summary>
        /// 读取APP占用内存（单位：KB）
        /// </summary>
        /// <returns></returns>
        public static long RAM()
        {
            long value = 0;
            Process p = null;
            try
            {
                p = Process.GetCurrentProcess();
                value = p.WorkingSet64 / 1024;
            }
            catch { }
            finally { p?.Dispose(); }
            return value;
        }
        public static long RAM(int id)
        {
            long value = 0;
            Process p = null;
            try
            {
                p = Process.GetProcessById(id);
                value = p.WorkingSet64 / 1024;
            }
            catch { }
            finally { p?.Dispose(); }
            return value;
        }
    }
}
