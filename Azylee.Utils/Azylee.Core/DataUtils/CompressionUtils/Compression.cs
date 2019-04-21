using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace Azylee.Core.DataUtils.CompressionUtils
{
    /// <summary>
    /// 压缩工具
    /// </summary>
    public static class Compression
    {
        /// <summary>
        /// 压缩字节
        /// 1.创建压缩的数据流 
        /// 2.设定compressStream为存放被压缩的文件流,并设定为压缩模式
        /// 3.将需要压缩的字节写到被压缩的文件流
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static byte[] Compress(byte[] bytes)
        {
            try
            {
                using (MemoryStream compressStream = new MemoryStream())
                {
                    using (var zipStream = new GZipStream(compressStream, CompressionMode.Compress))
                        zipStream.Write(bytes, 0, bytes.Length);
                    return compressStream.ToArray();
                }
            }
            catch { return null; }
        }
        /// <summary>
        /// 解压缩字节
        /// 1.创建被压缩的数据流
        /// 2.创建zipStream对象，并传入解压的文件流
        /// 3.创建目标流
        /// 4.zipStream拷贝到目标流
        /// 5.返回目标流输出字节
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static byte[] Decompress(byte[] bytes)
        {
            try
            {
                using (var compressStream = new MemoryStream(bytes))
                {
                    using (var zipStream = new GZipStream(compressStream, CompressionMode.Decompress))
                    {
                        using (var resultStream = new MemoryStream())
                        {
                            zipStream.CopyTo(resultStream);
                            return resultStream.ToArray();
                        }
                    }
                }
            }
            catch { return null; }
        }
    }
}
