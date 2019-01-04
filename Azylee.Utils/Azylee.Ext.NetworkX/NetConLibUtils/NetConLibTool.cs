using NETCONLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.Ext.NetworkX.NetConLibUtils
{
    /// <summary>
    /// NetConLib 操作工具类
    /// </summary>
    public static class NetConLibTool
    {
        /// <summary>
        /// 启用所有网络
        /// </summary>
        public static void Connect()
        {
            try
            {
                NetSharingManagerClass netSharingMgr = new NetSharingManagerClass();
                INetSharingEveryConnectionCollection connections = netSharingMgr.EnumEveryConnection;
                foreach (INetConnection connection in connections)
                {
                    try { connection.Connect(); } catch { }

                    // // // //INetConnectionProps connProps = netSharingMgr.get_NetConnectionProps(connection);
                    // // // //if (connProps.MediaType == tagNETCON_MEDIATYPE.NCM_LAN)
                    // // // //    try { connection.Connect(); } catch { }
                }
            }
            catch { }
        }
        /// <summary>
        /// 禁用所有网络
        /// </summary>
        public static void Disconnect()
        {
            try
            {
                NetSharingManagerClass netSharingMgr = new NetSharingManagerClass();
                INetSharingEveryConnectionCollection connections = netSharingMgr.EnumEveryConnection;
                foreach (INetConnection connection in connections)
                {
                    try { connection.Disconnect(); } catch { }
                }
            }
            catch { }
        }
    }
}