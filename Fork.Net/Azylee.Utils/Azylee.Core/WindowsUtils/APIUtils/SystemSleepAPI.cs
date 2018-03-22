//************************************************************************
//      https://github.com/yuzhengyang
//      author:     yuzhengyang
//      date:       2018.3.9 - 2018.3.9
//      desc:       工具描述
//      Copyright (c) yuzhengyang. All rights reserved.
//      Quote:https://www.cnblogs.com/TianFang/archive/2012/10/12/2721883.html
//************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Azylee.Core.WindowsUtils.APIUtils
{
    public class SystemSleepAPI
    {
        //定义API函数
        [DllImport("kernel32.dll")]
        static extern uint SetThreadExecutionState(ExecutionFlag flags);

        [Flags]
        enum ExecutionFlag : uint
        {
            System = 0x00000001,
            Display = 0x00000002,
            Continus = 0x80000000,
        }

        /// <summary>
        /// 阻止系统休眠
        /// </summary>
        /// <param name="screen">阻止息屏</param>
        public static void PreventSleep(bool screen = false)
        {
            try
            {
                if (screen)
                    SetThreadExecutionState(ExecutionFlag.System | ExecutionFlag.Display | ExecutionFlag.Continus);
                else
                    SetThreadExecutionState(ExecutionFlag.System | ExecutionFlag.Continus);
            }
            catch { }
        }

        /// <summary>
        /// 恢复系统休眠和息屏
        /// </summary>
        public static void ResotreSleep()
        {
            try { SetThreadExecutionState(ExecutionFlag.Continus); } catch { }
        }

        /// <summary>
        /// 重置系统休眠计时器
        /// </summary>
        /// <param name="screen">阻止息屏</param>
        public static void ResetSleepTimer(bool screen = false)
        {
            try
            {
                if (screen)
                    SetThreadExecutionState(ExecutionFlag.System | ExecutionFlag.Display);
                else
                    SetThreadExecutionState(ExecutionFlag.System);
            }
            catch { }
        }
    }
}
