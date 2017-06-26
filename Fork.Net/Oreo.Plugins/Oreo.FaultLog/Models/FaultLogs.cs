using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oreo.FaultLog.Models
{
    public class FaultLogs
    {
        public int Id { get; set; }
        public string Dept { get; set; }
        public string User { get; set; }
        public string Phone { get; set; }
        public string Ip { get; set; }
        public string System { get; set; }
        public string Problem { get; set; }
        public string Solution { get; set; }
        public string Postscript { get; set; }
    }
}
