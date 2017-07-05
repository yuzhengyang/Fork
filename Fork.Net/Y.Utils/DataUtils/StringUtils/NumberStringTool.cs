using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Y.Utils.DataUtils.StringUtils
{
    public class NumberStringTool
    {
        public static string ToString(ulong value, int digit = 32)
        {
            string basenumber = value.ToString();
            if (digit > basenumber.Length)
            {
                string digitnumber = new string('0', digit - basenumber.Length);
                return digitnumber + basenumber;
            }
            return basenumber;
        }
        public static ulong ToUlong(string value)
        {
            ulong number = 0;
            if (ulong.TryParse(value, out number))
            {

            }
            return number;
        }
    }
}
