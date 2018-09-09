//************************************************************************
//      author:     yuzhengyang
//      date:       2018.3.27 - 2018.6.3
//      desc:       Aes 加密解密工具
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AzyleeCC.Core.DataUtils.EncryptUtils
{
    public class AesTool
    {
        private static int AESKeyLength = 32;//AES加密的密码为32位
        private static char AESFillChar = 'Y';//AES密码填充字符

        public static string DefaultPassword = "yuzhengyang";//默认密码

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="str">要加密的 string 字符串</param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Encrypt(string str, string key)
        {
            key = FmtPassword(key);
            byte[] keyArray = Encoding.UTF8.GetBytes(key);
            byte[] toEncryptArray = Encoding.UTF8.GetBytes(str);

            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = rDel.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="array">要加密的 byte[] 数组</param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static byte[] Encrypt(byte[] array, string key)
        {
            key = FmtPassword(key);
            byte[] keyArray = Encoding.UTF8.GetBytes(key);

            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = rDel.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(array, 0, array.Length);

            return resultArray;
        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="str">要解密的 string 字符串</param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Decrypt(string str, string key)
        {
            key = FmtPassword(key);
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key);
            byte[] toEncryptArray = Convert.FromBase64String(str);

            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = rDel.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="array">要解密的 byte[] 数组</param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static byte[] Decrypt(byte[] array, string key)
        {
            key = FmtPassword(key);
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key);

            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = rDel.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(array, 0, array.Length);

            return resultArray;
        }
        /// <summary>
        /// 格式化密码
        /// </summary>
        /// <param name="s">要格式化的密码</param>
        /// <returns></returns>
        public static string FmtPassword(string s)
        {
            string password = s ?? "";

            //格式化密码
            if (password.Length < AESKeyLength)
            {
                //补足不够长的密码
                password = password + new string(AESFillChar, AESKeyLength - password.Length);
            }
            else if (password.Length > AESKeyLength)
            {
                //截取过长的密码
                password = password.Substring(0, AESKeyLength);
            }
            return password;
        }
    }
}
