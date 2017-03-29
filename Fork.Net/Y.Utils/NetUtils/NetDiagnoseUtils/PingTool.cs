using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Y.Utils.NetUtils.NetDiagnoseUtils
{
    public class PingTool
    {
        public static bool CanPing(string ip)
        {
            return CanPing(ip, 120);
        }
        public static bool CanPing(string ip, int timeout)
        {
            try
            {
                Ping pingSender = new Ping();
                PingReply reply = pingSender.Send(ip, timeout);//第一个参数为ip地址，第二个参数为ping的时间
                if (reply.Status == IPStatus.Success)
                {
                    //ping的通
                    return true;
                }
                else
                {
                    //ping不通
                    return false;
                }
            }
            catch { }
            //异常
            return false;
        }
    }
}
