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
        /// 普通查询（异常时抛出异常，不能内部处理掉）
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        DataTable SelectWithException(string sql);

        /// <summary>
        /// 查询所有数据库名称
        /// </summary>
        /// <returns></returns>
        DataTable SchemaList();

        /// <summary>
        /// 查询表字段信息列表
        /// </summary>
        /// <returns></returns>
        DataTable ColumnList(string database, string schema,string table);

        /// <summary>
        /// 执行文件
        /// </summary>
        /// <param name="SqlFile">执行文件路径</param>
        /// <param name="action">执行后动作（执行语句，是否成功，影响行数，异常提示信息）</param>
        /// <returns></returns>
        Tuple<bool, int, string> ExecuteFile(string SqlFile, Action<string, bool, int, string> action);
        /// <summary>
        /// 执行文件SQL（一段SQL脚本）
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        Tuple<bool, int, string> ExecuteFileSql(string sql);
        /// <summary>
        /// 执行SQL（返回影响行数）
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        int ExecuteNonQuery(string sql);
        /// <summary>
        /// 查询表清单
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        List<DbmTable> QueryTables(string key = "");
        /// <summary>
        /// 查询表字段列表
        /// </summary>
        /// <param name="database"></param>
        /// <param name="schema"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        List<DbmColumn> QueryColumns(string database, string schema, string table);
    }
}
