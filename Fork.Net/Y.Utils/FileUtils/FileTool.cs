using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Y.Utils.BaseUtils;

namespace Y.Utils.FileUtils
{
    public class FileTool
    {
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
        public static List<string> GetAllFile(string path, string pattern = "*")
        {
            List<string> result = null;
            try
            {
                result = Directory.EnumerateFiles(path, pattern, SearchOption.AllDirectories).ToList();
            }
            catch (Exception e) { }
            return result;
        }
        public static List<string> GetAllFile(string path, string[] pattern)
        {
            List<string> result = new List<string>();
            if (!ListTool.IsNullOrEmpty(pattern))
            {
                foreach (var p in pattern)
                {
                    List<string> temp = GetAllFile(path, p).ToList();
                    if (!ListTool.IsNullOrEmpty(temp)) result.AddRange(temp);
                }
            }
            return result;
        }
        public static List<string> GetAllFile(string[] paths, string[] patterns)
        {
            List<string> result = new List<string>();
            if (!ListTool.IsNullOrEmpty(paths))
            {
                foreach(var path in paths)
                {
                    if (!ListTool.IsNullOrEmpty(patterns))
                    {
                        foreach (var pattern in patterns)
                        {
                            List<string> temp = GetAllFile(path, pattern).ToList();
                            if (!ListTool.IsNullOrEmpty(temp)) result.AddRange(temp);
                        }
                    }else
                    {
                        List<string> temp = GetAllFile(path).ToList();
                        if (!ListTool.IsNullOrEmpty(temp)) result.AddRange(temp);
                    }
                }
            }
            return result;
        }
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
