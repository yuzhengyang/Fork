//############################################################
//      https://github.com/yuzhengyang
//      author:yuzhengyang
//############################################################
using Azylee.Core.DataUtils.GuidUtils;
using Azylee.Core.DataUtils.StringUtils;
using Azylee.Core.DelegateUtils.ProcessDelegateUtils;
using Azylee.Core.IOUtils.DirUtils;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace Azylee.YeahWeb.HttpUtils
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
        public static string Post(string url, string param, string encoding = "utf-8")
        {
            string result = string.Empty;
            try
            {
                Encoding myEncoding = Encoding.GetEncoding(encoding);
                HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(new Uri(url));
                webReq.Method = "POST";
                webReq.ContentType = "application/x-www-form-urlencoded";
                if (!string.IsNullOrWhiteSpace(param))
                {
                    byte[] byteArray = myEncoding.GetBytes(param); //转化
                    webReq.ContentLength = byteArray.Length;
                    Stream newStream = webReq.GetRequestStream();
                    newStream.Write(byteArray, 0, byteArray.Length);//写入参数
                    newStream.Close();
                }
                HttpWebResponse response = (HttpWebResponse)webReq.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.Default);
                result = sr.ReadToEnd();
                sr.Close();
                response.Close();
            }
            catch (Exception ex)
            { }
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
        public static T Post<T>(string url, string param, string encoding = "utf-8")
        {
            try
            {
                Encoding myEncoding = Encoding.GetEncoding(encoding);
                byte[] byteArray = myEncoding.GetBytes(param); //转化
                HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(new Uri(url));
                webReq.Method = "POST";
                webReq.ContentType = "application/x-www-form-urlencoded";
                webReq.ContentLength = byteArray.Length;
                using (Stream newStream = webReq.GetRequestStream())
                {
                    newStream.Write(byteArray, 0, byteArray.Length);//写入参数
                    newStream.Close();
                    using (HttpWebResponse response = (HttpWebResponse)webReq.GetResponse())
                    {
                        using (StreamReader sr = new StreamReader(response.GetResponseStream(), myEncoding))
                        {
                            string txt = sr.ReadToEnd();
                            if (!string.IsNullOrWhiteSpace(txt))
                            {
                                T result = JsonConvert.DeserializeObject<T>(txt);
                                return result;
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { }
            return default(T);
        }
        /// <summary>
        /// Http Get（返回值：>=0正常，-100编码异常，-200创建web请求异常，-300网络异常，-400返回内容为空）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="what"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static int Get<T>(string url, out T what, string encoding = "utf-8")
        {
            DateTime beginTime = DateTime.Now;
            what = default(T);
            //设置编码
            Encoding myEncoding;
            try { myEncoding = Encoding.GetEncoding(encoding); } catch { return -100; }//编码异常

            //创建web请求
            HttpWebRequest req;
            try
            {
                req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = "GET";
            }
            catch { return -200; }//创建web请求异常

            //请求数据
            string txt;
            try
            {
                using (WebResponse wr = req.GetResponse())
                {
                    txt = new StreamReader(wr.GetResponseStream(), myEncoding).ReadToEnd();
                }
            }
            catch { return -300; }//网络异常

            //转换模型
            if (StringTool.IsNullOrWhiteSpace(txt))
            {
                return -400;//返回内容为空
            }
            else
            {
                what = JsonConvert.DeserializeObject<T>(txt);
                return (int)Math.Ceiling((DateTime.Now - beginTime).TotalSeconds);//操作成功
            }
        }
        public static int Post<T>(string url, string param, out T what, string encoding = "utf-8")
        {
            DateTime beginTime = DateTime.Now;
            what = default(T);
            //设置编码
            Encoding myEncoding;
            try { myEncoding = Encoding.GetEncoding(encoding); } catch { return -100; }//编码异常

            //创建web请求
            HttpWebRequest webReq;
            byte[] byteArray;
            try
            {
                byteArray = myEncoding.GetBytes(param); //转化参数
                webReq = (HttpWebRequest)WebRequest.Create(new Uri(url));
                webReq.Method = "POST";
                webReq.ContentType = "application/x-www-form-urlencoded";
                webReq.ContentLength = byteArray.Length;
            }
            catch { return -200; }//创建web请求异常

            //请求数据
            string txt;
            try
            {
                using (Stream newStream = webReq.GetRequestStream())
                {
                    newStream.Write(byteArray, 0, byteArray.Length);//写入参数
                    newStream.Close();
                    using (HttpWebResponse response = (HttpWebResponse)webReq.GetResponse())
                    {
                        using (StreamReader sr = new StreamReader(response.GetResponseStream(), myEncoding))
                        {
                            txt = sr.ReadToEnd();
                        }
                    }
                }
            }
            catch { return -300; }//网络异常

            //转换模型
            if (StringTool.IsNullOrWhiteSpace(txt))
            {
                return -400;//返回内容为空
            }
            else
            {
                what = JsonConvert.DeserializeObject<T>(txt);
                return (int)Math.Ceiling((DateTime.Now - beginTime).TotalSeconds);//操作成功
            }
        }
        /// <summary>
        /// http下载文件
        /// </summary>
        /// <param name="url">下载文件地址</param>
        /// <param name="file">文件存放地址，包含文件名</param>
        /// <param name="progress">回调进度</param>
        /// <returns></returns>
        public static bool Download(string url, string file, ProgressDelegate.ProgressHandler progress = null, object sender = null)
        {
            try
            {
                string path = Path.GetDirectoryName(file);
                DirTool.Create(path);  //创建文件目录

                string tempFile = DirTool.Combine(path, GuidTool.Short() + ".temp"); //临时文件
                if (File.Exists(tempFile)) File.Delete(tempFile);    //存在则删除

                FileStream fs = new FileStream(tempFile, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                // 设置参数
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                //发送请求并获取相应回应数据
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求
                Stream responseStream = response.GetResponseStream();
                //创建本地文件写入流
                //Stream stream = new FileStream(tempFile, FileMode.Create);
                byte[] buffer = new byte[100 * 1024];
                int readCount = 0;
                long filesize = response.ContentLength, current = 0;
                while ((readCount = responseStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    fs.Write(buffer, 0, readCount);
                    current += readCount;
                    if (filesize <= 0 || filesize < current)
                    {
                        if (current > 0) filesize = current;
                        else filesize = 1;
                    }
                    progress?.Invoke(sender, new ProgressEventArgs(current, filesize));
                }
                //stream.Close();
                fs.Close();
                responseStream.Close();
                File.Delete(file);//删除原始文件
                File.Move(tempFile, file);//下载的临时文件重命名
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
