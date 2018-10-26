using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Azylee.YeahWeb.SocketUtils.TcpUtils
{
    /// <summary>
    /// Tcp 流数据处理辅助类
    /// </summary>
    public class TcpStreamHelper
    {
        const int ReceiveBufferSize = 1024;
        /// <summary>
        /// 流 写入
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Write(TcpClient client, TcpDataModel model)
        {
            try
            {
                if (client != null && client.GetStream() != null)
                {
                    byte[] md_byte = model.ToByte();
                    byte[] length_byte = BitConverter.GetBytes((int)(md_byte.Length + 4));

                    List<byte> data = new List<byte>();
                    data.AddRange(length_byte);//长度
                    data.AddRange(new byte[] { 111, 222, 66, 66 });//标志
                    data.AddRange(md_byte);//内容

                    client.GetStream().Write(data.ToArray(), 0, data.Count);//写出内容
                    return true;
                }
            }
            catch { }
            return false;
        }
        /// <summary>
        /// 流 读取
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static TcpDataModel Read(TcpClient client)
        {
            TcpDataModel data = null;
            try
            {
                if (client != null && client.GetStream() != null)
                {
                    //内容长度
                    byte[] data_length = new byte[4];
                    int read = client.GetStream().Read(data_length, 0, 4);
                    int length = BitConverter.ToInt32(data_length, 0) - 4;

                    if (read > 0 && length > 0)
                    {
                        //内容头部标志
                        byte[] data_head = new byte[4];
                        client.GetStream().Read(data_head, 0, 4);
                        bool head = data_head[0] == 111 && data_head[1] == 222 && data_head[2] == 66 && data_head[3] == 66;

                        if (head)
                        {
                            //读取内容
                            byte[] buffer = new byte[length];
                            int bf_read = 0;
                            while (bf_read < length)
                            {
                                //循环读取内容，防止断包
                                bf_read += client.GetStream().Read(buffer, bf_read, length - bf_read);
                                if (bf_read < length)
                                {
                                    int x = bf_read;
                                }
                            }
                            //解析内容
                            data = TcpDataModel.ToModel(buffer);
                        }
                    }
                    else
                    {
                        if (read == 0)
                            client?.Close();
                    }
                }
            }
            catch { }
            return data;
        }
    }
}
