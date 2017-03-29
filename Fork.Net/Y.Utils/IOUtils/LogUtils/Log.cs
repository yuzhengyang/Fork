using System;
using System.Runtime.InteropServices;
using Y.Utils.IOUtils.PathUtils;
using Y.Utils.IOUtils.TxtUtils;

namespace Y.Utils.IOUtils.LogUtils
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
        const string TimeFormat = "HH:mm:ss.fff";

        public static bool IsWriteFile = true;//是否写日志文件
        private static object LogFileLock = new object();//写日志文件锁
        private static LogLevel LogLevel = LogLevel.All;//日志输出等级

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
        private static ConsoleColor GetColor(LogType type)
        {
            switch (type)
            {
                case LogType.v: return ConsoleColor.Gray;
                case LogType.d: return ConsoleColor.Blue;
                case LogType.i: return ConsoleColor.Green;
                case LogType.w: return ConsoleColor.Yellow;
                case LogType.e: return ConsoleColor.Red;
                default: return ConsoleColor.Gray;
            }
        }

        /// <summary>
        /// 写出到控制台
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="tag">标记</param>
        /// <param name="message">消息</param>
        private static void Write(LogType type, string message)
        {
            Console.ForegroundColor = GetColor(type);
            Console.WriteLine(LogFormat, DateTime.Now.ToString(TimeFormat), type.ToString(), message);
            if (IsWriteFile) WriteFile(type, message);
        }

        private static void WriteFile(LogType type, string message)
        {
            if (IsWriteFile)
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
        }

        #region 分类详细输出
        /// <summary>
        /// 输出 verbose (啰嗦信息)
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="tag">可选：标记</param>
        public static void v<T>(T msg)
        {
            if ((LogLevel & LogLevel.Verbose) == LogLevel.Verbose)
                Write(LogType.v, msg.ToString());
        }
        /// <summary>
        /// 输出 Debug (调试信息)
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="tag">可选：标记</param>
        public static void d<T>(T msg)
        {
            if ((LogLevel & LogLevel.Debug) == LogLevel.Debug)
                Write(LogType.d, msg.ToString());
        }
        /// <summary>
        /// 输出 Information (重要信息)
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="tag">可选：标记</param>
        public static void i<T>(T msg)
        {
            if ((LogLevel & LogLevel.Information) == LogLevel.Information)
                Write(LogType.i, msg.ToString());
        }
        /// <summary>
        /// 输出 Warning (警告信息)
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="tag">可选：标记</param>
        public static void w<T>(T msg)
        {
            if ((LogLevel & LogLevel.Warning) == LogLevel.Warning)
                Write(LogType.w, msg.ToString());
        }
        /// <summary>
        /// 输出 Error (错误信息)
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="tag">可选：标记</param>
        public static void e<T>(T msg)
        {
            if ((LogLevel & LogLevel.Error) == LogLevel.Error)
                Write(LogType.e, msg.ToString());
        }
        #endregion
    }
}
