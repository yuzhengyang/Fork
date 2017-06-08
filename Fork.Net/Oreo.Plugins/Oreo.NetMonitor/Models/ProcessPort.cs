using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oreo.NetMonitor.Models
{
    public class ProcessPort
    {

        public int Port { get; set; }

        /// <summary>
        /// 协议
        /// </summary>
        public ProtocolType Type { get; set; }

        /// <summary>
        /// 本地地址
        /// </summary>
        public string LocalAddress { get; set; }

        /// <summary>
        /// 远程地址
        /// </summary>
        public string RemoteAddress { get; set; }

        /// <summary>
        /// 远程通信端口
        /// </summary>
        public int RemotePort { get; set; }
    }

    /// <summary>
    /// 支持的当前协议
    /// </summary>
    public enum ProtocolType
    {
        TCPType,
        UDPType
    }
}
