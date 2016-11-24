using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Y.Utils.AppUtils
{
    public class UniqueTool
    {
        /// <summary>
        /// 判断应用在当前系统实例下是否唯一
        /// </summary>
        /// <param name="appName"></param>
        /// <returns></returns>
        public static bool IsUnique(string appName)
        {
            bool unique;
            Mutex run = new Mutex(true, appName, out unique);
            return unique;
        }
    }
}
