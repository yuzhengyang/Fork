using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.Core.ProcessUtils;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Azylee.Core.WindowsUtils.InfoUtils
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
            if (GetControlList().Any(x => x.Name == name))
                return true;
            return false;
        }
        public static bool ExistControl(string[] names)
        {
            bool flag = false;
            if (ListTool.HasElements(names))
            {
                foreach (var n in names)
                {
                    if (ExistControl(n))
                        return true;
                }
            }
            return flag;
        }
        public static List<SoftwareInfo> GetControlList()
        {
            List<SoftwareInfo> result = new List<SoftwareInfo>();
            result.AddRange(GetControlList(Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall")));
            result.AddRange(GetControlList(Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall")));
            result.AddRange(GetControlList(Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall")));
            result.AddRange(GetControlList(Registry.CurrentUser.OpenSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall")));
            return result;
        }
        private static List<SoftwareInfo> GetControlList(RegistryKey key)
        {
            List<SoftwareInfo> result = new List<SoftwareInfo>();
            try
            {
                if (key != null)//如果系统禁止访问则返回null
                {
                    foreach (string SubKeyName in key.GetSubKeyNames())
                    {
                        //打开对应的软件名称
                        RegistryKey SubKey = key.OpenSubKey(SubKeyName);
                        if (SubKey != null)
                        {

                            string name = SubKey.GetValue("DisplayName", "").ToString();
                            string pub = SubKey.GetValue("Publisher", "").ToString();
                            string version = SubKey.GetValue("DisplayVersion", "").ToString();
                            string datestr = SubKey.GetValue("InstallDate", "").ToString();
                            string sizestr = SubKey.GetValue("EstimatedSize", "").ToString();
                            string helpurl = SubKey.GetValue("HelpLink", "").ToString();
                            string abouturl = SubKey.GetValue("URLInfoAbout", "").ToString();
                            DateTime date = DateTime.Parse("2001-10-25");//设置初始值为WindowsXP发布日期
                            DateTime.TryParseExact(datestr, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out date);
                            if (date.Year < 2001) date = DateTime.Parse("2001-10-25");

                            int size = 0;
                            int.TryParse(sizestr, out size);
                            result.Add(new SoftwareInfo()
                            {
                                Name = name,
                                Publisher = pub,
                                Version = version,
                                InstallDate = date,
                                EstimatedSize = size,
                                HelpLink = helpurl,
                                URLInfoAbout = abouturl,
                            });
                        }
                        SubKey?.Close();
                    }
                }
                key?.Close();
            }
            catch { }
            return result;
        }
        /// <summary>
        /// 存在进程
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool ExistProcess(string name)
        {
            return ProcessTool.IsExists(name);
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
