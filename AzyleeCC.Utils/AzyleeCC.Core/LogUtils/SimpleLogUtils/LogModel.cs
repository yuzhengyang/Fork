//************************************************************************
//      author:     yuzhengyang
//      date:       2018.3.27 - 2018.6.3
//      desc:       工具描述
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AzyleeCC.Core.LogUtils.SimpleLogUtils
{
    public  class LogModel
    {
        public LogType Type { get; set; }
        public string Message { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
