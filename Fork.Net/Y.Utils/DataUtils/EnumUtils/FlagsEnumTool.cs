using System;

namespace Y.Utils.DataUtils.EnumUtils
{
    /// <summary>
    /// 标志枚举修改工具
    /// 弃用：效率太低
    /// sa = sa | StatusAttributes.Join;//添加属性
    /// sa = (sa | StatusAttributes.Share) ^ StatusAttributes.Share;//删除属性
    /// </summary>
    [Obsolete]
    public sealed class FlagsEnumTool
    {
        public static int AddAttribute(int en, int att)
        {
            return en ^ att;
        }
        public static int AddAttribute<T>(T en, T att)
        {
            try
            {
                int intEn = (int)Convert.ChangeType(en, typeof(int));
                int intAtt = (int)Convert.ChangeType(att, typeof(int));
                return intEn ^ intAtt;
            }
            catch (Exception e) { }
            return 0;
        }
        public static int RemoveAttribute(int en, int att)
        {
            return (en | att) ^ att;
        }
        public static int RemoveAttribute<T>(T en, T att)
        {
            try
            {
                int intEn = (int)Convert.ChangeType(en, typeof(int));
                int intAtt = (int)Convert.ChangeType(att, typeof(int));
                return (intEn | intAtt) ^ intAtt;
            }
            catch (Exception e) { }
            return 0;
        }
    }
}
