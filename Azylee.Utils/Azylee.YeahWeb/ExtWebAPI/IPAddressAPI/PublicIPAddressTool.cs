using Azylee.Core.DataUtils.StringUtils;
using Azylee.Jsons;
using Azylee.YeahWeb.HttpUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.YeahWeb.ExtWebAPI.IPAddressAPI
{
    /// <summary>
    /// 公网IP地址API
    /// </summary>
    public class PublicIPAddressTool
    {
        const string URL = "http://pv.sohu.com/cityjson?ie=utf-8";
        const string URL_IP = "https://www.ipplus360.com/getIP";
        const string URL_LOC = "https://www.ipplus360.com/getLocation";

        /// <summary>
        /// 获取公网IP地址API
        /// </summary>
        /// <returns></returns>
        public static PublicIPAddressModel GetPublicIP()
        {
            string rs = HttpTool.Get(URL);
            if (Str.Ok(rs))
            {
                int flagbeg = rs.IndexOf("{");
                int flagend = rs.LastIndexOf("}");
                if (flagbeg < flagend)
                {
                    rs = rs.Substring(flagbeg, flagend - flagbeg + 1);
                    Dictionary<string, string> model = Json.String2Object<Dictionary<string, string>>(rs);
                    if (model != null)
                    {
                        model.TryGetValue("cip", out string cip);
                        model.TryGetValue("cid", out string cid);
                        model.TryGetValue("cname", out string cname);
                        PublicIPAddressModel result = new PublicIPAddressModel(cip, cid, cname);
                        return result;
                    }
                }
            }
            return null;
        }

        public static string GetIp()
        {
            string ip = "";
            try
            {
                Dictionary<string, string> keyValuePairs = HttpTool.Get<Dictionary<string, string>>(URL_IP);
            }catch(Exception ex) { }
            return ip;
        }

        public static string GetLocation()
        {
            string location = "";
            return location;
        }
    }
}
