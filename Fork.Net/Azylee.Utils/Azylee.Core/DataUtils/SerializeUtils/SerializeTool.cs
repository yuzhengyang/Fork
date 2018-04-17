using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Azylee.Core.DataUtils.SerializeUtils
{
    public static class SerializeTool
    {
        /// <summary>
        /// 序列化模型到 byte 数组 [Serializable]
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public static byte[] Serialize<T>(T model)
        {
            if (model != null)
            {
                MemoryStream ms = null;
                try
                {
                    ms = new MemoryStream(); //内存实例
                    BinaryFormatter formatter = new BinaryFormatter(); //创建序列化的实例
                    formatter.Serialize(ms, model);//序列化对象，写入ms流中    
                    byte[] bytes = ms.GetBuffer();
                    return bytes;
                }
                catch { }
                finally
                {
                    ms?.Close();
                }
            }
            return null;
        }
        public static T Deserialize<T>(byte[] bytes)
        {
            if (bytes != null)
            {
                MemoryStream ms = null;
                try
                {
                    object obj = null;
                    ms = new MemoryStream(bytes); //利用传来的byte[]创建一个内存流
                    ms.Position = 0;
                    BinaryFormatter formatter = new BinaryFormatter();
                    obj = formatter.Deserialize(ms);//把内存流反序列成对象
                    return (T)Convert.ChangeType(obj, typeof(T)); ;
                }
                catch { }
                finally
                {
                    ms?.Close();
                }
            }
            return default(T);
        }
    }
}
