using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.BlackBox.Models
{
    /// <summary>
    /// 运行状态
    /// </summary>
    public class RunningStatus
    {
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime Time { get; set; }
        /// <summary>
        /// 统计时长
        /// </summary>
        public int Long { get; set; }
        /// <summary>
        /// 脱机时长
        /// </summary>
        public long AFK { get; set; }
        /// <summary>
        /// Cpu使用率
        /// </summary>
        public double CpuPer { get; set; }
        /// <summary>
        /// 内存容量
        /// </summary>
        public long RamSize { get; set; }
        /// <summary>
        /// 可用内存
        /// </summary>
        public long RamFree { get; set; }
        /// <summary>
        /// 系统盘容量
        /// </summary>
        public long SysDriveSize { get; set; }
        /// <summary>
        /// 可用系统盘容量
        /// </summary>
        public long SysDriveFree { get; set; }
        /// <summary>
        /// 应用程序Cpu使用率
        /// </summary>
        public double AppCpuPer { get; set; }
        /// <summary>
        /// 应用程序占用内存
        /// </summary>
        public double AppRamUsed { get; set; }
    }
}
