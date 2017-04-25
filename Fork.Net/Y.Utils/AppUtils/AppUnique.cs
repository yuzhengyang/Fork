//############################################################
//      https://github.com/yuzhengyang
//      author:yuzhengyang
//############################################################
using System.Threading;

namespace Y.Utils.AppUtils
{
    public sealed class AppUnique
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
