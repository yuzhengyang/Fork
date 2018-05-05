using Azylee.Core.AppUtils;
using Azylee.Core.IOUtils.DirUtils;
using Azylee.Core.IOUtils.TxtUtils;
using Azylee.Core.LogUtils.SimpleLogUtils;
using Azylee.Core.ProcessUtils;
using Oreo.BigBirdDeployer.Commons;
using Oreo.BigBirdDeployer.Utils;
using Oreo.BigBirdDeployer.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace Oreo.BigBirdDeployer
{
    static class Program
    {
        static AppUnique appUnique = new AppUnique();
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (appUnique.IsUnique("Oreo.BigBirdDeployer"))
            {
                R.Log = new Log(true);
                InitIni();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
        }
        /// <summary>
        /// 初始化Ini配置信息
        /// </summary>
        static void InitIni()
        {
            DirTool.Create(R.Paths.Settings);

            R.Paths.PublishStorage = IniTool.GetStringValue(R.Files.Settings, "Paths", "PublishStorage", R.Paths.DefaultPublishStorage);
            if (string.IsNullOrWhiteSpace(R.Paths.PublishStorage)) R.Paths.PublishStorage = R.Paths.DefaultPublishStorage;

            R.Paths.NewStorage = IniTool.GetStringValue(R.Files.Settings, "Paths", "NewStorage", R.Paths.DefaultNewStorage);
            if (string.IsNullOrWhiteSpace(R.Paths.NewStorage)) R.Paths.NewStorage = R.Paths.DefaultNewStorage;
        }
    }
}
