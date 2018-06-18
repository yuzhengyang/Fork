//************************************************************************
//      author:     yuzhengyang
//      date:       2018.3.27 - 2018.6.3
//      desc:       工具描述
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************
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
