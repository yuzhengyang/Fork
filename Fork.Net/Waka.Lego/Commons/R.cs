using System;
using System.Windows.Forms;
using Y.Utils.ComputerUtils;

namespace Waka.Lego.Commons
{
    public static class R
    {
        public static string AppName = "Waka.Lego";
        public static string AppPath = AppDomain.CurrentDomain.BaseDirectory;
        public static string AppFile = Application.ExecutablePath;
        public static string AppDataPath;//应用根目录
        public static string SettingsFile;//应用配置信息目录
        public static string MarksPath;//应用记录数据目录
        public static string MarksFile;//应用记录文件文件名
        public static bool Release = false;
        public static string Name = Environment.MachineName;
        public static bool IsAdministrator = ComputerPermissionTool.IsAdministrator();
    }
}
