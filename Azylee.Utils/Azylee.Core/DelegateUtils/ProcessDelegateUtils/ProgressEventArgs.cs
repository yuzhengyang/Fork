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

namespace Azylee.Core.DelegateUtils.ProcessDelegateUtils
{
    public class ProgressEventArgs
    {
        public ProgressEventArgs()
        {

        }
        public ProgressEventArgs(long current, long total)
        {
            Current = current;
            Total = total;
        }
        public long Current { get; set; }
        public long Total { get; set; }
    }
}
