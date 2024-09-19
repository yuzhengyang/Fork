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
            testKeyValParser();

        }

        public static void testKeyValParser()
        {
            string s = "/* {{$HI.CMDST=>WAIT_BEFORE...10}} 执行脚本之前，先等待10秒钟 */\r\n/* {{$HI.CMDST=>WAIT_AFTER...10}} 执行脚本后，等待10秒钟 */";
            string val1 = StringKeyValParser.GetValue(s, "{{$HI.CMDST=>WAIT_BEFORE", "...", "}}", "0");
            string val2 = StringKeyValParser.GetValue(s, "{{$HI.CMDST=>WAIT_AFTER", "...", "}}", "0");
            Console.WriteLine(val1);
            Console.WriteLine(val2);
        }

        public static void testIp()
        {
            //var result = IPCNTool.Get();
            //var rs2 = IPLocationTool.GetLocation();
            //Console.ReadLine();
        }
        public static void testCusRep()
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
        }
    }
}
