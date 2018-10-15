using Azylee.Core.AppUtils;
using Azylee.Core.LogUtils.SimpleLogUtils;
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
            Log log = new Log(LogLevel.All, LogLevel.Information);

            Cons.Log("测试 Default 测试");
            log.V<string>(null);
            Cons.Log("测试 Muted 测试\r\n\r\n测试 Muted 测试\r\n\r\n测试 Muted 测试\r\n\r\n测试 Muted 测试", ConsColorMode.Muted);
            log.V("测试 Log V \r\n\r\n 测试 Log V \r\n\r\n 测试 Log V \r\n\r\n");

            Cons.Log("测试 Muted 测试\r\n\r\n测试 Muted 测试\r\n\r\n测试 Muted 测试\r\n\r\n测试 Muted 测试", ConsColorMode.Muted);
            log.I("测试 Log V \r\n\r\n 测试 Log V \r\n\r\n 测试 Log V \r\n\r\n");

            Cons.Log("测试 Primary 测试", ConsColorMode.Primary);
            Cons.Log("测试 Secondary 测试", ConsColorMode.Secondary);
            Cons.Log("测试 Success 测试", ConsColorMode.Success);
            Cons.Log("测试 Info 测试", ConsColorMode.Info);
            Cons.Log("测试 Warning 测试", ConsColorMode.Warning);
            Cons.Log("测试 Danger 测试", ConsColorMode.Danger);
            Cons.Log("测试 Dark 测试", ConsColorMode.Dark);
            Cons.Log("测试 Light 测试", ConsColorMode.Light);

            Console.WriteLine();
            Console.WriteLine("====================");
            Console.WriteLine("====================");
            Console.ReadLine();
            //Azylee.Core.ProcessUtils.ProcessTool.Start("CPAU.EXE","-u Zephyr -p 123456 ");
        }
    }
}
