using Azylee.Core.AppUtils.AppConfigUtils.AppConfigModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Azylee.Core.AppUtils.AppConfigUtils
{
    /// <summary>
    /// AppConfig 配置管理器
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AppConfig<T> where T : IAppConfigModel, new()
    {
        /// <summary>
        /// 配置信息模型
        /// </summary>
        public T Config { get; set; }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public AppConfig()
        { }

        /// <summary>
        /// 初始化配置信息
        /// </summary>
        /// <returns></returns>
        public abstract bool OnCreate();
        /// <summary>
        /// 销毁配置信息
        /// </summary>
        /// <returns></returns>
        public abstract bool OnDestroy();
        /// <summary>
        /// 保存配置信息
        /// </summary>
        /// <returns></returns>
        public abstract bool DoSave();
    }
}
