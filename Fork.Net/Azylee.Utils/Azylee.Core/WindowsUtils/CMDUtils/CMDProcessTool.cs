//************************************************************************
//      https://github.com/yuzhengyang
//      author:     yuzhengyang
//      date:       2018.4.27 - 2018.4.27
//      desc:       CMD 工具
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Azylee.Core.WindowsUtils.CMDUtils
{
    public class CMDProcessTool
    {
        /// <summary>
        /// 创建cmd的进程
        /// </summary>
        /// <returns></returns>
        public static Process GetProcess()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = @"/c C:\Windows\System32\cmd.exe ";
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            startInfo.Verb = "RunAs";
            Process process = new Process();
            process.StartInfo = startInfo;
            return process;
        }
        /// <summary>
        /// 开始运行CMD命令
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="output">输出动作</param>
        public static void Execute(string cmd, Action<string> output)
        {
            StreamReader reader = null;
            Process process = null;
            try
            {
                process = GetProcess();
                process.Start();
                process.StandardInput.AutoFlush = true;
                process.StandardInput.WriteLine(cmd);
                process.StandardInput.WriteLine("exit");
                reader = process.StandardOutput;
                do
                {
                    string line = reader.ReadLine();
                    output?.Invoke(line);
                } while (!reader.EndOfStream);
                process.WaitForExit();
                process.Close();
            }
            catch { }
        }
        /// <summary>
        /// 一次性运行CMD并读取结果（建议执行返回数据较小的命令）
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static List<string> Execute(string cmd)
        {
            List<string> result = null;
            StreamReader reader = null;
            Process process = null;
            try
            {
                process = GetProcess();
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
    }
}
