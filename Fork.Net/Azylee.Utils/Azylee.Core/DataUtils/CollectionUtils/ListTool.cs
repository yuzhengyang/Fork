//************************************************************************
//      author:     yuzhengyang
//      date:       2017.10.12 - 2017.10.12
//      desc:       元素列表工具类
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.Core.DataUtils.CollectionUtils
{
    /// <summary>
    /// 元素列表工具类
    /// </summary>
    public sealed class ListTool
    {
        /// <summary>
        /// 列表为空（null 或 count 等于 0）
        /// </summary>
        /// <typeparam name="T">元素类型</typeparam>
        /// <param name="list">元素列表</param>
        /// <returns></returns>
        [Obsolete("Please Use HasElements(list)", false)]
        public static bool IsNullOrEmpty<T>(IEnumerable<T> list)
        {
            if (list != null && list.Count() > 0)
                return false;
            return true;
        }
        /// <summary>
        /// 列表至少有一个元素
        /// </summary>
        /// <typeparam name="T">元素类型</typeparam>
        /// <param name="list">元素列表</param>
        /// <returns></returns>
        public static bool HasElements<T>(IEnumerable<T> list)
        {
            return !IsNullOrEmpty(list);
        }
    }
}
