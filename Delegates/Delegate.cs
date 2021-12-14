using System;

namespace Delegates
{
    // MSDN
    public class Delegate
    {
        // Declare a delegate.
        delegate void Del(string str);

        // Declare a method with the same signature as the delegate.
        static void Notify(string name)
        {
            Console.WriteLine($"Notification received for: {name}");
        }

        public void Main() 
        {
            // Create an instance of the delegate.
            Del del1 = new Del(Notify);

            // C# 2.0 provides a simpler way to declare an instance of Del.
            Del del2 = Notify;

            // Instantiate Del by using an anonymous method.
            Del del3 = delegate (string name) { Console.WriteLine($"Notification received for: {name}"); };

            // Instantiate Del by using a lambda expression.
            Del del4 = name => { Console.WriteLine($"Notification received for: {name}"); };

            // в del1, del2, del3, del4 в консоль пока ничего не напишет

            del1("classic");
            del2("simplier way");
            del3("anonimous");
            del4("lambda expression");
        }
    }
}
