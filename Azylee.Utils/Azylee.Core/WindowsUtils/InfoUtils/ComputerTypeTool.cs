using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;

namespace Azylee.Core.WindowsUtils.InfoUtils
{
    /// <summary>
    /// 获取计算机类型
    /// </summary>
    public static class ComputerTypeTool
    {
        /// <summary>
        /// 获取类型
        /// </summary>
        /// <returns></returns>
        public static ComputerType Get()
        {
            ComputerType type = ComputerType.Unknown;
            try
            {
                ManagementClass systemEnclosures = new ManagementClass("Win32_SystemEnclosure");
                foreach (ManagementObject obj in systemEnclosures.GetInstances())
                {
                    foreach (ComputerType i in (short[])(obj["ChassisTypes"]))
                    {
                        type = i;
                    }
                }
            }
            catch { }
            return type;
        }
    }
}
