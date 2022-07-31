using Azylee.Core.DataUtils.DataTableUtils;
using Azylee.Core.DataUtils.StringUtils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Azylee.Core.DbUtils.DbSqls
{
    /// <summary>
    /// Sql语句生成
    /// </summary>
    public static class SqlGenerate
    {
        /// <summary>
        /// 生成insert语句
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="table">数据表</param>
        /// <param name="insertSql">插入语句，默认：INSERT INTO，可自定义为：INSERT IGNORE INTO</param>
        /// <param name="splitLine">按VALUES分割行</param>
        /// <param name="spaceLine">每行间隔空行</param>
        /// <returns></returns>
        public static List<string> Insert(string tableName, DataTable table, string insertSql = "INSERT INTO", bool splitLine = false, bool spaceLine = false)
        {
            List<string> list = new List<string>();
            if (DataTableTool.Ok(table))
            {
                // 获取所有列名
                List<string> colNameList = new List<string>();
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    DataColumn column = table.Columns[i];
                    if (StringTool.Ok(column.ColumnName)) colNameList.Add(column.ColumnName);
                }

                // 遍历所有行，转换为插入语句
                for (int j = 0; j < table.Rows.Count; j++)
                {
                    DataRow row = table.Rows[j];
                    string cols = "", vals = "";

                    for (int k = 0; k < colNameList.Count; k++)
                    {
                        string value = DataRowTool.GetValueWithNull(row, colNameList[k]);

                        cols += $"`{colNameList[k]}`";
                        if (k < colNameList.Count - 1) cols += ", ";

                        vals += value != null ? $"'{value}'" : "NULL";
                        if (k < colNameList.Count - 1) vals += ", ";
                    }
                    string _splitLine = splitLine ? Environment.NewLine : "";
                    string _spaceLine = spaceLine ? Environment.NewLine : "";
                    string sql = $"{insertSql} `{tableName}` ({cols}) {_splitLine}VALUES ({vals});{_spaceLine}";
                    list.Add(sql);
                }

            }
            return list;
        }
    }
}
