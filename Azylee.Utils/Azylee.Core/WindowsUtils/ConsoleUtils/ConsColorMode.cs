using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.Core.WindowsUtils.ConsoleUtils
{
    /// <summary>
    /// 控制台颜色模式
    /// </summary>
    public enum ConsColorMode
    {
        /// <summary>
        /// 默认
        /// </summary>
        Default,
        /// <summary>
        /// 柔和
        /// </summary>
        Muted,
        /// <summary>
        /// 重要
        /// </summary>
        Primary,
        /// <summary>
        /// 副标题
        /// </summary>
        Secondary,
        /// <summary>
        /// 成功
        /// </summary>
        Success,
        /// <summary>
        /// 提示
        /// </summary>
        Info,
        /// <summary>
        /// 警告
        /// </summary>
        Warning,
        /// <summary>
        /// 危险
        /// </summary>
        Danger,
        /// <summary>
        /// 深色
        /// </summary>
        Dark,
        /// <summary>
        /// 浅色
        /// </summary>
        Light,
    }
}
