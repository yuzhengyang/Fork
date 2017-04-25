//############################################################
//      https://github.com/yuzhengyang
//      author:yuzhengyang
//############################################################
using System;
using System.Collections.Generic;
using System.Text;

namespace Y.Utils.DataUtils.DateTimeUtils
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
    }
}
