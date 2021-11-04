using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.Threading;

public class WhenAll
{
    public static async Task Main()
    {
        Console.WriteLine("\n***** WhenAll *****");

        var tasks = new List<Task<int>>();
        for (int ctr = 1; ctr <= 10; ctr++)
        {
            int baseValue = ctr;
            tasks.Add(Task.Factory.StartNew(b => (int)b * (int)b, baseValue));
        }
        var results = await Task.WhenAll(tasks);

        var tasksWhenAll = new List<Task<int>>();
        Console.WriteLine($"Before WhenAll {DateTime.Now}");
        tasksWhenAll.Add(Task.Factory.StartNew(x => {Thread.Sleep(1000); return (int)x;}, 1000));
        tasksWhenAll.Add(Task.Factory.StartNew(x => {Thread.Sleep(2000); return (int)x;}, 2000));
        tasksWhenAll.Add(Task.Factory.StartNew(x => {Thread.Sleep(3000); return (int)x;}, 3000));
        var resultsWhenAll = await Task.WhenAll(tasksWhenAll); // самая длительная задача
        Console.WriteLine($"After WhenAll {DateTime.Now} {tasksWhenAll[0].Result} {tasksWhenAll[1].Result} {tasksWhenAll[2].Result}");
        Console.WriteLine($"Before WaitAll waited {DateTime.Now}");
        Task.WaitAll(tasksWhenAll.ToArray()); // мгновенно, т.к. задачи уже подождались
        Console.WriteLine($"After WaitAll waited {DateTime.Now}\n");
        var resultsAny = await Task.WhenAny(tasksWhenAll); // какой будет результат? почему всегда 1-я задача?

        var tasksWaitAll = new List<Task<int>>();
        Console.WriteLine($"Before WaitAll {DateTime.Now}");
        tasksWaitAll.Add(Task.Factory.StartNew(x => {Thread.Sleep(1000); return (int)x;}, 1000));
        tasksWaitAll.Add(Task.Factory.StartNew(x => {Thread.Sleep(2000); return (int)x;}, 2000));
        Console.WriteLine($"Before WaitAll not waited {DateTime.Now}");
        Task.WaitAll(tasksWaitAll.ToArray()); // задержка, т.к. задачи не подождались
        Console.WriteLine($"After WaitAll not waited {DateTime.Now}");
    }
}