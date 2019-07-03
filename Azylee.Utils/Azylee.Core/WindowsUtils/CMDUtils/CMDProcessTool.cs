//************************************************************************
//      author:     yuzhengyang
//      date:       2018.4.27 - 2019.4.7
//      desc:       CMD 工具
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************
using Azylee.Core.DataUtils.StringUtils;
using Azylee.Core.ProcessUtils;
using Azylee.Core.ThreadUtils.SleepUtils;
using Azylee.Core.WindowsUtils.AdminUtils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace Azylee.Core.WindowsUtils.CMDUtils
{
    /// <summary>
    /// CMD进程启动工具
    /// </summary>
    public class CMDProcessTool
    {
        /// <summary>
        /// 创建cmd的进程
        /// </summary>
        /// <returns></returns>
        public static Process GetProcess(string verb = "RunAs", WindowsAccountModel account = null)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            if (account != null && account.Check())
            {
                if (Str.Ok(account.Domain)) startInfo.Domain = account.Domain;
                if (Str.Ok(account.UserName)) startInfo.UserName = account.UserName;
                if (Str.Ok(account.Password)) startInfo.Password = ProcessStarter.ConvertToSecureString(account.Password);
            }

            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = @"/c C:\Windows\System32\cmd.exe";
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            startInfo.Verb = verb;
            Process process = new Process();
            process.StartInfo = startInfo;
            return process;
        }
        /// <summary>
        /// 开始运行CMD命令
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="output">输出动作</param>
        public static void Execute(string cmd, Action<string> output, WindowsAccountModel account = null)
        {
            Process process = null;
            StreamReader outReader = null;
            StreamReader errReader = null;
            try
            {
                process = GetProcess(account: account);
                process.Start();
                process.StandardInput.AutoFlush = true;
                process.StandardInput.WriteLine(cmd);
                process.StandardInput.WriteLine("exit");

                outReader = process.StandardOutput;
                errReader = process.StandardError;

                ReaderAction(outReader, output);
                ReaderAction(errReader, output);

                process.WaitForExit();
                process.Close();
            }
            catch { }
        }
        /// <summary>
        /// 运行CMD并读取结果（建议执行返回数据较小的命令）
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static List<string> Execute(string cmd, WindowsAccountModel account = null)
        {
            List<string> result = null;
            StreamReader reader = null;
            Process process = null;
            try
            {
                process = GetProcess(account: account);
                process.Start();
                process.StandardInput.WriteLine(cmd);
                process.StandardInput.WriteLine("exit");
                reader = process.StandardOutput;
                result = new List<string>();
                do
                {
                    string line = reader.ReadLine();
                    if (Str.Ok(line)) result.Add(line.Trim());
                } while (!reader.EndOfStream);
                process.WaitForExit();
            }
            catch { }
            finally
            {
                reader?.Close();
                process?.Close();
                process?.Dispose();
            }
            return result;
        }
        private static void ReaderAction(StreamReader reader, Action<string> output)
        {
            try
            {
                Task.Factory.StartNew(() =>
                {
                    do
                    {
                        string line = reader.ReadLine();
                        output?.Invoke(line);
                    } while (!reader.EndOfStream);
                    string s = "reader process is end";
                });
            }
            catch { }
        }
    }
}
