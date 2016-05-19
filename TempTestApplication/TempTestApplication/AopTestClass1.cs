using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Extensibility;

namespace TempTestApplication
{
    public class AopTestClass1
    {
        [Log]
        public void foo()
        {
            Console.WriteLine("foo");
        }
    }
}
