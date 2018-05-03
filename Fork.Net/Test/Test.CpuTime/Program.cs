using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace Test.CpuTime
{
    class Program
    {
        static void Main(string[] args)
        {
            UsingProcess("Marx");
        }
        //+ using System.Diagnostics
        //+ using System.Threading
        static void UsingProcess(string pname)
        {
            using (var pro = Process.GetProcessesByName(pname)[0])
            {
                //间隔时间（毫秒）
                int interval = 1000;
                //上次记录的CPU时间
                var prevCpuTime = TimeSpan.Zero;
                while (true)
                {
                    //当前时间
                    var curTime = pro.TotalProcessorTime;
                    //间隔时间内的CPU运行时间除以逻辑CPU数量
                    var value = (curTime - prevCpuTime).TotalMilliseconds / interval / Environment.ProcessorCount * 100;
                    prevCpuTime = curTime;
                    //输出
                    Console.WriteLine($"{curTime}-{prevCpuTime}, CPU: {value} %");

                    Thread.Sleep(interval);
                }
            }
        }
    }
}
