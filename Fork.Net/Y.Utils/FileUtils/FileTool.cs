using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Y.Utils.BaseUtils;

namespace Y.Utils.FileUtils
{
    public class FileTool
    {
        public static List<string> GetFile(string path)
        {
            if (Directory.Exists(path))
                try { return Directory.EnumerateFiles(path).ToList(); } catch (Exception e) { }
            return null;
        }
        public static List<string> GetFile(string path, string ext)
        {
            if (Directory.Exists(path))
                try
                {
                    List<string> result = null;
                    List<string> temp = Directory.EnumerateFiles(path).ToList();
                    if (!ListTool.IsNullOrEmpty(temp))
                        foreach (var item in temp)
                        {
                            if (Path.GetExtension(item).ToUpper() == ext.ToUpper())
                            {
                                if (result == null)
                                    result = new List<string>();

                                result.Add(item);
                            }
                        }
                    return result;
                }
                catch (Exception e) { }
            return null;
        }
        public static List<string> GetAllFile(string path)
        {
            List<string> pathList = DirTool.GetAllPath(path);
            List<string> result = GetFile(path);
            if (!ListTool.IsNullOrEmpty(pathList))
            {
                foreach (var item in pathList)
                {
                    List<string> temp = GetFile(item);
                    if (!ListTool.IsNullOrEmpty(temp))
                        result.AddRange(temp);
                }
            }
            if (!ListTool.IsNullOrEmpty(result))
                return result;
            return null;
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
