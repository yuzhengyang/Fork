using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Y.Utils.Net20.ListUtils;

namespace Y.Utils.Net20.FileUtils
{
    public class FileTool
    {
        /// <summary>
        /// 获取文件（单层目录）
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="pattern">通配符</param>
        /// <returns></returns>
        public static List<string> GetFile(string path, string pattern = "*")
        {
            List<string> result = null;
            if (Directory.Exists(path))
            {
                try
                {
                    string[] list = Directory.GetFiles(path, pattern);
                    if (ListTool.HasElements(list))
                        result = new List<string>(list);
                }
                catch (Exception e) { }
            }
            return result;
        }
        /// <summary>
        /// 获取文件（所有目录）
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="pattern">通配符</param>
        /// <returns></returns>
        public static List<string> GetAllFile(string path, string pattern = "*")
        {
            List<string> result = null;
            try
            {
                string[] list = Directory.GetFiles(path, pattern, SearchOption.AllDirectories);
                if (ListTool.HasElements(list))
                    result = new List<string>(list);
            }
            catch (Exception e) { }
            return result;
        }
        /// <summary>
        /// 获取文件（所有目录）
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="pattern">通配符（支持多个通配符）</param>
        /// <returns></returns>
        public static List<string> GetAllFile(string path, string[] pattern)
        {
            List<string> result = new List<string>();
            if (!ListTool.IsNullOrEmpty(pattern))
            {
                foreach (var p in pattern)
                {
                    List<string> temp = GetAllFile(path, p);
                    if (!ListTool.IsNullOrEmpty(temp)) result.AddRange(temp);
                }
            }
            return result;
        }
        /// <summary>
        /// 获取文件（所有目录）
        /// </summary>
        /// <param name="paths">路径（支持多个路径）</param>
        /// <param name="patterns">通配符（支持多个通配符）</param>
        /// <returns></returns>
        public static List<string> GetAllFile(string[] paths, string[] patterns)
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
                            List<string> temp = GetAllFile(path, pattern);
                            if (!ListTool.IsNullOrEmpty(temp)) result.AddRange(temp);
                        }
                    }
                    else
                    {
                        List<string> temp = GetAllFile(path);
                        if (!ListTool.IsNullOrEmpty(temp)) result.AddRange(temp);
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// 获取文件（所有目录）（严格模式：从第一个.开始截取后缀）
        /// </summary>
        /// <param name="paths">路径（支持多个路径）</param>
        /// <param name="patterns">通配符（支持多个通配符）</param>
        /// <returns></returns>
        public static List<string> GetAllFileByExt(List<string> paths, List<string> patterns)
        {
            List<string> result = new List<string>();
            if (!ListTool.IsNullOrEmpty(paths))
            {
                foreach (var path in paths)
                {
                    List<string> temp = GetAllFile(path);
                    if (!ListTool.IsNullOrEmpty(temp)) result.AddRange(temp);
                }
            }
            if (!ListTool.IsNullOrEmpty(patterns) && !ListTool.IsNullOrEmpty(result))
            {
                for (int i = result.Count - 1; i >= 0; i--)
                {
                    string ext = Path.GetFileName(result[i]);
                    if (ext.IndexOf('.') >= 0)
                    {
                        ext = ext.Substring(ext.IndexOf('.'));
                    }
                    if (!patterns.Contains(ext)) result.RemoveAt(i);
                }
            }
            return result;
        }
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="file">文件路径</param>
        /// <returns></returns>
        public static bool Delete(string file)
        {
            try
            {
                if (File.Exists(file))
                {
                    File.Delete(file);
                    return true;
                }
                else
                {
                    return true;
                }
            }
            catch { }
            return false;
        }
        /// <summary>
        /// 删除文件（多个）
        /// </summary>
        /// <param name="files">文件路径（支持多个文件路径）</param>
        /// <returns></returns>
        public static bool Delete(string[] files)
        {
            bool result = true;
            if (!ListTool.IsNullOrEmpty(files))
            {
                foreach (var file in files)
                {
                    result = result || Delete(file);
                }
            }
            return result;
        }
    }
}
