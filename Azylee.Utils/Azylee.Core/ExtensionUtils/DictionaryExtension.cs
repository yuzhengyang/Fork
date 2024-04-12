using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.Core.ExtensionUtils
{
    /// <summary>
    /// Dictionary 类型的扩展方法
    /// </summary>
    public static class DictionaryExtension
    {
        public static string GetString(this IDictionary dic, string key, string defaultVal = "")
        {
            if (dic == null || key == null) return defaultVal;
            if (dic.Contains(key) && dic[key] != null) return dic[key].ToString();
            return defaultVal;
        }
    }
}
