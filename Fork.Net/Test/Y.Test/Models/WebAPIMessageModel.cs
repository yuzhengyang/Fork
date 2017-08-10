using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Y.Test.Models
{
    public class WebAPIMessageModel
    {
        /// <summary>
        /// 操作成功
        /// </summary>
        public bool IsSucc { get; set; }
        /// <summary>
        /// 错误码
        /// </summary>
        public int ErrorCode { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMsg { get; set; }
        /// <summary>
        /// 返回信息类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 信息
        /// </summary>
        public string Text { get; set; }
    }
}
