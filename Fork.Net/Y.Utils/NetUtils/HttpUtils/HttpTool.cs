//############################################################
//      https://github.com/yuzhengyang
//      author:yuzhengyang
//############################################################
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using Y.Utils.DataUtils.StringUtils;

namespace Y.Utils.NetUtils.HttpUtils
{
    public class HttpTool
    {
        public static string Get(string url, string encoding = "utf-8")
        {
            string result = "";
            try
            {
                Encoding myEncoding = Encoding.GetEncoding(encoding);
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = "GET";
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
            try
            {
                Encoding myEncoding = Encoding.GetEncoding(encoding);
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = "GET";
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
        public static string Post(string url, string param, string encoding = "utf-8")
        {
            string result = string.Empty;
            try
            {
                Encoding myEncoding = Encoding.GetEncoding(encoding);
                byte[] byteArray = myEncoding.GetBytes(param); //转化
                HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(new Uri(url));
                webReq.Method = "POST";
                webReq.ContentType = "application/x-www-form-urlencoded";
                webReq.ContentLength = byteArray.Length;
                Stream newStream = webReq.GetRequestStream();
                newStream.Write(byteArray, 0, byteArray.Length);//写入参数
                newStream.Close();
                HttpWebResponse response = (HttpWebResponse)webReq.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.Default);
                result = sr.ReadToEnd();
                sr.Close();
                response.Close();
                newStream.Close();
            }
            catch (Exception ex)
            { }
            return result;
        }
        //public static string PostJson(string url, string param)
        //{
        //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        //    request.Method = "POST";
        //    request.ContentType = "application/json";
        //    request.ContentLength = Encoding.UTF8.GetByteCount(param);
        //    Stream myRequestStream = request.GetRequestStream();
        //    StreamWriter myStreamWriter = new StreamWriter(myRequestStream, Encoding.GetEncoding("gb2312"));
        //    myStreamWriter.Write(param);
        //    myStreamWriter.Close();
        //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //    Stream myResponseStream = response.GetResponseStream();
        //    StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
        //    string retString = myStreamReader.ReadToEnd();
        //    myStreamReader.Close();
        //    myResponseStream.Close();
        //    return retString;
        //}
        public static string PostJson(string url, string param)
        {
            string rs = null;
            ServicePointManager.DefaultConnectionLimit = 300;
            System.GC.Collect();
            CookieContainer cookieContainer = new CookieContainer();
            // 设置提交的相关参数
            HttpWebRequest request = null;
            HttpWebResponse SendSMSResponse = null;
            Stream dataStream = null;
            StreamReader SendSMSResponseStream = null;
            try
            {
                request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "POST";
                request.KeepAlive = false;
                request.ServicePoint.ConnectionLimit = 300;
                request.AllowAutoRedirect = true;
                request.Timeout = 10000;
                request.ReadWriteTimeout = 10000;
                request.ContentType = "application/json";
                request.Accept = "application/xml";
                request.Headers.Add("X-Auth-Token", HttpUtility.UrlEncode("OpenStack"));
                string strContent = param;
                byte[] bytes = Encoding.UTF8.GetBytes(strContent);
                request.Proxy = null;
                request.CookieContainer = cookieContainer;
                using (dataStream = request.GetRequestStream())
                {
                    dataStream.Write(bytes, 0, bytes.Length);
                }
                SendSMSResponse = (HttpWebResponse)request.GetResponse();
                if (SendSMSResponse.StatusCode == HttpStatusCode.RequestTimeout)
                {
                    if (SendSMSResponse != null)
                    {
                        SendSMSResponse.Close();
                        SendSMSResponse = null;
                    }
                    if (request != null)
                    {
                        request.Abort();
                    }
                    return null;
                }
                SendSMSResponseStream = new StreamReader(SendSMSResponse.GetResponseStream(), Encoding.GetEncoding("utf-8"));
                string strRespone = SendSMSResponseStream.ReadToEnd();

                return strRespone;
            }
            catch (Exception ex)
            {

                if (dataStream != null)
                {
                    dataStream.Close();
                    dataStream.Dispose();
                    dataStream = null;
                }
                if (SendSMSResponseStream != null)
                {
                    SendSMSResponseStream.Close();
                    SendSMSResponseStream.Dispose();
                    SendSMSResponseStream = null;
                }
                if (SendSMSResponse != null)
                {
                    SendSMSResponse.Close();
                    SendSMSResponse = null;
                }
                if (request != null)
                {
                    request.Abort();
                }
            }
            finally
            {
                if (dataStream != null)
                {
                    dataStream.Close();
                    dataStream.Dispose();
                    dataStream = null;
                }
                if (SendSMSResponseStream != null)
                {
                    SendSMSResponseStream.Close();
                    SendSMSResponseStream.Dispose();
                    SendSMSResponseStream = null;
                }
                if (SendSMSResponse != null)
                {
                    SendSMSResponse.Close();
                    SendSMSResponse = null;
                }
                if (request != null)
                {
                    request.Abort();
                }
            }
            return rs;
        }

        /// <summary>
        /// http下载文件
        /// </summary>
        /// <param name="url">下载文件地址</param>
        /// <param name="file">文件存放地址，包含文件名</param>
        /// <returns></returns>
        public static bool Download(string url, string file)
        {
            string tempPath = Path.GetDirectoryName(file) + @"\temp";
            Directory.CreateDirectory(tempPath);  //创建临时文件目录
            string tempFile = tempPath + @"\" + Path.GetFileName(file) + ".temp"; //临时文件
            if (File.Exists(tempFile))
            {
                File.Delete(tempFile);    //存在则删除
            }
            try
            {
                FileStream fs = new FileStream(tempFile, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                // 设置参数
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                //发送请求并获取相应回应数据
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求
                Stream responseStream = response.GetResponseStream();
                //创建本地文件写入流
                //Stream stream = new FileStream(tempFile, FileMode.Create);
                byte[] bArr = new byte[1024];
                int size = responseStream.Read(bArr, 0, (int)bArr.Length);
                while (size > 0)
                {
                    //stream.Write(bArr, 0, size);
                    fs.Write(bArr, 0, size);
                    size = responseStream.Read(bArr, 0, (int)bArr.Length);
                }
                //stream.Close();
                fs.Close();
                responseStream.Close();
                File.Delete(file);
                File.Move(tempFile, file);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
