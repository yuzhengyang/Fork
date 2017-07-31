using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Y.Utils.DataUtils.Collections;

namespace Y.Test.Commons
{
    public static class R
    {
        public static FormDictionaryTool FD = new FormDictionaryTool();

        public static void Test()
        {
            FD.Get();
        }
    }
}
