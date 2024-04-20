using Azylee.YeahWeb.HttpUtils.MethodUtils.ExtendUtils;
using Azylee.YeahWeb.HttpUtils.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Azylee.YeahWeb.HttpUtils.MethodUtils.GetUtils
{
    internal static class GetToolPlus
    {
        internal static string Get(string url, ref CookieCollection cookie, Encoding encoding, Dictionary<string, string> headers = null, string contentType = HttpContentTypes.ApplicationXWwwFormUrlEncoded, bool autoRedirect = false, bool keepAlive = true, string userAgent = UserAgents.Mozilla4)
        {
            string html = "";
            Stream stream = null;
            StreamReader reader = null;
            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "GET";
                request.ContentType = contentType;
                request.AllowAutoRedirect = autoRedirect;
                request.KeepAlive = keepAlive;
                request.UserAgent = userAgent;
                request.CookieContainer = new CookieContainer();
                HeaderTool.Set(ref request, headers);
                if (cookie != null) request.CookieContainer.Add(cookie);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                response.Cookies = request.CookieContainer.GetCookies(request.RequestUri);
                cookie = response.Cookies;
                stream = response.GetResponseStream();
                reader = new StreamReader(stream, encoding == null ? Encoding.Default : encoding);
                html = reader.ReadToEnd();
            }
            catch
            {
            }
            finally
            {
                if (reader != null) reader.Close();
                if (stream != null) stream.Close();
            }
            return html;
        }
    }
}
