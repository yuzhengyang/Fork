using Azylee.Core.AppUtils.AppConfigUtils.AppConfigInterfaces;
using Azylee.Core.DataUtils.EncryptUtils;
using Azylee.Core.DataUtils.StringUtils;
using Azylee.Core.DbUtils;
using Azylee.Core.DbUtils.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.Core.AppUtils.AppConfigUtils.AppConfigModels
{
    /// <summary>
    /// 数据库配置信息
    /// </summary>
    public class AppConfigSshItem : IAppConfigItemModel
    {
        private string PASSWORD_ENC_SIGN = "ENC:::";
        private string PASSWORD_ENC_PWD = "app.db.pwd.20211202";
        /// <summary>
        /// 序号
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// 唯一名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 服务器IP地址
        /// </summary>
        public string Server { get; set; }
        /// <summary>
        /// 服务器端口号
        /// </summary>
        public string Port { get; set; }
        /// <summary>
        /// 登录用户
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// 登录用户密码
        /// </summary>
        public string Password { get; set; }
        public void SetPasswordEnc(string value)
        {
            if (Str.Ok(value) && !value.StartsWith(PASSWORD_ENC_SIGN))
            {
                Password = PASSWORD_ENC_SIGN + AesTool.Encrypt(value, PASSWORD_ENC_PWD);
            }
            else
            {
                Password = value ?? "";
            }
        }
        public string GetPasswordEnc()
        {
            if (Str.Ok(Password) && Password.StartsWith(PASSWORD_ENC_SIGN))
            {
                return AesTool.Decrypt(Password.Substring(PASSWORD_ENC_SIGN.Length), PASSWORD_ENC_PWD);
            }
            else
            {
                return Password;
            }
        }

        /// <summary>
        /// 全参数构造函数
        /// </summary>
        /// <param name="number"></param>
        /// <param name="name"></param>
        /// <param name="server"></param>
        /// <param name="port"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public AppConfigSshItem(int number, string name, string server, string port, string username, string password)
        {
            Number = number;
            Name = name;
            Server = server;
            Port = port;
            Username = username;
            SetPasswordEnc(password);
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
            return this.Name;
        }
    }
}
