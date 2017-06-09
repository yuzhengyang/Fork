using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Y.Utils.Net20.StringUtils;
using Y.Utils.Net20.TxtUtils;

namespace Y.Utils.Net20.JsonUtils
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
            if (!StringTool.IsNullOrWhiteSpace(json))
            {
                try { return JsonConvert.DeserializeObject(json); } catch (Exception e) { }
            }
            return null;
        }
        public static T ToObjFromStr<T>(string str)
        {
            string json = str;
            if (!StringTool.IsNullOrWhiteSpace(json))
            {
                try { return JsonConvert.DeserializeObject<T>(json); } catch (Exception e) { }
            }
            return default(T);
        }
        public static T ToObjFromFile<T>(string file)
        {
            string json = TxtTool.Read(file);
            if (!StringTool.IsNullOrWhiteSpace(json))
            {
                try { return JsonConvert.DeserializeObject<T>(json); } catch (Exception e) { }
            }
            return default(T);
        }
    }
}
