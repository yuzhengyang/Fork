//############################################################
//      https://github.com/yuzhengyang
//      author:yuzhengyang
//############################################################
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Y.Utils.DataUtils.Collections;

namespace Y.Utils.IOUtils.PathUtils
{
    public class DirTool
    {
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
        public static string Parent(string path)
        {
            try
            {
                return Directory.GetParent(path).ToString();
            }
            catch (Exception e) { }
            return null;
        }
        public static List<string> GetPath(string path)
        {
            if (Directory.Exists(path))
                try { return Directory.EnumerateDirectories(path).ToList(); } catch (Exception e) { }
            return null;
        }
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
        public static string Combine(params string[] paths)
        {
            if (ListTool.HasElements(paths))
            {
                if (paths.Length > 1)
                {
                    StringBuilder result = new StringBuilder();
                    foreach (var path in paths)
                    {
                        result.Append(path);
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
    }
}
