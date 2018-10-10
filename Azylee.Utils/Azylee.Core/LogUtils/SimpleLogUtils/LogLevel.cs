//************************************************************************
//      author:     yuzhengyang
//      date:       2018.3.27 - 2018.6.3
//      desc:       工具描述
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************
using System;

namespace Azylee.Core.LogUtils.SimpleLogUtils
{
    [Flags]
    public enum LogLevel
    {
        None = 0,
        Verbose = 1,
        Debug = 2,
        Information = 4,
        Warning = 8,
        Error = 16,
        All = Verbose | Debug | Information | Warning | Error,
    }
}
