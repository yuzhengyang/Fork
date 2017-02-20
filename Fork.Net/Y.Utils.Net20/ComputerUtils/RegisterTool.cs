using Microsoft.Win32;
using System;

namespace Y.Utils.Net20.ComputerUtils
{
    public class RegisterTool
    {
        /// <summary>
        /// 写入注册表项
        /// </summary>
        /// <param name="key">SOFTWARE\\NC_VideoConferenceSystem</param>
        /// <param name="name">RegTime</param>
        /// <param name="value">yyyy-MM-dd hh:mm:ss</param>
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
        /// <summary>
        /// 读取注册表项
        /// </summary>
        /// <param name="key">SOFTWARE\\NC_VideoConferenceSystem</param>
        /// <param name="name">Path</param>
        /// <returns></returns>
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
    }
}
