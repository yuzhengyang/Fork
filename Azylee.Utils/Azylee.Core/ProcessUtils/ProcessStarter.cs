﻿using Azylee.Core.DataUtils.StringUtils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;

namespace Azylee.Core.ProcessUtils
{
    /// <summary>
    /// 进程启动工具
    /// </summary>
    public static class ProcessStarter
    {
        /// <summary>
        /// 创建进程
        /// </summary>
        /// <returns></returns>
        public static Process NewProcess(string exe, string args = "", string domain = "", string username = "", string password = "")
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            if (Str.Ok(domain)) startInfo.Domain = domain;
            if (Str.Ok(username)) startInfo.UserName = username;
            if (Str.Ok(password)) startInfo.Password = ConvertToSecureString(password);

            startInfo.FileName = exe;
            startInfo.Arguments = args;
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            startInfo.Verb = "RunAs";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            Process process = new Process();
            process.StartInfo = startInfo;
            return process;
        }
        /// <summary>
        /// 带权限运行的密码保密文本转换
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static SecureString ConvertToSecureString(this string password)
        {
            try
            {
                if (password != null)
                {
                    unsafe
                    {
                        fixed (char* passwordChars = password)
                        {
                            var securePassword = new SecureString(passwordChars, password.Length);
                            securePassword.MakeReadOnly();
                            return securePassword;
                        }
                    }
                }
            }
            catch { }
            return null;
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
