using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.Core.ProcessUtils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Azylee.Core.WindowsUtils.AdminUtils
{
    /// <summary>
    /// Administrator 工具
    /// </summary>
    public static class AdminTool
    {
        /// <summary>
        /// 检查 Administrator 密码是否正确
        /// </summary>
        /// <param name="pwds"></param>
        /// <returns></returns>
        public static string CheckPasswords(List<string> pwds)
        {
            if (Ls.Ok(pwds))
                foreach (var item in pwds)
                    if (CheckPassword(item)) return item;
            return null;
        }
        /// <summary>
        /// 检查 Administrator 密码是否正确
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool CheckPassword(string password)
        {
            try
            {
                Process process = ProcessStarter.NewProcess(
                   exe: "cmd.exe",
                   username: "administrator",
                   password: password);
                bool flag = process.Start();
                process.Kill();
                return flag;
            }
            catch { return false; }
        }
    }
}
