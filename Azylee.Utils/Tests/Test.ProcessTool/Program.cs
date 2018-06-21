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
            Azylee.Core.ProcessUtils.ProcessTool.Start("CPAU.EXE","-u Zephyr -p 123456 ");
        }
    }
}
