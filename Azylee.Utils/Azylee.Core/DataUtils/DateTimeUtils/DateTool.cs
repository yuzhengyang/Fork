//************************************************************************
//      author:     yuzhengyang
//      date:       2017.8.17 - 2017.8.17
//      desc:       日期工具
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.Core.DataUtils.DateTimeUtils
{
    public sealed class DateTool
    {
        public static bool IsToday(DateTime date)
        {
            DateTime today = DateTime.Now;
            if (today.Year == date.Year && today.Month == date.Month && today.Day == date.Day)
                return true;
            return false;
        }
        public static bool IsYesterday(DateTime date)
        {
            DateTime yesterday = DateTime.Now.AddDays(-1);
            if (yesterday.Year == date.Year && yesterday.Month == date.Month && yesterday.Day == date.Day)
                return true;
            return false;
        }
        /// <summary>
        /// 当月有多少天
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static int MonthDays(int year, int month)
        {
            int days = 1;
            try
            {
                DateTime begin = new DateTime(year, month, 1);
                DateTime end = begin.AddMonths(1);
                days = (int)(end - begin).TotalDays;
            }
            catch { }
            return days;
        }
    }
}
