using Azylee.Core.AppUtils;
using Azylee.Core.ThreadUtils.SleepUtils;
using Azylee.Core.WindowsUtils.ConsoleUtils;
using Azylee.Core.WindowsUtils.ShortcutUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.ProcessTool
{
    class Program
    {
        static void Main(string[] args)
        {
            ShortcutTool.Create(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                "测试创建快捷方式",
                @"D:\CoCo\GitHub\Fork\Azylee.Utils\Tests\Test.ProcessTool\bin\Debug\Test.ProcessTool.exe");
            Cons.A("测试 Default 测试");
            Cons.A("测试 Muted 测试", ConsColorMode.Muted);
            Cons.A("测试 Primary 测试", ConsColorMode.Primary);
            Cons.A("测试 Secondary 测试", ConsColorMode.Secondary);
            Cons.A("测试 Success 测试", ConsColorMode.Success);
            Cons.A("测试 Info 测试", ConsColorMode.Info);
            Cons.A("测试 Warning 测试", ConsColorMode.Warning);
            Cons.A("测试 Danger 测试", ConsColorMode.Danger);
            Cons.A("测试 Dark 测试", ConsColorMode.Dark);
            Cons.A("测试 Light 测试", ConsColorMode.Light);

            Console.WriteLine();
            Console.WriteLine("====================");
            Console.WriteLine("====================");
            Console.ReadLine();
            //Azylee.Core.ProcessUtils.ProcessTool.Start("CPAU.EXE","-u Zephyr -p 123456 ");
        }
    }
}
