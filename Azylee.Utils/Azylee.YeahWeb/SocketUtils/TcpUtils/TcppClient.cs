using Azylee.Core.ThreadUtils.SleepUtils;
using Azylee.Core.WindowsUtils.ConsoleUtils;
using Azylee.Jsons;
using System;
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

        TcpDelegate.ReceiveMessage ReceiveMessage;
        TcpDelegate.OnConnect OnConnect;
        TcpDelegate.OnDisconnect OnDisconnect;

        //public TcpDataConverter.Message ReceiveMessage;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public TcppClient(string ip, int port,
            TcpDelegate.ReceiveMessage receive,
              TcpDelegate.OnConnect connect,
               TcpDelegate.OnDisconnect disconnect)
        {
            this._IP = ip;
            this._Port = port;

            ReceiveMessage += receive;
            OnConnect += connect;
            OnDisconnect += disconnect;
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
        /// 发送数据
        /// </summary>
        /// <param name="model">数据模型</param>
        public void Write(TcpDataModel model)
        {
            if (this.Client != null && this.Client.Connected)
            {
                bool flag = TcpStreamHelper.Write(Client, model);
            }
        }
        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="data">数据</param>
        public void Write(int type, byte[] data)
        {
            Write(new TcpDataModel() { Type = type, Data = data });
        }
        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="s">字符串</param>
        public void Write(int type, string s)
        {
            Write(new TcpDataModel() { Type = type, Data = Json.Object2Byte(s) });
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

                string host = this.Client.Client.RemoteEndPoint.ToString();
                ConnectTask(host, this.Client);
            }
            catch { }
        }
        private void ConnectTask(string host, TcpClient client)
        {
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
                                //返回心跳
                                Write(new TcpDataModel() { Type = int.MaxValue });
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
                OnDisconnect?.Invoke(host);//委托：断开连接
            });
            //lstn.BeginAcceptTcpClient(new AsyncCallback(acceptCallback), lstn);
        }
        #endregion
    }
}