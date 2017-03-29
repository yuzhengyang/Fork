using System;

namespace Y.Utils.DataUtils.DateTimeUtils
{
    public class WeekDayTool
    {
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
