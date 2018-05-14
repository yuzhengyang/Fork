using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Azylee.YeahWeb.HttpUtils
{
    public class HttpToolPlus
    {
        const string DefaultContentType = "application/x-www-form-urlencoded";
        const string DefaultUserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; Trident/4.0; .NET CLR 2.0.50727; .NET4.0C; .NET4.0E)";
        public static string Get(string url, ref CookieCollection cookie, Dictionary<string, string> headers = null, string contentType = DefaultContentType, bool autoRedirect = false, bool keepAlive = true, string userAgent = DefaultUserAgent)
        {
            string html = "";
            Stream stream = null;
            StreamReader reader = null;
            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "GET";
                request.ContentType = DefaultContentType;
                request.AllowAutoRedirect = autoRedirect;
                request.KeepAlive = keepAlive;
                request.UserAgent = DefaultUserAgent;
                request.CookieContainer = new CookieContainer();
                SetHeaders(ref request, headers);
                if (cookie != null) request.CookieContainer.Add(cookie);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                response.Cookies = request.CookieContainer.GetCookies(request.RequestUri);
                cookie = response.Cookies;
                stream = response.GetResponseStream();
                reader = new StreamReader(stream, Encoding.Default);
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
        public static string Post(string url, ref CookieCollection cookie, string data = null, Dictionary<string, string> headers = null, string contentType = DefaultContentType, bool autoRedirect = true, bool keepAlive = true, string userAgent = DefaultUserAgent)
        {
            string html = "";
            Stream stream = null, dataStream = null;
            StreamReader reader = null;
            try
            {
                //配置属性
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "POST";
                request.ContentType = DefaultContentType;
                request.AllowAutoRedirect = autoRedirect;
                request.KeepAlive = keepAlive;
                request.UserAgent = DefaultUserAgent;
                request.CookieContainer = new CookieContainer();
                SetHeaders(ref request, headers);
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
                reader = new StreamReader(stream, Encoding.Default);
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

        private static bool SetHeaders(ref HttpWebRequest request, Dictionary<string, string> headers)
        {
            try
            {
                if (request != null && headers != null && headers.Count > 0)
                    foreach (var head in headers)
                        request.Headers.Add(head.Key, head.Value);
                return true;
            }
            catch { return false; }
        }
    }
}
