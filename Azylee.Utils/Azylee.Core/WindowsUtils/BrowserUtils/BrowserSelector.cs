using Azylee.Core.DataUtils.StringUtils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Azylee.Core.WindowsUtils.BrowserUtils
{
    /// <summary>
    /// 浏览器选择器
    /// </summary>
    public class BrowserSelector
    {
        /// <summary>
        /// 现代浏览器
        /// </summary>
        /// <param name="browser"></param>
        /// <returns></returns>
        public static bool ModernBrowser(out string browser)
        {
            browser = "";

            string edge_86 = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe";
            string chrome = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
            string chrome_86 = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
            string chrome_app = @"C:\Users\Administrator\AppData\Local\Google\Chrome\Application\chrome.exe";
            string firefox = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            string firefox_86 = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";

            if (File.Exists(edge_86)) browser = edge_86;
            else if (File.Exists(chrome)) browser = chrome;
            else if (File.Exists(chrome_86)) browser = chrome_86;
            else if (File.Exists(chrome_app)) browser = chrome_app;
            else if (File.Exists(firefox)) browser = firefox;
            else if (File.Exists(firefox_86)) browser = firefox_86;

            if (Str.Ok(browser)) return true;
            return false;
        }

        /// <summary>
        /// 石器时代浏览器IE
        /// </summary>
        /// <param name="browser"></param>
        /// <returns></returns>
        public static bool StoneAgeIE(out string browser)
        {
            browser = "";

            string ie = @"C:\Program Files\internet explorer\iexplore.exe";
            string ie_86 = @"C:\Program Files (x86)\Internet Explorer\iexplore.exe";

            if (File.Exists(ie)) browser = ie;
            else if (File.Exists(ie_86)) browser = ie_86;

            if (Str.Ok(browser)) return true;
            return false;
        }
    }
}
