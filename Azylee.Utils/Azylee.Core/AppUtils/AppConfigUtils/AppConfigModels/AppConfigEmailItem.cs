using Azylee.Core.AppUtils.AppConfigUtils.AppConfigInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.Core.AppUtils.AppConfigUtils.AppConfigModels
{
    /// <summary>
    /// Email邮箱配置信息
    /// </summary>
    public class AppConfigEmailItem : IAppConfigItemModel
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// 邮箱地址
        /// </summary>
        public string MailAddress { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// 邮箱密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 对邮件内容进行socket层加密传输，false表示不加密
        /// </summary>
        public bool SslEnable { get; set; }
        /// <summary>
        /// 对发件人邮箱进行密码验证，false表示不对发件人邮箱进行密码验证
        /// </summary>
        public bool PwdCheckEnable { get; set; }
        /// <summary>
        /// 发送邮件所用的端口号（htmp协议默认为25）
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        /// <param name="_number"></param>
        /// <param name="_mailAddress"></param>
        /// <param name="_username"></param>
        /// <param name="_password"></param>
        /// <param name="_sslEnable"></param>
        /// <param name="_pwdCheckEnable"></param>
        /// <param name="_port"></param>
        public AppConfigEmailItem(int _number, string _mailAddress, string _username, string _password, bool _sslEnable = false, bool _pwdCheckEnable = false, int _port = 25)
        {
            Number = _number;
            MailAddress = _mailAddress;
            Username = _username;
            Password = _password;
            SslEnable = _sslEnable;
            PwdCheckEnable = _pwdCheckEnable;
            Port = _port;
        }

        /// <summary>
        /// 排序序号
        /// </summary>
        /// <returns></returns>
        public int GetOrderNumber()
        {
            return this.Number;
        }
        /// <summary>
        /// 唯一名称
        /// </summary>
        /// <returns></returns>
        public string GetUniqueName()
        {
            return this.MailAddress;
        }
    }
}
