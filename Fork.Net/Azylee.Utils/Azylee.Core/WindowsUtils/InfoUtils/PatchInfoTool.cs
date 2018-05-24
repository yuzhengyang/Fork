using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.Core.DataUtils.StringUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;

namespace Azylee.Core.WindowsUtils.InfoUtils
{
    public static class PatchInfoTool
    {
        public static List<string> Get()
        {
            List<string> rs = new List<string>();
            try
            {
                var searchQFE = new ManagementObjectSearcher("Select * from Win32_QuickFixEngineering");
                foreach (var item in searchQFE.Get())
                {
                    string _HotFixID = item.GetPropertyValue("HotFixID").ToString().Trim();
                    if (!string.IsNullOrWhiteSpace(_HotFixID) && !rs.Contains(_HotFixID))
                    {
                        rs.Add(_HotFixID);
                    }
                }
            }
            catch { }
            return rs;
        }
        public static bool Exist(string name)
        {
            List<string> list = Get();
            if (StringTool.Ok(name) && ListTool.HasElements(list))
            {
                if (list.Any(x => x == name.Trim())) return true;
            }
            return false;
        }
    }
}
