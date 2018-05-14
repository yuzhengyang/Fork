using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace Azylee.Core.NetUtils
{
    public class PingTool
    {
        public static bool Ping(string ip)
        {
            try
            {
                Ping _ping = new Ping();
                PingReply _reply = _ping.Send(ip);
                return _reply.Status == IPStatus.Success ? true : false;
            }
            catch { return false; }
        }
    }
}
