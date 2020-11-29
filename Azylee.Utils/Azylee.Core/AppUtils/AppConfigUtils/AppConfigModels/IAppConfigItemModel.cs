using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.Core.AppUtils.AppConfigUtils.AppConfigModels
{
    public interface IAppConfigItemModel
    {
        int GetOrderNumber();
        string GetUniqueName();
    }
}
