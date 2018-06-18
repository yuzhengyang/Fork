//************************************************************************
//      author:     yuzhengyang
//      date:       2017.3.29 - 2017.7.24
//      desc:       日期转换周
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************
using System;

namespace Azylee.Core.DataUtils.DateTimeUtils
{
    /// <summary>
    /// 日期转换周
    /// </summary>
    public class WeekDayTool
    {
        /// <summary>
        /// 显示日期为周几
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToWeekDay(DateTime date)
        {
            string result = "";
            switch (date.DayOfWeek.ToString())
            {
                case "Sunday": result = "星期日"; break;
                case "Monday": result = "星期一"; break;
                case "Tuesday": result = "星期二"; break;
                case "Wednesday": result = "星期三"; break;
                case "Thursday": result = "星期四"; break;
                case "Friday": result = "星期五"; break;
                case "Saturday": result = "星期六"; break;
            }
            return result;
        }
    }
}
