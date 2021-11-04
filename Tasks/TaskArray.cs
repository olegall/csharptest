using System;
using System.Threading;
using System.Threading.Tasks;

public class TaskArray
{
    public static void Main()
    {
        Task<Double>[] taskArray = { Task<Double>.Factory.StartNew(() => { Thread.Sleep(1000); return DoComputation(1); }),
                                     Task<Double>.Factory.StartNew(() => { Thread.Sleep(2000); return DoComputation(2); }),
                                     Task<Double>.Factory.StartNew(() => { Thread.Sleep(3000); return DoComputation(3); }) };

        //Console.Write($"{DateTime.Now}\n");
        Task.WaitAll(taskArray); // если раскомментировать WaitAll, то в for задержек не будет. задачи уже все подождуться
        //Console.Write($"{DateTime.Now}\n");

        for (int i = 0; i < taskArray.Length; i++)
        {
            Console.Write($"{taskArray[i].Result} {DateTime.Now}\n"); // .Result - ждёт, пока выполниться задача (Sleep)
        }
    }

    private static Double DoComputation(Double start) => start;
}