//************************************************************************
//      https://github.com/yuzhengyang
//      author:     yuzhengyang
//      date:       2017.10.12 - 2018.5.28
//      desc:       进程工具
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************
using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.Core.ThreadUtils.SleepUtils;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace Azylee.Core.ProcessUtils
{
    public static class ProcessTool
    {
        /// <summary>
        /// 判断进程是否存在
        /// </summary>
        /// <param name="name">进程名</param>
        /// <returns></returns>
        public static bool IsExists(string name)
        {
            try
            {
                var p = Process.GetProcessesByName(name);
                if (ListTool.HasElements(p)) return true;
            }
            catch { }
            return false;
        }
        /// <summary>
        /// 启动程序
        /// </summary>
        /// <param name="file">文件路径</param>
        /// <param name="args">启动参数</param>
        /// <returns></returns>
        public static bool Start(string file, string args = "")
        {
            if (File.Exists(file))
            {
                try
                {
                    Process.Start(file, args);
                    return true;
                }
                catch { }
            }
            return false;
        }
        /// <summary>
        /// 启动进程（定制启动配置）
        /// </summary>
        /// <param name="args"></param>
        public static bool StartCustom(string file, string args = "")
        {
            try
            {
                if (File.Exists(file))
                {
                    Process p = new Process();
                    p.StartInfo.FileName = file;
                    p.StartInfo.Arguments = args;
                    p.StartInfo.UseShellExecute = true;
                    p.Start();
                    p.WaitForInputIdle(3000);
                    return true;
                }
            }
            catch (Exception ex) { }
            return false;
        }
        /// <summary>
        /// 停止进程
        /// </summary>
        /// <param name="name">进程名</param>
        public static void Kill(string name)
        {
            try
            {
                Process[] processes = Process.GetProcessesByName(name);
                foreach (Process p in processes)
                {
                    p.Kill();
                    p.Close();
                }
            }
            catch (Exception e) { }
        }
        /// <summary>
        /// 停止当前进程
        /// </summary>
        public static void KillCurrent()
        {
            try
            {
                Process current = Process.GetCurrentProcess();
                current.Kill();
            }
            catch { }
        }
        /// <summary>
        /// 停止多个进程
        /// </summary>
        /// <param name="names"></param>
        public static void Kills(string[] names)
        {
            if (ListTool.HasElements(names))
            {
                foreach (var name in names)
                {
                    if (!string.IsNullOrWhiteSpace(name))
                        Kill(name);
                }
            }
        }
        /// <summary>
        /// 停止超时进程
        /// </summary>
        /// <param name="name">进程名（不含后缀）</param>
        /// <param name="file">文件路径（为空则不验证）</param>
        /// <param name="second">超时时间（单位：秒）</param>
        public static void Kills(string name, string file, int second)
        {
            try
            {
                Process[] list = Process.GetProcessesByName(name);
                if (ListTool.HasElements(list))
                {
                    DateTime time = DateTime.Now.AddSeconds(-1 * second);
                    foreach (var p in list)
                    {
                        if (file == null || p.MainModule.FileName == file)
                            if (p.StartTime < time)
                                try { p.Kill(); } catch { }
                    }
                }
            }
            catch { }
        }
        /// <summary>
        /// 强制关闭超时进程
        /// </summary>
        /// <param name="process"></param>
        /// <param name="second"></param>
        public static void Kill(Process process, int second)
        {
            DateTime time = DateTime.Now.AddSeconds(-1 * second);
            if (process.StartTime < time)
                try { process.Kill(); } catch { }
        }
        /// <summary>
        /// 延时并关闭进程
        /// </summary>
        /// <param name="process"></param>
        /// <param name="second"></param>
        public static void SleepKill(Process process, short second)
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    Sleep.S(second);
                    process?.Kill();
                }
                catch { }
            });
        }
        /// <summary>
        /// 根据PID获取InstanceName（不要用于性能计数器，#1..实例名会自动改变）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetInstanceNameById(int id)
        {
            try
            {
                PerformanceCounterCategory cat = new PerformanceCounterCategory("Process");
                string[] instances = cat.GetInstanceNames();
                foreach (string instance in instances)
                {
                    try
                    {
                        using (PerformanceCounter cnt = new PerformanceCounter("Process", "ID Process", instance, true))
                        {
                            int val = (int)cnt.RawValue;
                            if (val == id)
                            {
                                return instance;
                            }
                        }
                    }
                    catch { }
                }
            }
            catch { }
            return null;
        }
    }
}
