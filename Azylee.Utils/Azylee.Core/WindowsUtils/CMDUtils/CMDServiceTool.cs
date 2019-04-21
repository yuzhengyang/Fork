using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.Core.DataUtils.StringUtils;
using Azylee.Core.WindowsUtils.AdminUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.Core.WindowsUtils.CMDUtils
{
    /// <summary>
    /// CMD 系统服务工具类
    /// </summary>
    public static class CMDServiceTool
    {
        /// <summary>
        /// 安装服务（安装、运行、设置自启，一条龙服务）
        /// </summary>
        /// <param name="name">服务名</param>
        /// <param name="path">应用程序路径</param>
        /// <param name="account">运行账户信息</param>
        /// <returns></returns>
        public static bool Install(string name, string path, WindowsAccountModel account = null)
        {
            try
            {
                List<string> createResult = CMDProcessTool.Execute($"sc create {name} binPath= \"{path}\"", account);
                List<string> startResult = CMDProcessTool.Execute($"net start {name}", account);
                List<string> configResult = CMDProcessTool.Execute($"sc config {name} start= AUTO", account);
                if (Ls.Ok(createResult))
                {
                    return createResult.Any(x => x.Contains("成功") || x.Contains("服务已存在"));
                }
                return false;
            }
            catch { return false; }
        }
        /// <summary>
        /// 卸载服务（关闭、删除，一条龙服务）
        /// </summary>
        /// <param name="name"></param>
        /// <param name="account">运行账户信息</param>
        public static bool Uninstall(string name, WindowsAccountModel account = null)
        {
            try
            {
                List<string> stopResult = CMDProcessTool.Execute($"sc stop {name}", account);
                List<string> deleteResult = CMDProcessTool.Execute($"sc delete {name}", account);
                List<string> queryResult = CMDProcessTool.Execute($"sc query {name}");
                if (Ls.Ok(queryResult))
                {
                    return queryResult.Any(x => x.Contains("失败") || x.Contains("1060") || x.Contains("服务未安装"));
                }
                return false;
            }
            catch { return false; }
        }
    }
}
