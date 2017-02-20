using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace Y.Utils.WindowsAPI
{
    public class WindowInfo
    {
        #region Windows 窗口操作
        /// <summary>
        /// 获取当前窗口句柄
        /// </summary>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow();
        /// <summary>
        /// 显示窗口
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="nCmdShow">0关闭 1正常显示 2最小化 3最大化</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);
        /// <summary>
        /// 获取窗口大小
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lpRect"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);
        #region 窗口大小结构体
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left; //最左坐标
            public int Top; //最上坐标
            public int Right; //最右坐标
            public int Bottom; //最下坐标
        }
        #endregion
        /// <summary>
        /// 获取窗口所在进程ID
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="pid"></param>
        /// <returns></returns>
        [DllImport("user32", EntryPoint = "GetWindowThreadProcessId")]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int pid);
        /// <summary>
        /// 获取窗体标题
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lpString"></param>
        /// <param name="nMaxCount"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public extern static int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
        [DllImport("user32.dll")]
        public static extern int GetWindowTextLength(IntPtr hWnd);
        #endregion

        /// <summary>
        /// 当前窗口标题
        /// </summary>
        /// <returns></returns>
        public static string GetNowWindowName()
        {
            StringBuilder windowName = new StringBuilder(GetWindowTextLength(GetForegroundWindow()) + 1);
            GetWindowText(GetForegroundWindow(), windowName, windowName.Capacity);
            return windowName.ToString() ?? "";
        }
        /// <summary>
        /// 当前窗口进程名
        /// </summary>
        /// <returns></returns>
        public static string GetNowProcessName()
        {
            int windowPid = 0;
            GetWindowThreadProcessId(GetForegroundWindow(), out windowPid);
            string processName = Process.GetProcessById(windowPid).ProcessName;
            return processName ?? "";
        }
    }
}
