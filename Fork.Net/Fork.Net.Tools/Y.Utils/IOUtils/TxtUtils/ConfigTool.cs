using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Y.Utils.IOUtils.TxtUtils
{
    class ConfigTool
    {
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
