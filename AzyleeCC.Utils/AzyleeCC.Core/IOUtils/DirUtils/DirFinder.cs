using AzyleeCC.Core.DataUtils.CollectionUtils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AzyleeCC.Core.IOUtils.DirUtils
{
    public class DirFinder
    {
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
            if (Ls.Ok(result))
            {
                List<string> temp = new List<string>();
                foreach (var item in result)
                {
                    List<string> t = GetAllPath(item);
                    if (Ls.Ok(t)) temp.AddRange(t);
                }
                result.AddRange(temp);
                return result;
            }
            return null;
        }
    }
}
