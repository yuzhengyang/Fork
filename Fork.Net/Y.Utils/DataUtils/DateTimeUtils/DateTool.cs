//************************************************************************
//      https://github.com/yuzhengyang
//      author:     yuzhengyang
//      date:       2017.8.17 - 2017.8.17
//      desc:       日期工具
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Y.Utils.DataUtils.DateTimeUtils
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
    }
}
