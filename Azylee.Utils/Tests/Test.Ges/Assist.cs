using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Ges
{
    public class Assist<T>
    {
        public Assist()
        {
            Type tp = typeof(T);
            Console.WriteLine($"{tp.ToString()}");
        }
    }
}
