using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y.Utils.BaseUtils
{
    public class DateTimeTool
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
        public static Tuple<int, int> ToMS(double second)
        {
            int Minute = 0, Second = 0;
            Minute = (int)second / 60;
            Second = (int)second % 60;
            return new Tuple<int, int>(Minute, Second);
        }
    }
}
