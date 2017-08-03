//************************************************************************
//      https://github.com/yuzhengyang
//      author:     yuzhengyang
//      date:       2017.8.1 - 2017.8.1
//      desc:       程序更新工具
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Y.Utils.DelegateUtils;
using Y.Utils.IOUtils.FileUtils;
using Y.Utils.IOUtils.PathUtils;
using Y.Utils.NetUtils.FTPUtils;
using Y.Utils.NetUtils.HttpUtils;

namespace Y.Utils.UpdateUtils
{
    /// <summary>
    /// 程序更新工具
    /// </summary>
    public class AppUpdateTool
    {
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="name">功能名称</param>
        /// <param name="version">当前版本号</param>
        /// <param name="url">请求新版本地址</param>
        /// <param name="path">文件下载位置</param>
        /// <param name="dictionary">文件相对位置字典</param>
        /// <param name="downprogress">下载进度回调</param>
        /// <param name="downsender">下载进度事件数据</param>
        /// <param name="releaseprogress">释放进度回调</param>
        /// <param name="releasesender">释放进度事件数据</param>
        /// <returns>
        /// -10000;//无最新版本，停止操作
        /// -20000;//请求服务器最新版本失败
        /// -30000;//新版本号格式不正确，解析失败
        /// -40000;//文件下载失败
        /// -50000;//文件释放失败
        /// </returns>
        public int Update(string name, Version version, string url, string path, Dictionary<string, string> dictionary,
            ProgressDelegate.ProgressHandler downprogress = null, object downsender = null,
            ProgressDelegate.ProgressHandler releaseprogress = null, object releasesender = null)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            //请求最新版本信息
            AppUpdateInfo info = HttpTool.Get<AppUpdateInfo>(string.Format("{0}?name={1}", url, name));
            if (info != null)
            {
                Version newVersion = GerVersion(info.Version);
                if (newVersion == null) return -30000;//新版本号格式不正确，解析失败

                if (newVersion > version)
                {
                    string file = DirTool.Combine(path, name + newVersion.ToString());
                    //准备更新（下载） 
                    string downfile = Download(file, info, downprogress, downsender);
                    if (!string.IsNullOrWhiteSpace(downfile) && File.Exists(downfile))
                    {
                        //格式化释放文件目录
                        string releasepath = AppDirTool.Get(info.ReleasePath, dictionary);
                        //释放文件
                        int unpackCode = 0;
                        if ((unpackCode = FilePackageTool.Unpack(downfile, releasepath, releaseprogress, releasesender)) > 0)
                        {
                            stopwatch.Stop();
                            return (int)stopwatch.Elapsed.TotalSeconds;
                        }
                        else
                        {
                            return -50000 + unpackCode;//文件释放失败
                        }
                    }
                    else
                    {
                        return -40000;//文件下载失败
                    }
                }
                else
                {
                    return -10000;//无最新版本，停止操作
                }
            }
            else
            {
                return -20000;//请求服务器最新版本失败
            }
        }
        private Version GerVersion(string s)
        {
            //解析最新版本号
            Version version = null;
            try
            {
                version = new Version(s);
            }
            catch (Exception e) { }
            return version;
        }
        private string Download(string file, AppUpdateInfo info, ProgressDelegate.ProgressHandler progress = null, object sender = null)
        {
            FtpTool ftp = new FtpTool(info.FtpIp, info.FtpAccount, info.FtpPassword);
            if (ftp.Download(info.FtpFile, file, progress, sender))
                return file;
            return null;
        }
    }
}
