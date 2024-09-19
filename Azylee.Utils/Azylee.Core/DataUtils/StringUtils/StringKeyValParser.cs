using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.Core.DataUtils.StringUtils
{
    public static class StringKeyValParser
    {
        public static string GetValue(string s, string key, string split, string end, string defaultValue = "")
        {
            string head = key + split;
            int valBegIndex = s.IndexOf(head) + head.Length;
            if (valBegIndex >= 0)
            {
                int valEndIndex = s.IndexOf(end, valBegIndex);
                if (valEndIndex >= 0)
                {
                    return s.Substring(valBegIndex, valEndIndex - valBegIndex);
                }

            }
            return defaultValue;
        }
    }
}
