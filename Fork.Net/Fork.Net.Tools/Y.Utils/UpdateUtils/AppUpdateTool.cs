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
using Y.Utils.DataUtils.GuidUtils;
using Y.Utils.DelegateUtils;
using Y.Utils.IOUtils.FileUtils;
using Y.Utils.IOUtils.PathUtils;
using Y.Utils.NetUtils.FTPUtils;
using Y.Utils.NetUtils.HttpUtils;
using Y.Utils.VersionUtils;

namespace Y.Utils.UpdateUtils
{
    /// <summary>
    /// 程序更新工具
    /// </summary>
    public class AppUpdateTool
    {
        /// <summary>
        /// 获取新版本
        /// </summary>
        /// <param name="url"></param>
        /// <param name="version"></param>
        /// <param name="info"></param>
        /// <returns>
        /// -10;//请求版本失败
        /// -20;//没有更新的版本
        /// </returns>
        public int GetNewVersion(string url, Version version, out AppUpdateInfo info)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            info = HttpTool.Get<AppUpdateInfo>(url);
            if (info != null)
            {
                Version newVersion = VersionTool.Format(info.Version);
                if (newVersion != null && newVersion > version)
                {
                    stopwatch.Stop();
                    return (int)stopwatch.Elapsed.TotalSeconds;//成功返回操作时长
                }
                else
                {
                    return -20;//没有更新的版本
                }
            }
            return -10;//请求版本失败
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="info">新版本信息</param>
        /// <param name="tempPath">文件下载位置</param>
        /// <param name="dictionary">文件相对位置字典</param>
        /// <param name="downProgress">下载进度回调</param>
        /// <param name="downSender">下载进度事件数据</param>
        /// <param name="releaseProgress">释放进度回调</param>
        /// <param name="releaseSender">释放进度事件数据</param>
        /// <returns>
        /// -10000;//没有新版本
        /// -20000;//文件下载失败
        /// -30000;//文件释放失败
        /// </returns>
        public int Update(AppUpdateInfo info, string tempPath, Dictionary<string, string> dictionary,
            ProgressDelegate.ProgressHandler downProgress = null, object downSender = null,
            ProgressDelegate.ProgressHandler releaseProgress = null, object releaseSender = null)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            //请求最新版本信息
            if (info != null)
            {
                string file = DirTool.Combine(tempPath, GuidTool.Short() + "-" + info.Version);
                //准备更新（下载） 
                string downfile = Download(file, info, downProgress, downSender);
                if (!string.IsNullOrWhiteSpace(downfile) && File.Exists(downfile))
                {
                    //格式化释放文件目录（相对路径转换为绝对路径）
                    string releasepath = AppDirTool.Get(info.ReleasePath, dictionary);
                    //释放文件，释放完成后删除临时文件
                    int unpackCode = FilePackageTool.Unpack(downfile, releasepath, releaseProgress, releaseSender);
                    File.Delete(file);
                    if (unpackCode > 0)
                    {
                        stopwatch.Stop();
                        return (int)stopwatch.Elapsed.TotalSeconds;
                    }
                    else
                    {
                        return -30000 + unpackCode;//文件释放失败
                    }
                }
                else
                {
                    return -20000;//文件下载失败
                }
            }
            else
            {
                return -10000;//没有新版本
            }
        }
        private string Download(string file, AppUpdateInfo info, ProgressDelegate.ProgressHandler progress = null, object sender = null)
        {
            if (info != null)
            {
                switch (info.DownloadMode)
                {
                    case 0://http 下载
                        {
                            if (HttpTool.Download(info.HttpUrl, file, progress, sender))
                                return file;
                        }
                        break;

                    case 1://ftp 下载  
                        {
                            FtpTool ftp = new FtpTool(info.FtpIp, info.FtpAccount, info.FtpPassword);
                            if (ftp.Download(info.FtpFile, file, progress, sender))
                                return file;
                        }
                        break;
                }
            }
            return null;
        }
    }
}
