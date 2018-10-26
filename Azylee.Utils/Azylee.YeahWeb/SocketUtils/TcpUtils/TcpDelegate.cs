using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.YeahWeb.SocketUtils.TcpUtils
{
    /// <summary>
    /// Tcp 工具 委托声明
    /// </summary>
    public class TcpDelegate
    {
        /// <summary>
        /// 接受消息委托
        /// </summary>
        /// <param name="host"></param>
        /// <param name="model"></param>
        public delegate void ReceiveMessage(string host, TcpDataModel model);
        /// <summary>
        /// Tcp 连接消息委托
        /// </summary>
        /// <param name="host"></param>
        public delegate void OnConnect(string host);
        /// <summary>
        /// Tcp 断开连接消息委托
        /// </summary>
        /// <param name="host"></param>
        public delegate void OnDisconnect(string host);
    }
}
