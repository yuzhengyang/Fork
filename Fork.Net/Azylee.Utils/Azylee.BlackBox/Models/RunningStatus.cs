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
        /// 主键
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime BeginTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 脱机时长
        /// </summary>
        public long AfkTime { get; set; }
        /// <summary>
        /// 操作使用率
        /// </summary>
        public double OperationUtilization { get; set; }
        /// <summary>
        /// Cpu使用率
        /// </summary>
        public double CpuUtilization { get; set; }
        /// <summary>
        /// 内存容量
        /// </summary>
        public long RamCapacity { get; set; }
        /// <summary>
        /// 已用内存
        /// </summary>
        public long RamUsed { get; set; }
        /// <summary>
        /// 内存使用率
        /// </summary>
        public double RamUtilization { get; set; }
        /// <summary>
        /// 系统盘容量
        /// </summary>
        public long SysDriveCapacity { get; set; }
        /// <summary>
        /// 已用系统盘容量
        /// </summary>
        public long SysDriveUsed { get; set; }
        /// <summary>
        /// 系统盘使用率
        /// </summary>
        public double SysDriveUtilization { get; set; }
        /// <summary>
        /// 应用程序Cpu使用率
        /// </summary>
        public double AppCpuUtilization { get; set; }
        /// <summary>
        /// 应用程序占用内存
        /// </summary>
        public double AppRamUsed { get; set; }
    }
}
