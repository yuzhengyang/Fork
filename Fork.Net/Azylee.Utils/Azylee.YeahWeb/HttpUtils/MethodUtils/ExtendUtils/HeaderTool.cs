using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Azylee.YeahWeb.HttpUtils.MethodUtils.ExtendUtils
{
    public static class HeaderTool
    {
        public static bool Set(ref HttpWebRequest request, Dictionary<string, string> headers)
        {
            try
            {
                if (request != null && headers != null && headers.Count > 0)
                    foreach (var head in headers)
                        request.Headers.Add(head.Key, head.Value);
                return true;
            }
            catch { return false; }
        }
    }
}
