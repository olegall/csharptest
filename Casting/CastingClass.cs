namespace Casting
{
    class Cast1 { }
    class Cast2 { }

    // upcasting downcasting
    public class CastingClass
    {
        public void Main()
        {
            double double_ = 1234.7;
            // Cast double to int.
            int int_ = (int)double_;

            // Cast1 cast = (Cast1) new Cast2(); // нельзя кастить несвязанные классы
        }
    }
}
