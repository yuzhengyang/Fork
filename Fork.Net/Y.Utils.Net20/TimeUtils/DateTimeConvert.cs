using System;
using System.Collections.Generic;
using System.Text;

namespace Y.Utils.Net20.TimeUtils
{
    public sealed class DateTimeConvert
    {
        public static string ToStandardString(DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
