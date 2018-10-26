//************************************************************************
//      https://github.com/yuzhengyang
//      author:     yuzhengyang
//      date:       2017.10.12 - 2018.10.24
//      desc:       客户端启动器
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************
using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.Core.DataUtils.StringUtils;
using Azylee.Core.IOUtils.DirUtils;
using Azylee.Core.IOUtils.FileUtils;
using Azylee.Core.ProcessUtils;
using System;
using System.Collections.Generic;
using System.IO;

namespace Azylee.Core.AppUtils
{
    public static class AppLaunchTool
    {
        /// <summary>
        /// 启动最新版本程序
        /// </summary>
        /// <param name="route">路径：程序版本文件夹路径</param>
        /// <param name="exeFile">可执行文件名</param>
        /// <returns></returns>
        public static bool StartNewVersion(string route, string exeFile)
        {
            if (GetNewVersion(route, exeFile, out Version version, out string startFile))
            {
                return ProcessTool.Start(startFile);
            }
            return false;
        }
        public static bool Start(string file)
        {
            return ProcessTool.Start(file);
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
        /// <param name="exeFile">可执行文件名</param>
        /// <returns></returns>
        public static bool GetNewVersion(string route, string exeFile, out Version version, out string startFile)
        {
            version = null;
            startFile = "";

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
                                string tempFile = DirTool.Combine(path, exeFile);
                                if ((version == null || tempVersion > version) && File.Exists(tempFile))
                                {
                                    version = tempVersion;
                                    startFile = tempFile;
                                }
                            }
                            catch { }
                        }
                    }
                }
            }
            if (version != null && Str.Ok(startFile)) return true;
            return false;
        }
    }
}
