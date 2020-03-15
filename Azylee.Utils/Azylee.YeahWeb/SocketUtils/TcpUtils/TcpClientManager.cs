using Azylee.Core.DataUtils.CollectionUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Azylee.YeahWeb.SocketUtils.TcpUtils
{
    /// <summary>
    /// 客户端信息管理器
    /// </summary>
    public class TcpClientManager
    {
        private int HostNumber { get; set; }
        private List<TcpClientInfo> TcpClientList { get; set; }
        /// <summary>
        /// 构造方法（初始化标号起始标记6位，初始化客户端列表）
        /// </summary>
        public TcpClientManager()
        {
            HostNumber = 100000;
            TcpClientList = new List<TcpClientInfo>();
        }


        #region 统计项
        /// <summary>
        /// 当前连接客户端总数
        /// </summary>
        /// <returns></returns>
        public int CountClient()
        {
            return TcpClientList.Count();
        }
        #endregion

        #region 判定项
        public bool IsExistByNumber(int number)
        {
            if (Ls.Ok(TcpClientList))
            {
                return TcpClientList.Any(x => x.Number == number);
            }
            return false;
        }
        public bool IsExistByHost(string host)
        {
            if (Ls.Ok(TcpClientList))
            {
                return TcpClientList.Any(x => x.Host == host);
            }
            return false;
        }
        public bool IsConnectKey(string host, string key)
        {
            var item = GetInfoByHost(host);
            if (item != null) return item.ConnectKey == key;
            return false;
        }
        #endregion


        #region 查询项
        public List<TcpClientInfo> GetAll()
        {
            return TcpClientList;
        }
        public TcpClientInfo GetInfoByNumber(int number)
        {
            if (IsExistByNumber(number))
            {
                return TcpClientList.FirstOrDefault(x => x.Number == number);
            }
            return null;
        }
        public TcpClientInfo GetInfoByHost(string host)
        {
            TcpClientInfo client = null;
            try
            {
                if (IsExistByHost(host))
                {
                    client = TcpClientList.FirstOrDefault(x => x.Host == host);
                }
            }
            catch { }
            return client;
        }
        #endregion

        #region 添加项
        /// <summary>
        /// 添加或更新到客户端列表
        /// </summary>
        public int AddOrUpdate(string host, TcpClient client)
        {
            try
            {
                HostNumber++;
                var item = TcpClientList.FirstOrDefault(x => x.Host == host);
                if (item == null)
                {
                    string ip = "";
                    int ipFlagIndex = host.IndexOf(":");
                    if (ipFlagIndex > 0) ip = host.Substring(0, ipFlagIndex);

                    var model = new TcpClientInfo()
                    {
                        Number = HostNumber,
                        IP = ip,
                        Host = host,
                        Client = client,
                        IsConnect = true,
                        ConnectTime = DateTime.Now
                    };
                    TcpClientList.Add(model);
                    return model.Number;
                }
                else
                {
                    item.Client = client;
                }
            }
            catch { }
            return 0;
        }
        #endregion

        #region 更新项
        /// <summary>
        /// 更新 ConnectKey 连接秘钥
        /// </summary>
        /// <param name="host"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool UpdateConnectKey(string host, string s)
        {
            if (IsExistByHost(host))
            {
                for (var i = 0; i < TcpClientList.Count; i++)
                {
                    if (TcpClientList[i].Host == host)
                    {
                        TcpClientList[i].ConnectKey = s;
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// 更新 UserEmail 用户邮箱
        /// </summary>
        /// <param name="host"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool UpdateUserEmail(string host, string s)
        {
            if (IsExistByHost(host))
            {
                for (var i = 0; i < TcpClientList.Count; i++)
                {
                    if (TcpClientList[i].Host == host)
                    {
                        TcpClientList[i].UserEmail = s;
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// 更新 AccessCode 权限编码
        /// </summary>
        /// <param name="host"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool UpdateAccessCode(string host, string s)
        {
            if (IsExistByHost(host))
            {
                for (var i = 0; i < TcpClientList.Count; i++)
                {
                    if (TcpClientList[i].Host == host)
                    {
                        TcpClientList[i].AccessCode = s;
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// 更新 MachineID 主机ID
        /// </summary>
        /// <param name="host"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool UpdateMachineID(string host, string s)
        {
            if (IsExistByHost(host))
            {
                for (var i = 0; i < TcpClientList.Count; i++)
                {
                    if (TcpClientList[i].Host == host)
                    {
                        TcpClientList[i].MachineID = s;
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// 更新 MachineName 主机名称
        /// </summary>
        /// <param name="host"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool UpdateMachineName(string host, string s)
        {
            if (IsExistByHost(host))
            {
                for (var i = 0; i < TcpClientList.Count; i++)
                {
                    if (TcpClientList[i].Host == host)
                    {
                        TcpClientList[i].MachineName = s;
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// 更新 UserName 用户名
        /// </summary>
        /// <param name="host"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool UpdateUserName(string host, string s)
        {
            if (IsExistByHost(host))
            {
                for (var i = 0; i < TcpClientList.Count; i++)
                {
                    if (TcpClientList[i].Host == host)
                    {
                        TcpClientList[i].UserName = s;
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// 更新 AppCode 应用程序编码
        /// </summary>
        /// <param name="host"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool UpdateAppCode(string host, string s)
        {
            if (IsExistByHost(host))
            {
                for (var i = 0; i < TcpClientList.Count; i++)
                {
                    if (TcpClientList[i].Host == host)
                    {
                        TcpClientList[i].AppCode = s;
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// 更新上行流量
        /// </summary>
        /// <param name="host"></param>
        /// <param name="flow"></param>
        /// <returns></returns>
        public bool UpdateUploadFlowCount(string host, long flow)
        {
            if (IsExistByHost(host))
            {
                for (var i = 0; i < TcpClientList.Count; i++)
                {
                    if (TcpClientList[i].Host == host)
                    {
                        TcpClientList[i].UploadFlowCount += flow;
                        TcpClientList[i].LastUploadTime = DateTime.Now;
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// 更新下行流量
        /// </summary>
        /// <param name="host"></param>
        /// <param name="flow"></param>
        /// <returns></returns>
        public bool UpdateDownloadFlowCount(string host, long flow)
        {
            if (IsExistByHost(host))
            {
                for (var i = 0; i < TcpClientList.Count; i++)
                {
                    if (TcpClientList[i].Host == host)
                    {
                        TcpClientList[i].DownloadFlowCount += flow;
                        TcpClientList[i].LastDownloadTime = DateTime.Now;
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// 更新心跳时间
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        public bool UpdateHeartbeatTime(string host)
        {
            if (IsExistByHost(host))
            {
                for (var i = 0; i < TcpClientList.Count; i++)
                {
                    if (TcpClientList[i].Host == host)
                    {
                        TcpClientList[i].HeartbeatTime = DateTime.Now;
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion

        #region 删除项
        public int RemoveByNumber(int number)
        {
            try
            {
                return TcpClientList.RemoveAll(x => x.Number == number);
            }
            catch { }
            return 0;
        }
        public int RemoveByHost(string host)
        {
            try
            {
                return TcpClientList.RemoveAll(x => x.Host == host);
            }
            catch { }
            return 0;
        }
        #endregion
    }
}
