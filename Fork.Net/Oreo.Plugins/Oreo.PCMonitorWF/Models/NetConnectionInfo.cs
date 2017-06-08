using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oreo.PCMonitor.Models
{
    public class NetConnectionInfo
    {
        public string ProcessName { get; set; }
        public string ProtocolName { get; set; }
        public string LocalIP { get; set; }
        public int LocalPort { get; set; }
        public string RemoteIP { get; set; }
        public int RemotePort { get; set; }
        public string Status { get; set; }
    }
}
