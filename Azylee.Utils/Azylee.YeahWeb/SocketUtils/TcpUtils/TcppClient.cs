using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.Core.ThreadUtils.SleepUtils;
using Azylee.Core.WindowsUtils.ConsoleUtils;
using Azylee.Jsons;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Azylee.YeahWeb.SocketUtils.TcpUtils
{
    public class TcppClient
    {
        const int ReceiveBufferSize = 1024;
        private string _IP = "";
        private int _Port = 52801;
        private TcpClient Client = null;
        private NetworkStream networkStream = null;

        Action OnConnectAction = null;
        Action OnDisconnectAction = null;
        Action<TcpDataModel> OnReceiveAction = null;
        ConcurrentQueue<Tuple<int, Action<TcpDataModel>>> SyncFunction = new ConcurrentQueue<Tuple<int, Action<TcpDataModel>>>();

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="onConnect">连接动作</param>
        /// <param name="onDisconnect">断开动作</param>
        /// <param name="onReceive">接收消息</param>
        public TcppClient(string ip, int port, Action onConnect, Action onDisconnect, Action<TcpDataModel> onReceive)
        {
            this._IP = ip;
            this._Port = port;

            OnConnectAction = onConnect;
            OnDisconnectAction = onDisconnect;
            OnReceiveAction = onReceive;
        }

        #region 连接和关闭连接
        /// <summary>
        /// 连接到TcpServer（重连）
        /// </summary>
        public bool Connect()
        {
            try
            {
                if (this.Client == null || !this.Client.Connected)
                {
                    this.Client = new TcpClient();
                    //this.Read();
                    IAsyncResult ar = this.Client.BeginConnect(this._IP, this._Port, acceptCallback, this.Client);
                    bool isConnect = ar.AsyncWaitHandle.WaitOne(1000);
                    if (isConnect) return true;
                }
            }
            catch { }
            return false;
        }
        /// <summary>
        /// 关闭连接
        /// </summary>
        public void Disconnect()
        {
            networkStream?.Close();
            Client?.Close();
        }
        #endregion

        #region 连接后的读写操作
        /// <summary>
        /// 发送数据（action禁止使用阻塞操作，必须新建task线程操作）
        /// </summary>
        /// <param name="model">数据模型</param>
        /// <param name="actionType">事件驱动处理类型</param>
        /// <param name="action">事件驱动处理方法</param>
        public bool Write(TcpDataModel model, int? actionType = 0, Action<TcpDataModel> action = null)
        {
            bool flag = false;
            if (Client != null && Client.Connected)
            {
                flag = TcpStreamHelper.Write(Client, model);
            }
            if (flag)
            {
                if (actionType != null && action != null)
                {
                    int type = actionType.GetValueOrDefault();
                    SyncFunction.Enqueue(new Tuple<int, Action<TcpDataModel>>(type, action));
                }
            }
            return flag;
        }
        /// <summary>
        /// 接受数据
        /// </summary>
        private void acceptCallback(IAsyncResult state)
        {
            try
            {
                this.Client = (TcpClient)state.AsyncState;
                this.Client.EndConnect(state);

                // c# 系统检测到在一个调用中尝试使用指针参数时的无效指针地址 怎么解决
                // 用管理身份运行cmd，执行 netsh winsock reset 重启问题解决
                //string host = this.Client.Client.RemoteEndPoint.ToString();
                ConnectTask(Client);
            }
            catch (Exception ex) { }
        }
        private void ConnectTask(TcpClient client)
        {
            Task.Factory.StartNew(() =>
            {
                OnConnectAction?.Invoke();//委托：已连接
                while (client.Connected)
                {
                    try
                    {
                        TcpDataModel model = TcpStreamHelper.Read(client);
                        if (model != null)
                        {
                            if (model.Type == int.MaxValue)
                            {
                                //返回心跳
                                Write(new TcpDataModel(int.MaxValue));
                            }
                            else
                            {
                                //优先调用默认接收消息方法Action
                                OnReceiveAction?.Invoke(model);

                                //调用同步处理委托方法
                                if (Ls.Ok(SyncFunction))
                                {
                                    for (var i = 0; i < SyncFunction.Count; i++)
                                    {
                                        bool flag = SyncFunction.TryDequeue(out Tuple<int, Action<TcpDataModel>> fun);
                                        if (flag)
                                        {
                                            Task.Factory.StartNew(() => { fun.Item2?.Invoke(model); });
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch { }
                    //Sleep.S(1);
                }
                client.Close();
                OnDisconnectAction?.Invoke();//委托：断开连接
            });
            //lstn.BeginAcceptTcpClient(new AsyncCallback(acceptCallback), lstn);
        }
        #endregion
    }
}