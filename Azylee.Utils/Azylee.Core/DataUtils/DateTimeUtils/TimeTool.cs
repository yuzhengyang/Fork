using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.Core.DataUtils.DateTimeUtils
{
    /// <summary>
    /// 时间计算工具类
    /// </summary>
    public static class TimeTool
    {
        /// <summary>
        /// 时间与当前时间差
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static double TimeDiffSec(DateTime dt)
        {
            return (dt - DateTime.Now).TotalSeconds;
        }
    }
}
