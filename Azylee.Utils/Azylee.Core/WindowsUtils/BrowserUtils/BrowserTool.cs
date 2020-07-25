using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Azylee.Core.WindowsUtils.BrowserUtils
{
    public class BrowserTool
    {
        public static bool OpenUrl(string url)
        {
            bool _flag = false;
            if (BrowserSelector.ModernBrowser(out string browser))
            {
                try
                {
                    Process.Start(browser, $"{url}");
                    _flag = true;
                }
                catch { }
            }

            if (_flag == false)
            {
                try
                {
                    Process.Start($"{url}");
                    _flag = true;
                }
                catch { }
            }
            return _flag;
        }
    }
}
