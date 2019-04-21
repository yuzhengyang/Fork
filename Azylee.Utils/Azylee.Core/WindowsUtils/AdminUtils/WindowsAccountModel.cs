using Azylee.Core.ProcessUtils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Azylee.Core.WindowsUtils.AdminUtils
{
    /// <summary>
    /// Windows 系统账号信息
    /// </summary>
    public class WindowsAccountModel
    {
        /// <summary>
        /// 域
        /// </summary>
        public string Domain { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="domain"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public WindowsAccountModel(string domain = "", string username = "", string password = "")
        {
            Domain = domain;
            UserName = username;
            Password = password;
        }
        /// <summary>
        /// 验证账号密码正确性
        /// </summary>
        public bool Check()
        {
            try
            {
                Process process = ProcessStarter.NewProcess(
                   exe: "cmd.exe",
                   domain: Domain,
                   username: UserName,
                   password: Password);
                bool flag = process.Start();
                process.Kill();
                return flag;
            }
            catch { return false; }
        }
        /// <summary>
        /// 验证账号密码为管理员账号
        /// </summary>
        /// <returns></returns>
        public bool CheckAdmin(string password)
        {
            return AdminTool.CheckPassword(password);
        }
    }
}
