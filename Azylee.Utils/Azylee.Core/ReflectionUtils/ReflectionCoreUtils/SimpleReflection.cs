//############################################################
//      https://github.com/yuzhengyang
//      author:yuzhengyang
//############################################################
using Azylee.Core.IOUtils.FileUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Azylee.Core.ReflectionUtils.ReflectionCoreUtils
{
    public class SimpleReflection : MarshalByRefObject
    {
        //public string AssemblyPath { get; set; }
        //public SimpleReflection(string assemblyPath)
        //{
        //    AssemblyPath = assemblyPath;
        //}
        //public Assembly AssemblyResolve(object sender, ResolveEventArgs args)
        //{
        //    return SearchAssembly(AssemblyPath, args.Name);
        //}

        private Assembly SearchAssembly(string path, string name)
        {
            List<string> dlls = FileTool.GetFile(path, "*.dll");
            foreach (var dll in dlls)
            {
                try
                {
                    Assembly ass = Assembly.LoadFile(dll);
                    if (ass.FullName == name)
                        return ass;
                }
                catch { }
            }
            return null;
        }

        public T Do<T>(string file, string className, string methodName, object[] args, object[] values)
        {
            //获取dll中所有类
            Type[] types = Assembly.LoadFile(file).GetTypes();
            //从列表中获取指定类
            Type cls = types.FirstOrDefault(x => x.FullName.Contains(className));
            if (cls != null)
            {
                //创建实例
                object instance = Activator.CreateInstance(cls, args);
                //根据名称获取方法
                MethodInfo method = cls.GetMethod(methodName);
                //执行方法
                object result = method.Invoke(instance, values);
                return (T)result;
            }
            return default(T);
        }
    }
}
