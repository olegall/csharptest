using System;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks
{
    public class ExampleDetachedChildTasks1
    {
        public static void Main()
        {
            Console.WriteLine("\n***** DetachedChildTasks *****");

            var parent = Task.Factory.StartNew(() =>
            {
                Console.WriteLine($"Outer task executing. {Ms}");
                var child = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine($"Nested task starting. {Ms}");
                    Thread.SpinWait(500000);
                    //Thread.Sleep(500);
                    Console.WriteLine($"Nested task completing. {Ms}");
                });
            });

            parent.Wait();
            //await parent;

            Console.WriteLine($"Outer task has completed. {Ms}");
        }
        
        private static string Ms => DateTime.Now.ToString("HH:mm:ss.fffffff");
    }
}

// в MSDN
// The example produces output like the following:
//        Outer task executing.
//        Nested task starting.
//        Outer has completed. // засчёт parent.Wait() ?
//        Nested task completing.

// или как в MSDN или так
// Outer task executing.
// Outer has completed.
// Nested task starting.
// Nested task completing.



// без parent.Wait(); - наоборот outer... результат разный
// Outer has completed.
// Outer task executing.
// Nested task starting.
// Nested task completing.