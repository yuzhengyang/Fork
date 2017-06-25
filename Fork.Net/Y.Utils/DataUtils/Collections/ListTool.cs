//############################################################
//      https://github.com/yuzhengyang
//      author:yuzhengyang
//############################################################
using System.Collections.Generic;
using System.Linq;

namespace Y.Utils.DataUtils.Collections
{
    public sealed class ListTool
    {
        /// <summary>
        /// 列表为空（null 或 count 等于 0）
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(List<string> list)
        {
            if (list != null && list.Count() > 0)
                return false;
            return true;
        }
        /// <summary>
        /// 列表为空（null 或 count 等于 0）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(List<T> list)
        {
            if (list != null && list.Count() > 0)
                return false;
            return true;
        }
        /// <summary>
        /// 列表为空（null 或 count 等于 0）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(IEnumerable<T> list)
        {
            if (list != null && list.Count() > 0)
                return false;
            return true;
        }
        /// <summary>
        /// 列表至少有一个元素
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool HasElements<T>(IEnumerable<T> list)
        {
            return !IsNullOrEmpty(list);
        }
    }
}
