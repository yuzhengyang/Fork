using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Y.Utils.DataUtils.Collections;

namespace Y.Utils.WindowsUtils.InfoUtils
{
    public class SoftwareTool
    {
        /// <summary>
        /// 存在控制面板
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool ExistControl(string name)
        {
            List<string> list = new List<string>();
            try
            {
                //打开注册列表卸载选项 SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall
                RegistryKey Key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall");
                if (Key != null)//如果系统禁止访问则返回null
                {
                    foreach (String SubKeyName in Key.GetSubKeyNames())
                    {
                        //打开对应的软件名称
                        RegistryKey SubKey = Key.OpenSubKey(SubKeyName);
                        if (SubKey != null)
                        {
                            String SoftwareName = SubKey.GetValue("DisplayName", "Nothing").ToString();
                            //如果没有取到，则不存入动态数组
                            if (SoftwareName != "Nothing")
                            {
                                list.Add(SoftwareName.Trim());
                            }
                        }
                    }
                }
            }
            catch { }
            if (list.Contains(name))
                return true;
            return false;
        }
        public static bool ExistControl(string[] names)
        {
            bool flag = false;
            if (!ListTool.IsNullOrEmpty(names))
            {
                foreach (var n in names)
                {
                    if (ExistControl(n))
                        return true;
                }
            }
            return flag;
        }
        /// <summary>
        /// 存在进程
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool ExistProcess(string name)
        {
            try
            {
                var p = Process.GetProcessesByName(name);
                if (p != null && p.Length == 0)
                    return false;
                else
                    return true;
            }
            catch { }
            return false;
        }
        public static bool ExistProcess(string[] names)
        {
            bool flag = false;
            if (!ListTool.IsNullOrEmpty(names))
            {
                foreach (var n in names)
                {
                    if (ExistProcess(n))
                        return true;
                }
            }
            return flag;
        }
        /// <summary>
        /// 存在文件
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool ExistFile(string name)
        {
            if (File.Exists(name))
                return true;
            return false;
        }
        public static bool ExistFile(string[] names)
        {
            bool flag = false;
            if (!ListTool.IsNullOrEmpty(names))
            {
                foreach (var n in names)
                {
                    if (ExistFile(n))
                        return true;
                }
            }
            return flag;
        }
        /// <summary>
        /// 存在注册表项
        /// </summary>
        /// <param name="item"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool ExistRegist(string item, string key)
        {
            try
            {
                object obj = Registry.GetValue(item, key, null);
                if (obj != null)
                    return true;
            }
            catch { }
            return false;
        }
    }
}
