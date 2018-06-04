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

namespace Azylee.Core.DataUtils.StringUtils
{
    public static class Str
    {
        /// <summary>
        /// 判断字符串 非null、""、空格（Not NullOrWhiteSpace）
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool Ok(string s)
        {
            return StringTool.Ok(s);
        }
        /// <summary>
        /// 判断字符串 非null、""（Not NullOrEmpty）
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool Ok2(string s)
        {
            return StringTool.Ok2(s);
        }
    }
}
