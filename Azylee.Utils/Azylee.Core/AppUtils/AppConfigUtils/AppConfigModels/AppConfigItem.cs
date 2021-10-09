using Azylee.Core.AppUtils.AppConfigUtils.AppConfigInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.Core.AppUtils.AppConfigUtils.AppConfigModels
{
    public class AppConfigItem : IAppConfigItemModel
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public Dictionary<string, string> Datas { get; set; }

        public AppConfigItem()
        {
            this.Datas = new Dictionary<string, string>();
        }
        public string GetValue(string key, string defaultValue = "")
        {
            if (Datas.TryGetValue(key, out string value))
            {
                return value;
            }
            return defaultValue;
        }
        public void SetValue(string key, string value)
        {
            if (Datas.ContainsKey(key))
            {
                Datas[key] = value;
            }
            else
            {
                Datas.Add(key, value);
            }
        }

        public int GetOrderNumber()
        {
            return this.Number;
        }

        public string GetUniqueName()
        {
            return this.Name;
        }
    }
}
