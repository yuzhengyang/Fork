using Azylee.Core.WindowsUtils.ConsoleUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.YeahWeb.SocketUtils.TcpUtils
{
    public static class TcpDataConverter
    {
        const int HeadLength = 4 + 4 + 4;
        const int ReceiveBufferSize = 1024;
        public static int Byte2Model(List<byte> data, out TcpDataModel model)
        {
            model = null;

            if (data.Count > HeadLength &&
                data[0] == 111 && data[1] == 222 && data[2] == 66 && data[3] == 66)
            {
                int msgCode = BitConverter.ToInt32(new byte[] { data[4], data[5], data[6], data[7] }, 0);
                int msgBodyLength = BitConverter.ToInt32(new byte[] { data[8], data[9], data[10], data[11] }, 0);
                if (data.Count >= HeadLength + msgBodyLength)
                {
                    byte[] body = data.GetRange(HeadLength, msgBodyLength).ToArray();
                    string bodyToGBK = Encoding.GetEncoding("GBK").GetString(body);
                    //ReceiveByteContent(body);
                    Cons.Log(bodyToGBK);
                    //Send(ReceiveByte.GetRange(0, 6).ToArray());
                    data.RemoveRange(0, 6 + msgBodyLength);

                    //ReceiveMessage?.Invoke(msgCode, body);
                }
            }
            else
            {
                data.Clear();
                //Socket.Send(new byte[] { 0 });
            }
            return 0;
        }
    }
}
