//############################################################
//      https://github.com/yuzhengyang
//      author:yuzhengyang
//############################################################
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Y.Utils.DataUtils.EncryptUtils
{
    public class AesTool
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="s"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Encrypt(string s, string key)
        {
            //byte[] keyArray = UTF8Encoding.UTF8.GetBytes("12345678901234567890123456789012");
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key);
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(s);

            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = rDel.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="s"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Decrypt(string s, string key)
        {
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key);
            byte[] toEncryptArray = Convert.FromBase64String(s);

            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = rDel.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return UTF8Encoding.UTF8.GetString(resultArray);
        }
    }
}
