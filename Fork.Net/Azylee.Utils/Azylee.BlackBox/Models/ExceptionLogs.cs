using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.BlackBox.Models
{
    /// <summary>
    /// 异常日志
    /// </summary>
    public class ExceptionLogs
    {
        /// <summary>
        /// 主键
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 关键字
        /// </summary>
        public string Keywords { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 异常名称
        /// </summary>
        public string ExceptionName { get; set; }
        /// <summary>
        /// 异常消息
        /// </summary>
        public string ExceptionMessage { get; set; }
        /// <summary>
        /// 异常跟踪
        /// </summary>
        public string ExceptionStackTrace { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
