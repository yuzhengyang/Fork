using Newtonsoft.Json;
using System.IO;

namespace Azylee.Jsons
{
    public static class JsonFormat
    {
        public static string Format(string s)
        {
            JsonSerializer serializer = new JsonSerializer();
            TextReader tr = new StringReader(s);
            JsonTextReader jtr = new JsonTextReader(tr);
            object obj = serializer.Deserialize(jtr);
            if (obj != null)
            {
                StringWriter textWriter = new StringWriter();
                JsonTextWriter jsonWriter = new JsonTextWriter(textWriter)
                {
                    Formatting = Formatting.Indented,
                    Indentation = 4,
                    IndentChar = ' '
                };
                serializer.Serialize(jsonWriter, obj);
                return textWriter.ToString();
            }
            else
            {
                return s;
            }
        }
    }
}
