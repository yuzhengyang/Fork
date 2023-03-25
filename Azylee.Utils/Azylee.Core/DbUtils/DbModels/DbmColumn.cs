using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.Core.DbUtils.DbModels
{
    public class DbmColumn
    {
        public string Field { get; set; }
        public string Type { get; set; }
        public int Length { get; set; }
        public string Null { get; set; }
        public string Key { get; set; }
        public string Default { get; set; }
    }
}
