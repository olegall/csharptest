using System;
using System.Threading;
using System.Threading.Tasks;

public class ContinuationExample
{
    public static async Task Main()
    {
        Console.WriteLine("\n***** Continuation *****");

        // Declare, assign, and start the antecedent task.
        //Task<DayOfWeek> taskA = Task.Run(() => DateTime.Today.DayOfWeek);
        Task<DayOfWeek> taskA = Task.Run(() => { // Status: Running
            Thread.Sleep(5000);
            Console.WriteLine("Thread.Sleep(5000) passed");
            return DateTime.Today.DayOfWeek;
        });

        // Execute the continuation when the antecedent finishes.
        await taskA.ContinueWith(antecedent => { // Status: Ran to completion
            Thread.Sleep(3000);
            Console.WriteLine($"Today is {antecedent.Result}.");
        });
    }
}
// The example displays the following output:
//       Today is Monday.