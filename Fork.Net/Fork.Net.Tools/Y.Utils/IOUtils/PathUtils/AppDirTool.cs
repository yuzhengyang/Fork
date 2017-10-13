using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Y.Utils.IOUtils.PathUtils
{
    class AppDirTool
    {
        public static string Get(string s, Dictionary<string, string> dictionary)
        {
            string path = s.Trim();
            string result = null;

            if (!string.IsNullOrWhiteSpace(path) && dictionary != null)
            {
                foreach (var dic in dictionary)
                {
                    if (dic.Key != null && dic.Value != null && path.Contains(dic.Key))
                    {
                        result = path.Replace(dic.Key, dic.Value);
                        break;
                    }
                }
            }

            return result;
        }
    }
}
