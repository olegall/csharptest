using System;
using System.Threading;

namespace Multithreading
{
    public class ThreadSleepExample
    {
        public static void Main()
        {
            // Interrupt a sleeping thread.
            var sleepingThread = new Thread(ThreadSleepExample.SleepIndefinitely);
            sleepingThread.Name = "Sleeping";
            sleepingThread.Start();
            Thread.Sleep(5000);
            sleepingThread.Interrupt();

            Thread.Sleep(10000);

            sleepingThread = new Thread(ThreadSleepExample.SleepIndefinitely);
            sleepingThread.Name = "Sleeping2";
            sleepingThread.Start();
            Thread.Sleep(5000);
            sleepingThread.Abort();
            Thread.Sleep(10000);
        }

        private static void SleepIndefinitely()
        {
            Console.WriteLine("Thread '{0}' about to sleep indefinitely.", Thread.CurrentThread.Name);
            try
            {
                Thread.Sleep(Timeout.Infinite);
            }
            catch (ThreadInterruptedException)
            {
                Console.WriteLine("Thread '{0}' awoken.", Thread.CurrentThread.Name);
            }
            catch (ThreadAbortException)
            {
                Console.WriteLine("Thread '{0}' aborted.", Thread.CurrentThread.Name);
            }
            finally
            {
                Console.WriteLine("Thread '{0}' executing finally block.", Thread.CurrentThread.Name);
            }
            Console.WriteLine("Thread '{0} finishing normal execution.", Thread.CurrentThread.Name);
            Console.WriteLine();
        }

        // The example displays the following output:
        //       Thread 'Sleeping' about to sleep indefinitely.
        //       Thread 'Sleeping' awoken.
        //       Thread 'Sleeping' executing finally block.
        //       Thread 'Sleeping finishing normal execution.
        //
        //       Thread 'Sleeping2' about to sleep indefinitely.
        //       Thread 'Sleeping2' aborted.
        //       Thread 'Sleeping2' executing finally block.
    }
}