using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.Utils.WindowsUtils.InfoUtils;

namespace Y.Utils.AppUtils
{
    public class StartupTool
    {
        public static string RegeditRunKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
        public static bool Regedit(string appName, string appFile, bool start = true)
        {
            if (start)
            {
                //添加启动注册表
                if (RegisterTool.Write(RegeditRunKey, appName, appFile))
                    return true;
            }
            else
            {
                //删除启动注册表
                if (RegisterTool.Delete(RegeditRunKey, appName))
                    return true;
            }
            return false;
        }
        public static bool Shortcut(string appName, string appFile, bool start = true)
        {
            if (start)
            {
                //添加开机启动开始菜单项
            }
            else
            {
                //删除开机启动开始菜单项
            }
            return false;
        }
    }
}
