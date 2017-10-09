using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Y.Utils.DataUtils.Collections;

namespace Y.Utils.IOUtils.DriveUtils
{
    public class DriveTool
    {
        /// <summary>
        /// 获取磁盘上次格式化时间
        /// </summary>
        /// <param name="dstr"></param>
        /// <returns></returns>
        public static DateTime GetLastFormatTime(string dstr)
        {
            string volInfo = dstr + "System Volume Information";
            DateTime result = DateTime.Now;
            if (Directory.Exists(volInfo))
            {
                try
                {
                    DirectoryInfo di = new DirectoryInfo(volInfo);
                    result = di.CreationTime;
                }
                catch (Exception e) { }
            }
            return result;
        }
    }
}
