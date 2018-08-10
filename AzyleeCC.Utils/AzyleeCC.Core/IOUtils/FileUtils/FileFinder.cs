using AzyleeCC.Core.DataUtils.CollectionUtils;
using AzyleeCC.Core.IOUtils.DirUtils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AzyleeCC.Core.IOUtils.FileUtils
{
    /// <summary>
    /// 文件搜索
    /// </summary>
    public static class FileFinder
    {
        /// <summary>
        /// 获取文件（单层目录）
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="pattern">通配符</param>
        /// <returns></returns>
        public static List<string> GetFile(string path, string pattern = "*")
        {
            try
            {
                if (Directory.Exists(path))
                {
                    List<string> result = Directory.EnumerateFiles(path, pattern).ToList();
                    return result;
                }
            }
            catch (Exception e) { }
            return null;
        }
        /// <summary>
        /// 获取所有目录中的所有文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="action"></param>
        /// <param name="patterns"></param>
        public static void GetAllFile(string path, Action<List<string>> action, string[] patterns = null)
        {
            List<string> allpath = DirFinder.GetAllPath(path);
            if (allpath == null) allpath = new List<string>();
            allpath.Add(path);

            foreach (var p in allpath)
            {
                if (Ls.Ok(patterns))
                {
                    foreach (var pattern in patterns)
                    {
                        List<string> files = GetFile(p, pattern);
                        if (Ls.Ok(files)) action?.Invoke(files);
                    }
                }
                else
                {
                    List<string> files = GetFile(p);
                    if (Ls.Ok(files)) action?.Invoke(files);
                }
            }
        }
    }
}
