using Microsoft.Win32;
using System;

namespace Y.Utils.WindowsUtils.InfoUtils
{
    public class RegisterTool
    {
        [Obsolete]
        public static bool Write(string key, string name, string value)
        {
            try
            {
                RegistryKey RKey = Registry.LocalMachine.OpenSubKey(key, true);
                if (RKey == null)
                    RKey = Registry.LocalMachine.CreateSubKey(key);
                RKey.SetValue(name, value);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        [Obsolete]
        public static string Read(string key, string name)
        {
            try
            {
                RegistryKey RKey = Registry.LocalMachine.OpenSubKey(key, true);
                if (RKey != null)
                {
                    return RKey.GetValue(name) != null ? RKey.GetValue(name).ToString() : "";
                }
            }
            catch (Exception e) { }
            return null;
        }
        [Obsolete]
        public static bool Delete(string key, string name)
        {
            try
            {
                RegistryKey RKey = Registry.LocalMachine.OpenSubKey(key, true);
                if (RKey != null)
                    RKey.DeleteValue(name);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// 添加注册表值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool SetValue(string key, string name, string value)
        {
            try
            {
                using (RegistryKey RKey = Create(key))
                {
                    RKey.SetValue(name, value);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        /// <summary>
        /// 删除注册表值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetValue(string key, string name)
        {
            try
            {
                using (RegistryKey RKey = Open(key, false))
                {
                    if (RKey != null)
                    {
                        return RKey.GetValue(name) != null ? RKey.GetValue(name).ToString() : "";
                    }
                }
            }
            catch (Exception e) { }
            return null;
        }
        /// <summary>
        /// 删除注册表值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool DeleteValue(string key, string name)
        {
            try
            {
                using (RegistryKey RKey = Open(key, true))
                {
                    if (RKey != null)
                        RKey.DeleteValue(name);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        /// <summary>
        /// 分离注册表根目录和子目录
        /// </summary>
        /// <param name="key"></param>
        /// <param name="reg"></param>
        /// <param name="sub"></param>
        /// <returns></returns>
        private static bool ExtractInfo(string key, out string reg, out string sub)
        {
            reg = ""; sub = "";
            int splitPos = 1;
            if ((splitPos = key.IndexOf('\\')) > 0)
            {
                reg = key.Substring(0, splitPos);
                sub = key.Substring(splitPos + 1);
                return true;
            }
            return false;
        }
        /// <summary>
        /// 打开注册表相应目录
        /// </summary>
        /// <param name="key">目标子项</param>
        /// <param name="writable">是否具有写权限</param>
        /// <returns></returns>
        private static RegistryKey Open(string key, bool writable)
        {
            string regkey, subkey;
            if (ExtractInfo(key, out regkey, out subkey))
            {
                switch (regkey)
                {
                    case "HKEY_CLASSES_ROOT": return Registry.ClassesRoot.OpenSubKey(subkey, writable);
                    case "HKEY_CURRENT_USER": return Registry.CurrentUser.OpenSubKey(subkey, writable);
                    case "HKEY_LOCAL_MACHINE": return Registry.LocalMachine.OpenSubKey(subkey, writable);
                    case "HKEY_USERS": return Registry.Users.OpenSubKey(subkey, writable);
                    case "HKEY_CURRENT_CONFIG": return Registry.CurrentConfig.OpenSubKey(subkey, writable);
                    default: return Registry.CurrentUser.OpenSubKey(subkey, writable);
                }
            }
            return Registry.CurrentUser.OpenSubKey(subkey, writable);
        }
        /// <summary>
        /// 创建或打开注册表相应目录
        /// </summary>
        /// <param name="key">目标子项</param>
        /// <returns></returns>
        private static RegistryKey Create(string key)
        {
            string regkey, subkey;
            if (ExtractInfo(key, out regkey, out subkey))
            {
                switch (regkey)
                {
                    case "HKEY_CLASSES_ROOT": return Registry.ClassesRoot.CreateSubKey(subkey);
                    case "HKEY_CURRENT_USER": return Registry.CurrentUser.CreateSubKey(subkey);
                    case "HKEY_LOCAL_MACHINE": return Registry.LocalMachine.CreateSubKey(subkey);
                    case "HKEY_USERS": return Registry.Users.CreateSubKey(subkey);
                    case "HKEY_CURRENT_CONFIG": return Registry.CurrentConfig.CreateSubKey(subkey);
                    default: return Registry.CurrentUser.CreateSubKey(subkey);
                }
            }
            return Registry.CurrentUser.CreateSubKey(subkey);
        }
    }
}
