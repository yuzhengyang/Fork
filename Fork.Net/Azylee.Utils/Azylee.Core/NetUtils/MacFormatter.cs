using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Azylee.Core.NetUtils
{
    public class MacFormatter
    {
        /// <summary>
        /// 验证MAC地址格式
        /// </summary>
        /// <param name="mac"></param>
        /// <returns></returns>
        public static bool CheckMac(string mac)
        {
            Regex r = new Regex("[0-9A-F][0-9A-F]:[0-9A-F][0-9A-F]:[0-9A-F][0-9A-F]:[0-9A-F][0-9A-F]:[0-9A-F][0-9A-F]:[0-9A-F][0-9A-F]");
            if (r.IsMatch(mac)) return true;
            return false;
        }
    }
}
