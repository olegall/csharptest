using System;

namespace Keywords
{
    // msdn
    public class BaseC
    {
        public int x;
        public void Invoke() 
        {
        }
    }
    public class DerivedC : BaseC
    {
        public new void Invoke() // без new поведение такое же, но предупреждение
        {
            base.Invoke(); // если BaseC.Invoke() private, то нельзя вызвать
        }
    }



    public class BaseC2
    {
        public static int x = 55;
        public static int y = 22;
    }

    public class DerivedC2 : BaseC2
    {
        // Hide field 'x'.
        new public static int x = 100; // new м.б. поле

        public static void Main()
        {
            // Display the new value of x:
            Console.WriteLine(x);

            // Display the hidden value of x:
            Console.WriteLine(BaseC2.x);

            // Display the unhidden member y:
            Console.WriteLine(y);
        }
    }
    /*
    Output:
    100
    55
    22
    */


    public class BaseC3
    {
        public class NestedC3
        {
            public int x = 200;
            public int y;
        }
    }

    public class DerivedC3 : BaseC3
    {
        // Nested type hiding the base type members.
        new public class NestedC3
        {
            public int x = 100;
            public int y;
            public int z;
        }

        public static void Main()
        {
            // Creating an object from the overlapping class:
            NestedC3 c1 = new NestedC3();

            // Creating an object from the hidden class:
            BaseC3.NestedC3 c2 = new BaseC3.NestedC3();

            Console.WriteLine(c1.x);
            Console.WriteLine(c2.x);

            /*
            Output:
            100
            200
            */
        }
    }


    public class New
    {

    }
}
