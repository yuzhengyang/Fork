using Azylee.Jsons.JsonAppConfigUtils;
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

            JsonAppConfig<User> appConfig = new JsonAppConfig<User>(@"D:\tmp\test\AppConfig.json");
            //JsonConfig<User> jsonConfig = new JsonConfig<User>(@"D:\tmp\test\AppConfig.json");
            appConfig.Config.Age = 1;
            appConfig.DoSave();

        }
    }
}
