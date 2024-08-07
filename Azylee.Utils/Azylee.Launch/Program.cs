using Azylee.Core.AppUtils;
using Azylee.Core.DataUtils.StringUtils;
using Azylee.Core.IOUtils.DirUtils;
using Azylee.Core.IOUtils.TxtUtils;
using Azylee.Core.ProcessUtils;
using Azylee.Core.ThreadUtils.SleepUtils;
using Azylee.Core.WindowsUtils.CMDUtils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Azylee.Launch
{
    internal static class Program
    {
        static AppUnique AppUnique = new AppUnique();

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string app = AppDomain.CurrentDomain.BaseDirectory;
            string bootstrap = DirTool.Combine(app, "bootstrap.ini");

            bool isStart = false;
            string appName = IniTool.GetString(bootstrap, "app", "name", "");
            string appFile = IniTool.GetString(bootstrap, "app", "file", "");
            string appType = IniTool.GetString(bootstrap, "app", "type", "");
            string currentVersion = IniTool.GetString(bootstrap, "version", "current", "");
            string readyVersion = IniTool.GetString(bootstrap, "version", "ready", "");

            //程序单开验证
            if (AppUnique.IsUnique($"{appName}-{appFile}"))
            {
                if (args.Contains("-delay5")) Sleep.S(5);//带参数等待：5秒
                if (args.Contains("-delay10")) Sleep.S(10);//带参数等待：10秒
                if (args.Contains("-delay30")) Sleep.S(30);//带参数等待：30秒

                // 执行最新准备好的版本
                if (StringTool.Ok(readyVersion))
                {
                    string runAppFile = DirTool.Combine(app, readyVersion, appFile);
                    if (Str.Ok(readyVersion) && File.Exists(runAppFile))
                    {
                        switch (appType)
                        {
                            case "exe":
                                isStart = ProcessTool.StartCustom(runAppFile);
                                break;
                            case "cmd":
                            case "bat":
                                CMDProcessTool.Execute(runAppFile);
                                break;
                            default: break;
                        }
                    }
                }
            }
        }
    }
}
