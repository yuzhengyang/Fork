using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.Core.LogUtils.SimpleLogUtils
{
    public  class LogModel
    {
        public LogType Type { get; set; }
        public string Message { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
