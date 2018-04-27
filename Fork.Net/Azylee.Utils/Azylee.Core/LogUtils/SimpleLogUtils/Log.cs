//************************************************************************
//      https://github.com/yuzhengyang
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
        const string LOG_PATH = "azylee.log";

        private int CACHE_DAYS = 30;//缓存天数
        private object LogFileLock = new object();//写日志文件锁
        private bool IsWriteFile = false;//是否写日志文件
        private string LogPath = AppDomain.CurrentDomain.BaseDirectory + LOG_PATH;
        public LogLevel LogLevel = LogLevel.All;//日志输出等级
        #endregion

        public Log() { }
        public Log(bool isWrite, LogLevel level = LogLevel.All)
        {
            if (isWrite)
            {
                IsWriteFile = true;
                LogLevel = level;
            }
        }

        public void SetLogPath(string path)
        {
            if (!string.IsNullOrWhiteSpace(path))
            {
                LogPath = DirTool.Combine(path, LOG_PATH);
            }
        }
        public void SetCacheDays(int days)
        {
            if (days >= 0) CACHE_DAYS = days;
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
            try
            {
                Console.ForegroundColor = GetColor(type);
                Console.WriteLine(LOG_FORMAT, DateTime.Now.ToString(TIME_FORMAT), type.ToString(), message);
                //取消单独线程输出日志文件（单独线程输出日志必然会有延迟）
                //if (IsWriteFile) Queue.Enqueue(new LogModel() { Type = type, Message = message, CreateTime = DateTime.Now });
                if (IsWriteFile) WriteFile(new LogModel() { Type = type, Message = message, CreateTime = DateTime.Now });
            }
            catch { }
        }
        /// <summary>
        /// 写出到日志文件
        /// </summary>
        /// <param name="log"></param>
        private void WriteFile(LogModel log)
        {
            if (IsWriteFile)
            {
                lock (LogFileLock)
                {
                    //设置日志目录和日志文件
                    string filePath = GetFilePath(log.Type);
                    string file = DirTool.Combine(filePath, DateTime.Now.ToString("yyyy-MM-dd") + ".txt");
                    //创建日志目录
                    DirTool.Create(filePath);
                    //写出日志
                    TxtTool.Append(
                        file,
                        string.Format(LOG_FORMAT,
                            log.CreateTime.ToString(TIME_FORMAT),
                            log.Type.ToString(),
                            StringTool.ReplaceNewLine(log.Message)));
                    Cleaner(log.Type);
                }
            }
        }
        /// <summary>
        /// 根据分类分配目录
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private string GetFilePath(LogType type)
        {
            string filePath = LogPath;
            switch (type)
            {
                case LogType.d: filePath = DirTool.Combine(LogPath, "debug"); break;
                case LogType.i: filePath = DirTool.Combine(LogPath, "information"); break;
                case LogType.e: filePath = DirTool.Combine(LogPath, "error"); break;
                case LogType.w: filePath = DirTool.Combine(LogPath, "warning"); break;
                case LogType.v: filePath = DirTool.Combine(LogPath, "verbose"); break;
            }
            return filePath;
        }
        /// <summary>
        /// 清理过多的日志文件
        /// </summary>
        private void Cleaner(LogType type)
        {
            List<string> files = FileTool.GetFile(GetFilePath(type));
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
