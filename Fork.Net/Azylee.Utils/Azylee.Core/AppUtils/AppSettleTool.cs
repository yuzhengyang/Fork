//************************************************************************
//      author:     yuzhengyang
//      date:       2017.10.12 - 2017.10.12
//      desc:       客户端定居工具
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************
using Azylee.Core.IOUtils.DirUtils;
using Azylee.Core.IOUtils.FileUtils;
using System.Collections.Generic;
using System.IO;

namespace Azylee.Core.AppUtils
{
    /// <summary>
    /// 客户端定居工具
    /// </summary>
    public class AppSettleTool
    {
        /// <summary>
        /// 判断是否已定居
        /// </summary>
        /// <param name="path">定居路径</param>
        /// <param name="list">货物清单</param>
        /// <returns></returns>
        public static bool IsSettle(string path, Dictionary<string, string> list)
        {
            if (Directory.Exists(path))
            {
                if (list != null)
                {
                    bool allOk = true;
                    foreach (var l in list)
                    {
                        if (!string.IsNullOrWhiteSpace(l.Value))
                            allOk &= File.Exists(l.Value);
                    }
                    return allOk;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 定居
        /// </summary>
        /// <param name="path">定居路径</param>
        /// <param name="list">货物清单</param>
        /// <returns></returns>
        public static bool Settle(string path, Dictionary<string, string> list)
        {
            if (DirTool.Create(path))
            {
                if (list != null)
                {
                    foreach (var l in list)
                    {
                        FileTool.Copy(l.Key, l.Value, true);
                    }
                }
            }
            return IsSettle(path, list);
        }
    }
}
