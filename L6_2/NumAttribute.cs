using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L6_2
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    class NumAttribute : Attribute
    {
        public NumAttribute() { }
        public NumAttribute(int numpole)
        {
            NumPole = numpole;
        }

        public int NumPole { get; set; }
    }
}
