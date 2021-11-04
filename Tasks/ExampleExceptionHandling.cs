using System;
using System.Threading.Tasks;

public class ExampleExceptionHandling
{
    public static void Main()
    {                              // искл. выбросится, на catch не сработает. почему?
                                   // почему ловит catch (AggregateException ae) - искл. другого типа?
        var task1 = Task.Run(() => { throw new CustomException("This exception is expected!"); });

        try
        {
            task1.Wait(); // сработает catch (AggregateException ae), т.к. в теле
        }
        catch (AggregateException ae) // сработает после Wait()
        {
            foreach (var e in ae.InnerExceptions)
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

public class CustomException : Exception
{
    public CustomException(String message) : base(message)
    { }
}
// The example displays the following output:
//        This exception is expected!