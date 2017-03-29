using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Y.Utils.NetUtils.SocketUtils
{
    public class SocketTool : IDisposable
    {
        const int ReceiveBufferSize = 1024;

        private string _IP;
        private int _Port;
        private bool IsReceive = false;
        private List<byte> ReceiveByte = new List<byte>();
        private readonly object ReceiveLock = new object();

        public string IP { get; }
        public int Port { get; }
        private IPAddress IPAddress { get; set; }
        private IPEndPoint IPEndPoint { get; set; }
        public Socket Socket { get; set; }

        public delegate void GetByteDelegate(byte[] b);
        public GetByteDelegate ReceiveByteContent;

        private SocketTool() { }

        public SocketTool(string ip, int port)
        {
            _IP = ip;
            _Port = port;
            IPAddress = IPAddress.Parse(ip);
            IPEndPoint = new IPEndPoint(IPAddress, port);
        }

        public bool Connect()
        {
            try
            {
                if (Socket != null)
                {
                    return true;
                }
                else
                {
                    Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    Socket.Connect(IPEndPoint);
                    return true;
                }
            }
            catch { }
            return false;
        }

        public bool Send(string s)
        {
            try
            {
                byte[] sb = Encoding.ASCII.GetBytes(s);
                return Send(sb);
            }
            catch { }
            return false;
        }
        public bool Send(byte[] b)
        {
            try
            {
                int rs = Socket.Send(b);
                if (rs > 0) return true;
            }
            catch { }
            return false;
        }

        public void Receive()
        {
            Task.Factory.StartNew(() =>
            {
                if (!IsReceive)
                {
                    lock (ReceiveLock)
                    {
                        if (!IsReceive)
                        {
                            IsReceive = true;
                            while (IsReceive)
                            {
                                ReceiveContent();
                            }
                        }
                    }
                }
            });
        }
        private void ReceiveContent()
        {
            //string recStr = "";
            //byte[] recBytes = new byte[4096];
            //int bytes = Socket.Receive(recBytes, recBytes.Length, 0);
            //recStr += Encoding.ASCII.GetString(recBytes, 0, bytes);
            try
            {
                byte[] recByte = new byte[ReceiveBufferSize];
                int recLength = Socket.Receive(recByte, recByte.Length, 0);
                for (int k = 0; k < recLength; k++)
                {
                    ReceiveByte.Add(recByte[k]);
                }

                if (ReceiveByte.Count > 6 && ReceiveByte[0] == 255 && ReceiveByte[1] == 254)
                {
                    int msgBodyLength = BitConverter.ToInt32(new byte[] { ReceiveByte[2], ReceiveByte[3], ReceiveByte[4], ReceiveByte[5] }, 0);
                    if (ReceiveByte.Count >= 6 + msgBodyLength)
                    {
                        byte[] body = ReceiveByte.GetRange(6, msgBodyLength).ToArray();
                        string bodyToGBK = Encoding.GetEncoding("GBK").GetString(body);
                        ReceiveByteContent(body);
                        Send(ReceiveByte.GetRange(0, 6).ToArray());
                        ReceiveByte.RemoveRange(0, 6 + msgBodyLength);
                    }
                }
                else
                {
                    ReceiveByte.Clear();
                    Socket.Send(new byte[] { 0 });
                }

                //string recStr = Encoding.GetEncoding("GBK").GetString(recByte, 0, recLength);
                //if (recLength > 0)
                //{
                //    Console.Write("rec:");
                //    for (int j = 0; j < recLength; j++)
                //    {
                //        Console.Write(recByte[j] + " ");
                //    }
                //    Console.WriteLine(" ,");
                //}
                //if (recStr.Length > 0)
                //    Console.WriteLine("接收到信息：" + recStr); 
            }
            catch (Exception e)
            { }
        }

        #region IDisposable Support
        private bool disposedValue = false; // 要检测冗余调用

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)。
                    IsReceive = false;
                    Socket?.Shutdown(SocketShutdown.Both);
                    Socket?.Close();
                    Socket?.Dispose();
                }

                // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // TODO: 将大型字段设置为 null。

                disposedValue = true;
            }
        }

        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        // ~SocketTool() {
        //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        // 添加此代码以正确实现可处置模式。
        public void Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
