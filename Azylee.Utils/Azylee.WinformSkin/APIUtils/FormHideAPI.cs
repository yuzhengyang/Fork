using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Azylee.WinformSkin.APIUtils
{
    public class FormHideAPI
    {
        [DllImport("user32.dll")]
        private static extern Int32 GetWindowLong(IntPtr hwnd, Int32 index);
        [DllImport("user32.dll")]
        private static extern Int32 SetWindowLong(IntPtr hwnd, Int32 index, Int32 newValue);

        private const int GWL_EXSTYLE = (-20);
        private const int WS_EX_APPWINDOW = 0x00040000;
        private const int WS_EX_TOOLWINDOW = 0x00000080;

        public static bool HideTabAltMenu(IntPtr hwnd)
        {
            bool result = true;
            int exStyle = GetWindowLong(hwnd, GWL_EXSTYLE);
            if (exStyle == 0)
            {
                result = false;
            }
            else
            {
                exStyle = exStyle & (~WS_EX_APPWINDOW);
                exStyle = exStyle | WS_EX_TOOLWINDOW;
                if (0 == SetWindowLong(hwnd, GWL_EXSTYLE, exStyle))
                {
                    result = false;
                }
            }
            return result;
        }
    }
}
