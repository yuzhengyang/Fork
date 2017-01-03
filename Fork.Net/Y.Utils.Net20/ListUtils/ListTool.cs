using System;
using System.Collections.Generic;
using System.Text;

namespace Y.Utils.Net20.ListUtils
{
    public sealed class ListTool
    {
        public static bool IsNullOrEmpty(List<string> list)
        {
            if (list != null && list.Count > 0)
                return false;
            return true;
        }
        public static bool IsNullOrEmpty<T>(List<T> list)
        {
            if (list != null && list.Count > 0)
                return false;
            return true;
        }
        public static bool IsNullOrEmpty<T>(IEnumerable<T> list)
        {
            if (list != null)
            {
                foreach(var l in list)
                {
                    return false;
                }
            }
            return true;
        }
        public static bool HasElements<T>(IEnumerable<T> list)
        {
            return !IsNullOrEmpty(list);
        }
    }
}
