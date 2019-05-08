using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Azylee.Core.WindowsUtils.APIUtils.WallpaperUtils
{
    /// <summary>
    /// 系统桌面壁纸工具类
    /// </summary>
    public static class WallpaperTool
    {
        #region 获取windows桌面背景        
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int SystemParametersInfo(int uAction, int uParam, StringBuilder lpvParam, int fuWinIni);
        private const int SPI_GETDESKWALLPAPER = 0x0073;
        #endregion
        #region 设置windows桌面背景
        [DllImport("user32.dll")]
        private static extern bool SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
        #endregion

        /// <summary>
        /// 获取当前桌面壁纸路径
        /// </summary>
        /// <returns></returns>
        public static string Get()
        {
            try
            {
                //定义存储缓冲区大小
                StringBuilder s = new StringBuilder(300);
                //获取Window 桌面背景图片地址，使用缓冲区
                SystemParametersInfo(SPI_GETDESKWALLPAPER, 300, s, 0);
                //缓冲区中字符进行转换
                return s.ToString(); //系统桌面背景图片路径
            }
            catch { return null; }
        }
        /// <summary>
        /// 设置当前桌面背景
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool Set(string path)
        {
            try
            {
                SystemParametersInfo(20, 0, path, 0x01 | 0x02);
                return true;
            }
            catch { return false; }
        }
    }
}
