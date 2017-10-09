using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Y.Utils.DataUtils.Collections;
using Y.Utils.DataUtils.StringUtils;
using Y.Utils.IOUtils.PathUtils;
using Y.Utils.WindowsUtils.ProcessUtils;

namespace Y.Utils.AppUtils
{
    public static class AppLaunchTool
    {
        public static bool Start(string appfile, string startfilename)
        {
            if (File.Exists(appfile))
            {
                //获取程序运行目录
                string exePath = DirTool.GetFilePath(appfile);
                if (Directory.Exists(exePath))
                {
                    //获取运行目录下所有文件
                    List<string> paths = DirTool.GetPath(exePath);
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
            }
            return false;
        }
        public static bool StartNewVersion(string appPath, string startfilename)
        {
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
    }
}
