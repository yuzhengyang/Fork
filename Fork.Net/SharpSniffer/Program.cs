//////////////////////////////////
//  C# 也可以做Sniffer
//  SharpSniffer
////////////////////////////////
using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace SharpSniffer
{

    class Program
    {
        static long AllCount = 0;

        static void Main(string[] args)
        {
            try
            {
                //创建socket
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);

                using (socket)
                {
                    PrintLine("socket created!");

                    //绑定到本机，端口可以任意
                    var localHostIpAddress = GetHostAdress();
                    Console.WriteLine("trying to bind to local IP: {0}", localHostIpAddress);
                    socket.Bind(new IPEndPoint(localHostIpAddress, 0));
                    PrintLine("binded to [" + socket.LocalEndPoint + "]");

                    byte[] outValue = BitConverter.GetBytes(0);
                    byte[] inValue = BitConverter.GetBytes(1);
                    socket.IOControl(IOControlCode.ReceiveAll, inValue, outValue);   //对IO设置为可以接受所有包
                    PrintLine("IOControl seted!");

                    byte[] buf = new byte[65535];   //缓存大一点没关系，小了可能一次放不下
                    PrintLine("Sniffer begined.");

                    IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 0); //从任何地方接收数据

                    int index = 0;  //表示当前是第几个包（1based）

                    while (true)
                    {
                        index++;
                        try
                        {
                            ipep.Address = IPAddress.Any;   //从任何地方接收数据
                            ipep.Port = 0;

                            EndPoint ep = ipep;

                            int recvedSize = socket.ReceiveFrom(buf, ref ep);   //用ReceiveFrom接受数据
                                                                                //        socket.Receive(buf);             //用Receive也能接受到数据，不过使用ReceiveFrom可以直接获取发送方IP地址
                            AllCount += recvedSize;

                            //接收到包了，打印出来
                            //Print('[');
                            //Print(GetCurrentTimeString());
                            //PrintLine("] Received [" + recvedSize + "] bytes from [" + ep.ToString() + "]");
                            ////string s = Encoding.ASCII.GetString(buf, 0, recvedSize);
                            ////Print("ASCII: \n");
                            ////PrintLine(s);
                            //string s = GetByteArrayHexString(buf, 0, recvedSize);
                            //Print("Hex: \n");
                            //PrintLine(s);

                            Print(index);
                            PrintLine(string.Format(" This: {1:f2} KB  /  AllCount: {1:f2} MB",
                                (double)recvedSize / 1024, (double)AllCount / 1024 / 1024));

                            if (recvedSize > 1000)
                            {
                                PrintLine("////////////////////");
                            }
                        }
                        catch (Exception ex)
                        {
                            if (ex is SocketException)
                            {
                                var sex = (SocketException)ex;
                                Console.Error.WriteLine("SocketErrorCode=" + sex.ErrorCode);
                            }
                            Console.Error.WriteLine(ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex is SocketException)
                {
                    var sex = (SocketException)ex;
                    Console.Error.WriteLine("SocketErrorCode=" + sex.ErrorCode);
                }
                Console.Error.WriteLine(ex);
            }
        }
        //获取本机IP地址
        private static IPAddress GetHostAdress()
        {
            string hostName = Dns.GetHostName();
            var hostAddreses = Dns.GetHostAddresses(hostName);
            List<IPAddress> addressList = new List<IPAddress>(hostAddreses.Length);
            foreach (var item in hostAddreses)
            {
                if (item.AddressFamily == AddressFamily.InterNetwork)
                {
                    addressList.Add(item);
                }
            }
            if (addressList.Count != 0)
            {
                if (addressList.Count == 1)
                {
                    return addressList[0];
                }
                else
                {
                    Console.WriteLine("请选择要绑定到的本机IP地址(IPv4)：");
                    for (int i = 0; i < addressList.Count; i++)
                    {
                        var addr = addressList[i];
                        Console.WriteLine("\t{0}: {1}", i, addr);
                    }
                    int sel = int.Parse(Console.ReadLine());
                    return addressList[sel];
                }
            }
            else
            {
                Console.Write("请输入本机IP地址：");
                string s = Console.ReadLine();
                return IPAddress.Parse(s);
            }
        }
        //获取表示当前时间的字符串
        private static string GetCurrentTimeString()
        {
            DateTime now = DateTime.Now;
            return now.Hour + ":" + now.Minute + ":" + now.Second + "." + now.Millisecond;
        }
        const string HexValues = "0123456789ABCDEF";
        //把字节数组转换为十六进制表示的字符串
        private static string GetByteArrayHexString(byte[] buf, int startIndex, int size)
        {
            StringBuilder sb = new StringBuilder(size * 5);
            sb.AppendFormat("{0,3:X}: ", 0);
            int j = 1;
            for (int i = startIndex, n = startIndex + size; i < n; i++, j++)
            {
                byte b = buf[i];
                char c = HexValues[(b & 0x0f0) >> 4];
                sb.Append(c);
                c = HexValues[(b & 0x0f)];
                sb.Append(c);
                sb.Append(' ');
                if ((j & 0x0f) == 0)
                {
                    sb.Append(' ');
                    //sb.Append(Encoding.ASCII.GetString(buf,i-15,8));
                    AppendPrintableBytes(sb, buf, i - 15, 8);
                    sb.Append(' ');
                    //sb.Append(Encoding.ASCII.GetString(buf, i - 7, 8));
                    AppendPrintableBytes(sb, buf, i - 7, 8);
                    if (i + 1 != n)
                    {
                        sb.Append('\n');
                        sb.AppendFormat("{0,3:X}: ", i - 1);    //偏移
                    }
                }
                else if ((j & 0x07) == 0)
                {
                    sb.Append(' ');
                }
            }
            int t;
            if ((t = ((j - 1) & 0x0f)) != 0)
            {
                for (int k = 0, kn = 16 - t; k < kn; k++)
                {
                    sb.Append("   ");
                }
                if (t <= 8)
                {
                    sb.Append(' ');
                }

                sb.Append(' ');
                //   sb.Append(Encoding.ASCII.GetString(buf, startIndex + size - t, t>8?8:t));
                AppendPrintableBytes(sb, buf, startIndex + size - t, t > 8 ? 8 : t);
                if (t > 8)
                {
                    sb.Append(' ');
                    //   sb.Append(Encoding.ASCII.GetString(buf, startIndex + size - t + 8, t - 8));
                    AppendPrintableBytes(sb, buf, startIndex + size - t + 8, t - 8);
                }
            }
            return sb.ToString();
        }
        //向sb中添加buf中可打印字符，不可打印字符用'.'代替
        private static void AppendPrintableBytes(StringBuilder sb, byte[] buf, int startIndex, int len)
        {
            for (int i = startIndex, n = startIndex + len; i < n; i++)
            {
                char c = (char)buf[i];
                if (!char.IsControl(c))
                {
                    sb.Append(c);
                }
                else
                {
                    sb.Append('.');
                }
            }
        }
        //打印t+'\n'
        static void PrintLine<T>(T t)
        {
            Console.WriteLine(t);
        }
        //打印t
        static void Print<T>(T t)
        {
            Console.Write(t);
        }
    }
}
