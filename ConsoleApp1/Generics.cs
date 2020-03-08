using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Generics
    {
        internal sealed class SomeGenericClass<T> where T : new()
        {
            public static T SomeMethod()
            {
                return new T();
            }
        }
    }
}
