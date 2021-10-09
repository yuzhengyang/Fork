using Azylee.Core.AppUtils.AppConfigUtils.AppConfigModels;
using Azylee.Core.DbUtils.DbModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Azylee.Core.DbUtils.DbInterface
{
    /// <summary>
    /// 数据库工具类接口定义
    /// </summary>
    public interface IDatabaseHelper : IDisposable
    {
        /// <summary>
        /// 创建并打开连接
        /// 注意：通常在构造函数中直接调用
        /// </summary>
        /// <returns></returns>
        bool OpenConnect();

        /// <summary>
        /// 测试连接
        /// </summary>
        /// <returns></returns>
        bool TestConnect();

        /// <summary>
        /// 普通查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        DataTable Select(string sql);
        /// <summary>
        /// 查询所有数据库名称
        /// </summary>
        /// <returns></returns>
        DataTable SchemaList();

        /// <summary>
        /// 执行文件
        /// </summary>
        /// <param name="SqlFile"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        Tuple<bool, int, string> ExecuteFile(string SqlFile, Action<string, bool, int, string> action);
    }
}
