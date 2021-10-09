using Azylee.Core.AppUtils.AppConfigUtils.AppConfigInterfaces;
using Azylee.Core.AppUtils.AppConfigUtils.AppConfigModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Ges
{
    public class UserBook : IAppConfigItemModel
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public int Page { get; set; }
        public double Price { get; set; }

        public int GetOrderNumber()
        {
            return Number;
        }

        public string GetUniqueName()
        {
            return Name;
        }
    }
}
