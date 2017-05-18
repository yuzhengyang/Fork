using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y.Utils.DataUtils.UnitConvertUtils
{
    public class ByteConvertTool
    {
        public static string Fmt(long size, int digits = 2)
        {
            string rs = "";
            if (size > 1024 * 1024 * 1024)
            {
                rs = Math.Round((double)size / 1024 / 1024 / 1024, digits) + " GB";
            }
            else if (size > 1024 * 1024)
            {
                rs = Math.Round((double)size / 1024 / 1024, digits) + " MB";
            }
            else if (size > 1024)
            {
                rs = Math.Round((double)size / 1024, digits) + " KB";
            }
            else
            {
                rs = size + " B";
            }
            return rs;
        }
        public static string Fmt(double size, int digits = 2)
        {
            string rs = "";
            if (size > 1024 * 1024 * 1024)
            {
                rs = Math.Round(size / 1024 / 1024 / 1024, digits) + " GB";
            }
            else if (size > 1024 * 1024)
            {
                rs = Math.Round(size / 1024 / 1024, digits) + " MB";
            }
            else if (size > 1024)
            {
                rs = Math.Round(size / 1024, digits) + " KB";
            }
            else
            {
                rs = size + " B";
            }
            return rs;
        }
        public static string Cvt(long size, string unit, int digits = 2)
        {
            double rs = 0;
            switch (unit)
            {
                case "B": rs = size; break;
                case "KB": rs = (double)size / 1024; break;
                case "MB": rs = (double)size / 1024 / 1024; break;
                case "GB": rs = (double)size / 1024 / 1024 / 1024; break;
            }
            return Math.Round(rs, digits).ToString();
        }
        public static string Cvt(double size, string unit, int digits = 2)
        {
            double rs = 0;
            switch (unit)
            {
                case "B": rs = size; break;
                case "KB": rs = size / 1024; break;
                case "MB": rs = size / 1024 / 1024; break;
                case "GB": rs = size / 1024 / 1024 / 1024; break;
            }
            return Math.Round(rs, digits).ToString();
        }
    }
}
