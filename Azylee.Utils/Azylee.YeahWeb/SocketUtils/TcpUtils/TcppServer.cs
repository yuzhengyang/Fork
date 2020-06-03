using Azylee.Core.ThreadUtils.SleepUtils;
using Azylee.Core.WindowsUtils.ConsoleUtils;
using Azylee.Jsons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Azylee.YeahWeb.SocketUtils.TcpUtils
{
    /// <summary>
    /// Tcp 服务工具
    /// </summary>
    public class TcppServer
    {
        const int ReceiveBufferSize = 1024;
        private List<byte> ReceiveByte = new List<byte>();
        private int _Port = 52801;
        TcpListener Listener = null;
        Action<TcpClientInfo> OnConnectAction = null;
        Action<TcpClientInfo> OnDisconnectAction = null;
        Action<TcpClientInfo, TcpDataModel> OnReceiveAction = null;
        public TcpClientManager TcpClientManager = new TcpClientManager();

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="port">端口号</param>
        /// <param name="onConnect">连接动作</param>
        /// <param name="onDisconnect">断开动作</param>
        /// <param name="onReceive">接收消息</param>
        public TcppServer(int port, Action<TcpClientInfo> onConnect, Action<TcpClientInfo> onDisconnect, Action<TcpClientInfo, TcpDataModel> onReceive)
        {
            _Port = port;

            OnConnectAction = onConnect;
            OnDisconnectAction = onDisconnect;
            OnReceiveAction = onReceive;
        }

        #region 启动和停止服务
        /// <summary>
        /// 启动服务
        /// </summary>
        public void Start()
        {
            this.Listener = new TcpListener(IPAddress.Any, _Port);
            this.Listener.Start();
            this.Listener.BeginAcceptTcpClient(new AsyncCallback(acceptCallback), this.Listener);
        }
        /// <summary>
        /// 停止服务
        /// </summary>
        public void Stop()
        {
            foreach (var client in TcpClientManager.GetAll())
            {
                client?.Client?.Close();
            }
            Listener?.Stop();
        }
        #endregion

        #region 连接后的读写操作
        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="host">主机地址</param>
        /// <param name="model">数据模型</param>
        public bool Write(string host, TcpDataModel model)
        {
            var dictionary = TcpClientManager.GetInfoByHost(host);
            if (dictionary != null && dictionary.Client != null)
            {
                if (dictionary.Client.Connected)
                {
                    TcpClientManager.UpdateUploadFlowCount(host, model.Data.Length);
                    bool flag = TcpStreamHelper.Write(dictionary.Client, model);
                    return flag;
                }
            }
            return false;
        }

        private void acceptCallback(IAsyncResult state)
        {
            try
            {
                TcpListener lstn = (TcpListener)state.AsyncState;
                TcpClient client = lstn.EndAcceptTcpClient(state);
                string host = client.Client.RemoteEndPoint.ToString();

                TcpClientManager.AddOrUpdate(host, client);
                ConnectTask(host, client);

                lstn.BeginAcceptTcpClient(new AsyncCallback(acceptCallback), lstn);
            }
            catch { }
        }
        private void ConnectTask(string host, TcpClient client)
        {
            TcpClientInfo clientInfo = TcpClientManager.GetInfoByHost(host);

            //发送心跳
            Task.Factory.StartNew(() =>
            {
                while (client.Connected)
                {
                    TcpDataModel model = new TcpDataModel(int.MaxValue);
                    TcpStreamHelper.Write(client, model);

                    Sleep.S(5);
                    //if (DateTime.Now.AddSeconds(-10) > HeartbeatTime)
                    //    client.Close();
                    Sleep.S(5);
                }
            });
            //接收消息
            Task.Factory.StartNew(() =>
            {
                OnConnectAction?.Invoke(clientInfo);//委托：已连接
                while (client.Connected)
                {
                    try
                    {
                        TcpDataModel model = TcpStreamHelper.Read(client);
                        if (model != null)
                        {
                            if (model.Type == int.MaxValue)
                            {
                                //过滤心跳，并记录心跳时间
                                TcpClientManager.UpdateHeartbeatTime(host);
                            }
                            else
                            {
                                TcpClientManager.UpdateDownloadFlowCount(host, model.Data.Length);
                                OnReceiveAction(clientInfo, model);//委托：接收消息
                            }
                        }
                    }
                    catch { }
                    //Sleep.S(1);
                }
                client.Close();
                TcpClientManager.RemoveByHost(host);
                OnDisconnectAction?.Invoke(clientInfo);//委托：断开连接
            });
        }
        #endregion
    }
}
