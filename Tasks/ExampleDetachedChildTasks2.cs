using System;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks
{
    public class ExampleDetachedChildTasks2
    {
        public static void Main()
        {
            var outer = Task<int>.Factory.StartNew(() => {
                Console.WriteLine("Outer task executing.");
                
                var nested = Task<int>.Factory.StartNew(() => {
                    Console.WriteLine("Nested task starting.");
                    Thread.SpinWait(5000000);
                    Console.WriteLine("Nested task completing.");
                    return 42;
                });

                // Parent will wait for this detached child.
                return nested.Result;
            });

            Console.WriteLine("Outer has returned {0}.", outer.Result);
        }
    }
    // The example displays the following output:
    //       Outer task executing.
    //       Nested task starting.
    //       Nested task completing.
    //       Outer has returned 42.
}