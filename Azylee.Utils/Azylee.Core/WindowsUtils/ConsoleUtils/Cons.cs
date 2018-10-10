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
        /// <summary>
        /// 输出换行内容（advanced 高级版）
        /// </summary>
        /// <param name="value">内容</param>
        /// <param name="mode">文字颜色</param>
        public static void A(string value, ConsColorMode mode = ConsColorMode.Default)
        {
            switch (mode)
            {
                case ConsColorMode.Default: Console.ResetColor(); break;
                case ConsColorMode.Muted: SetColor(ConsoleColor.Gray, ConsoleColor.DarkGray); break;
                case ConsColorMode.Primary: SetColor(ConsoleColor.Cyan, ConsoleColor.Black); break;
                case ConsColorMode.Secondary: SetColor(ConsoleColor.DarkCyan, ConsoleColor.Black); break;
                case ConsColorMode.Success: SetColor(ConsoleColor.Green, ConsoleColor.Black); break;
                case ConsColorMode.Info: SetColor(ConsoleColor.Blue, ConsoleColor.Black); break;
                case ConsColorMode.Warning: SetColor(ConsoleColor.Yellow, ConsoleColor.Black); break;
                case ConsColorMode.Danger: SetColor(ConsoleColor.Red, ConsoleColor.Black); break;
                case ConsColorMode.Dark: SetColor(ConsoleColor.DarkGray, ConsoleColor.Black); break;
                case ConsColorMode.Light: SetColor(ConsoleColor.Black, ConsoleColor.White); break;
            }
            Console.WriteLine(value);
            Console.ResetColor();
        }

        /// <summary>
        /// 输出换行内容（standard 标准版）
        /// </summary>
        /// <param name="value">内容</param>
        /// <param name="color">文字颜色</param>
        /// <param name="bgcolor">背景颜色</param>
        public static void S(string value, ConsoleColor color = ConsoleColor.White, ConsoleColor bgcolor = ConsoleColor.Black)
        {
            Console.ForegroundColor = color;
            Console.BackgroundColor = bgcolor;
            Console.WriteLine(value);
        }

        /// <summary>
        /// 输出内容
        /// </summary>
        /// <param name="value">内容</param>
        public static void Print(string value)
        {
            Console.Write(value);
        }
        /// <summary>
        /// 输出内容
        /// </summary>
        /// <param name="value">内容</param>
        /// <param name="color">文字颜色</param>
        public static void Print(string value, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(value);
        }
        /// <summary>
        /// 输出内容
        /// </summary>
        /// <param name="value">内容</param>
        /// <param name="color">文字颜色</param>
        /// <param name="bgcolor">背景颜色</param>
        public static void Print(string value, ConsoleColor color, ConsoleColor bgcolor)
        {
            Console.ForegroundColor = color;
            Console.BackgroundColor = bgcolor;
            Console.Write(value);
        }
        /// <summary>
        /// 输出换行内容
        /// </summary>
        /// <param name="value">内容</param>
        public static void PrintLine(string value)
        {
            Console.WriteLine(value);
        }
        /// <summary>
        /// 输出换行内容
        /// </summary>
        /// <param name="value">内容</param>
        /// <param name="color">文字颜色</param>
        public static void PrintLine(string value, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(value);
        }
        /// <summary>
        /// 输出换行内容
        /// </summary>
        /// <param name="value">内容</param>
        /// <param name="color">文字颜色</param>
        /// <param name="bgcolor">背景颜色</param>
        public static void PrintLine(string value, ConsoleColor color, ConsoleColor bgcolor)
        {
            Console.ForegroundColor = color;
            Console.BackgroundColor = bgcolor;
            Console.WriteLine(value);
        }

        private static void SetColor(ConsoleColor color, ConsoleColor bgcolor)
        {
            Console.ForegroundColor = color;
            Console.BackgroundColor = bgcolor;
        }
    }
}
