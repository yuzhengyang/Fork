//************************************************************************
//      author:     yuzhengyang
//      date:       2018.4.27 - 2018.4.27
//      desc:       Explorer工具类
//      Copyright (c) yuzhengyang. All rights reserved.
//      Quote:      https://www.cnblogs.com/crwy/p/SHOpenFolderAndSelectItems.html
//************************************************************************
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Azylee.Core.WindowsUtils.APIUtils
{
    public class ExplorerAPI
    {
        /// <summary>
        /// 打开文件夹
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool Open(string path)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    Process.Start(@"explorer.exe", "/select,\"" + path + "\"");
                    return true;
                }
            }
            catch { }
            return false;
        }

        /// <summary>
        /// 打开路径并定位文件...
        /// 对于@"h:\Bleacher Report - Hardaway with the safe call ??.mp4"
        /// 这样的，explorer.exe /select,d:xxx不认，用API整它
        /// </summary>
        /// <param name="filePath">文件绝对路径</param>
        [DllImport("shell32.dll", ExactSpelling = true)]
        private static extern void ILFree(IntPtr pidlList);

        [DllImport("shell32.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern IntPtr ILCreateFromPathW(string pszPath);

        [DllImport("shell32.dll", ExactSpelling = true)]
        private static extern int SHOpenFolderAndSelectItems(IntPtr pidlList, uint cild, IntPtr children, uint dwFlags);

        public static void ExplorerFile(string filePath)
        {
            if (!File.Exists(filePath) && !Directory.Exists(filePath))
                return;

            if (Directory.Exists(filePath))
                Process.Start(@"explorer.exe", "/select,\"" + filePath + "\"");
            else
            {
                IntPtr pidlList = ILCreateFromPathW(filePath);
                if (pidlList != IntPtr.Zero)
                {
                    try
                    {
                        Marshal.ThrowExceptionForHR(SHOpenFolderAndSelectItems(pidlList, 0, IntPtr.Zero, 0));
                    }
                    finally
                    {
                        ILFree(pidlList);
                    }
                }
            }
        }
    }
}
