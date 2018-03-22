using Azylee.YeahWeb.BaiDuWebAPI.IPLocationAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.BaiDuWebAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            var loc = IPLocationTool.GetLocation();
            Console.WriteLine("");
        }
    }
}
