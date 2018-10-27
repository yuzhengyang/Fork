using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Azylee.YeahWeb.SocketUtils.TcpUtils
{
    public class TcpClientDictionary
    {
        public string Host { get; set; }
        public TcpClient Client { get; set; }
    }
}
