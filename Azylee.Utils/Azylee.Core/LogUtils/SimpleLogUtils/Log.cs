//************************************************************************
//      author:     yuzhengyang
//      date:       2017.3.29 - 2018.4.27
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

using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.Core.DataUtils.StringUtils;
using Azylee.Core.IOUtils.DirUtils;
using Azylee.Core.IOUtils.FileUtils;
using Azylee.Core.IOUtils.TxtUtils;
using Azylee.Core.WindowsUtils.ConsoleUtils;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace Azylee.Core.LogUtils.SimpleLogUtils
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
        #region 基础属性
        //输出的 Log 格式
        const string LOG_FORMAT = "{0}  {1}  {2}";
        const string TIME_FORMAT = "HH:mm:ss.fff";
        const string LOG_PATH = @"azylee.log\log";

        private int CACHE_DAYS = 30;//缓存天数
        private object LogFileLock = new object();//写日志文件锁
        private string LogPath = AppDomain.CurrentDomain.BaseDirectory + LOG_PATH;
        private LogLevel ConsoleLogLevel = LogLevel.All;//日志输出到"控制台"等级
        private LogLevel FileLogLevel = LogLevel.All;//日志输出到"文件"等级
        #endregion

        /// <summary>
        /// 日志输出回调方法
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="msg">内容</param>
        public delegate void LogEventDelegate(LogType type, string msg);
        public LogEventDelegate LogEvent;


        private Log() { }
        /// <summary>
        /// 初始化 Log 工具（不建议使用）
        /// </summary>
        /// <param name="isWrite">是否写出日志</param>
        /// <param name="logLevel"></param>
        /// <param name="writeLevel"></param>
        [Obsolete]
        public Log(bool isWrite, LogLevel logLevel = LogLevel.All, LogLevel writeLevel = LogLevel.All)
        {
            if (isWrite)
            {
                //IsWriteFile = true;//已禁用，使用文件输出等级控制
                ConsoleLogLevel = logLevel;
                FileLogLevel = writeLevel;
            }
            else
            {
                ConsoleLogLevel = logLevel;
                FileLogLevel = LogLevel.None;
            }
        }
        /// <summary>
        /// 初始化 Log 工具
        /// </summary>
        /// <param name="console">控制台输出级别</param>
        /// <param name="file">文件输出级别</param>
        /// <param name="action">日志输出回调</param>
        public Log(LogLevel console = LogLevel.All, LogLevel file = LogLevel.All, LogEventDelegate logEvent = null)
        {
            ConsoleLogLevel = console;
            FileLogLevel = file;
            if (logEvent != null) LogEvent += logEvent;
        }

        /// <summary>
        /// 设置日志路径
        /// </summary>
        /// <param name="path"></param>
        public void SetLogPath(string path)
        {
            if (!string.IsNullOrWhiteSpace(path))
            {
                LogPath = DirTool.Combine(path, LOG_PATH);
            }
        }
        /// <summary>
        /// 设置日志缓存天数（默认30天）
        /// </summary>
        /// <param name="days"></param>
        public void SetCacheDays(int days)
        {
            if (days >= 0) CACHE_DAYS = days;
        }

        #region Console 开启/关闭 API
        /// <summary>
        /// 启用系统控制台输出
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        public static extern Boolean AllocConsole();
        /// <summary>
        /// 关闭系统控制台
        /// </summary>
        /// <returns></returns>
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
        /// <param name="message">消息</param>
        private void WriteConsole(LogType type, string message)
        {
            try
            {
                message = Cons.FormatLine(message); //处理日志信息（换行）

                Cons.SetColor(GetColor(type), ConsoleColor.Black);
                Console.WriteLine(LOG_FORMAT, DateTime.Now.ToString(TIME_FORMAT), type.ToString(), message);
                Cons.ResetColor();
                //取消单独线程输出日志文件（单独线程输出日志必然会有延迟）
                //if (IsWriteFile) Queue.Enqueue(new LogModel() { Type = type, Message = message, CreateTime = DateTime.Now });
            }
            catch { }
        }
        /// <summary>
        /// 写出到日志文件
        /// </summary>
        /// <param name="log"></param>
        private void WriteFile(LogModel log)
        {
            lock (LogFileLock)
            {
                //设置日志目录和日志文件
                string filePath = LogPath;
                //string filePath = GetFilePath(log.Type);//根据分类分配目录
                string file = DirTool.Combine(filePath, DateTime.Now.ToString("yyyy-MM-dd") + ".txt");
                //创建日志目录
                DirTool.Create(filePath);
                //处理日志信息（换行）
                log.Message = Cons.FormatLine(log.Message);
                //写出日志
                TxtTool.Append(
                    file,
                    string.Format(LOG_FORMAT,
                        log.CreateTime.ToString(TIME_FORMAT),
                        log.Type.ToString(),
                        log.Message));
                Cleaner(log.Type);
            }
        }

        /// <summary>
        /// 根据分类分配目录
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        //private string GetFilePath(LogType type)
        //{
        //    string filePath = LogPath;
        //    switch (type)
        //    {
        //        case LogType.d: filePath = DirTool.Combine(LogPath, "debug"); break;
        //        case LogType.i: filePath = DirTool.Combine(LogPath, "information"); break;
        //        case LogType.e: filePath = DirTool.Combine(LogPath, "error"); break;
        //        case LogType.w: filePath = DirTool.Combine(LogPath, "warning"); break;
        //        case LogType.v: filePath = DirTool.Combine(LogPath, "verbose"); break;
        //    }
        //    return filePath;
        //}
        /// <summary>
        /// 清理过多的日志文件
        /// </summary>
        private void Cleaner(LogType type)
        {
            List<string> files = FileTool.GetFile(LogPath);
            //List<string> files = FileTool.GetFile(GetFilePath(type));//根据分类分配目录
            if (ListTool.HasElements(files))
            {
                files.ForEach(f =>
                {
                    try
                    {
                        string filename = Path.GetFileNameWithoutExtension(f);
                        if (filename.Length == 10)
                        {
                            DateTime date = DateTime.Parse(filename);
                            if (date < DateTime.Now.AddDays(-CACHE_DAYS - 1)) FileTool.Delete(f);
                        }
                        else { FileTool.Delete(f); }
                    }
                    catch { FileTool.Delete(f); }
                });
            }
        }

        #region 分类详细输出
        #region 因大小写命名规范冲突，将次类方法标记为弃用
        /// <summary>
        /// 输出 verbose (啰嗦信息)
        /// </summary>
        /// <param name="msg">消息</param>
        [Obsolete]
        public void v<T>(T msg)
        {
            V(msg);
        }
        /// <summary>
        /// 输出 Debug (调试信息)
        /// </summary>
        /// <param name="msg">消息</param>
        [Obsolete]
        public void d<T>(T msg)
        {
            D(msg);
        }
        /// <summary>
        /// 输出 Information (重要信息)
        /// </summary>
        /// <param name="msg">消息</param>
        [Obsolete]
        public void i<T>(T msg)
        {
            I(msg);
        }
        /// <summary>
        /// 输出 Warning (警告信息)
        /// </summary>
        /// <param name="msg">消息</param>
        [Obsolete]
        public void w<T>(T msg)
        {
            W(msg);
        }
        /// <summary>
        /// 输出 Error (错误信息)
        /// </summary>
        /// <param name="msg">消息</param>
        [Obsolete]
        public void e<T>(T msg)
        {
            E(msg);
        }
        #endregion

        /// <summary>
        /// 输出 verbose (啰嗦信息)
        /// </summary>
        /// <param name="msg">消息</param>
        public void V<T>(T msg)
        {
            if ((ConsoleLogLevel & LogLevel.Verbose) == LogLevel.Verbose)
                WriteConsole(LogType.v, msg?.ToString());

            if ((FileLogLevel & LogLevel.Verbose) == LogLevel.Verbose)
                WriteFile(new LogModel() { Type = LogType.v, Message = msg?.ToString(), CreateTime = DateTime.Now });

            try { LogEvent(LogType.v, msg?.ToString()); } catch { }
        }
        /// <summary>
        /// 输出 Debug (调试信息)
        /// </summary>
        /// <param name="msg">消息</param>
        public void D<T>(T msg)
        {
            if ((ConsoleLogLevel & LogLevel.Debug) == LogLevel.Debug)
                WriteConsole(LogType.d, msg?.ToString());

            if ((FileLogLevel & LogLevel.Debug) == LogLevel.Debug)
                WriteFile(new LogModel() { Type = LogType.d, Message = msg?.ToString(), CreateTime = DateTime.Now });

            try { LogEvent(LogType.d, msg?.ToString()); } catch { }
        }
        /// <summary>
        /// 输出 Information (重要信息)
        /// </summary>
        /// <param name="msg">消息</param>
        public void I<T>(T msg)
        {
            if ((ConsoleLogLevel & LogLevel.Information) == LogLevel.Information)
                WriteConsole(LogType.i, msg?.ToString());

            if ((FileLogLevel & LogLevel.Information) == LogLevel.Information)
                WriteFile(new LogModel() { Type = LogType.i, Message = msg?.ToString(), CreateTime = DateTime.Now });

            try { LogEvent(LogType.i, msg?.ToString()); } catch { }
        }
        /// <summary>
        /// 输出 Warning (警告信息)
        /// </summary>
        /// <param name="msg">消息</param>
        public void W<T>(T msg)
        {
            if ((ConsoleLogLevel & LogLevel.Warning) == LogLevel.Warning)
                WriteConsole(LogType.w, msg?.ToString());

            if ((FileLogLevel & LogLevel.Warning) == LogLevel.Warning)
                WriteFile(new LogModel() { Type = LogType.w, Message = msg?.ToString(), CreateTime = DateTime.Now });

            try { LogEvent(LogType.w, msg?.ToString()); } catch { }
        }
        /// <summary>
        /// 输出 Error (错误信息)
        /// </summary>
        /// <param name="msg">消息</param>
        public void E<T>(T msg)
        {
            if ((ConsoleLogLevel & LogLevel.Error) == LogLevel.Error)
                WriteConsole(LogType.e, msg?.ToString());

            if ((FileLogLevel & LogLevel.Error) == LogLevel.Error)
                WriteFile(new LogModel() { Type = LogType.e, Message = msg?.ToString(), CreateTime = DateTime.Now });

            try { LogEvent(LogType.e, msg?.ToString()); } catch { }
        }
        #endregion
    }
}
