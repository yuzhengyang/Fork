//############################################################
//      https://github.com/yuzhengyang
//      author:yuzhengyang
//############################################################
using System;

namespace Y.Utils.DataUtils.DateTimeUtils
{
    public class ChineseHourTool
    {
        public static string GetDesc(DateTime time)
        {
            string result = "";
            if (time.Hour >= 23 || time.Hour < 1)
            {
                //子时（23 - 1点）：半夜
                result = "半夜";
            }
            else if (time.Hour >= 1 && time.Hour < 3)
            {
                //丑时（1 - 3点）：凌晨
                result = "凌晨";
            }
            else if (time.Hour >= 3 && time.Hour < 5)
            {
                //寅时（3 - 5点）：黎明
                result = "黎明";
            }
            else if (time.Hour >= 5 && time.Hour < 7)
            {
                //卯时（5 - 7点）：清晨
                result = "清晨";
            }
            else if (time.Hour >= 7 && time.Hour < 9)
            {
                //辰时（7 - 9点）：早上
                result = "早上";
            }
            else if (time.Hour >= 9 && time.Hour < 11)
            {
                //巳时（9 - 11点）：上午
                result = "上午";
            }
            else if (time.Hour >= 11 && time.Hour < 13)
            {
                //午时（11 - 13点）：中午
                result = "中午";
            }
            else if (time.Hour >= 13 && time.Hour < 15)
            {
                //未时（13 - 15点）：午后
                result = "午后";
            }
            else if (time.Hour >= 15 && time.Hour < 17)
            {
                //申时（15 - 17点）：下午
                result = "下午";
            }
            else if (time.Hour >= 17 && time.Hour < 19)
            {
                //酉时（17 - 19点）：傍晚
                result = "傍晚";
            }
            else if (time.Hour >= 19 && time.Hour < 21)
            {
                //戌时（19 - 21点）：晚上
                result = "晚上";
            }
            else if (time.Hour >= 21 && time.Hour < 23)
            {
                //亥时（21 - 23点）：深夜
                result = "深夜";
            }
            return result;
        }
    }
}
