using Azylee.Core.DataUtils.CollectionUtils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Azylee.Core.DataUtils.StringUtils
{
    public static class StringArrayTool
    {
        public static int Find(string[] array, string s)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == s) return i;
            }
            return -1;
        }
        public static string Join(List<string> list, string quotation = "`", string joinChar = ",")
        {
            string result = "";
            if (Ls.ok(list))
            {
                for (int i = 0; i < list.Count; i++)
                {
                    result += $"{quotation}{list[i]}{quotation}";
                    if (i < list.Count - 1) result += joinChar;
                }
            }
            return result;
        }
    }
}
