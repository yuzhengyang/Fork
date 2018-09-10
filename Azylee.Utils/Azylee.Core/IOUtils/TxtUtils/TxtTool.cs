//************************************************************************
//      author:     yuzhengyang
//      date:       2018.3.27 - 2018.6.3
//      desc:       工具描述
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************
using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.Core.IOUtils.DirUtils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Azylee.Core.IOUtils.TxtUtils
{
    public class TxtTool
    {
        public static bool Append(string file, List<string> txt)
        {
            try
            {
                DirTool.Create(Path.GetDirectoryName(file));
                using (StreamWriter sw = new StreamWriter(file, true))
                {
                    if (!ListTool.IsNullOrEmpty(txt))
                        foreach (var t in txt)
                            sw.WriteLine(t);
                }
                return true;
            }
            catch (Exception e) { }
            return false;
        }
        public static bool Append(string file, string txt)
        {
            try
            {
                DirTool.Create(Path.GetDirectoryName(file));
                using (StreamWriter sw = new StreamWriter(file, true))
                {
                    sw.WriteLine(txt);
                }
                return true;
            }
            catch (Exception e) { }
            return false;
        }
        public static bool Create(string file, string txt)
        {
            try
            {
                DirTool.Create(Path.GetDirectoryName(file));
                using (StreamWriter sw = new StreamWriter(file, false, Encoding.UTF8))
                {
                    sw.WriteLine(txt);
                }
                return true;
            }
            catch (Exception e) { }
            return false;
        }
        public static string Read(string file)
        {
            try
            {
                if (File.Exists(file))
                {
                    using (StreamReader sr = new StreamReader(file, Encoding.UTF8))
                    {
                        string result = "", line;
                        while ((line = sr.ReadLine()) != null)
                            result += line.ToString();
                        return result;
                    }
                }
            }
            catch { }
            return null;
        }
        public static List<string> ReadLine(string file)
        {
            try
            {
                using (StreamReader sr = new StreamReader(file, Encoding.UTF8))
                {
                    List<string> result = new List<string>();
                    string line;
                    while ((line = sr.ReadLine()) != null)
                        result.Add(line.ToString());
                    return result;
                }
            }
            catch (Exception e) { }
            return null;
        }
        public static void ReadLine(string file, Action<int, string> action)
        {
            try
            {
                using (StreamReader sr = new StreamReader(file, Encoding.UTF8))
                {
                    string line;
                    int number = 1;
                    while ((line = sr.ReadLine()) != null)
                        action.Invoke(number++, line);
                }
            }
            catch (Exception e) { }
        }
        public static void ReadLine(string file,Encoding encoding, Action<int, string> action)
        {
            try
            {
                using (StreamReader sr = new StreamReader(file, encoding))
                {
                    string line;
                    int number = 1;
                    while ((line = sr.ReadLine()) != null)
                        action.Invoke(number++, line);
                }
            }
            catch (Exception e) { }
        }
        public static long CountLine(string file, string[] filter)
        {
            long count = 0;
            try
            {
                using (StreamReader sr = new StreamReader(file, Encoding.UTF8))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        bool access = true;
                        if (!ListTool.IsNullOrEmpty(filter))
                        {
                            foreach (var f in filter)
                            {
                                if (line.Trim() == f) access = false;
                            }
                        }
                        if (access) count++;
                    }
                }
            }
            catch (Exception e) { }
            return count;
        }
    }
}
