using System;
using System.Data;
using System.Drawing;

namespace Y.Utils.NetUtils.NetManUtils
{
    public class NetConnectionInfo
    {
        public string ProtocolName { get; set; }
        public string LocalIP { get; set; }
        public int LocalPort { get; set; }
        public string RemoteIP { get; set; }
        public int RemotePort { get; set; }
        public ConnectionState Status { get; set; }
        public DateTime LastUpdateTime { get; set; }
    }
}
