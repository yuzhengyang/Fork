//************************************************************************
//      https://github.com/yuzhengyang
//      author:     yuzhengyang
//      date:       2017.3.29 - 2017.7.6
//      desc:       日志功能
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************

//R.Log.IsWriteFile = true;
//R.Log.LogLevel = LogLevel.Warning | LogLevel.Debug;
//Log.AllocConsole();
//R.Log.v("this is v 啰嗦");
//R.Log.d("this is d 调试");
//R.Log.i("this is i 重要");
//R.Log.w("this is w 警告");
//R.Log.e("this is e 错误");

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
        const string LOG_FORMAT = "{0}  {1}  {2}";
        const string TIME_FORMAT = "HH:mm:ss.fff";
        const string LOG_PATH = "Log";

        private object LogFileLock = new object();//写日志文件锁

        private bool IsWriteFile = false;//是否写日志文件
        public string LogPath = LOG_PATH;
        public LogLevel LogLevel = LogLevel.All;//日志输出等级

        public Log()
        { }
        public Log(bool isWrite, string logPath = LOG_PATH, LogLevel level = LogLevel.All)
        {
            if (isWrite && !string.IsNullOrWhiteSpace(logPath))
            {
                LogPath = logPath.Trim();
                IsWriteFile = true;
                LogLevel = level;
            }
        }
        public bool SetWriteFile(bool isWrite, string logPath)
        {
            if (isWrite && !string.IsNullOrWhiteSpace(logPath))
            {
                LogPath = logPath.Trim();
                IsWriteFile = true;
                return true;
            }
            IsWriteFile = false;
            return false;
        }

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
        private ConsoleColor GetColor(LogType type)
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
        private void Write(LogType type, string message)
        {
            Console.ForegroundColor = GetColor(type);
            Console.WriteLine(LOG_FORMAT, DateTime.Now.ToString(TIME_FORMAT), type.ToString(), message);
            if (IsWriteFile) WriteFile(type, message);
        }

        private void WriteFile(LogType type, string message)
        {
            if (IsWriteFile)
            {
                lock (LogFileLock)
                {
                    //设置日志目录
                    string logPath = AppDomain.CurrentDomain.BaseDirectory + LogPath;
                    string file = string.Format(@"{0}\{1}.txt", logPath, DateTime.Now.ToString("yyyy-MM-dd"));
                    //创建日志目录
                    DirTool.Create(logPath);
                    //写出日志
                    TxtTool.Append(file, string.Format(LOG_FORMAT, DateTime.Now.ToString(TIME_FORMAT), type.ToString(), message));
                }
            }
        }

        #region 分类详细输出
        /// <summary>
        /// 输出 verbose (啰嗦信息)
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="tag">可选：标记</param>
        public void v<T>(T msg)
        {
            if ((LogLevel & LogLevel.Verbose) == LogLevel.Verbose)
                Write(LogType.v, msg.ToString());
        }
        /// <summary>
        /// 输出 Debug (调试信息)
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="tag">可选：标记</param>
        public void d<T>(T msg)
        {
            if ((LogLevel & LogLevel.Debug) == LogLevel.Debug)
                Write(LogType.d, msg.ToString());
        }
        /// <summary>
        /// 输出 Information (重要信息)
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="tag">可选：标记</param>
        public void i<T>(T msg)
        {
            if ((LogLevel & LogLevel.Information) == LogLevel.Information)
                Write(LogType.i, msg.ToString());
        }
        /// <summary>
        /// 输出 Warning (警告信息)
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="tag">可选：标记</param>
        public void w<T>(T msg)
        {
            if ((LogLevel & LogLevel.Warning) == LogLevel.Warning)
                Write(LogType.w, msg.ToString());
        }
        /// <summary>
        /// 输出 Error (错误信息)
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="tag">可选：标记</param>
        public void e<T>(T msg)
        {
            if ((LogLevel & LogLevel.Error) == LogLevel.Error)
                Write(LogType.e, msg.ToString());
        }
        #endregion
    }
}
