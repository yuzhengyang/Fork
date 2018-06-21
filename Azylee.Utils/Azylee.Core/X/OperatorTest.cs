using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.Core.X
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
