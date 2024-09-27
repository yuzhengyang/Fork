using Azylee.Core.DataUtils.CollectionUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.Core.DataUtils.StringUtils
{
    public class UrlTool
    {

        /// <summary>
        /// 连接多个string构成url
        /// </summary>
        /// <param name="paths"></param>
        /// <returns></returns>
        public static string Combine(params string[] paths)
        {
            if (ListTool.HasElements(paths))
            {
                if (paths.Length > 1)
                {
                    StringBuilder result = new StringBuilder(paths[0]);
                    for (int i = 1; i < paths.Length; i++)
                    {
                        if (paths[i] != null)
                        {
                            string u = paths[i];
                            if (u.StartsWith("/")) u = u.Substring(1);
                            if (!result.ToString().EndsWith("/")) result.Append("/");
                            result.Append(u);
                        }
                    }
                    return result.ToString();
                }
                else
                {
                    return paths[0];
                }
            }
            return "";
        }
    }
}
