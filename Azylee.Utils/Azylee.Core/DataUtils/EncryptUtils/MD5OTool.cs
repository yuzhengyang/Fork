//引用：https://blog.csdn.net/scimence/article/details/51593817

using System;
using System.IO;

namespace Azylee.Core.DataUtils.EncryptUtils
{
    //示例： 
    // MD5.Encrypt("a");                        // 计算字符串MD5值
    // MD5.Encrypt(new FileInfo("D:\\1.rar"));  // 计算文件MD5值
    // MD5.Encrypt(byte[] Bytes);               // 计算Byte数组MD5值

    //MD5 ("") = d41d8cd98f00b204e9800998ecf8427e   
    //MD5 ("a") = 0cc175b9c0f1b6a831c399e269772661   
    //MD5 ("abc") = 900150983cd24fb0d6963f7d28e17f72   
    //MD5 ("message digest") = f96b697d7cb7938d525a2f31aaf161d0   
    //MD5 ("abcdefghijklmnopqrstuvwxyz") = c3fcd3d76192e4007dfb496cca67e13b  
    public class MD5OTool
    {

        #region MD5调用接口

        /// <summary>
        /// 计算data的MD5值
        /// </summary>
        public static string Encrypt(string data)
        {
            uint[] X = To16Array(data);
            return calculate(X);
        }

        /// <summary>
        /// 计算byte数组的MD5值
        /// </summary>
        public static string Encrypt(byte[] Bytes)
        {
            uint[] X = To16Array(Bytes);
            return calculate(X);
        }

        /// <summary>
        /// 计算文件的MD5值
        /// </summary>
        public static string Encrypt(FileInfo file)
        {
            uint[] X = To16Array(file);
            return calculate(X);
        }

        #endregion


        #region MD5计算逻辑

        /// <summary>
        /// 转化byte数组为uint数组，数组长度为16的倍数
        /// 
        /// 1、字符串转化为字节数组，每4个字节转化为一个uint，依次存储到uint数组
        /// 2、附加0x80作为最后一个字节
        /// 3、在uint数组最后位置记录文件字节长度信息
        /// </summary>
        public static uint[] To16Array(byte[] Bytes)
        {
            uint DataLen = (uint)Bytes.Length;

            // 计算FileLen对应的uint长度（要求为16的倍数、预留2个uint、最小为16）
            uint ArrayLen = (((DataLen + 8) / 64) + 1) * 16;
            uint[] Array = new uint[ArrayLen];

            uint ArrayPos = 0;
            int pos = 0;
            uint ByteCount = 0;
            for (ByteCount = 0; ByteCount < DataLen; ByteCount++)
            {
                // 每4个Byte转化为1个uint
                ArrayPos = ByteCount / 4;
                pos = (int)(ByteCount % 4) * 8;
                Array[ArrayPos] = Array[ArrayPos] | ((uint)Bytes[ByteCount] << pos);
            }

            // 附加0x80作为最后一个字节，添加到uint数组对应位置
            ArrayPos = ByteCount / 4;
            pos = (int)(ByteCount % 4) * 8;
            Array[ArrayPos] = Array[ArrayPos] | ((uint)0x80 << pos);

            // 记录总长度信息
            Array[ArrayLen - 2] = (DataLen << 3);
            Array[ArrayLen - 1] = (DataLen >> 29);

            return Array;
        }

        /// <summary>
        /// 转化字符串为uint数组，数组长度为16的倍数
        /// 
        /// 1、字符串转化为字节数组，每4个字节转化为一个uint，依次存储到uint数组
        /// 2、附加0x80作为最后一个字节
        /// 3、在uint数组最后位置记录文件字节长度信息
        /// </summary>
        public static uint[] To16Array(string data)
        {
            byte[] datas = System.Text.Encoding.Default.GetBytes(data);
            return To16Array(datas);
        }

