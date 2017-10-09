//************************************************************************
//      https://github.com/yuzhengyang
//      author:     yuzhengyang
//      date:       2017.3.29 - 2017.8.7
//      desc:       文件目录工具类
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Y.Utils.DataUtils.Collections;
using Y.Utils.DataUtils.StringUtils;

namespace Y.Utils.IOUtils.PathUtils
{
    /// <summary>
    /// 文件目录工具类
    /// </summary>
    public class DirTool
    {
        /// <summary>
        /// 创建文件目录（文件不存在则创建）
        /// </summary>
        /// <param name="path"></param>
        /// <returns>
        /// 如果文件已存在，返回true
        /// 如果文件不存在，则创建文件，成功返回true，失败返回false
        /// </returns>
        public static bool Create(string path)
        {
            if (Directory.Exists(path))
                return true;
            else
                try
                {
                    Directory.CreateDirectory(path); return true;
                }
                catch (Exception e)
                {
                }
            return false;
        }
        /// <summary>
        /// 获取目录的父目录
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string Parent(string path)
        {
            string p = path;
            if (!string.IsNullOrWhiteSpace(p))
            {
                while (p.EndsWith("\\")) p = p.Substring(0, p.Length - 1);
                if (StringTool.SubStringCount(p, "\\") >= 1)
                {
                    try
                    {
                        return Directory.GetParent(p).ToString();
                    }
                    catch (Exception e) { }
                }
            }
            return p;
        }
        /// <summary>
        /// 获取目录下的目录（一层）
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static List<string> GetPath(string path)
        {
            if (Directory.Exists(path))
                try { return Directory.EnumerateDirectories(path).ToList(); } catch (Exception e) { }
            return null;
        }
        /// <summary>
        /// 获取目录下所有目录（递归）
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static List<string> GetAllPath(string path)
        {
            List<string> result = GetPath(path);
            if (!ListTool.IsNullOrEmpty(result))
            {
                List<string> temp = new List<string>();
                foreach (var item in result)
                {
                    List<string> t = GetAllPath(item);
                    if (!ListTool.IsNullOrEmpty(t))
                        temp.AddRange(t);
                }
                result.AddRange(temp);
                return result;
            }
            return null;
        }
        /// <summary>
        /// 判断目录是否为磁盘
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool IsDriver(string path)
        {
            if (path != null && path.Length >= 2)
            {
                if (path.Substring(1, 1) == ":")
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 获取文件所在的目录
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string GetFilePath(string filePath)
        {
            string result = "";
            if (!string.IsNullOrWhiteSpace(filePath))
            {
                string fileName = Path.GetFileName(filePath);
                result = filePath.Substring(0, filePath.Length - fileName.Length);
            }
            return result;
        }
        /// <summary>
        /// 连接多个string构成目录
        /// </summary>
        /// <param name="paths"></param>
        /// <returns></returns>
        public static string Combine(params string[] paths)
        {
            if (ListTool.HasElements(paths))
            {
                if (paths.Length > 1)
                {
                    StringBuilder result = new StringBuilder(paths[0]);
                    for (int i = 1; i < paths.Length; i++)
                    {
                        result.Append("\\");
                        result.Append(paths[i]);
                    }
                    while (result.ToString().IndexOf("\\\\") >= 0)
                    {
                        result.Replace("\\\\", "\\");
                    }
                    return result.ToString();
                }
                else
                {
                    return paths[0];
                }
            }
            return "";
        }
        /// <summary>
        /// 路径包含关系
        /// </summary>
        /// <param name="path1"></param>
        /// <param name="path2"></param>
        /// <returns>
        /// -1：不存在包含关系
        /// 0：两个目录相同
        /// 1：path1 包含 path2（path1 大）
        /// 2：path2 包含 path1（path2 大）
        /// </returns>
        public static int Include(string path1, string path2)
        {
            if (path1 == path2) return 0;//两个目录相同

            string p1 = Combine(path1 + "\\");
            string p2 = Combine(path2 + "\\");

            if (p1 == p2) return 0;//两个目录相同（防止路径后有带\或不带\的情况）
            if (p1.Length > p2.Length && p1.Contains(p2)) return 1;//path1 包含 path2（path1 大）
            if (p2.Length > p1.Length && p2.Contains(p1)) return 2;//path2 包含 path1（path2 大）

            return -1;//不存在包含关系
        }
        public static string GetPathName(string s)
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(s))
            {
                char[] c = s.ToArray();
                for (int i = c.Length - 1; i >= 0; i--)
                {
                    if (c[i] != '\\') { sb.Append(c[i]); }
                    else { if (sb.Length > 0) break; }
                }
                char[] mirror = sb.ToString().ToArray();
                sb.Clear();
                for (int i = mirror.Length - 1; i >= 0; i--)
                {
                    sb.Append(mirror[i]);
                }
            }
            return sb.ToString();
        }
    }
}
