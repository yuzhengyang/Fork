using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oreo.BigBirdDeployer.Utils
{
    public static class ConsoleCodeTool
    {
        const string HEAD = "***BigBirdDeployer***";
        const string CODE = "::CODE::";
        const string LOG = "::LOG::";

        const string BBD_CODE = HEAD + CODE;
        const string BBD_LOG = HEAD + LOG;

        const string LUNCH_SUCCESS = BBD_CODE + "LaunchedSuccessfully";

        /// <summary>
        /// 启动成功
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsLunchSuccess(string s)
        {
            if (!string.IsNullOrWhiteSpace(s) && s.Contains(LUNCH_SUCCESS))
            {
                return true;
            }
            return false;
        }
        public static string GetLogInfo(string s)
        {
            if (!string.IsNullOrWhiteSpace(s) && s.Contains(BBD_LOG))
            {
                return s.Substring(s.IndexOf(BBD_LOG) + BBD_LOG.Length);
            }
            return null;
        }
    }
}
