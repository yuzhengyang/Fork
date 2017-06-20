using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Y.Utils.DelegateUtils
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
