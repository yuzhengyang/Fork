//************************************************************************
//      https://github.com/yuzhengyang
//      author:     yuzhengyang
//      date:       2017.10.12 - 2017.10.12
//      desc:       客户端启动器
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Y.Utils.DataUtils.Collections;
using Y.Utils.DataUtils.StringUtils;
using Y.Utils.IOUtils.FileUtils;
using Y.Utils.IOUtils.PathUtils;
using Y.Utils.WindowsUtils.ProcessUtils;

namespace Y.Utils.AppUtils
{
    public static class AppLaunchTool
    {
        /// <summary>
        /// 启动最新版本程序
        /// </summary>
        /// <param name="route">路径：程序版本文件夹路径</param>
        /// <param name="startfilename">可执行文件名</param>
        /// <returns></returns>
        public static bool StartNewVersion(string route, string startfilename)
        {
            //判断路径是文件还是文件夹，并统一处理为文件夹
            string appPath = route;
            if (FileTool.IsFile(route))
                appPath = DirTool.GetFilePath(route);

            if (Directory.Exists(appPath))
            {
                //获取运行目录下所有文件
                List<string> paths = DirTool.GetPath(appPath);
                if (ListTool.HasElements(paths))
                {
                    //解析属于版本号的文件
                    Version version = null;
                    string startfile = null;
                    foreach (var path in paths)
                    {
                        //只解析文件名带三个点的文件夹
                        string filename = Path.GetFileName(path);
                        if (StringTool.SubStringCount(filename, ".") == 3)
                        {
                            try
                            {
                                Version tempVersion = new Version(filename);
                                string tempFile = DirTool.Combine(path, startfilename);
                                if ((version == null || tempVersion > version) && File.Exists(tempFile))
                                {
                                    version = tempVersion;
                                    startfile = tempFile;
                                }
                            }
                            catch { }
                        }
                    }
                    //准备启动
                    if (startfile != null)
                    {
                        return ProcessTool.Start(startfile);
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// 查询是否有最新版本程序可以执行
        /// </summary>
        /// <param name="route">路径：程序版本文件夹路径</param>
        /// <param name="startfilename">可执行文件名</param>
        /// <returns></returns>
        public static bool HasNewVersion(string route, string startfilename)
        {
            //判断路径是文件还是文件夹，并统一处理为文件夹
            string appPath = route;
            if (FileTool.IsFile(route))
                appPath = DirTool.GetFilePath(route);

            if (Directory.Exists(appPath))
            {
                //获取运行目录下所有文件
                List<string> paths = DirTool.GetPath(appPath);
                if (ListTool.HasElements(paths))
                {
                    //解析属于版本号的文件
                    foreach (var path in paths)
                    {
                        //只解析文件名带三个点的文件夹
                        string filename = Path.GetFileName(path);
                        if (StringTool.SubStringCount(filename, ".") == 3)
                        {
                            try
                            {
                                //有版本命名的文件，且文件中有exe程序
                                Version tempVersion = new Version(filename);
                                string tempFile = DirTool.Combine(path, startfilename);
                                if (File.Exists(tempFile)) return true;
                            }
                            catch { }
                        }
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// 获取最新版本号
        /// </summary>
        /// <param name="route">路径：程序版本文件夹路径</param>
        /// <param name="startfilename">可执行文件名</param>
        /// <returns></returns>
        public static Version GetNewVersion(string route, string startfilename)
        {
            //解析属于版本号的文件
            Version version = null;
            string startfile = null;

            //判断路径是文件还是文件夹，并统一处理为文件夹
            string appPath = route;
            if (FileTool.IsFile(route))
                appPath = DirTool.GetFilePath(route);

            if (Directory.Exists(appPath))
            {
                //获取运行目录下所有文件
                List<string> paths = DirTool.GetPath(appPath);
                if (ListTool.HasElements(paths))
                { 
                    foreach (var path in paths)
                    {
                        //只解析文件名带三个点的文件夹
                        string filename = Path.GetFileName(path);
                        if (StringTool.SubStringCount(filename, ".") == 3)
                        {
                            try
                            {
                                Version tempVersion = new Version(filename);
                                string tempFile = DirTool.Combine(path, startfilename);
                                if ((version == null || tempVersion > version) && File.Exists(tempFile))
                                {
                                    version = tempVersion;
                                    startfile = tempFile;
                                }
                            }
                            catch { }
                        }
                    } 
                }
            }
            return version;
        }
    }
}
