using System;
using System.Threading;

namespace Multithreading
{
    public class ThreadCreationProgram
    {
        public static void CallToChildThread()
        {
            try
            {
                Console.WriteLine("Child thread starts");
                var a1 = Thread.CurrentThread.ManagedThreadId;
                // do some work, like counting to 10
                for (int counter = 0; counter <= 10; counter++)
                {
                    Thread.Sleep(500); // Этот Thread уже дочерний? Почему при вызове .Sleep общего статического класса притормаживается дочерний поток?
                    Console.WriteLine(counter);
                }

                Console.WriteLine("Child Thread Completed");
            }
            catch (ThreadAbortException e)
            {
                Console.WriteLine("Thread Abort Exception");
            }
            finally
            {
                Console.WriteLine("Couldn't catch the Thread Exception");
            }
        }

        public static void CallToChildThread2() 
        {
            var a1 = Thread.CurrentThread.ManagedThreadId;
            var name = Thread.CurrentThread.Name; // third
        }

        public static void Main()
        {
            ThreadStart childref = new ThreadStart(CallToChildThread);

            Console.WriteLine("In Main: Creating the Child thread");
            Thread childThread = new Thread(childref);
            var a1 = Thread.CurrentThread.ManagedThreadId; // отличается от в CallToChildThread
            childThread.Start();

            //stop the main thread for some time
            Thread.Sleep(2000);

            //now abort the child
            Console.WriteLine("In Main: Aborting the Child thread");
            childThread.Abort();

            ThreadStart childref2 = new ThreadStart(CallToChildThread2);
            var childThread2 = new Thread(childref2);
            childThread2.Name = "third";
            childThread2.Start();

            Console.ReadKey();
        }
    }
}