        /// <summary>
        /// 转化文件为uint数组，数组长度为16的倍数
        /// 
        /// 1、读取文件字节信息，每4个字节转化为一个uint，依次存储到uint数组
        /// 2、附加0x80作为最后一个字节
        /// 3、在uint数组最后位置记录文件字节长度信息
        /// </summary>
        public static uint[] To16Array(FileInfo info)
        {
            FileStream fs = new FileStream(info.FullName, FileMode.Open);// 读取方式打开，得到流
            int SIZE = 1024 * 1024 * 10;        // 10M缓存
            byte[] datas = new byte[SIZE];      // 要读取的内容会放到这个数组里
            int countI = 0;
            long offset = 0;

            // 计算FileLen对应的uint长度（要求为16的倍数、预留2个uint、最小为16）
            uint FileLen = (uint)info.Length;
            uint ArrayLen = (((FileLen + 8) / 64) + 1) * 16;
            uint[] Array = new uint[ArrayLen];

            int pos = 0;
            uint ByteCount = 0;
            uint ArrayPos = 0;
            while (ByteCount < FileLen)
            {
                if (countI == 0)
                {
                    fs.Seek(offset, SeekOrigin.Begin);// 定位到指定字节
                    fs.Read(datas, 0, datas.Length);

                    offset += SIZE;
                }

                // 每4个Byte转化为1个uint
                ArrayPos = ByteCount / 4;
                pos = (int)(ByteCount % 4) * 8;
                Array[ArrayPos] = Array[ArrayPos] | ((uint)datas[countI] << pos);

                ByteCount = ByteCount + 1;

                countI++;
                if (countI == SIZE) countI = 0;
            }

            // 附加0x80作为最后一个字节，添加到uint数组对应位置
            ArrayPos = ByteCount / 4;
            pos = (int)(ByteCount % 4) * 8;
            Array[ArrayPos] = Array[ArrayPos] | ((uint)0x80 << pos);

            // 记录总长度信息
            Array[ArrayLen - 2] = (FileLen << 3);
            Array[ArrayLen - 1] = (FileLen >> 29);

            fs.Close();
            return Array;
        }



        private static uint F(uint x, uint y, uint z)
        {
            return (x & y) | ((~x) & z);
        }
        private static uint G(uint x, uint y, uint z)
        {
            return (x & z) | (y & (~z));
        }

        // 0^0^0 = 0
        // 0^0^1 = 1
        // 0^1^0 = 1
        // 0^1^1 = 0
        // 1^0^0 = 1
        // 1^0^1 = 0
        // 1^1^0 = 0
        // 1^1^1 = 1
        private static uint H(uint x, uint y, uint z)
        {
            return (x ^ y ^ z);
        }
        private static uint I(uint x, uint y, uint z)
        {
            return (y ^ (x | (~z)));
        }

        // 循环左移
        private static uint RL(uint x, int y)
        {
            y = y % 32;
            return (x << y) | (x >> (32 - y));
        }

        private static void md5_FF(ref uint a, uint b, uint c, uint d, uint x, int s, uint ac)
        {
            uint f = F(b, c, d);
            a = x + ac + a + f;

            a = RL(a, s);
            a = a + b;
        }
        private static void md5_GG(ref uint a, uint b, uint c, uint d, uint x, int s, uint ac)
        {
            uint g = G(b, c, d);
            a = x + ac + a + g;

            a = RL(a, s);
            a = a + b;
        }
        private static void md5_HH(ref uint a, uint b, uint c, uint d, uint x, int s, uint ac)
        {
            uint h = H(b, c, d);
            a = x + ac + a + h;

            a = RL(a, s);
            a = a + b;
        }
        private static void md5_II(ref uint a, uint b, uint c, uint d, uint x, int s, uint ac)
        {
            uint i = I(b, c, d);
            a = x + ac + a + i;

            a = RL(a, s);
            a = a + b;
        }

        private static string RHex(uint n)
        {
            string S = Convert.ToString(n, 16);
            return ReOrder(S);
        }

