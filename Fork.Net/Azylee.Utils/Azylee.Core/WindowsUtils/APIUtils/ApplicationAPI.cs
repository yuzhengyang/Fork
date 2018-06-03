//************************************************************************
//      author:     yuzhengyang
//      date:       2018.3.27 - 2018.3.27
//      desc:       工具描述
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Azylee.Core.WindowsUtils.APIUtils
{
    /// <summary>
    /// 应用程序API
    /// </summary>
    public static class ApplicationAPI
    {
        #region 常量
        private const int SW_RESTORE = 9;
        #endregion

        #region dll方法声明
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        private static extern bool IsIconic(IntPtr hWnd);
        #endregion

        /// <summary>
        /// 唤起进程窗口（搭配 AppUnique.IsUnique() 食用更佳）
        /// -测试无法唤起隐藏窗口，仅能唤起常规窗口
        /// </summary>
        public static void Raise(Process process, bool all = false)
        {
            Process.GetProcesses();
            foreach (Process otherProc in Process.GetProcessesByName(process.ProcessName))
            {
                //ignore "this" process
                if (process.Id != otherProc.Id)
                {
                    // Found a "same named process".
                    // Assume it is the one we want brought to the foreground.
                    // Use the Win32 API to bring it to the foreground.
                    IntPtr hWnd = otherProc.MainWindowHandle;
                    if (IsIconic(hWnd))
                    {
                        ShowWindowAsync(hWnd, 9);
                    }
                    SetForegroundWindow(hWnd);
                    if (!all) break;//搜索并唤起一个程序则终止
                }
            }
        }
    }
}
