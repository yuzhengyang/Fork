using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Azylee.YeahWeb.SocketUtils.TcpUtils
{
    /// <summary>
    /// 客户端信息
    /// </summary>
    public class TcpClientInfo
    {
        #region 连接基础信息
        /// <summary>
        /// 唯一编号（每次登录都不一样）
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// 客户端应用程序编码（应用程序区分）
        /// </summary>
        public string AppCode { get; set; }
        /// <summary>
        /// 连接密钥
        /// </summary>
        public string ConnectKey { get; set; }
        /// <summary>
        /// 客户端远程终结点IP
        /// </summary>
        public string IP { get; set; }
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
        #endregion

        #region 用户信息及认证
        /// <summary>
        /// 权限编码（可扩展权限管理功能）
        /// </summary>
        public string AccessCode { get; set; }
        /// <summary>
        /// 用户邮箱
        /// </summary>
        public string UserEmail { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 主机ID
        /// </summary>
        public string MachineID { get; set; }
        /// <summary>
        /// 主机名称
        /// </summary>
        public string MachineName { get; set; }
        #endregion

        #region 扩展信息
        /// <summary>
        /// 公网IP地址
        /// </summary>
        //public string  PublicIP { get; set; }
        /// <summary>
        /// 扩展数据
        /// </summary>
        //public Dictionary<string, string> ExtData { get; set; }
        #endregion

        #region 流量管理
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
        /// 心跳通信时间
        /// </summary>
        public DateTime HeartbeatTime { get; set; }
        #endregion

        #region 连接对象
        /// <summary>
        /// 客户端对象
        /// </summary>
        public TcpClient Client { get; set; }
        #endregion
    }
}
