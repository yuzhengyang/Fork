//************************************************************************
//      https://github.com/yuzhengyang
//      author:     yuzhengyang
//      date:       2017.10.12 - 2018.5.17
//      desc:       字符串工具类
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************
using Azylee.Core.DataUtils.CollectionUtils;
using System;
using System.Text.RegularExpressions;

namespace Azylee.Core.DataUtils.StringUtils
{
    public sealed class StringTool
    {
        /// <summary>
        /// 判断字符串 非null、""、空格（Not NullOrWhiteSpace）
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool Ok(string s)
        {
            return !string.IsNullOrWhiteSpace(s);
        }
        /// <summary>
        /// 判断字符串 非null、""（Not NullOrEmpty）
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool Ok2(string s)
        {
            return !string.IsNullOrEmpty(s);
        }
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
        /// 查看字符串包含字符（不区分大小写）
        /// </summary>
        /// <param name="s"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public static bool Contains(string s, string word)
        {
            if (s.ToLower().Contains(word.ToLower()))
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
        /// <summary>
        /// 根据通配符验证字符串
        /// </summary>
        /// <param name="s">字符串</param>
        /// <param name="pattern">通配符：%和_</param>
        /// <returns></returns>
        public static bool IsMatch(string s, string pattern)
        {
            try
            {
                //key = key.Replace("%", @"[\s\S]*").Replace("_", @"[\s\S]");
                pattern = pattern.Replace("%", ".*").Replace("_", ".");
                return Regex.IsMatch(s, pattern);
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 使用指定字符替换字符串中换行符
        /// </summary>
        /// <param name="s"></param>
        /// <param name="sign"></param>
        /// <returns></returns>
        public static string ReplaceNewLine(string s, string sign = " , ")
        {
            try
            {
                return s.Replace("\r\n", sign).
                Replace("\n\r", sign).
                Replace(Environment.NewLine, sign);
            }
            catch { return s; }
        }
    }
}
