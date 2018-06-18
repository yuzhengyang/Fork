//############################################################
//      https://github.com/yuzhengyang
//      author:yuzhengyang
//############################################################
using Azylee.Core.DelegateUtils.ProcessDelegateUtils;
using Azylee.Core.IOUtils.DirUtils;
using System;
using System.IO;
using System.Net;

namespace Azylee.YeahWeb.FTPUtils
{
    /// <summary>
    /// FTP 帮助类
    /// </summary>
    public class FtpTool
    {
        private string HostIP { get; set; }
        private string UserName { get; set; }
        private string Password { get; set; }
        private string FtpUri { get { return $@"ftp://{HostIP}/"; } }
        public FtpTool(string ftpHostIP, string username, string password)
        {
            this.HostIP = ftpHostIP;
            this.UserName = username;
            this.Password = password;
        }
        private FtpWebRequest GetRequest(string uri)
        {
            //根据服务器信息FtpWebRequest创建类的对象
            FtpWebRequest result = (FtpWebRequest)WebRequest.Create(uri);
            result.Credentials = new NetworkCredential(UserName, Password);
            result.KeepAlive = false;
            result.UsePassive = false;
            result.UseBinary = true;
            //request.Proxy = this.proxy;
            result.EnableSsl = false;
            return result;
        }
        public bool DownloadFile(string ftpFilePath, string saveDir)
        {
            try
            {
                string filename = ftpFilePath.Substring(ftpFilePath.LastIndexOf("\\") + 1);
                string tmpname = Guid.NewGuid().ToString();
                string uri = Path.Combine(FtpUri, ftpFilePath);
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

        public long GetFileSize(string ftpFile)
        {
            long result = 0;
            try
            {
                string uri = Path.Combine(FtpUri, ftpFile);
                FtpWebRequest request = GetRequest(uri);
                request.Method = WebRequestMethods.Ftp.GetFileSize;
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    result = response.ContentLength;
                }
            }
            catch (Exception e) { }
            return result;
        }
        public bool Download(string ftpFile, string localFile, ProgressDelegate.ProgressHandler progress = null, object sender = null, bool overwrite = true)
        {
            try
            {
                long current = 0, filesize = GetFileSize(ftpFile);
                string localPath = DirTool.GetFilePath(localFile);
                if (!Directory.Exists(localPath)) Directory.CreateDirectory(localPath);
                string uri = Path.Combine(FtpUri, ftpFile);
                FtpWebRequest ftp = GetRequest(uri);
                ftp.Method = WebRequestMethods.Ftp.DownloadFile;
                using (FtpWebResponse response = (FtpWebResponse)ftp.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (FileStream fs = new FileStream(localFile, FileMode.Create))
                        {
                            byte[] buffer = new byte[1024 * 1024];
                            int read = 0;
                            do
                            {
                                read = responseStream.Read(buffer, 0, buffer.Length);
                                fs.Write(buffer, 0, read);
                                current += read;
                                progress?.Invoke(sender, new ProgressEventArgs(current, filesize));
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
