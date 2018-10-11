using Azylee.Core.DataUtils.CollectionUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.Core.WindowsUtils.ConsoleUtils
{
    /// <summary>
    /// 控制台输出工具
    /// </summary>
    public static class Cons
    {
        const string LOG_FORMAT = "{0}  {1}  ";
        const string TIME_FORMAT = "HH:mm:ss.fff";
        /// <summary>
        /// 输出换行内容（advanced 高级版）
        /// </summary>
        /// <param name="value">内容</param>
        /// <param name="mode">文字颜色</param>
        public static void Log(string value, ConsColorMode mode = ConsColorMode.Default)
        {
            ConsoleColor headcolor = ConsoleColor.White, headbgcolor = ConsoleColor.DarkRed;
            ConsoleColor bodycolor = ConsoleColor.White, bodybgcolor = ConsoleColor.DarkRed;
            #region 设置内容颜色，格式化内容
            switch (mode)
            {
                case ConsColorMode.Default: bodycolor = ConsoleColor.Gray; bodybgcolor = ConsoleColor.Black; break;
                case ConsColorMode.Muted: bodycolor = ConsoleColor.Gray; bodybgcolor = ConsoleColor.DarkGray; break;
                case ConsColorMode.Primary: bodycolor = ConsoleColor.White; bodybgcolor = ConsoleColor.DarkGray; break;
                case ConsColorMode.Secondary: bodycolor = ConsoleColor.Cyan; bodybgcolor = ConsoleColor.DarkGray; break;
                case ConsColorMode.Success: bodycolor = ConsoleColor.Green; bodybgcolor = ConsoleColor.DarkGray; break;
                case ConsColorMode.Info: bodycolor = ConsoleColor.Blue; bodybgcolor = ConsoleColor.DarkGray; break;
                case ConsColorMode.Warning: bodycolor = ConsoleColor.Yellow; bodybgcolor = ConsoleColor.DarkGray; break;
                case ConsColorMode.Danger: bodycolor = ConsoleColor.Red; bodybgcolor = ConsoleColor.DarkGray; break;
                case ConsColorMode.Dark: bodycolor = ConsoleColor.White; bodybgcolor = ConsoleColor.Black; break;
                case ConsColorMode.Light: bodycolor = ConsoleColor.Black; bodybgcolor = ConsoleColor.White; break;
            }
            try
            {
                //string[] lines = value.Split(new[] { "\r", "\n", "\r\n", "\n\r", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                //value = String.Join<string>($"{Environment.NewLine}{new string(' ', 18)}└", lines);
            }
            catch { }
            #endregion


            #region 输出内容
            SetColor(headcolor, headbgcolor);
            Write(string.Format(LOG_FORMAT, DateTime.Now.ToString(TIME_FORMAT), ">"));

            SetColor(bodycolor, bodybgcolor);
            Write(value);
            WriteLine("");

            ResetColor();
            #endregion
        }


        /// <summary>
        /// 输出内容
        /// </summary>
        /// <param name="value">内容</param>
        /// <param name="color">文字颜色</param>
        /// <param name="bgcolor">背景颜色</param>
        public static void Write(string value)
        {
            try { Console.Write(value); } catch { }
        }
        /// <summary>
        /// 输出换行内容
        /// </summary>
        /// <param name="value">内容</param>
        /// <param name="color">文字颜色</param>
        /// <param name="bgcolor">背景颜色</param>
        public static void WriteLine(string value)
        {
            try { Console.WriteLine(value); } catch { }
        }

        public static void SetColor(ConsoleColor color, ConsoleColor bgcolor)
        {
            try
            {
                Console.ForegroundColor = color;
                Console.BackgroundColor = bgcolor;
            }
            catch { }
        }
        public static void ResetColor()
        {
            try
            {
                Console.ResetColor();
            }
            catch { }
        }
    }
}
