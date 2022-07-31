using System;
using System.Collections.Generic;
using System.Data;
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
    }
}
