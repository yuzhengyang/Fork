//############################################################
//      https://github.com/yuzhengyang
//      author:yuzhengyang
//############################################################
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Azylee.Core.DrawingUtils.ImageUtils
{
    /// <summary>
    /// 屏幕捕获类
    /// </summary>
    public class ScreenCapture
    {
        /// <summary>
        /// Winform 屏幕截图
        /// </summary>
        /// <returns></returns>
        public static Bitmap Capture()
        {
            try
            {
                //屏幕宽
                int iWidth = Screen.PrimaryScreen.Bounds.Width;
                //屏幕高
                int iHeight = Screen.PrimaryScreen.Bounds.Height;
                //按照屏幕宽高创建位图
                Bitmap bitmap = new Bitmap(iWidth, iHeight);
                //从一个继承自Image类的对象中创建Graphics对象
                Graphics gc = Graphics.FromImage(bitmap);
                //抓屏并拷贝到myimage里
                gc.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(iWidth, iHeight));
                gc.Dispose();
                return bitmap;
            }
            catch { }
            return null;
        }

        #region gdi 屏幕截图
        /// <summary>
        /// 把当前屏幕捕获到位图对象中
        /// </summary>
        /// <param name="hdcDest">目标设备的句柄</param>
        /// <param name="nXDest">目标对象的左上角的X坐标</param>
        /// <param name="nYDest">目标对象的左上角的X坐标</param>
        /// <param name="nWidth">目标对象的矩形的宽度</param>
        /// <param name="nHeight">目标对象的矩形的长度</param>
        /// <param name="hdcSrc">源设备的句柄</param>
        /// <param name="nXSrc">源对象的左上角的X坐标</param>
        /// <param name="nYSrc">源对象的左上角的X坐标</param>
        /// <param name="dwRop">光栅的操作值</param>
        /// <returns></returns>
        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        private static extern bool BitBlt(
        IntPtr hdcDest,
        int nXDest,
        int nYDest,
        int nWidth,
        int nHeight,
        IntPtr hdcSrc,
        int nXSrc,
        int nYSrc,
        int dwRop
        );
        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        private static extern IntPtr CreateDC(
        string lpszDriver, // 驱动名称
        string lpszDevice, // 设备名称
        string lpszOutput, // 无用，可以设定位"NULL"
        IntPtr lpInitData // 任意的打印机数据
        );
        /// <summary>
        /// 屏幕捕获到位图对象中
        /// </summary>
        /// <returns></returns>
        public static Bitmap CaptureDC()
        {
            try
            {
                //创建显示器的DC
                IntPtr dc1 = CreateDC("DISPLAY", null, null, (IntPtr)null);
                //由一个指定设备的句柄创建一个新的Graphics对象
                Graphics g1 = Graphics.FromHdc(dc1);
                //根据屏幕大小创建一个与之相同大小的Bitmap对象
                Bitmap ScreenImage = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, g1);

                Graphics g2 = Graphics.FromImage(ScreenImage);
                //获得屏幕的句柄
                IntPtr dc3 = g1.GetHdc();
                //获得位图的句柄
                IntPtr dc2 = g2.GetHdc();
                //把当前屏幕捕获到位图对象中
                BitBlt(dc2, 0, 0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, dc3, 0, 0, 13369376);
                //释放屏幕句柄
                g1.ReleaseHdc(dc3);
                //释放位图句柄
                g2.ReleaseHdc(dc2);
                g1.Dispose();
                g2.Dispose();
                return ScreenImage;
            }
            catch { return null; }
        }
        [StructLayout(LayoutKind.Sequential)]
        struct CURSORINFO
        {
            public int cbSize;
            public int flags;
            public IntPtr hCursor;
            public Point ptScreenPos;
        }
        [DllImport("user32.dll")]
        static extern bool GetCursorInfo(out CURSORINFO pci);
        private const int CURSOR_SHOWING = 0x00000001;
        /// <summary>  
        /// 将鼠标指针形状绘制到屏幕截图上  
        /// </summary>  
        /// <param name="g"></param>  
        public static void DrawCursorImageToScreenImage(ref Graphics g)
        {
            CURSORINFO vCurosrInfo;
            vCurosrInfo.cbSize = Marshal.SizeOf(typeof(CURSORINFO));
            GetCursorInfo(out vCurosrInfo);
            if ((vCurosrInfo.flags & CURSOR_SHOWING) != CURSOR_SHOWING) return;
            Cursor vCursor = new Cursor(vCurosrInfo.hCursor);
            Rectangle vRectangle = new Rectangle(new Point(vCurosrInfo.ptScreenPos.X - vCursor.HotSpot.X, vCurosrInfo.ptScreenPos.Y - vCursor.HotSpot.Y), vCursor.Size);

            vCursor.Draw(g, vRectangle);
        }
        #endregion
    }
}
