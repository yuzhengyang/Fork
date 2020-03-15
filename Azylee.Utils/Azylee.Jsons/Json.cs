//************************************************************************
//      https://github.com/yuzhengyang
//      author:     yuzhengyang
//      date:       2017.3.29 - 2018.10.19
//      desc:       Json转换工具类（需要Newtonsoft.Json支持）
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************
using Azylee.Core.IOUtils.TxtUtils;
using Newtonsoft.Json;
using System;
using System.Text;

namespace Azylee.Jsons
{
    /// <summary>
    /// Json 工具
    /// </summary>
    public class Json
    {
        /// <summary>
        /// 对象 转 字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Object2String(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        /// <summary>
        /// 字符串 转 对象
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static object String2Object(string s)
        {
            string json = s;
            if (!string.IsNullOrWhiteSpace(json))
            {
                try { return JsonConvert.DeserializeObject(json); } catch (Exception e) { }
            }
            return null;
        }
        /// <summary>
        /// 字符串 转 模型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="s"></param>
        /// <returns></returns>
        public static T String2Object<T>(string s)
        {
            string json = s;
            if (!string.IsNullOrWhiteSpace(json))
            {
                try { return JsonConvert.DeserializeObject<T>(json); } catch (Exception e) { }
            }
            return default(T);
        }
        /// <summary>
        /// 读取文件文本 转 模型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="file"></param>
        /// <returns></returns>
        public static T File2Object<T>(string file)
        {
            string json = TxtTool.Read(file);
            if (!string.IsNullOrWhiteSpace(json))
            {
                try { return JsonConvert.DeserializeObject<T>(json); } catch (Exception e) { }
            }
            return default(T);
        }/// <summary>
         /// 模型 存储到文件
         /// </summary>
         /// <typeparam name="T"></typeparam>
         /// <param name="file"></param>
         /// <returns></returns>
        public static bool Object2File<T>(string file, T t)
        {
            string s = Object2String(t);
            bool rs = TxtTool.Create(file, s);
            return rs;
        }
        /// <summary>
        /// 对象 转 字节（JSON中转）
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte[] Object2Byte(object obj)
        {
            try
            {
                string s = JsonConvert.SerializeObject(obj);
                byte[] b = Encoding.UTF8.GetBytes(s);
                return b;
            }
            catch { return null; }
        }
        /// <summary>
        /// 字节 转 模型（JSON中转）
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static T Byte2Object<T>(byte[] b)
        {
            try
            {
                string s = Encoding.UTF8.GetString(b);
                return JsonConvert.DeserializeObject<T>(s);
            }
            catch(Exception ex) { return default(T); }
        }
    }
}