        // 16进制串重排序 67452301 -> 01234567
        private static string ReOrder(String S)
        {
            string T = "";
            for (int i = S.Length - 2; i >= 0; i = i - 2)
            {
                if (i == -1) T = T + "0" + S[i + 1];
                else T = T + "" + S[i] + S[i + 1];
            }
            return T;
        }


        /// <summary>
        /// 对长度为16倍数的uint数组，执行md5数据摘要，输出md5信息
        /// </summary>
        public static string calculate(uint[] x)
        {
            //uint time1 = DateTime.Now.Ticks;

            // 7   12  17   22
            // 5   9   14   20
            // 4   11  16   23
            // 6   10  15   21
            const int S11 = 7;
            const int S12 = 12;
            const int S13 = 17;
            const int S14 = 22;
            const int S21 = 5;
            const int S22 = 9;
            const int S23 = 14;
            const int S24 = 20;
            const int S31 = 4;
            const int S32 = 11;
            const int S33 = 16;
            const int S34 = 23;
            const int S41 = 6;
            const int S42 = 10;
            const int S43 = 15;
            const int S44 = 21;

            uint a = 0x67452301;
            uint b = 0xEFCDAB89;
            uint c = 0x98BADCFE;
            uint d = 0x10325476;

            for (int k = 0; k < x.Length; k += 16)
            {
                uint AA = a;
                uint BB = b;
                uint CC = c;
                uint DD = d;

                md5_FF(ref a, b, c, d, x[k + 0], S11, 0xD76AA478);  // 3604027302
                md5_FF(ref d, a, b, c, x[k + 1], S12, 0xE8C7B756);  // 877880356
                md5_FF(ref c, d, a, b, x[k + 2], S13, 0x242070DB);  // 2562383102
                md5_FF(ref b, c, d, a, x[k + 3], S14, 0xC1BDCEEE);
                md5_FF(ref a, b, c, d, x[k + 4], S11, 0xF57C0FAF);
                md5_FF(ref d, a, b, c, x[k + 5], S12, 0x4787C62A);
                md5_FF(ref c, d, a, b, x[k + 6], S13, 0xA8304613);
                md5_FF(ref b, c, d, a, x[k + 7], S14, 0xFD469501);
                md5_FF(ref a, b, c, d, x[k + 8], S11, 0x698098D8);
                md5_FF(ref d, a, b, c, x[k + 9], S12, 0x8B44F7AF);
                md5_FF(ref c, d, a, b, x[k + 10], S13, 0xFFFF5BB1);
                md5_FF(ref b, c, d, a, x[k + 11], S14, 0x895CD7BE);
                md5_FF(ref a, b, c, d, x[k + 12], S11, 0x6B901122);
                md5_FF(ref d, a, b, c, x[k + 13], S12, 0xFD987193);
                md5_FF(ref c, d, a, b, x[k + 14], S13, 0xA679438E);
                md5_FF(ref b, c, d, a, x[k + 15], S14, 0x49B40821); //3526238649
                md5_GG(ref a, b, c, d, x[k + 1], S21, 0xF61E2562);
                md5_GG(ref d, a, b, c, x[k + 6], S22, 0xC040B340);  //1572812400
                md5_GG(ref c, d, a, b, x[k + 11], S23, 0x265E5A51);
                md5_GG(ref b, c, d, a, x[k + 0], S24, 0xE9B6C7AA);
                md5_GG(ref a, b, c, d, x[k + 5], S21, 0xD62F105D);
                md5_GG(ref d, a, b, c, x[k + 10], S22, 0x2441453);
                md5_GG(ref c, d, a, b, x[k + 15], S23, 0xD8A1E681);
                md5_GG(ref b, c, d, a, x[k + 4], S24, 0xE7D3FBC8);
                md5_GG(ref a, b, c, d, x[k + 9], S21, 0x21E1CDE6);
                md5_GG(ref d, a, b, c, x[k + 14], S22, 0xC33707D6);
                md5_GG(ref c, d, a, b, x[k + 3], S23, 0xF4D50D87);
                md5_GG(ref b, c, d, a, x[k + 8], S24, 0x455A14ED);
                md5_GG(ref a, b, c, d, x[k + 13], S21, 0xA9E3E905);
                md5_GG(ref d, a, b, c, x[k + 2], S22, 0xFCEFA3F8);
                md5_GG(ref c, d, a, b, x[k + 7], S23, 0x676F02D9);
                md5_GG(ref b, c, d, a, x[k + 12], S24, 0x8D2A4C8A);
                md5_HH(ref a, b, c, d, x[k + 5], S31, 0xFFFA3942);  // 3750198684 2314002400 1089690627 990001115 0 4 -> 2749600077
                md5_HH(ref d, a, b, c, x[k + 8], S32, 0x8771F681);  // 990001115
                md5_HH(ref c, d, a, b, x[k + 11], S33, 0x6D9D6122); // 1089690627
                md5_HH(ref b, c, d, a, x[k + 14], S34, 0xFDE5380C); // 2314002400
                md5_HH(ref a, b, c, d, x[k + 1], S31, 0xA4BEEA44);  // 555633090
                md5_HH(ref d, a, b, c, x[k + 4], S32, 0x4BDECFA9);
                md5_HH(ref c, d, a, b, x[k + 7], S33, 0xF6BB4B60);
                md5_HH(ref b, c, d, a, x[k + 10], S34, 0xBEBFBC70);
                md5_HH(ref a, b, c, d, x[k + 13], S31, 0x289B7EC6);
                md5_HH(ref d, a, b, c, x[k + 0], S32, 0xEAA127FA);
                md5_HH(ref c, d, a, b, x[k + 3], S33, 0xD4EF3085);
                md5_HH(ref b, c, d, a, x[k + 6], S34, 0x4881D05);
                md5_HH(ref a, b, c, d, x[k + 9], S31, 0xD9D4D039);
                md5_HH(ref d, a, b, c, x[k + 12], S32, 0xE6DB99E5);
                md5_HH(ref c, d, a, b, x[k + 15], S33, 0x1FA27CF8);
                md5_HH(ref b, c, d, a, x[k + 2], S34, 0xC4AC5665);  // 1444303940
                md5_II(ref a, b, c, d, x[k + 0], S41, 0xF4292244);  // 808311156
                md5_II(ref d, a, b, c, x[k + 7], S42, 0x432AFF97);
                md5_II(ref c, d, a, b, x[k + 14], S43, 0xAB9423A7);
                md5_II(ref b, c, d, a, x[k + 5], S44, 0xFC93A039);
                md5_II(ref a, b, c, d, x[k + 12], S41, 0x655B59C3);
                md5_II(ref d, a, b, c, x[k + 3], S42, 0x8F0CCC92);
                md5_II(ref c, d, a, b, x[k + 10], S43, 0xFFEFF47D);
                md5_II(ref b, c, d, a, x[k + 1], S44, 0x85845DD1);
                md5_II(ref a, b, c, d, x[k + 8], S41, 0x6FA87E4F);
                md5_II(ref d, a, b, c, x[k + 15], S42, 0xFE2CE6E0);
                md5_II(ref c, d, a, b, x[k + 6], S43, 0xA3014314);
                md5_II(ref b, c, d, a, x[k + 13], S44, 0x4E0811A1);
                md5_II(ref a, b, c, d, x[k + 4], S41, 0xF7537E82);
                md5_II(ref d, a, b, c, x[k + 11], S42, 0xBD3AF235);
                md5_II(ref c, d, a, b, x[k + 2], S43, 0x2AD7D2BB);
                md5_II(ref b, c, d, a, x[k + 9], S44, 0xEB86D391);  // 4120542881

                a = a + AA; //3844921825
                b = b + BB;
                c = c + CC;
                d = d + DD;
            }

            string MD5 = RHex(a) + RHex(b) + RHex(c) + RHex(d);

            //uint time2 = DateTime.Now.Ticks;
            //MessageBox.Show("MD5计算耗时：" + ((time2 - time1) / 10000000f) + "秒");

            return MD5;
        }

        #endregion

    }
}
