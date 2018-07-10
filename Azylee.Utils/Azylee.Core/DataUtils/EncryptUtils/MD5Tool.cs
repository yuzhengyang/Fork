//************************************************************************
//      author:     yuzhengyang
//      date:       2018.3.27 - 2018.6.3
//      desc:       MD5 工具
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Azylee.Core.DataUtils.EncryptUtils
{
    public class MD5Tool
    {
        /// <summary>
        /// 给一个字符串进行MD5加密
        /// </summary>
        /// <param name="s">待加密字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string Encrypt(string s)
        {
            string result = "";
            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(s);
                HashAlgorithm algorithm = MD5.Create();
                byte[] hashBytes = algorithm.ComputeHash(buffer);
                result = BitConverter.ToString(hashBytes).Replace("-", "");
            }
            catch { }
            return result;
        }
    }
}
