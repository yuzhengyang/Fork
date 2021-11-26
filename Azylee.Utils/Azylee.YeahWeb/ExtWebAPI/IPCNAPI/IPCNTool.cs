using Azylee.Core.DataUtils.StringUtils;
using Azylee.Jsons;
using Azylee.YeahWeb.HttpUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Azylee.YeahWeb.ExtWebAPI.IPCNAPI
{
    public static class IPCNTool
    {
        const string URL = "https://www.ip.cn/api/index?ip=&type=0";

        /// <summary>
        /// 获取IP地址信息
        /// </summary>
        /// <returns></returns>
        public static Tuple<string, string> Get()
        {
            try
            {
                CookieCollection cookie = new CookieCollection();
                string rss1 = HttpToolPlus.Get(URL, ref cookie);
                Dictionary<string, string> model = Json.String2Object<Dictionary<string, string>>(rss1);

                string ip = "", address = "";
                if (model.TryGetValue("ip", out string _ip)) ip = _ip;
                if (model.TryGetValue("address", out string _address)) address = _address;
                return new Tuple<string, string>(ip, address);
            }
            catch (Exception e) { return null; }
        }
    }
}
