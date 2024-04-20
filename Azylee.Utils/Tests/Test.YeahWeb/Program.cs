using Azylee.Core.DataUtils.StringUtils;
using Azylee.Core.LogUtils.SimpleLogUtils;
using Azylee.Jsons;
using Azylee.YeahWeb.BaiDuWebAPI.dwz;
using Azylee.YeahWeb.BaiDuWebAPI.IPLocationAPI;
using Azylee.YeahWeb.ExtWebAPI.IPAddressAPI;
using Azylee.YeahWeb.ExtWebAPI.IPCNAPI;
using System;
using System.Collections.Generic;

namespace Test.YeahWeb
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = IPCNTool.Get();

            var rs2 = IPLocationTool.GetLocation();

            Console.ReadLine();
        }
    }
}
