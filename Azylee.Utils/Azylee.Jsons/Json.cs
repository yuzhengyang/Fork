//************************************************************************
//      https://github.com/yuzhengyang
//      author:     yuzhengyang
//      date:       2017.3.29 - 2017.8.24
//      desc:       Json转换工具类（需要Newtonsoft.Json支持）
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************
using Azylee.Core.IOUtils.TxtUtils;
using Newtonsoft.Json;
using System;

namespace Azylee.Jsons
{
    public class Json
    {
        public static string Object2String(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        public static object String2Object(string s)
        {
            string json = s;
            if (!string.IsNullOrWhiteSpace(json))
            {
                try { return JsonConvert.DeserializeObject(json); } catch (Exception e) { }
            }
            return null;
        }
        public static T String2Object<T>(string s)
        {
            string json = s;
            if (!string.IsNullOrWhiteSpace(json))
            {
                try { return JsonConvert.DeserializeObject<T>(json); } catch (Exception e) { }
            }
            return default(T);
        }
        public static T File2Object<T>(string file)
        {
            string json = TxtTool.Read(file);
            if (!string.IsNullOrWhiteSpace(json))
            {
                try { return JsonConvert.DeserializeObject<T>(json); } catch (Exception e) { }
            }
            return default(T);
        }
    }
}
