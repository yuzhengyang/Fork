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
        TcpDelegate.ReceiveMessage ReceiveMessage;
        TcpDelegate.OnConnect OnConnect;
        TcpDelegate.OnDisconnect OnDisconnect;
        List<TcpClientDictionary> Clients = new List<TcpClientDictionary>();

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="port">端口号</param>
        /// <param name="receive">接收消息</param>
        /// <param name="connect">连接动作</param>
        /// <param name="disconnect">断开动作</param>
        public TcppServer(int port,
            TcpDelegate.ReceiveMessage receive,
              TcpDelegate.OnConnect connect,
               TcpDelegate.OnDisconnect disconnect)
        {
            _Port = port;

            ReceiveMessage += receive;
            OnConnect += connect;
            OnDisconnect += disconnect;
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
            foreach (var client in Clients)
            {
                client?.Client?.Close();
            }
            Clients.Clear();
            this.Listener?.Stop();
        }
        #endregion

        #region 连接后的读写操作
        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="host">主机地址</param>
        /// <param name="model">数据模型</param>
        public void Write(string host, TcpDataModel model)
        {
            var dictionary = Clients_Get(host);
            if (dictionary != null && dictionary.Client != null)
            {
                if (dictionary.Client.Connected)
                {
                    bool flag = TcpStreamHelper.Write(dictionary.Client, model);
                }
            }
        }
        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="host">主机地址</param>
        /// <param name="type">类型</param>
        /// <param name="data">数据</param>
        public void Write(string host, int type, byte[] data)
        {
            Write(host, new TcpDataModel() { Type = type, Data = data });
        }
        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="host">主机地址</param>
        /// <param name="type">类型</param>
        /// <param name="s">字符串</param>
        public void Write(string host, int type, string s)
        {
            Write(host, new TcpDataModel() { Type = type, Data = Json.Object2Byte(s) });
        }

        private void acceptCallback(IAsyncResult state)
        {
            try
            {
                TcpListener lstn = (TcpListener)state.AsyncState;
                TcpClient client = lstn.EndAcceptTcpClient(state);
                string host = client.Client.RemoteEndPoint.ToString();

                Clients_Add_Update(host, client);
                ConnectTask(host, client);

                lstn.BeginAcceptTcpClient(new AsyncCallback(acceptCallback), lstn);
            }
            catch { }
        }
        private void ConnectTask(string host, TcpClient client)
        {
            DateTime HeartbeatTime = DateTime.Now;

            //发送心跳
            Task.Factory.StartNew(() =>
            {
                while (client.Connected)
                {
                    TcpDataModel model = new TcpDataModel() { Type = int.MaxValue };
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
                OnConnect?.Invoke(host);//委托：已连接
                while (client.Connected)
                {
                    try
                    {
                        TcpDataModel model = TcpStreamHelper.Read(client);
                        if (model != null)
                        {
                            if (model.Type == int.MaxValue)
                            {
                                //过滤心跳
                                HeartbeatTime = DateTime.Now;
                            }
                            else
                            {
                                ReceiveMessage(host, model);//委托：接收消息
                            }
                        }
                    }
                    catch { }
                    //Sleep.S(1);
                }
                client.Close();
                Clients_Del(host);
                OnDisconnect?.Invoke(host);//委托：断开连接
            });
        }
        #endregion

        #region 连接的客户端列表维护
        /// <summary>
        /// 获取连接的客户端
        /// </summary>
        /// <returns></returns>
        private TcpClientDictionary Clients_Get(string host)
        {
            TcpClientDictionary client = null;
            try
            {
                client = Clients.FirstOrDefault(x => x.Host == host);
            }
            catch { }
            return client;
        }
        /// <summary>
        /// 添加或更新到客户端列表
        /// </summary>
        private void Clients_Add_Update(string host, TcpClient client)
        {
            try
            {
                var item = Clients.FirstOrDefault(x => x.Host == host);
                if (item == null)
                {
                    Clients.Add(new TcpClientDictionary() { Host = host, Client = client });
                }
                else
                {
                    item.Client = client;
                }
            }
            catch { }
        }
        /// <summary>
        /// 从客户端列表中删除
        /// </summary>
        private int Clients_Del(string host)
        {
            int count = 0;
            try
            {
                count = Clients.RemoveAll(x => x.Host == host);
            }
            catch { }
            return count;
        }
        /// <summary>
        /// 当前连接客户端总数
        /// </summary>
        /// <returns></returns>
        public int ClientsCount()
        {
            return Clients.Count();
        }
        #endregion
    }
}
