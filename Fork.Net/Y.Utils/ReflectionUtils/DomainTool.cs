using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.Utils.LogUtils;

namespace Y.Utils.ReflectionUtils
{
    public static class DomainTool
    {
        public static AppDomain CreateDomain(string friendlyName, string appBase)
        {
            try
            {
                AppDomainSetup setup = new AppDomainSetup();
                setup.ApplicationName = friendlyName;
                setup.ApplicationBase = appBase;
                //setup.PrivateBinPath = appBasePath + @"\Private";
                //setup.CachePath = setup.ApplicationBase;
                //setup.ShadowCopyFiles = "true";
                //setup.ShadowCopyDirectories = setup.ApplicationBase;
                AppDomain appDomain = AppDomain.CreateDomain(friendlyName, null, setup);
                return appDomain;
            }
            catch (Exception e)
            {
                Log.e(e.Message);
            }
            return null;
        }
        public static T CreateInstance<T>(AppDomain domain)
        {
            T obj = (T)domain.CreateInstanceAndUnwrap(typeof(T).Assembly.FullName, typeof(T).FullName);
            return obj;
        }
    }
}
