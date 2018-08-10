//************************************************************************
//      author:     yuzhengyang
//      date:       2018.3.27 - 2018.6.3
//      desc:       工具描述
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************
using System;

namespace AzyleeCC.Core.DataUtils.DateTimeUtils
{
    public class UnixTimeTool
    {
        public static DateTime Parse(float second)
        {
            TimeSpan span = new TimeSpan((long)second * 10000000);
            DateTime baseTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            DateTime resultTime = baseTime.Add(span);
            return resultTime;
        }
        public static DateTime Parse(double second)
        {
            TimeSpan span = new TimeSpan((long)second * 10000000);
            DateTime baseTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            DateTime resultTime = baseTime.Add(span);
            return resultTime;
        }
        public static DateTime Parse(long second)
        {
            TimeSpan span = new TimeSpan(second * 10000000);
            DateTime baseTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            DateTime resultTime = baseTime.Add(span);
            return resultTime;
        }
    }
}
