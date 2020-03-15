using Azylee.Core.DataUtils.SerializeUtils;
using Azylee.Core.WindowsUtils.ConsoleUtils;
using Azylee.Jsons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.YeahWeb.SocketUtils.TcpUtils
{
    /// <summary>
    /// Tcp 传输数据模型
    /// </summary>
    public class TcpDataModel
    {
        /// <summary>
        /// 类型
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public byte[] Data { get; set; }
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public TcpDataModel() { }
        /// <summary>
        /// 构造函数（仅指令）
        /// </summary>
        /// <param name="type"></param>
        public TcpDataModel(int type)
        {
            this.Type = type;
        }
        /// <summary>
        /// 构造函数（默认）
        /// </summary>
        /// <param name="type"></param>
        /// <param name="data"></param>
        public TcpDataModel(int type, byte[] data)
        {
            this.Type = type;
            this.Data = data;
        }
        /// <summary>
        /// 构造函数（自动转换）
        /// </summary>
        /// <param name="type"></param>
        /// <param name="data"></param>
        public TcpDataModel(int type, object data)
        {
            this.Type = type;
            this.Data = Json.Object2Byte(data);
        }

        /// <summary>
        /// 将当前模型转换为 byte 数组
        /// </summary>
        /// <returns></returns>
        public byte[] ToByte()
        {
            List<byte> result = new List<byte>();
            result.AddRange(BitConverter.GetBytes(Type));
            if (Data != null)
            {
                result.AddRange(BitConverter.GetBytes((int)Data.Length));
                result.AddRange(Data);
            }
            else
            {
                result.AddRange(BitConverter.GetBytes((int)0));
                result.AddRange(new byte[] { });
            }
            return result.ToArray();
        }
        /// <summary>
        /// 转换为模型
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static TcpDataModel ToModel(byte[] bytes)
        {
            TcpDataModel model = null;
            try
            {
                int type = BitConverter.ToInt32(bytes, 0);
                int length = BitConverter.ToInt32(bytes, 4);

                byte[] data_byte = bytes.Skip(8).Take(length).ToArray();

                model = new TcpDataModel(type, data_byte);
            }
            catch { }
            return model;
        }
    }
}
