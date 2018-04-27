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
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            return p;
        }

        /// <summary>
        /// 开始运行CMD命令
        /// </summary>
        /// <param name="cmd"></param>
        public static void StartExecute(string cmd)
        { 
            StreamReader reader = null;
            Process process = null;
            try
            {
                process = GetProcess();
                process.Start();
                process.StandardInput.WriteLine(cmd);
                reader = process.StandardOutput;
                do
                {
                    string line = reader.ReadLine();
                } while (!reader.EndOfStream);
                process.WaitForExit();
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
                    result.Add(line.Trim());
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
