//############################################################
//      https://github.com/yuzhengyang
//      author:yuzhengyang
//############################################################
using System;
using System.Collections.Generic;
using System.Text;
using Y.Utils.DataUtils.Collections;

namespace Y.Utils.DataUtils.StringUtils
{
    public class StringTool
    {
        public static bool IsNullOrWhiteSpace(string str)
        {
            if (str == null)
                return true;
            if (str.Trim().Length == 0)
                return true;

            return false;
        }
        public static int Split(string str, char separator, out string[] result)
        {
            if (!string.IsNullOrWhiteSpace(str))
            {
                string[] list = str.Split(separator);
                if (ListTool.HasElements(list))
                {
                    result = list;
                    return result.Length;
                }
            }
            result = null;
            return 0;
        }
    }
}
