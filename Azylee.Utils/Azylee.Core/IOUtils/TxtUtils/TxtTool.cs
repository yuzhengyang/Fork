//************************************************************************
//      author:     yuzhengyang
//      date:       2018.3.27 - 2018.6.3
//      desc:       工具描述
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************
using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.Core.DataUtils.StringUtils;
using Azylee.Core.IOUtils.DirUtils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Azylee.Core.IOUtils.TxtUtils
{
    public class TxtTool
    {
        public static bool Append(string file, List<string> txt, bool append = true)
        {
            try
            {
                DirTool.Create(Path.GetDirectoryName(file));
                using (StreamWriter sw = new StreamWriter(file, append))
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
        public static bool Append(string file, string txt, bool append = true)
        {
            try
            {
                DirTool.Create(Path.GetDirectoryName(file));
                using (StreamWriter sw = new StreamWriter(file, append))
                {
                    sw.WriteLine(txt);
                }
                return true;
            }
            catch (Exception e) { }
            return false;
        }
        public static bool Create(string file, string txt, string encoding = "utf-8")
        {
            try
            {
                Encoding enc = Encoding.GetEncoding(encoding);
                DirTool.Create(Path.GetDirectoryName(file));
                using (StreamWriter sw = new StreamWriter(file, false, enc))
                {
                    sw.WriteLine(txt);
                }
                return true;
            }
            catch (Exception e) { }
            return false;
        }
        public static bool Create(string file, List<string> txt, string encoding = "utf-8")
        {
            try
            {
                Encoding enc = Encoding.GetEncoding(encoding);
                DirTool.Create(Path.GetDirectoryName(file));
                using (StreamWriter sw = new StreamWriter(file, false, enc))
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
        public static string Read(string file, Encoding encoding)
        {
            try
            {
                if (File.Exists(file))
                {
                    using (StreamReader sr = new StreamReader(file, encoding))
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
        public static List<string> ReadLine(string file, Encoding encoding)
        {
            try
            {
                using (StreamReader sr = new StreamReader(file, encoding))
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
        public static void ReadLine(string file, Encoding encoding, Action<int, string> action)
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

        /// <summary>
        /// 替换执行文件文本块
        /// </summary>
        /// <param name="file"></param>
        /// <param name="begString"></param>
        /// <param name="endString"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static bool ReplaceBlock(string file, string begString, string endString, List<string> content)
        {
            if (Str.Ok(file) && File.Exists(file))
            {
                List<string> result = new List<string>();
                int begIndex = 0, endIndex = 0;

                // 找到标记位置
                List<string> txt = TxtTool.ReadLine(file);
                if (Ls.Ok(txt))
                {
                    for (int i = 0; i < txt.Count; i++)
                    {
                        // 找到要替换内容的开始行和结束行
                        if (txt[i].StartsWith(begString)) begIndex = i;
                        if (txt[i].StartsWith(endString)) endIndex = i;
                    }
                }
                else
                {
                    txt = new List<string>();
                }
                // 整理输出内容
                if (begIndex < endIndex)
                {
                    List<string> upPart = txt.GetRange(0, begIndex + 1);
                    List<string> downPart = txt.GetRange(endIndex, txt.Count - endIndex);

                    result.AddRange(upPart);
                    result.AddRange(content);
                    result.AddRange(downPart);
                }
                else
                {
                    result.AddRange(txt);
                    result.Add("");
                    result.Add(begString);
                    result.AddRange(content);
                    result.Add(endString);
                }
                // 写出文件
                try
                {
                    var utf8WithoutBom = new UTF8Encoding(false);
                    using (StreamWriter sw = new StreamWriter(file, false, utf8WithoutBom))
                    {
                        foreach (var line in result)
                        {
                            sw.WriteLine(line);
                        }
                    }
                    return true;
                }
                catch (Exception ex) { }
            }
            return false;
        }
    }
}
