using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.Core.DataUtils.StringUtils;
using Azylee.Core.IOUtils.DirUtils;
using Azylee.Core.ProcessUtils;
using System;
using System.Collections.Generic;
using System.IO;

namespace Azylee.ExeLaunch
{
    public class Launch
    {
        /// <summary>
        /// 启动最新版本程序
        /// </summary>
        /// <param name="path"></param>
        /// <param name="exe"></param>
        /// <returns></returns>
        public static bool Run(string appPath, string startfilename)
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
