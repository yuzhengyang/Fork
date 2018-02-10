using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Azylee.WinformSkin.APIUtils
{
    public class FormAnimateAPI
    {
        /// <summary>
        /// 窗体动画函数
        /// </summary>
        /// <param name="hwnd">指定产生动画的窗口的句柄</param>
        /// <param name="dwTime">指定动画持续的时间</param>
        /// <param name="dwFlags">指定动画类型，可以是一个或多个标志的组合。</param>
        /// <returns></returns>
        [DllImport("user32")]
        public static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);

        /// <summary>
        /// 自左向右显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        /// </summary>
        public static int AW_HOR_POSITIVE { get { return 0x0001; } }
        /// <summary>
        /// 自右向左显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        /// </summary>
        public static int AW_HOR_NEGATIVE { get { return 0x0002; } }
        /// <summary>
        /// 自顶向下显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        /// </summary>
        public static int AW_VER_POSITIVE { get { return 0x0004; } }
        /// <summary>
        /// 自下向上显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志该标志
        /// </summary>
        public static int AW_VER_NEGATIVE { get { return 0x0008; } }
        /// <summary>
        /// 若使用了AW_HIDE标志，则使窗口向内重叠；否则向外扩展
        /// </summary>
        public static int AW_CENTER { get { return 0x0010; } }
        /// <summary>
        /// 隐藏窗口
        /// </summary>
        public static int AW_HIDE { get { return 0x10000; } }
        /// <summary>
        /// 激活窗口，在使用了AW_HIDE标志后不要使用这个标志
        /// </summary>
        public static int AW_ACTIVE { get { return 0x20000; } }
        /// <summary>
        /// 使用滑动类型动画效果，默认为滚动动画类型，当使用AW_CENTER标志时，这个标志就被忽略
        /// </summary>
        public static int AW_SLIDE { get { return 0x40000; } }
        /// <summary>
        /// 使用淡入淡出效果
        /// </summary>
        public static int AW_BLEND { get { return 0x80000; } }
    }
}
