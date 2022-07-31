using Azylee.Core.DataUtils.CollectionUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.Core.DataUtils.StringUtils
{
    public class StringFinder
    {
        public static bool has(string s, params string[] array)
        {
            bool result = true;
            if (Str.Ok(s) && Ls.ok(array))
            {
                foreach (var item in array)
                {
                    if (!s.Contains(item))
                    {
                        result = false;
                        break;
                    }
                }
                return result;
            }
            return false;
        }
    }
}
