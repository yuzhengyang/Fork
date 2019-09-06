using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.Core.DataUtils.StringUtils
{
    /// <summary>
    /// String类型扩展方法
    /// </summary>
    public static class StringExtension
    {
        private static void Test()
        {
            string s = "Hello Extension Methods";
            int i = s.WordCount();
        }
        /// <summary>
        /// 判断字符串 非null、""、空格（Not NullOrWhiteSpace）
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool Ok(this String s)
        {
            return Str.Ok(s);
        }
        public static int WordCount(this String str)
        {
            return str.Split(new char[] { ' ', '.', '?' },
                             StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}
