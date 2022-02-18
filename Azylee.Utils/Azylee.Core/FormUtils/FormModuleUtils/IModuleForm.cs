using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Azylee.Core.FormUtils.FormModuleUtils
{
    /// <summary>
    /// 窗体模块接口定义
    /// </summary>
    public interface IModuleForm
    {
        /// <summary>
        /// 窗体初始化，触发点在Load前
        /// </summary>
        /// <param name="args"></param>
        void Init(Dictionary<string, object> args);
    }
}
