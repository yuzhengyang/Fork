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
    public static class StringBuilderExtension
    {
        public static StringBuilder replace(this StringBuilder stringBuilder, Dictionary<string, string> pms)
        {
            return Replace(stringBuilder, pms);
        }
        public static StringBuilder Replace(this StringBuilder stringBuilder, Dictionary<string, string> pms)
        {
            if (pms != null)
            {
                foreach (var key in pms.Keys)
                {
                    stringBuilder = stringBuilder.Replace(key, pms[key]);
                }
            }
            return stringBuilder;
        }
    }
}
