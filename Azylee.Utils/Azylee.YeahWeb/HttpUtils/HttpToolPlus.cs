using Azylee.Jsons;
using Azylee.YeahWeb.HttpUtils.MethodUtils.GetUtils;
using Azylee.YeahWeb.HttpUtils.MethodUtils.PostUtils;
using Azylee.YeahWeb.HttpUtils.Models;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Azylee.YeahWeb.HttpUtils
{
    public class HttpToolPlus
    {
        public static string Get(string url, ref CookieCollection cookie, Encoding encoding= null, Dictionary<string, string> headers = null, string contentType = HttpContentTypes.ApplicationXWwwFormUrlEncoded, bool autoRedirect = false, bool keepAlive = true, string userAgent = UserAgents.Mozilla4)
        {
            return GetToolPlus.Get(url, ref cookie, encoding, headers, contentType, autoRedirect, keepAlive, userAgent);
        }
        public static string Post(string url, ref CookieCollection cookie, Dictionary<string, string> data = null, Encoding encoding = null, Dictionary<string, string> headers = null, string contentType = HttpContentTypes.ApplicationXWwwFormUrlEncoded, bool autoRedirect = true, bool keepAlive = true, string userAgent = UserAgents.Mozilla4)
        {
            string param = null;
            try
            {
                if (data != null && data.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in data)
                    {
                        sb.Append($"&{item.Key}={item.Value}");
                    }
                    param = sb.ToString().Substring(1);
                }
            }
            catch { }
            return PostToolPlus.Post(url, ref cookie, param, encoding, headers, contentType, autoRedirect, keepAlive, userAgent);
        }
        public static string PostJson(string url, ref CookieCollection cookie, object data, Encoding encoding = null, Dictionary<string, string> headers = null, bool autoRedirect = true, bool keepAlive = true, string userAgent = UserAgents.Mozilla4)
        {
            string param = Json.Object2String(data);
            return PostToolPlus.Post(url, ref cookie, param, encoding, headers, HttpContentTypes.ApplicationJson, autoRedirect, keepAlive, userAgent);
        }
    }
}
