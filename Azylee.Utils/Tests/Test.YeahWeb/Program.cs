using Azylee.Core.DataUtils.CollectionUtils;
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
            List<string> CustRepList = new List<string>();
            CustRepList.Add("{{$HI.SYSREP=>USER.ACCOUNT1}}1");
            CustRepList.Add("{{$HI.SYSREP=>USER.ACCOUNT2}}  2");
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            foreach (var item in CustRepList)
            {
                string begSign = "{{$";
                string endSign = "}}";
                int endPos = item.IndexOf(endSign);
                if (item.StartsWith(begSign) && endPos > -1)
                {
                    string key = item.Substring(0, endPos);
                    if (key.Ok()) key = key + endSign;
                    string val = item.Substring(endPos + endSign.Length);
                    if (val.Ok()) val = val.Trim();
                    keyValuePairs[key] = val;
                }
            }
            Console.WriteLine(keyValuePairs);
            //var result = IPCNTool.Get();

            //var rs2 = IPLocationTool.GetLocation();

            //Console.ReadLine();
        }
    }
}
