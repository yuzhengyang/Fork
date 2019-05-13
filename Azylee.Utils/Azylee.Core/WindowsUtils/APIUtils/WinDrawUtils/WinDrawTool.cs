using Azylee.Core.DataUtils.StringUtils;
using System;
using System.Drawing;
using System.IO;

namespace Azylee.Core.WindowsUtils.APIUtils.WinDrawUtils
{
    /// <summary>
    /// 桌面绘制工具
    /// </summary>
    public static class WindowsDrawTool
    {
        /// <summary>
        /// 将图片绘制到桌面上
        /// </summary>
        /// <param name="file"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static void Paint(string file, int x, int y, int width, int height)
        {
            try
            {
                Image image = null;
                if (Str.Ok(file) && File.Exists(file)) image = Image.FromFile(file);
                if (image != null) Paint(image, x, y, width, height);
            }
            catch { }
        }
        /// <summary>
        /// 将图片绘制到桌面上
        /// </summary>
        /// <param name="image"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static void Paint(Image image, int x, int y, int width, int height)
        {
            IntPtr workerw = IntPtr.Zero;
            WindowsDrawAPI.EnumWindows(new WindowsDrawAPI.EnumWindowsProc((tophandle, topparamhandle) =>
            {
                IntPtr p = WindowsDrawAPI.FindWindowEx(tophandle, IntPtr.Zero, "SHELLDLL_DefView", IntPtr.Zero);
                if (p != IntPtr.Zero) workerw = WindowsDrawAPI.FindWindowEx(IntPtr.Zero, tophandle, "WorkerW", IntPtr.Zero);

                return true;
            }), IntPtr.Zero);

            IntPtr dc = WindowsDrawAPI.GetDCEx(workerw, IntPtr.Zero, (WindowsDrawAPI.DeviceContextValues)0x403);
            if (dc != IntPtr.Zero)
            {
                using (Graphics g = Graphics.FromHdc(dc))
                {
                    g.DrawImage(image, x, y, width, height);
                }
                WindowsDrawAPI.ReleaseDC(workerw, dc);
            }
        }
    }
}
