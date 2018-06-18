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

namespace Azylee.Core.Plus.DataUtils.JsonUtils
{
    public class JsonTool
    {
        public static string ToStr(object value)
        {
            return JsonConvert.SerializeObject(value);
        }
        public static object ToObjFromStr(string str)
        {
            string json = str;
            if (!string.IsNullOrWhiteSpace(json))
            {
                try { return JsonConvert.DeserializeObject(json); } catch (Exception e) { }
            }
            return null;
        }
        public static T ToObjFromStr<T>(string str)
        {
            string json = str;
            if (!string.IsNullOrWhiteSpace(json))
            {
                try { return JsonConvert.DeserializeObject<T>(json); } catch (Exception e) { }
            }
            return default(T);
        }
        public static T ToObjFromFile<T>(string file)
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
