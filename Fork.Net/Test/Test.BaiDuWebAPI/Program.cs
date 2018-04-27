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
            var loc1 = IPLocationTool.GetLocation();
            var loc2 = IPLocationTool.GetLocation();
            bool cp = loc1.Like(loc2);
            Console.WriteLine("");
        }
    }
}
