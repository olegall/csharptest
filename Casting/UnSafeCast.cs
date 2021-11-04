using System;

namespace Casting
{
    class Animal
    {
        public void Eat() => Console.WriteLine("Eating.");

        public override string ToString() => "I am an animal.";
    }

    class Reptile : Animal 
    {
    }
    
    class Mammal : Animal 
    {
    }

    public class UnSafeCast
    {
        public static void Main()
        {
            Test(new Reptile()); // ok
            //Test(new Animal()); // ошибка
            //Test(new Mammal()); // ошибка

            // Keep the console window open in debug mode.
            //Console.WriteLine("Press any key to exit.");
            //Console.ReadKey();
        }

        static void Test(Animal a)
        {
            // System.InvalidCastException at run time
            // Unable to cast object of type 'Mammal' to type 'Reptile'
            Reptile r = (Reptile)a;
        }
    }
}
