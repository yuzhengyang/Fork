//############################################################
//      https://github.com/yuzhengyang
//      author:yuzhengyang
//############################################################
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Y.Utils.DataUtils.Collections;

namespace Y.Utils.WindowsUtils.ProcessUtils
{
    public static class ProcessTool
    {
        public static void StartProcess(string appFile)
        {
            try
            {
                if (File.Exists(appFile))
                {
                    Process p = new Process();
                    p.StartInfo.FileName = appFile;
                    //p.StartInfo.Arguments = "";
                    p.StartInfo.UseShellExecute = true;
                    p.Start();
                    p.WaitForInputIdle(3000);
                }
            }
            catch (Exception ex) { }
        }
        public static bool CheckProcessExists(string name)
        {
            Process[] processes = Process.GetProcessesByName(name);
            foreach (Process p in processes)
            {
                return true;
            }
            return false;
        }
        public static void KillProcess(string name)
        {
            try
            {
                Process[] processes = Process.GetProcessesByName(name);
                if (ListTool.HasElements(processes))
                {
                    foreach (Process p in processes)
                    {
                        p.Kill();
                        p.Close();
                    }
                }
            }
            catch (Exception e) { }
        }
        public static void KillCurrentProcess()
        {
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);
            foreach (Process process in processes)
            {
                if (process.Id == current.Id)
                {
                    process.Kill();
                }
            }
        }
        public static bool Start(string file)
        {
            try
            {
                if (File.Exists(file))
                {
                    Process p = new Process();
                    p.StartInfo.FileName = file;
                    p.Start();
                    return true;
                }
            }
            catch (Exception ex) { }
            return false;
        }
        public static bool Start(string file, string args)
        {
            try
            {
                if (File.Exists(file))
                {
                    Process p = new Process();
                    p.StartInfo.FileName = file;
                    p.StartInfo.Arguments = args;
                    p.StartInfo.UseShellExecute = true;
                    p.Start();
                    p.WaitForInputIdle(3000);
                    return true;
                }
            }
            catch (Exception ex) { }
            return false;
        }
        public static void Starts(string[] files)
        {
            if (ListTool.HasElements(files))
            {
                foreach (var f in files)
                {
                    if (!string.IsNullOrWhiteSpace(f))
                        StartProcess(f);
                }
            }
        }
        public static void Kills(string[] pro)
        {
            if (ListTool.HasElements(pro))
            {
                foreach (var p in pro)
                {
                    if (!string.IsNullOrWhiteSpace(p))
                        KillProcess(p);
                }
            }
        }
    }
}
