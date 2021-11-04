﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks
{
    public class ExampleAttachedChildTasks1
    {
        public static void Main()
        {
            var parent = Task.Factory.StartNew(() => { // vs Task.Run - можно
                Console.WriteLine("Parent task executing.");
                
                var child = Task.Factory.StartNew(() => {
                    Console.WriteLine("Attached child starting.");
                    Thread.SpinWait(5000000);
                    Console.WriteLine("Attached child completing.");
                }, TaskCreationOptions.AttachedToParent);
            });
            parent.Wait();
            Console.WriteLine("Parent has completed.");
        }
    }
}
// The example displays the following output:
//       Parent task executing.
//       Attached child starting.
//       Attached child completing.
//       Parent has completed.