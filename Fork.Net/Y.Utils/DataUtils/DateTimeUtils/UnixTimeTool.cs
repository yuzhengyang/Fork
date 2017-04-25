//############################################################
//      https://github.com/yuzhengyang
//      author:yuzhengyang
//############################################################
using System;

namespace Y.Utils.DataUtils.DateTimeUtils
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
