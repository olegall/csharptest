using System;

namespace Casting
{
    class Cast1 { }
    class Cast2 { }

    // upcasting downcasting
    public class CastingClass
    {
        public static void Main()
        {
            double x = 1234.7;
            int a;
            // Cast double to int.
            a = (int)x;
            Console.WriteLine(a);

            // Cast1 cast = (Cast1) new Cast2(); // нельзя кастить несвязанные классы
        }
    }
}
