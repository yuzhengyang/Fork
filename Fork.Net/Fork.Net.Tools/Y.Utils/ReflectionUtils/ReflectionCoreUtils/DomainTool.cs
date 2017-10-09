//############################################################
//      https://github.com/yuzhengyang
//      author:yuzhengyang
//############################################################
using System;
using Y.Utils.IOUtils.LogUtils;

namespace Y.Utils.ReflectionUtils.ReflectionCoreUtils
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
            { }
            return null;
        }
        public static T CreateInstance<T>(AppDomain domain)
        {
            T obj = (T)domain.CreateInstanceAndUnwrap(typeof(T).Assembly.FullName, typeof(T).FullName);
            return obj;
        }
    }
}
