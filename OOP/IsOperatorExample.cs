using System;

namespace OOP
{
    public class Base { }

    public class Derived : Base { }

    public static class IsOperatorExample
    {
        public static void Main()
        {
            object b = new Base();
            var a1 = b is Base;  // output: True
            var a2 = b is Derived;  // output: False

            object d = new Derived();
            var a3 = d is Base;  // output: True
            var a4 = d is Derived; // output: True
        }
    }
}
