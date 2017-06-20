using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Y.Utils.DelegateUtils
{
    public class ProgressDelegate
    {
        //public delegate void ProgressHandler(long current, long total);
        public delegate void ProgressHandler(object sender, ProgressEventArgs e);
    }
}
