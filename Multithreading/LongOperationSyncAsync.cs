using System;
using System.Threading;

namespace Multithreading
{
    public class LongOperationSyncAsync
    {
        public static void Main() 
        {
            Thread t1 = new Thread(LongOperation1)
            {
                Name = "Thread1"
            };
            Thread t2 = new Thread(LongOperation2)
            {
                Name = "Thread2"
            };
            Thread t3 = new Thread(LongOperation3)
            {
                Name = "Thread3"
            };

            //Executing the methods
            Console.WriteLine($"Started sync {DateTime.Now}");
            LongOperation1Sync();
            LongOperation2Sync();
            LongOperation3Sync();
            Console.WriteLine($"Ended sync {DateTime.Now} \n");

            Console.WriteLine($"Started async {DateTime.Now}");
            t1.Start();
            t2.Start();
            t3.Start();
        }

        static void LongOperation1Sync()
        {
            Thread.Sleep(1000);
        }

        static void LongOperation2Sync()
        {
            Thread.Sleep(2000);
        }

        static void LongOperation3Sync()
        {
            Thread.Sleep(3000);
        }

        static void LongOperation1()
        {
            Thread.Sleep(1000);
            Console.WriteLine($"Ended async thread1: {DateTime.Now}");
        }

        static void LongOperation2()
        {
            Thread.Sleep(2000);
            Console.WriteLine($"Ended async thread2: {DateTime.Now}");
        }

        static void LongOperation3()
        {
            Thread.Sleep(3000);
            Console.WriteLine($"Ended async thread3: {DateTime.Now}");
        }
    }
}