using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Azylee.Core.ProcessUtils
{
    public static class ProcessStarter
    {
        /// <summary>
        /// 创建进程
        /// </summary>
        /// <returns></returns>
        public static Process NewProcess(string exe, string args = "")
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = exe;
            startInfo.Arguments = args;
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
        /// 开始运行
        /// </summary>
        /// <param name="process"></param>
        /// <param name="output"></param>
        public static void Execute(Process process, Action<string> output)
        {
            StreamReader reader = null;
            try
            {
                process.Start();
                process.StandardInput.AutoFlush = true;
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
    }
}
