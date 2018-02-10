//************************************************************************
//      https://github.com/yuzhengyang
//      author:     yuzhengyang
//      date:       2017.3.29 - 2017.6.13
//      desc:       设为开机启动
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************
using Azylee.Core.WindowsUtils.RegisterUtils;
using Azylee.Core.WindowsUtils.ShortcutUtils;
using System;

namespace Azylee.Core.AppUtils
{
    /// <summary>
    /// 设为开机启动
    /// </summary>
    public class StartupTool
    {

        private static string regAll = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
        private static string regCurrent = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run";
        private static string commonStartup = Environment.GetFolderPath(Environment.SpecialFolder.CommonStartup);
        private static string startup = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
        public static bool Register(string name, string file, bool start = true, bool allUser = true)
        {
            if (start)
            {
                //注册开机启动注册表项
                if (allUser)
                {
                    if (RegisterTool.SetValue(regAll, name, file)) return true;
                }
                else
                {
                    if (RegisterTool.SetValue(regCurrent, name, file)) return true;
                }
            }
            else
            {
                //移除开机启动注册表项
                if (allUser)
                {
                    if (RegisterTool.DeleteValue(regAll, name)) return true;
                }
                else
                {
                    if (RegisterTool.DeleteValue(regCurrent, name)) return true;
                }
            }
            return false;
        }
        public static bool Shortcut(string name, string file, bool start = true, bool allUser = true)
        {
            if (start)
            {
                //添加开机启动开始菜单项
                if (allUser)
                {
                    if (ShortcutTool.Create(commonStartup, name, file)) return true;
                }
                else
                {
                    if (ShortcutTool.Create(startup, name, file)) return true;
                }
            }
            else
            {
                //删除开机启动开始菜单项
                if (allUser)
                {
                    if (ShortcutTool.Delete(commonStartup, name)) return true;
                }
                else
                {
                    if (ShortcutTool.Delete(startup, name)) return true;
                }
            }
            return false;
        }
    }
}
