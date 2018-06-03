//************************************************************************
//      author:     yuzhengyang
//      date:       2018.3.27 - 2018.6.3
//      desc:       工具描述
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Azylee.Core.IOUtils.TxtUtils
{
    public class ConfigTool
    {
        public static string Get(string key, string defaultValue = "")
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                return config.AppSettings.Settings[key]?.Value ?? defaultValue;
            }
            catch { return defaultValue; }
        }
        public static string Get(string exePath, string key, string defaultValue = "")
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(exePath);
                return config.AppSettings.Settings[key]?.Value ?? defaultValue;
            }
            catch { return defaultValue; }
        }
        public static int GetInt(string key, int defaultValue = 0)
        {
            string s = Get(key: key);
            if (int.TryParse(s, out int value)) return value;
            return defaultValue;
        }
        public static int GetInt(string exePath, string key, int defaultValue = 0)
        {
            string s = Get(exePath: exePath, key: key);
            if (int.TryParse(s, out int value)) return value;
            return defaultValue;
        }

        public static bool Set(string key, string value)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings[key].Value = value;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");//重新加载新的配置文件
                return true;
            }
            catch { return false; }
        }
        public static bool Set(string exePath, string key, string value)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(exePath);
                config.AppSettings.Settings[key].Value = value;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");//重新加载新的配置文件
                return true;
            }
            catch { return false; }
        }
        //private bool CanUpdate()
        //{
        //    string file = AppDomain.CurrentDomain.BaseDirectory + "Settings";
        //    string key = "TodayUpdateTimes";
        //    DateTime today = DateTime.Parse(string.Format("{0}-{1}-{2} 00:00:00", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day));
        //    DateTime setday = today;

        //    //读取配置
        //    string temp = CanUpdateGetConfig(file, key);
        //    if (DateTime.TryParse(temp, out setday) && setday >= today && setday <= today.AddDays(1))
        //    {
        //        if (setday.Hour < 3)
        //            CanUpdateSetConfig(file, key, setday.AddHours(1).ToString());//累加hour记录次数
        //        else
        //            return false;
        //    }
        //    else
        //    {
        //        //配置失效，设置为默认值
        //        CanUpdateSetConfig(file, key, today.ToString());
        //    }
        //    return true;
        //}
        //private bool CanUpdateSetConfig(string file, string key, string value)
        //{
        //    try
        //    {
        //        //文件不存在则创建
        //        if (!File.Exists(file + ".config"))
        //        {
        //            XElement xe = new XElement("configuration");
        //            xe.Save(file + ".config");
        //        }
        //        Configuration config = ConfigurationManager.OpenExeConfiguration(file);
        //        if (config.AppSettings.Settings.AllKeys.Contains(key))
        //        {
        //            config.AppSettings.Settings[key].Value = value;
        //        }
        //        else
        //        {
        //            config.AppSettings.Settings.Add(key, value);
        //        }
        //        config.Save(ConfigurationSaveMode.Modified);
        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        return false;
        //    }
        //}
        //private string CanUpdateGetConfig(string file, string key)
        //{
        //    try
        //    {
        //        Configuration config = ConfigurationManager.OpenExeConfiguration(file);
        //        if (config.AppSettings.Settings.AllKeys.Contains(key))
        //        {
        //            return config.AppSettings.Settings[key].Value;
        //        }
        //    }
        //    catch (Exception e) { }
        //    return null;
        //}
    }
}
