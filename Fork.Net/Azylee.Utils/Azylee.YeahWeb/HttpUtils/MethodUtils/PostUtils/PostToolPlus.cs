using Azylee.YeahWeb.HttpUtils.MethodUtils.ExtendUtils;
using Azylee.YeahWeb.HttpUtils.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Azylee.YeahWeb.HttpUtils.MethodUtils.PostUtils
{
    internal static class PostToolPlus
    {
        internal static string Post(string url, ref CookieCollection cookie, string data = null, Encoding encoding = null, Dictionary<string, string> headers = null, string contentType = HttpContentTypes.ApplicationXWwwFormUrlEncoded, bool autoRedirect = true, bool keepAlive = true, string userAgent = UserAgents.Mozilla4)
        {
            string html = "";
            Stream stream = null, dataStream = null;
            StreamReader reader = null;
            try
            {
                //配置属性
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "POST";
                request.ContentType = contentType;
                request.AllowAutoRedirect = autoRedirect;
                request.KeepAlive = keepAlive;
                request.UserAgent = userAgent;
                request.CookieContainer = new CookieContainer();
                HeaderTool.Set(ref request, headers);
                if (cookie != null) request.CookieContainer.Add(cookie);
                //配置参数
                if (data != null)
                {
                    byte[] dataByte = Encoding.UTF8.GetBytes(data);
                    request.ContentLength = dataByte.Length;
                    dataStream = request.GetRequestStream();
                    dataStream.Write(dataByte, 0, dataByte.Length);
                }
                //请求数据
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                response.Cookies = request.CookieContainer.GetCookies(request.RequestUri);
                cookie = response.Cookies;
                stream = response.GetResponseStream();
                reader = new StreamReader(stream, encoding ?? Encoding.Default);
                html = reader.ReadToEnd();
            }
            catch
            {
            }
            finally
            {
                if (reader != null) reader.Close();
                if (stream != null) stream.Close();
                if (dataStream != null) dataStream.Close();
            }
            return html;
        }
    }
}
