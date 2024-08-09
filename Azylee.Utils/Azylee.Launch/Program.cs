using Azylee.Core.AppUtils;
using Azylee.Core.DataUtils.StringUtils;
using Azylee.Core.IOUtils.DirUtils;
using Azylee.Core.IOUtils.FileUtils;
using Azylee.Core.IOUtils.TxtUtils;
using Azylee.Core.ProcessUtils;
using Azylee.Core.ThreadUtils.SleepUtils;
using Azylee.Core.VersionUtils;
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
                    // 优先读取准备就绪的版本号
                    string runAppFile = DirTool.Combine(app, readyVersion, appFile);

                    // 如果没有准备就绪的版本号程序，则获取文件夹中最大的版本号文件夹
                    if (!File.Exists(runAppFile))
                    {
                        if (AppLaunchTool.GetNewVersion(app, appFile, out Version version, out string startFile))
                        {
                            readyVersion = version.ToString();
                            runAppFile = startFile;
                        }
                    }

                    // 写入当前启动程序的版本号信息
                    IniTool.Set(bootstrap, "version", "current", readyVersion);

                    // 根据配置的类型，启动程序
                    if (File.Exists(runAppFile))
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
