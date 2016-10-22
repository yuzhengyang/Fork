using System;
using Y.Utils.FileUtils;

namespace Y.Utils.TxtUtils
{
    public class LogTool
    {
        public static void Normal(string tag, string info)
        {
            try
            {
                string today = DateTime.Now.ToString("yyyy-MM-dd");
                string logPath = AppDomain.CurrentDomain.BaseDirectory + "Log";
                string file = string.Format(@"{0}\{1}.txt", logPath, today);
                DirTool.Create(logPath);
                TxtTool.Append(file, string.Format("time:{0} tag:{1} info:{2}", DateTime.Now.ToString("HH:mm:ss"), tag, info));
            }
            catch (Exception e) { }
        }
    }
}
