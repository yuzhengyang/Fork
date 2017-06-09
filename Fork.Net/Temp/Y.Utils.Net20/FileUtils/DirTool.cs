using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Y.Utils.Net20.ListUtils;

namespace Y.Utils.Net20.FileUtils
{
    public class DirTool
    {
        public static bool Create(string path)
        {
            if (Directory.Exists(path))
                return true;
            else
                try { Directory.CreateDirectory(path); return true; } catch (Exception e) { }
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
            List<string> result = null;
            if (Directory.Exists(path))
            {
                try
                {
                    string[] list = Directory.GetDirectories(path);
                    if (ListTool.HasElements(list))
                        result = new List<string>(list);
                }
                catch (Exception e) { }
            }
            return result;
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
    }
}
