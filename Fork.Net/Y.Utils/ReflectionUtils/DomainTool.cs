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
        public static AppDomain CreateDomain(string friendlyName)
        {
            try
            {
                //AppDomainSetup setup = new AppDomainSetup();
                //setup.ApplicationName = "Test";
                //setup.ApplicationBase = AppDomain.CurrentDomain.BaseDirectory;
                //setup.PrivateBinPath = AppDomain.CurrentDomain.BaseDirectory + "Private";
                //setup.CachePath = setup.ApplicationBase;
                //setup.ShadowCopyFiles = "true";
                //setup.ShadowCopyDirectories = setup.ApplicationBase;
                //AppDomain appDomain = AppDomain.CreateDomain("TestDomain", null, setup);
                AppDomain appDomain = AppDomain.CreateDomain(friendlyName);
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
