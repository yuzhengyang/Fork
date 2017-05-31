//############################################################
//      https://github.com/yuzhengyang
//      author:yuzhengyang
//############################################################
using System;
using System.IO;
using System.Net;
using Y.Utils.IOUtils.PathUtils;

namespace Y.Utils.NetUtils.FTPUtils
{
    /// <summary>
    /// FTP 帮助类
    /// </summary>
    public class FtpHelper
    {
        private string ftpHostIP { get; set; }
        private string username { get; set; }
        private string password { get; set; }
        private string ftpURI { get { return $@"ftp://{ftpHostIP}/"; } }
        public FtpHelper(string ftpHostIP, string username, string password)
        {
            this.ftpHostIP = ftpHostIP;
            this.username = username;
            this.password = password;
        }
        private FtpWebRequest GetRequest(string URI)
        {
            //根据服务器信息FtpWebRequest创建类的对象
            FtpWebRequest result = (FtpWebRequest)WebRequest.Create(URI);
            result.Credentials = new NetworkCredential(username, password);
            result.KeepAlive = false;
            result.UsePassive = false;
            result.UseBinary = true;
            return result;
        }
        public bool DownloadFile(string ftpFilePath, string saveDir)
        {
            try
            {
                string filename = ftpFilePath.Substring(ftpFilePath.LastIndexOf("\\") + 1);
                string tmpname = Guid.NewGuid().ToString();
                string uri = Path.Combine(ftpURI, ftpFilePath);
                if (!Directory.Exists(saveDir)) Directory.CreateDirectory(saveDir);
                FtpWebRequest ftp = GetRequest(uri);
                ftp.Method = WebRequestMethods.Ftp.DownloadFile;
                using (FtpWebResponse response = (FtpWebResponse)ftp.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (FileStream fs = new FileStream(Path.Combine(saveDir, filename), FileMode.CreateNew))
                        {
                            byte[] buffer = new byte[2048];
                            int read = 0;
                            do
                            {
                                read = responseStream.Read(buffer, 0, buffer.Length);
                                fs.Write(buffer, 0, read);
                            } while (!(read == 0));
                            fs.Flush();
                        }
                    }
                }
                return true;
            }
            catch { }
            return false;
        }
        public bool Download(string ftpFile, string localFile)
        {
            try
            {
                string localPath = DirTool.GetFilePath(localFile);
                if (!Directory.Exists(localPath)) Directory.CreateDirectory(localPath);

                string uri = Path.Combine(ftpURI, ftpFile);
                FtpWebRequest ftp = GetRequest(uri);
                ftp.Method = WebRequestMethods.Ftp.DownloadFile;
                using (FtpWebResponse response = (FtpWebResponse)ftp.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (FileStream fs = new FileStream(localFile, FileMode.CreateNew))
                        {
                            byte[] buffer = new byte[2048];
                            int read = 0;
                            do
                            {
                                read = responseStream.Read(buffer, 0, buffer.Length);
                                fs.Write(buffer, 0, read);
                            } while (!(read == 0));
                            fs.Flush();
                        }
                    }
                }
                return true;
            }
            catch { }
            return false;
        }
    }
}
