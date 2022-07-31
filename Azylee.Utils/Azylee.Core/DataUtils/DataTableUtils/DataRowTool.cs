using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Azylee.Core.DataUtils.DataTableUtils
{
    public static class DataRowTool
    {
        public static string GetValue(DataRow row, string key)
        {
            string rs = "";
            try
            {
                if (row.Table.Columns.Contains(key))
                {
                    return row[key].ToString();
                }
            }
            catch { }
            return rs;
        }

        public static string GetValueWithNull(DataRow row, string key)
        {
            string rs = null;
            try
            {
                if (row.Table.Columns.Contains(key))
                {
                    if (!Convert.IsDBNull(row[key]))
                    {
                        rs = row[key]?.ToString();
                    }
                }
            }
            catch { }
            return rs;
        }
    }
}
