//************************************************************************
//      https://github.com/yuzhengyang
//      author:     yuzhengyang
//      date:       2017.3.29 - 2017.7.12
//      desc:       网卡信息工具类
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using Y.Utils.DataUtils.Collections;

namespace Y.Utils.NetUtils.NetInfoUtils
{
    public class NetCardInfoTool
    {
        /// <summary>
        /// 获取网卡信息
        /// 【名称、描述、物理地址（Mac）、Ip地址、网关地址】
        /// </summary>
        /// <returns></returns>
        public static List<Tuple<string, string, string, string, string>> GetNetworkCardInfo()
        {
            try
            {
                List<Tuple<string, string, string, string, string>> result = new List<Tuple<string, string, string, string, string>>();
                NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
                foreach (var item in adapters)
                {
                    if (item.NetworkInterfaceType == NetworkInterfaceType.Ethernet || item.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                    {
                        string _name = item.Name.Trim();
                        string _desc = item.Description.Trim();
                        string _mac = item.GetPhysicalAddress().ToString();
                        string _ip = item.GetIPProperties().UnicastAddresses.Count >= 2 ?
                            item.GetIPProperties().UnicastAddresses[1].Address.ToString() : null;
                        string _gateway = item.GetIPProperties().GatewayAddresses.Count >= 1 ?
                            item.GetIPProperties().GatewayAddresses[0].Address.ToString() : null;
                        result.Add(new Tuple<string, string, string, string, string>(_name, _desc, _mac, _ip, _gateway));
                    }
                }
                return result;
            }
            catch (NetworkInformationException e)
            {
                return null;
            }
        }
        /// <summary>
        /// 获取网卡实例名称
        /// </summary>
        /// <returns></returns>
        public static string[] GetInstanceNames()
        {
            string[] instances = null;
            try
            {
                PerformanceCounterCategory performanceCounterCategory = new PerformanceCounterCategory("Network Interface");
                instances = performanceCounterCategory.GetInstanceNames();
            }
            catch { }
            return instances;
        }

        /// <summary>
        /// 获取本机IPv4的IP地址
        /// </summary>
        /// <returns></returns>
        public static List<IPAddress> GetIPv4Address()
        {
            List<IPAddress> hosts = new List<IPAddress>();
            try
            {
                var temp = Dns.GetHostAddresses(Dns.GetHostName());
                if (ListTool.HasElements(temp))
                {
                    foreach (var t in temp)
                    {
                        if (t.AddressFamily == AddressFamily.InterNetwork)
                        {
                            hosts.Add(t);
                        }
                    }
                }
            }
            catch (Exception e) { }
            return hosts;
        }
        /// <summary>
        /// 获取本机IPv4的IP地址
        /// </summary>
        /// <returns></returns>
        public static List<string> GetAllIPv4Address()
        {
            List<string> hosts = new List<string>();
            try
            {
                var temp = Dns.GetHostAddresses(Dns.GetHostName());
                if (ListTool.HasElements(temp))
                {
                    foreach (var t in temp)
                    {
                        if (t.AddressFamily == AddressFamily.InterNetwork)
                        {
                            hosts.Add(t.ToString());
                        }
                    }
                }
            }
            catch (Exception e) { }
            hosts.Add("0.0.0.0");
            hosts.Add("127.0.0.1");
            return hosts;
        }
    }
}
