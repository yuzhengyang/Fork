//############################################################
//      https://github.com/yuzhengyang
//      author:yuzhengyang
//############################################################
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y.Utils.Test
{
    public class OperatorTest
    {
        public static implicit operator string(OperatorTest dog)
        {
            return "";
        }
        public static OperatorTest operator +(OperatorTest a, OperatorTest b)
        {
            return a;
        }
    }
}
