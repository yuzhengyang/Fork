using System.Collections.Generic;
using System.Linq;

namespace Y.Utils.BaseUtils
{
    public class ListTool
    {
        public static bool IsNullOrEmpty(List<string> list)
        {
            if (list != null && list.Count() > 0)
                return false;
            return true;
        }
        public static bool IsNullOrEmpty<T>(List<T> list)
        {
            if (list != null && list.Count() > 0)
                return false;
            return true;
        }
        public static bool IsNullOrEmpty<T>(IEnumerable<T> list)
        {
            if (list != null && list.Count() > 0)
                return false;
            return true;
        }
    }
}
