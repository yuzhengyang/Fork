using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Azylee.Core.IOUtils.FileUtils
{
    public static class FileTimeTool
    {
        /// <summary>
        /// 检查文件创建至此已过n分钟
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static double pastMinutes(string fileName)
        {
            double result = -1;
            if (File.Exists(fileName))
            {
                try
                {
                    FileInfo fi = new FileInfo(fileName);
                    result = (DateTime.Now - fi.CreationTime).TotalMinutes;
                }
                catch (Exception e) { }
            }
            return result;
        }
    }
}
