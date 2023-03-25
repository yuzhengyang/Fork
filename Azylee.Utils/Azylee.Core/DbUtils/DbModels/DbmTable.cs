using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.Core.DbUtils.DbModels
{
    public class DbmTable
    {
        public string Name { get; set; }
        public long Rows { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Comment { get; set; }
    }
}
