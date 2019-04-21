using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.Core.DataUtils.DateTimeUtils
{
    /// <summary>
    /// 时间差
    /// </summary>
    public static class TimeDiff
    {
        /// <summary>
        /// 当前时间差（秒）
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static long Sec(DateTime dt)
        {
            return (long)(dt - DateTime.Now).TotalSeconds;
        }
    }
}
