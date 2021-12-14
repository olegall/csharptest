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
        public void Main()
        {
            //Test(new Reptile()); // ok
            //Test(new Animal()); // ошибка
            //

            Reptile res1 = (Reptile) new Reptile();
            //Reptile res2 = (Reptile) new Animal(); // эксепшн в рантайме
            //Reptile res3 = (Reptile) new Mammal(); // ошибка в дизайн тайме
            //Cast(new Mammal()); // ошибка в рантайме

            // Keep the console window open in debug mode.
            //Console.WriteLine("Press any key to exit.");
            //Console.ReadKey();
        }

        private void Cast(Animal a)
        {
            // System.InvalidCastException at run time
            // Unable to cast object of type 'Mammal' to type 'Reptile'
            Reptile r = (Reptile)a;
        }
    }
}
