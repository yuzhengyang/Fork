using Azylee.Core.DataUtils.StringUtils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Azylee.Core.DataUtils.DataTableUtils
{
    public class DataTableTool
    {
        public static bool Ok(DataTable table)
        {
            if (table != null && table.Rows != null && table.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public static List<Dictionary<string, object>> ToDictionary(DataTable data, NameType nameType = NameType.NONE)
        {
            List<Dictionary<string, object>> result = new List<Dictionary<string, object>>();
            if (Ok(data))
            {
                List<string> colNames = new List<string>();
                foreach (DataColumn col in data.Columns) colNames.Add(col.ColumnName);

                foreach (DataRow row in data.Rows)
                {
                    Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
                    foreach (string name in colNames)
                    {
                        keyValuePairs.Add(NameFormat.Format(name, nameType), row[name]);
                    }
                    result.Add(keyValuePairs);
                }
            }
            return result;
        }
    }
}
