using Azylee.Jsons.JsonConfigUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Ges
{
    class Program
    {
        static void Main(string[] args)
        {
            //Assist<User> assist = new Assist<User>();

            //Console.Read();

            JsonConfig<User> jsonConfig = new JsonConfig<User>(@"D:\tmp\test\AppConfig.json");
            jsonConfig.Get().Age = 1;
            jsonConfig.Save();

        }
    }
}
