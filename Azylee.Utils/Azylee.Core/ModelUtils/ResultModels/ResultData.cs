using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.Core.ModelUtils.ResultModels
{
    /// <summary>
    /// 用于方法执行返回结果
    /// </summary>
    public class ResultData
    {
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 成功与否
        /// </summary>
        public bool IsSuccess { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public ResultData()
        {

        }
        /// <summary>
        /// 自定义构造函数
        /// </summary>
        /// <param name="isSucc"></param>
        /// <param name="desc"></param>
        public ResultData(bool isSucc, string desc)
        {
            IsSuccess = isSucc;
            Description = desc;
        }
        /// <summary>
        /// 初始化（默认为异常结果）
        /// </summary>
        /// <returns></returns>
        public static ResultData InitForError()
        {
            return new ResultData()
            {
                IsSuccess = false,
                Status = -1,
                Description = "未知异常"
            };
        }
    }
}
