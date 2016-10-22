using Newtonsoft.Json;
using System;
using Y.Utils.TxtUtils;

namespace Y.Utils.JsonUtils
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
