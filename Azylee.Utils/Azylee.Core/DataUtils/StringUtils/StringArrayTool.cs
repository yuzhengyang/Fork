using System;
using System.Collections.Generic;
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
    }
}
