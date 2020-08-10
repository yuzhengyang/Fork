//************************************************************************
//      author:     yuzhengyang
//      date:       2017.3.29 - 2017.6.27
//      desc:       日期格式转换
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azylee.Core.DataUtils.DateTimeUtils
{
    /// <summary>
    /// 日期格式转换工具
    /// </summary>
    public sealed class DateTimeFormatter
    {
        /// <summary>
        /// yyyy-MM-dd HH:mm:ss
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string Standard(DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd HH:mm:ss");
        }
        /// <summary>
        /// yyyyMMddHHmmss
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string Compact(DateTime dt)
        {
            return dt.ToString("yyyyMMddHHmmss");
        }
        /// <summary>
        /// yyyy-MM-dd HH:mm:ss.fff
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string Detail(DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }
    }
}
