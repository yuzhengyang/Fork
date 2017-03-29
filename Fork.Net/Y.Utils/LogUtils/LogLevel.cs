using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y.Utils.LogUtils
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
