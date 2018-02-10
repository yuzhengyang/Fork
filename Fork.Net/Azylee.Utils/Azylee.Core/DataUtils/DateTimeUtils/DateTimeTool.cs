//************************************************************************
//      https://github.com/yuzhengyang
//      author:     yuzhengyang
//      date:       2017.3.29 - 2017.8.17
//      desc:       日期时间工具
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace Azylee.Core.DataUtils.DateTimeUtils
{
    public sealed class DateTimeTool
    {
        public static DateTime TodayDate()
        {
            DateTime today = DateTime.Now;
            DateTime result = new DateTime(today.Year, today.Month, today.Day);
            return result;
        }
        public static DateTime TodayDate(DateTime today)
        {
            DateTime result = new DateTime(today.Year, today.Month, today.Day);
            return result;
        }
        public static TimeSpan TimeSpan(DateTime dt1, DateTime dt2)
        {
            if (dt1 > dt2)
                return dt1 - dt2;
            else
                return dt2 - dt1;
        }
        public static Tuple<int, int> ToMS(double second)
        {
            int Minute = 0, Second = 0;
            Minute = (int)second / 60;
            Second = (int)second % 60;
            return new Tuple<int, int>(Minute, Second);
        }
        public static Tuple<long, long, long> ToHMS(double second)
        {
            double Hour = second / 60 / 60;
            double Minute = second / 60 % 60;
            double Second = second % 60;
            return new Tuple<long, long, long>((long)Hour, (long)Minute, (long)Second);
        }
        public static Tuple<long, long, long> ToHMS(long ms)
        {
            long Hour = ms / 1000 / 60 / 60;
            long Minute = ms / 1000 / 60 % 60;
            long Second = ms / 1000 % 60;
            return new Tuple<long, long, long>(Hour, Minute, Second);
        }
        public static Tuple<int, int, int> ToHMS(int ms)
        {
            int Hour = ms / 1000 / 60 / 60;
            int Minute = ms / 1000 / 60 % 60;
            int Second = ms / 1000 % 60;
            return new Tuple<int, int, int>(Hour, Minute, Second);
        }
    }
}
