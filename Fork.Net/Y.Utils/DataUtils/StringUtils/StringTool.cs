//************************************************************************
//      https://github.com/yuzhengyang
//      author:     yuzhengyang
//      date:       2017.3.29 - 2017.8.3
//      desc:       字符串工具类
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using Y.Utils.DataUtils.Collections;

namespace Y.Utils.DataUtils.StringUtils
{
    public sealed class StringTool
    {
        /// <summary>
        /// 判断字符串为null或为空格
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(string str)
        {
            if (str == null)
                return true;
            if (str.Trim().Length == 0)
                return true;

            return false;
        }
        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="separator"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static int Split(string str, char separator, out string[] result)
        {
            if (!string.IsNullOrWhiteSpace(str))
            {
                string[] list = str.Split(separator);
                if (ListTool.HasElements(list))
                {
                    result = list;
                    return result.Length;
                }
            }
            result = null;
            return 0;
        }
        /// <summary>
        /// 字符串中字符出现次数
        /// </summary>
        /// <param name="s"></param>
        /// <param name="sub"></param>
        /// <returns></returns>
        public static int SubStringCount(string s, string sub)
        {
            if (s.Contains(sub))
            {
                string sReplaced = s.Replace(sub, "");
                return (s.Length - sReplaced.Length) / sub.Length;
            }
            return 0;
        }
    }
}
