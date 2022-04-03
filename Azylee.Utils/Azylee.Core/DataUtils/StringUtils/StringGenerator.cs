using Azylee.Core.DataUtils.CollectionUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.Core.DataUtils.StringUtils
{
    public class StringGenerator
    {
        /// <summary>
        /// 通过数字区间生成一组字符串（支持一个[-]区间）
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static List<string> CreateByNumberSection(string s)
        {
            List<string> resultList = new List<string>();
            int startNumber = 0, stopNumber = 0, lens = 1;
            string startString = "", stopString = "", arrow = "<";

            string[] sp = s.Split('[', ']');
            foreach (string item in sp)
            {
                if (arrow == "-") arrow = ">";

                if (item.Contains("-"))
                {
                    string[] numbers = ArrayTool.Formatter<string>(item.Split('-'), 2);
                    if (int.TryParse(numbers[0], out startNumber) && int.TryParse(numbers[1], out stopNumber))
                    {
                        lens = numbers[0].Length;
                        arrow = "-";
                    }
                }

                if (arrow == "<") startString += item;
                if (arrow == ">") stopString += item;

            }
            if (startNumber < stopNumber)
            {
                for (int i = startNumber; i <= stopNumber; i++)
                {
                    string number = i.ToString();
                    if (number.Length < lens)
                    {
                        number = number.PadLeft(lens, '0');
                    }
                    resultList.Add(startString + number + stopString);
                }
            }
            if (!Ls.Ok(resultList)) resultList.Add(s);
            return resultList;
        }
    }
}
