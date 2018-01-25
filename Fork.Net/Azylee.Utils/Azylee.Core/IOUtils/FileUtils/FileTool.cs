//************************************************************************
//      https://github.com/yuzhengyang
//      author:     yuzhengyang
//      date:       2017.3.29 - 2017.6.29
//      desc:       文件操作工具
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************
using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.Core.DataUtils.UnitConvertUtils;
using Azylee.Core.IOUtils.DirUtils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace Azylee.Core.IOUtils.FileUtils
{
    /// <summary>
    /// 文件操作工具
    /// </summary>
    public class FileTool
    {
        /// <summary>
        /// 判断字符串是文件路径
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsFile(string s)
        {
            if (File.Exists(s)) return true;
            return false;
        }
        /// <summary>
        /// 获取文件（单层目录）
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="pattern">通配符</param>
        /// <returns></returns>
        public static List<string> GetFile(string path, string pattern = "*")
        {
            if (Directory.Exists(path))
                try
                {
                    List<string> result = Directory.EnumerateFiles(path, pattern).ToList();
                    return result;
                }
                catch (Exception e) { }
            return null;
        }
        ///// <summary>
        ///// 获取文件（向下钻取所有目录）
        ///// </summary>
        ///// <param name="path">路径</param>
        ///// <param name="pattern">通配符</param>
        ///// <returns></returns>
        //public static List<string> GetAllFile(string path, string pattern = "*")
        //{
        //    List<string> result = null;
        //    try
        //    {
        //        result = Directory.EnumerateFiles(path, pattern, SearchOption.TopDirectoryOnly).ToList();
        //    }
        //    catch (Exception e) { }
        //    return result;
        //}
        /// <summary>
        /// 获取目录下的所有文件
        /// 防止遇到（$文件夹报错无法获取目录的错误）
        /// </summary>
        /// <param name="path"></param>
        /// <param name="patterns"></param>
        /// <returns></returns>
        public static List<string> GetAllFile(string path, string[] patterns = null)
        {
            List<string> allpath = DirTool.GetAllPath(path);
            if (allpath == null) allpath = new List<string>();
            allpath.Add(path);
            return FileTool.GetAllFile(allpath, patterns);
        }
        /// <summary>
        /// 获取文件（多个目录）（向下钻取所有目录）
        /// </summary>
        /// <param name="paths">路径（支持多个路径）</param>
        /// <param name="patterns">通配符（支持多个通配符）</param>
        /// <returns></returns>
        public static List<string> GetAllFile(List<string> paths, string[] patterns = null)
        {
            List<string> result = new List<string>();
            if (!ListTool.IsNullOrEmpty(paths))
            {
                foreach (var path in paths)
                {
                    if (!ListTool.IsNullOrEmpty(patterns))
                    {
                        foreach (var pattern in patterns)
                        {
                            List<string> temp = GetFile(path, pattern);
                            if (ListTool.HasElements(temp)) result.AddRange(temp);
                        }
                    }
                    else
                    {
                        List<string> temp = GetFile(path);
                        if (!ListTool.IsNullOrEmpty(temp)) result.AddRange(temp);
                    }
                }
            }
            return result;
        }
        ///// <summary>
        ///// 获取文件（所有目录）（严格模式：从第一个.开始截取后缀）
        ///// </summary>
        ///// <param name="paths">路径（支持多个路径）</param>
        ///// <param name="patterns">通配符（支持多个通配符）</param>
        ///// <returns></returns>
        //public static List<string> GetAllFileByExt(string[] paths, string[] patterns)
        //{
        //    List<string> result = new List<string>();
        //    if (!ListTool.IsNullOrEmpty(paths))
        //    {
        //        foreach (var path in paths)
        //        {
        //            List<string> temp = GetAllFile(path);
        //            if (!ListTool.IsNullOrEmpty(temp)) result.AddRange(temp);
        //        }
        //    }
        //    if (!ListTool.IsNullOrEmpty(patterns) && !ListTool.IsNullOrEmpty(result))
        //    {
        //        for (int i = result.Count() - 1; i >= 0; i--)
        //        {
        //            string ext = System.IO.Path.GetFileName(result[i]);
        //            if (ext.IndexOf('.') >= 0)
        //            {
        //                ext = ext.Substring(ext.IndexOf('.'));
        //            }
        //            if (!patterns.Contains(ext)) result.RemoveAt(i);
        //        }
        //    }
        //    return result;
        //}


        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="file">文件路径</param>
        /// <returns></returns>
        public static void Delete(string file)
        {
            try
            {
                File.Delete(file);
            }
            catch (Exception e) { }
        }
        /// <summary>
        /// 删除文件（多个）
        /// </summary>
        /// <param name="files">文件路径（支持多个文件路径）</param>
        /// <returns></returns>
        public static void Delete(string[] files)
        {
            if (ListTool.HasElements(files))
            {
                foreach (var file in files)
                {
                    Delete(file);
                }
            }
        }
        /// <summary>
        /// 获取文件的大小（字节数）
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static long Size(string fileName)
        {
            long result = -1;
            if (File.Exists(fileName))
            {
                try
                {
                    FileInfo fi = new FileInfo(fileName);
                    result = fi.Length;
                }
                catch (Exception e) { }
            }
            return result;
        }
        /// <summary>
        /// 获取多个文件的大小（字节数）
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public static long[] Size(List<string> files)
        {
            long[] result = new long[files.Count];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Size(files[i]);
            }
            return result;
        }
        /// <summary>
        /// 获取文件大小（根据单位换算）
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="unit">B，KB，MB，GB</param>
        /// <returns></returns>
        public static double Size(string fileName, string unit)
        {
            return ByteConvertTool.Cvt(Size(fileName), unit);
        }
        /// <summary>
        /// 获取文件大小信息（自动适配）（如：1MB，10KB...）
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string SizeFormat(string fileName)
        {
            return ByteConvertTool.Fmt(Size(fileName));
        }
        /// <summary>
        /// 获取文件的MD5特征码
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string GetMD5(string file)
        {
            string result = string.Empty;
            if (!File.Exists(file)) return result;

            using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
            {
                HashAlgorithm algorithm = MD5.Create();
                byte[] hashBytes = algorithm.ComputeHash(fs);
                result = BitConverter.ToString(hashBytes).Replace("-", "");
            }
            return result;
        }
        /// <summary>
        /// 获取多个文件的MD5特征码
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string[] GetMD5(List<string> files)
        {
            string[] result = new string[files.Count];
            for (int i = 0; i < files.Count; i++)
            {
                result[i] = GetMD5(files[i]);
            }
            return result;
        }
        public static bool Copy(string sourceFileName, string destFileName, bool overwrite)
        {
            if (File.Exists(sourceFileName))
            {
                string destPath = DirTool.GetFilePath(destFileName);
                if (DirTool.Create(destPath))
                {
                    try
                    {
                        File.Copy(sourceFileName, destFileName, overwrite);
                        return true;
                    }
                    catch { }
                }
            }
            return false;
        }
    }
}
