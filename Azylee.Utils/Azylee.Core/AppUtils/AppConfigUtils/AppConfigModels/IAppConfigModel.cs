using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.Core.AppUtils.AppConfigUtils.AppConfigModels
{
    /// <summary>
    /// AppConfig 配置管理器 指定模型接口
    /// </summary>
    public interface IAppConfigModel
    {
        /// <summary>
        /// 强制设置配置值
        /// </summary>
        void ForceSet();
    }
}
