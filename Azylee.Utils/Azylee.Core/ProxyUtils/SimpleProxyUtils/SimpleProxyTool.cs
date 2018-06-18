using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Azylee.Core.ProxyUtils.SimpleProxyUtils
{
    public class SimpleProxyTool<T>
    {
        T Object;
        /// <summary>
        /// 记录方法前置操作和后置操作
        /// </summary>
        List<Tuple<int, RunMode, string, Action>> Operation = new List<Tuple<int, RunMode, string, Action>>();

        public SimpleProxyTool(T obj)
        {
            Object = obj;
        }
        /// <summary>
        /// 添加操作
        /// </summary>
        /// <param name="type">执行类型</param>
        /// <param name="method">方法名</param>
        /// <param name="action">动作</param>
        public void Add(RunMode type, string method, Action action)
        {
            Operation.Add(new Tuple<int, RunMode, string, Action>(Operation.Count, type, method, action));
        }
        /// <summary>
        /// 执行方法
        /// </summary>
        /// <typeparam name="R">返回值</typeparam>
        /// <param name="methodName">方法名</param>
        /// <param name="objs">参数</param>
        /// <returns></returns>
        public R Invoke<R>(string methodName, object[] objs)
        {
            //执行全局前置操作
            List<Tuple<int, RunMode, string, Action>> allBefore = Operation.Where(x => x.Item2 == RunMode.AllBefore).ToList();
            if (allBefore != null) allBefore.ForEach(b => { b.Item4?.Invoke(); });

            //执行方法前置操作
            List<Tuple<int, RunMode, string, Action>> methodBefore = Operation.Where(x => x.Item3 == methodName && x.Item2 == RunMode.MethodBefore).ToList();
            if (methodBefore != null) methodBefore.ForEach(b => { b.Item4?.Invoke(); });

            MethodInfo method = Object.GetType().GetMethod(methodName);
            object rs = method.Invoke(Object, objs);

            //执行方法后置操作
            List<Tuple<int, RunMode, string, Action>> methodAfter = Operation.Where(x => x.Item3 == methodName && x.Item2 == RunMode.MethodAfter).ToList();
            if (methodAfter != null) methodAfter.ForEach(b => { b.Item4?.Invoke(); });

            //执行全局后置操作
            List<Tuple<int, RunMode, string, Action>> allAfter = Operation.Where(x => x.Item2 == RunMode.AllAfter).ToList();
            if (allAfter != null) allAfter.ForEach(b => { b.Item4?.Invoke(); });

            return (R)rs;
        }
    }

    public class Dog
    {
        public string Jump(string name) { return name + " Jump"; }
        public string Play(string name) { return name + " Play"; }
    }
    class Test
    {
        private void Main()
        {
            //新建对象
            Dog dog = new Dog();
            //新建代理
            SimpleProxyTool<Dog> proxy = new SimpleProxyTool<Dog>(dog);
            //初始化代理前置、后置操作
            proxy.Add(RunMode.MethodBefore, "Jump", new Action(() => { Console.WriteLine("跳之前1"); }));
            proxy.Add(RunMode.MethodBefore, "Jump", new Action(() => { Console.WriteLine("跳之前2"); }));
            proxy.Add(RunMode.MethodAfter, "Jump", new Action(() => { Console.WriteLine("跳之后1"); }));
            proxy.Add(RunMode.MethodAfter, "Jump", new Action(() => { Console.WriteLine("跳之后2"); }));

            proxy.Add(RunMode.MethodBefore, "Play", new Action(() => { Console.WriteLine("Play之前"); }));
            proxy.Add(RunMode.MethodAfter, "Play", new Action(() => { Console.WriteLine("Play之后"); }));

            proxy.Add(RunMode.AllBefore, "", new Action(() => { Console.WriteLine("所有方法之前"); }));

            //执行目标方法
            string rs = proxy.Invoke<string>("Jump", new[] { "Tom" });
        }
    }
}
