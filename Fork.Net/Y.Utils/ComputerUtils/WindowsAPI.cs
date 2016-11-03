using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Y.Utils.ComputerUtils
{
    public class WindowsAPI
    {
        #region 系统空闲时间
        #region 捕获时间结构体
        [StructLayout(LayoutKind.Sequential)]
        struct LASTINPUTINFO
        {
            // 设置结构体块容量  
            [MarshalAs(UnmanagedType.U4)]
            public int cbSize;
            // 捕获的时间  
            [MarshalAs(UnmanagedType.U4)]
            public uint dwTime;
        }
        #endregion
        [DllImport("user32.dll")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);
        /// <summary>
        /// 获取计算机无操作时间
        /// </summary>
        /// <returns></returns>
        public static long GetLastInputTime()
        {
            LASTINPUTINFO vLastInputInfo = new LASTINPUTINFO();
            vLastInputInfo.cbSize = Marshal.SizeOf(vLastInputInfo);
            // 捕获时间  
            if (!GetLastInputInfo(ref vLastInputInfo))
                return 0;
            else
                return Environment.TickCount - (long)vLastInputInfo.dwTime;
        }
        #endregion

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
    }
}
