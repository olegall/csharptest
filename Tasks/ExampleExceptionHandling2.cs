using System;
using System.Threading;
using System.Threading.Tasks;

public class ExampleExceptionHandling2
{
    public class CustomException : Exception
    {
        public CustomException(String message) : base(message)
        { }
    }

    public static void Main()
    {
        var task1 = Task.Run(() => { Thread.Sleep(3000);  throw new CustomException("This exception is expected!"); });

        while (!task1.IsCompleted) {
            Console.WriteLine(DateTime.Now);
        }

        if (task1.Status == TaskStatus.Faulted)
        {
            foreach (var e in task1.Exception.InnerExceptions)
            {
                // Handle the custom exception.
                if (e is CustomException)
                {
                    Console.WriteLine(e.Message);
                }
                // Rethrow any other exception.
                else
                {
                    throw e;
                }
            }
        }
    }
}

