using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.Core.DataUtils.StringUtils
{
    public class NameFormat
    {
        /// <summary>
        /// 转换为驼峰命名
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToCamelCase(string s)
        {
            string result = "";
            if (Str.Ok(s))
            {
                if (s.IndexOf('_') >= 0)
                {
                    bool upFlag = false;
                    char[] cArray = s.ToArray();
                    foreach (var c in cArray)
                    {
                        if (c == '_')
                        {
                            upFlag = true;
                            continue;
                        }

                        if (upFlag)
                        {
                            result += c.ToString().ToUpper();
                            upFlag = false;
                        }
                        else
                        {
                            result += c.ToString().ToLower();
                        }
                    }
                }
                else
                {
                    result = s;
                }
            }
            return result;
        }
        /// <summary>
        /// 转换为驼峰命名（首字母大写）
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToUpCamelCase(string s)
        {
            string result = "";
            if (Str.Ok(s))
            {
                bool upFlag = false;
                char[] cArray = s.ToArray();
                for (int i = 0; i < cArray.Length; i++)
                {
                    char c = cArray[i];
                    if (c == '_')
                    {
                        upFlag = true;
                        continue;
                    }

                    if (upFlag || i == 0)
                    {
                        result += c.ToString().ToUpper();
                        upFlag = false;
                    }
                    else
                    {
                        result += c.ToString().ToLower();
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// 转换为下划线命名
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToUnderline(string s)
        {
            string result = "";
            if (Str.Ok(s))
            {
                char[] cArray = s.ToArray();
                foreach (var c in cArray)
                {
                    char cUpper = char.ToUpper(c);
                    char cLower = char.ToLower(c);
                    if (c >= 'A' && c <= 'Z')
                    {
                        result += "_";
                    }
                    result += char.ToLower(c);
                }
            }
            return result;
        }

        public static string Format(string s, NameType nameType)
        {
            switch (nameType)
            {
                case NameType.CAMEL:
                    return ToCamelCase(s);

                case NameType.UPPER_CAMEL:
                    return ToUpCamelCase(s);

                case NameType.UNDER_LINE:
                    return ToUnderline(s);

                case NameType.NONE:
                default:
                    return s;
            }
        }
    }
}
