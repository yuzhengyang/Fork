//************************************************************************
//      https://github.com/yuzhengyang
//      author:     yuzhengyang
//      date:       2017.8.1 - 2017.8.7
//      desc:       程序更新工具模型
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Y.Utils.UpdateUtils
{
    /// <summary>
    /// 程序更新信息
    /// </summary>
    public class AppUpdateInfo
    {
        /// <summary>
        /// 功能名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 版本号（必须是点分四位版本号：1.1.1.1）
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// 新版本描述（Readme）
        /// </summary>
        public string Desc { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// 发布日期
        /// </summary>
        public DateTime DateTime { get; set; }
        /// <summary>
        /// 下载方式（0：http；1：ftp）
        /// </summary>
        public int DownloadMode { get; set; }
        /// <summary>
        /// ftp地址
        /// </summary>
        public string FtpIp { get; set; }
        /// <summary>
        /// ftp账号
        /// </summary>
        public string FtpAccount { get; set; }
        /// <summary>
        /// ftp密码
        /// </summary>
        public string FtpPassword { get; set; }
        /// <summary>
        /// Ftp文件
        /// </summary>
        public string FtpFile { get; set; }
        /// <summary>
        /// http地址
        /// </summary>
        public string HttpUrl { get; set; }
        /// <summary>
        /// 文件Md5码
        /// </summary>
        public string Md5 { get; set; }
        /// <summary>
        /// 释放文件目录
        /// </summary>
        public string ReleasePath { get; set; }
    }
}
