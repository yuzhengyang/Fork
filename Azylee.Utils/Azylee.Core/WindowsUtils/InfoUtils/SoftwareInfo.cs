//************************************************************************
//      author:     yuzhengyang
//      date:       2018.3.27 - 2018.6.3
//      desc:       工具描述
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************
using System;

namespace Azylee.Core.WindowsUtils.InfoUtils
{
    public class SoftwareInfo
    {
        /// <summary>
        /// 软件名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 软件版本
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// 开发商
        /// </summary>
        public string Publisher { get; set; }
        /// <summary>
        /// 安装后路径
        /// </summary>
        public string InstallLocation { get; set; }
        /// <summary>
        /// 帮助链接
        /// </summary>
        public string HelpLink { get; set; }
        /// <summary>
        /// 介绍链接
        /// </summary>
        public string URLInfoAbout { get; set; }
        /// <summary>
        /// 卸载字符串
        /// </summary>
        public string UninstallString { get; set; }
        /// <summary>
        /// 空间占用
        /// </summary>
        public int EstimatedSize { get; set; }
        /// <summary>
        /// 安装日期
        /// </summary>
        public DateTime InstallDate { get; set; }
    }
}
