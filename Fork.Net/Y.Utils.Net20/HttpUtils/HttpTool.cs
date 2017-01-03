using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Y.Utils.Net20.StringUtils;

namespace Y.Utils.Net20.HttpUtils
{
    public class HttpTool
    {
        public static string Get(string url, string encoding = "utf-8")
        {
            string result = "";
            Encoding myEncoding = Encoding.GetEncoding(encoding);
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Method = "GET";
            try
            {
                using (WebResponse wr = req.GetResponse())
                {
                    //在这里对接收到的页面内容进行处理
                    result = new StreamReader(wr.GetResponseStream(), myEncoding).ReadToEnd();
                }
            }
            catch (Exception e) { }
            return result;
        }
        public static T Get<T>(string url, string encoding = "utf-8")
        {
            Encoding myEncoding = Encoding.GetEncoding(encoding);
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Method = "GET";
            try
            {
                using (WebResponse wr = req.GetResponse())
                {
                    //在这里对接收到的页面内容进行处理
                    string response = new StreamReader(wr.GetResponseStream(), myEncoding).ReadToEnd();
                    if (!StringTool.IsNullOrWhiteSpace(response))
                    {
                        T result = JsonConvert.DeserializeObject<T>(response);
                        return result;
                    }
                }
            }
            catch (Exception e) { }
            return default(T);
        }
    }
}
