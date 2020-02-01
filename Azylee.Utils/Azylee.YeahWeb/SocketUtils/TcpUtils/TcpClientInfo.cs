using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Azylee.YeahWeb.SocketUtils.TcpUtils
{
    public class TcpClientInfo
    {
        /// <summary>
        /// 唯一编号
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// 客户端远程终结点（IP:Port）
        /// </summary>
        public string Host { get; set; }
        /// <summary>
        /// 连接时间
        /// </summary>
        public DateTime ConnectTime { get; set; }
        /// <summary>
        /// 是否连接
        /// </summary>
        public bool IsConnect { get; set; }
        /// <summary>
        /// 连接密钥
        /// </summary>
        public string  ConnectKey { get; set; }
        /// <summary>
        /// 上行流量总计
        /// </summary>
        public long UploadFlowCount { get; set; }
        /// <summary>
        /// 最后发送数据时间
        /// </summary>
        public DateTime LastUploadTime { get; set; }
        /// <summary>
        /// 下行流量总计
        /// </summary>
        public long DownloadFlowCount { get; set; }
        /// <summary>
        /// 最后接受数据时间
        /// </summary>
        public DateTime LastDownloadTime { get; set; }
        /// <summary>
        /// 客户端对象
        /// </summary>
        public TcpClient Client { get; set; }
    }
}
