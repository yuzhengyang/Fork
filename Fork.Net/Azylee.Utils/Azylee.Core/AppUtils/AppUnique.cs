//************************************************************************
//      https://github.com/yuzhengyang
//      author:     yuzhengyang
//      date:       2017.10.12 - 2017.10.12
//      desc:       App唯一启动工具
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************
using System.Threading;

namespace Azylee.Core.AppUtils
{
    public sealed class AppUnique
    {
        private Mutex Mutex { get; set; }

        /// <summary>
        /// 判断应用在当前系统实例下是否唯一（搭配 ApplicationAPI.Raise() 食用更佳）
        /// </summary>
        /// <param name="appName"></param>
        /// <returns></returns>
        public bool IsUnique(string appName)
        {
            bool unique;
            Mutex = new Mutex(true, appName, out unique);
            return unique;
        }
    }
}
