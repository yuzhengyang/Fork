using Azylee.Core.DataUtils.CollectionUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Azylee.YeahWeb.SocketUtils.TcpUtils
{
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
                    var model = new TcpClientInfo()
                    {
                        Number = HostNumber,
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
