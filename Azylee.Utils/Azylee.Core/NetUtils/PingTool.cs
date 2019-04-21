//************************************************************************
//      author:     yuzhengyang
//      date:       2018.3.27 - 2018.6.3
//      desc:       工具描述
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************
using Azylee.Core.NetUtils.NetAddressUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace Azylee.Core.NetUtils
{
    /// <summary>
    /// Ping 工具
    /// </summary>
    public class PingTool
    {
        /// <summary>
        /// Ping 指定 IP 地址
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 判断是否连接互联网
        /// </summary>
        /// <returns></returns>
        public static bool Internet()
        {
            try
            {
                Ping _ping = new Ping();
                PingReply _reply = _ping.Send(DNSTool.AliDNS);
                if (_reply.Status == IPStatus.Success && _reply.Address.ToString() == DNSTool.AliDNS) return true;
            }
            catch { }
            try
            {
                Ping _ping = new Ping();
                PingReply _reply = _ping.Send(DNSTool.BaiduDNS);
                if (_reply.Status == IPStatus.Success && _reply.Address.ToString() == DNSTool.BaiduDNS) return true;
            }
            catch { }
            return false;
        }
    }
}
