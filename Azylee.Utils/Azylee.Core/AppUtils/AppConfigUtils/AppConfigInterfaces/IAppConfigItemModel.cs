using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.Core.AppUtils.AppConfigUtils.AppConfigInterfaces
{
    /// <summary>
    /// AppConfig 配置管理器 详细配置项接口
    /// </summary>
    public interface IAppConfigItemModel
    {
        /// <summary>
        /// 配置项序号
        /// </summary>
        /// <returns></returns>
        int GetOrderNumber();

        /// <summary>
        /// 配置项唯一名称
        /// </summary>
        /// <returns></returns>
        string GetUniqueName();
    }
}
