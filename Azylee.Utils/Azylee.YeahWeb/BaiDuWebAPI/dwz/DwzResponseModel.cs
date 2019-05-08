using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.YeahWeb.BaiDuWebAPI.dwz
{
    /// <summary>
    /// 短网址响应结果模型
    /// </summary>
    public class DwzResponseModel
    {
        /// <summary>
        /// 0：正常返回短网址，
        /// -1：短网址生成失败，
        /// -2：长网址不合法，
        /// -3：长网址存在安全隐患，
        /// -4：长网址插入数据库失败，
        /// -5：长网址在黑名单中，不允许注册
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 短网址
        /// </summary>
        public string ShortUrl { get; set; }
        /// <summary>
        /// 长网址（原网址）
        /// </summary>
        public string LongUrl { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrMsg { get; set; }
    }
}
