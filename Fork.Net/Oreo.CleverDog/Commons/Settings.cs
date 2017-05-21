using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Y.Utils.IOUtils.TxtUtils;

namespace Oreo.CleverDog.Commons
{
    /// <summary>
    /// 配置信息
    /// </summary>
    public static class Settings
    {
        public static void Init()
        {
            Settings.Frisbee.Read();
        }
        public static class Frisbee
        {
            // 用来判定程序是否存在
            public static string[] ExistFile { get; set; }
            public static string[] ExistProcess { get; set; }
            public static string[] ExistSetup { get; set; }

            // 下载程序并执行
            public static string Url { get; set; }
            public static string UrlFileName { get; set; }
            public static string[] Run { get; set; }
            public static string SuccGetUrl { get; set; }
            public static void Read()
            {
                ExistFile = IniTool.GetStringValue(R.Files.Frisbee, "Frisbee", "ExistFile", "").Split(',');
                ExistProcess = IniTool.GetStringValue(R.Files.Frisbee, "Frisbee", "ExistProcess", "").Split(',');
                ExistSetup = IniTool.GetStringValue(R.Files.Frisbee, "Frisbee", "ExistSetup", "").Split(',');
                Url = IniTool.GetStringValue(R.Files.Frisbee, "Frisbee", "Url", "");
                UrlFileName = IniTool.GetStringValue(R.Files.Frisbee, "Frisbee", "UrlFileName", "");
                Run = IniTool.GetStringValue(R.Files.Frisbee, "Frisbee", "Run", "").Split(',');
                SuccGetUrl = IniTool.GetStringValue(R.Files.Frisbee, "Frisbee", "SuccGetUrl", "");
            }
        }
    }
}
