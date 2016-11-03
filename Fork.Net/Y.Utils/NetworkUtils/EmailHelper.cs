using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Y.Utils.NetworkUtils
{
    public class EmailHelper
    {
        private MailMessage mMailMessage;   //主要处理发送邮件的内容（如：收发人地址、标题、主体、图片等等）
        private SmtpClient mSmtpClient; //主要处理用smtp方式发送此邮件的配置信息（如：邮件服务器、发送端口号、验证方式等等）
        private int mSenderPort;   //发送邮件所用的端口号（htmp协议默认为25）
        private string mSenderServerHost;    //发件箱的邮件服务器地址（IP形式或字符串形式均可）
        private string mSenderPassword;    //发件箱的密码
        private string mSenderUsername;   //发件箱的用户名（即@符号前面的字符串，例如：hello@163.com，用户名为：hello）
        private bool mEnableSsl;    //是否对邮件内容进行socket层加密传输
        private bool mEnablePwdAuthentication;  //是否对发件人邮箱进行密码验证

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fromMail">发件人地址</param>
        /// <param name="toMail">收件人地址（多个电子邮件地址之间必须用逗号字符（“,”）分隔）</param>
        /// <param name="subject">邮件标题</param>
        /// <param name="emailBody">邮件内容（可以以html格式进行设计）</param>
        /// <param name="username">发件箱的用户名（即@符号前面的字符串，例如：hello@163.com，用户名为：hello）</param>
        /// <param name="password">发件人邮箱密码</param>
        /// <param name="attachments">邮件附件</param>
        /// <param name="sslEnable">对邮件内容进行socket层加密传输，false表示不加密</param>
        /// <param name="pwdCheckEnable">对发件人邮箱进行密码验证，false表示不对发件人邮箱进行密码验证</param>
        /// <param name="port">发送邮件所用的端口号（htmp协议默认为25）</param>
        public EmailHelper(string fromMail, string toMail, string subject, string emailBody,
            string username, string password,
            string[] attachments = null, bool sslEnable = false, bool pwdCheckEnable = false, int port = 25)
        {
            try
            {
                mMailMessage = new MailMessage();
                mMailMessage.To.Add(toMail);
                mMailMessage.From = new MailAddress(fromMail);
                mMailMessage.Subject = subject;
                mMailMessage.Body = emailBody;
                mMailMessage.IsBodyHtml = true;
                mMailMessage.BodyEncoding = System.Text.Encoding.UTF8;
                mMailMessage.Priority = MailPriority.Normal;
                mSenderServerHost = GetSmtp(fromMail);
                mSenderUsername = username;
                mSenderPassword = password;
                mSenderPort = port;
                mEnableSsl = sslEnable;
                mEnablePwdAuthentication = pwdCheckEnable;
                AddAttachments(attachments);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static string GetSmtp(string fromMail)
        {
            string result = "";
            if (!string.IsNullOrWhiteSpace(fromMail) && fromMail.IndexOf('@') > 0)
            {
                string ext = fromMail.Substring(fromMail.IndexOf('@') + 1);
                switch (ext)
                {
                    case "163.com":
                        result = "smtp.163.com";
                        break;
                    case "gmail.com":
                        result = "smtp.gmail.com";
                        break;
                    case "qq.com":
                        result = "smtp.qq.com";
                        break;
                    case "sina.com":
                        result = "smtp.sina.com";
                        break;
                }
            }
            return result;
        }
        private bool AddAttachments(string[] attachments)
        {
            try
            {
                if (attachments != null && attachments.Count() > 0)
                {
                    Attachment data;
                    ContentDisposition disposition;
                    foreach (var item in attachments)
                    {
                        data = new Attachment(item, MediaTypeNames.Application.Octet);
                        disposition = data.ContentDisposition;
                        disposition.CreationDate = File.GetCreationTime(item);
                        disposition.ModificationDate = File.GetLastWriteTime(item);
                        disposition.ReadDate = File.GetLastAccessTime(item);
                        mMailMessage.Attachments.Add(data);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Send()
        {
            try
            {
                if (mMailMessage != null)
                {
                    mSmtpClient = new SmtpClient();
                    //mSmtpClient.Host = "smtp." + mMailMessage.From.Host;
                    mSmtpClient.Host = mSenderServerHost;
                    mSmtpClient.Port = mSenderPort;
                    mSmtpClient.UseDefaultCredentials = false;
                    mSmtpClient.EnableSsl = mEnableSsl;
                    if (mEnablePwdAuthentication)
                    {
                        System.Net.NetworkCredential nc = new System.Net.NetworkCredential(mSenderUsername, mSenderPassword);
                        //mSmtpClient.Credentials = new System.Net.NetworkCredential(this.mSenderUsername, this.mSenderPassword);
                        //NTLM: Secure Password Authentication in Microsoft Outlook Express
                        mSmtpClient.Credentials = nc.GetCredential(mSmtpClient.Host, mSmtpClient.Port, "NTLM");
                    }
                    else
                    {
                        mSmtpClient.Credentials = new System.Net.NetworkCredential(mSenderUsername, mSenderPassword);
                    }
                    mSmtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    mSmtpClient.Send(mMailMessage);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
