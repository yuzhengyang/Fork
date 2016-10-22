using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y.Utils.BaseUtils
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
