using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.Core.WindowsUtils.ConsoleUtils
{
    public static class Ct
    {
        public static void P(string value)
        {
            Console.Write(value);
        }
        public static void P(string value, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(value);
        }
        public static void P(string value, ConsoleColor color, ConsoleColor bgcolor)
        {
            Console.ForegroundColor = color;
            Console.BackgroundColor = bgcolor;
            Console.Write(value);
        }
        public static void Pl(string value)
        {
            Console.WriteLine(value);
        }
        public static void Pl(string value, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(value);
        }
        public static void Pl(string value, ConsoleColor color, ConsoleColor bgcolor)
        {
            Console.ForegroundColor = color;
            Console.BackgroundColor = bgcolor;
            Console.WriteLine(value);
        }
    }
}
