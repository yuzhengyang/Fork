using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace Y.Utils.NetworkUtils
{
    public class HttpHelper
    {
        public string Get(string url, string encoding)
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
        public T Get<T>(string url, string encoding)
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
                    if (!string.IsNullOrWhiteSpace(response))
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
