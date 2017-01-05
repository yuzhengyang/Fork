using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Y.Utils.Net20.FileUtils;
using Y.Utils.Net20.TxtUtils;

namespace Y.Utils.Net20.LogUtils
{
    /// <summary>
    /// Log 输出工具
    /// 
    /// 说明：
    /// 1、Log.AllocConsole();开启控制台
    /// 2、Log.FreeConsole();关闭控制台
    /// 3、Log.i("information");输出消息
    /// </summary>
    public class Log
    {
        //输出的 Log 格式
        const string LogFormat = "{0}  {1}  {2}";
        const string TimeFormat = "MM-dd HH:mm:ss.fff";

        private static object LogFileLock = new object();

        #region 输出类型
        /// <summary>
        /// 输出类型
        /// </summary>
        enum PrintType
        {
            v,//verbose 啰嗦的意思
            d,//debug 调试的信息
            i,//information 一般提示性的消息
            w,//warning 警告
            e,//error 错误信息
        }
        #endregion

        #region Console 开启/关闭 API
        [DllImport("kernel32.dll")]
        public static extern Boolean AllocConsole();
        [DllImport("kernel32.dll")]
        public static extern Boolean FreeConsole();
        #endregion

        /// <summary>
        /// 获取输出颜色
        /// </summary>
        /// <param name="type">输出类型</param>
        /// <returns></returns>
        private static ConsoleColor GetColor(PrintType type)
        {
            switch (type)
            {
                case PrintType.v: return ConsoleColor.Gray;
                case PrintType.d: return ConsoleColor.Blue;
                case PrintType.i: return ConsoleColor.Green;
                case PrintType.w: return ConsoleColor.Yellow;
                case PrintType.e: return ConsoleColor.Red;
                default: return ConsoleColor.Gray;
            }
        }

        /// <summary>
        /// 写出到控制台
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="tag">标记</param>
        /// <param name="message">消息</param>
        private static void Write(PrintType type, string message)
        {
            Console.ForegroundColor = GetColor(type);
            Console.WriteLine(LogFormat, DateTime.Now.ToString(TimeFormat), type.ToString(), message);
            WriteFile(type, message);
        }


        private static void WriteFile(PrintType type, string message)
        {
            lock (LogFileLock)
            {
                //设置日志目录
                string logPath = AppDomain.CurrentDomain.BaseDirectory + "Log";
                string file = string.Format(@"{0}\{1}.txt", logPath, DateTime.Now.ToString("yyyy-MM-dd"));
                //创建日志目录
                DirTool.Create(logPath);
                //写出日志
                TxtTool.Append(file, string.Format(LogFormat, DateTime.Now.ToString(TimeFormat), type.ToString(), message));
            }
        }

        #region 分类详细输出
        /// <summary>
        /// 输出 verbose (啰嗦信息)
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="tag">可选：标记</param>
        public static void v<T>(T msg)
        {
            Write(PrintType.v, msg.ToString());
        }
        /// <summary>
        /// 输出 Debug (调试信息)
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="tag">可选：标记</param>
        public static void d<T>(T msg)
        {
            Write(PrintType.d, msg.ToString());
        }
        /// <summary>
        /// 输出 Information (重要信息)
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="tag">可选：标记</param>
        public static void i<T>(T msg)
        {
            Write(PrintType.i, msg.ToString());
        }
        /// <summary>
        /// 输出 Warning (警告信息)
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="tag">可选：标记</param>
        public static void w<T>(T msg)
        {
            Write(PrintType.w, msg.ToString());
        }
        /// <summary>
        /// 输出 Error (错误信息)
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="tag">可选：标记</param>
        public static void e<T>(T msg)
        {
            Write(PrintType.e, msg.ToString());
        }
        #endregion
    }
}
