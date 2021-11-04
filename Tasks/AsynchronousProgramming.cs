using System;
using System.Threading.Tasks;

namespace Tasks
{
    class Coffee { }
    class Egg { }
    class Bacon { }
    public class Toast { }
    class Juice { }

    public class AsynchronousProgramming
    {
        public static void MainSync()
        {
            Console.WriteLine("\n***** MainSync *****");

            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready\n");

            Egg eggs = FryEggs(2);
            Console.WriteLine("eggs are ready\n");

            Bacon bacon = FryBacon(3);
            Console.WriteLine("bacon is ready\n");

            Toast toast = ToastBread(2);
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("toast is ready\n");

            Juice oj = PourOJ();
            Console.WriteLine("oj is ready\n");
            Console.WriteLine("Breakfast is ready!\n");
        }

        public static async Task MainAsync()
        {
            Console.WriteLine("\n***** MainAsync *****");

            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready\n");

            Egg eggs = await FryEggsAsync(2);
            Console.WriteLine("eggs are ready\n");

            Bacon bacon = await FryBaconAsync(3);
            Console.WriteLine("bacon is ready\n");

            Toast toast = await ToastBreadAsync(2);
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("toast is ready\n");

            Juice oj = PourOJ();
            Console.WriteLine("oj is ready\n");
            Console.WriteLine("Breakfast is ready!\n");
        }

        public static async Task MainConcurrently()
        {
            Console.WriteLine("\n***** MainConcurrently *****");

            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready\n");

            Task<Egg> eggsTask = FryEggsAsync(2);
            Egg eggs = await eggsTask;
            Console.WriteLine("eggs are ready\n");

            Task<Bacon> baconTask = FryBaconAsync(3);
            Bacon bacon = await baconTask;
            Console.WriteLine("bacon is ready\n");

            Task<Toast> toastTask = ToastBreadAsync(2);
            Toast toast = await toastTask;
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("toast is ready\n");

            Juice oj = PourOJ();
            Console.WriteLine("oj is ready\n");
            Console.WriteLine("Breakfast is ready!\n");
        }

        public static async Task MainConcurrently2()
        {
            Console.WriteLine("\n***** MainConcurrently2 *****");

            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready\n");

            Task<Egg> eggsTask = FryEggsAsync(2);
            Task<Bacon> baconTask = FryBaconAsync(3);
            Task<Toast> toastTask = ToastBreadAsync(2);

            Toast toast = await toastTask;
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("toast is ready\n");
            Juice oj = PourOJ();
            Console.WriteLine("oj is ready\n");

            Egg eggs = await eggsTask;
            Console.WriteLine("eggs are ready\n");
            Bacon bacon = await baconTask;
            Console.WriteLine("bacon is ready\n");

            Console.WriteLine("Breakfast is ready!\n");
        }

        public static async Task MainComposition()
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");

            var eggsTask = FryEggsAsync(2);
            var baconTask = FryBaconAsync(3);
            var toastTask = MakeToastWithButterAndJamAsync(2);

            var eggs = await eggsTask;
            Console.WriteLine("eggs are ready");

            var bacon = await baconTask;
            Console.WriteLine("bacon is ready");

            var toast = await toastTask;
            Console.WriteLine("toast is ready");

            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready!");
        }

        public static async Task<Toast> MakeToastWithButterAndJamAsync(int number)
        {
            var toast = await ToastBreadAsync(number);
            ApplyButter(toast);
            ApplyJam(toast);

            return toast;
        }

        private static Juice PourOJ()
        {
            Console.WriteLine("Pouring orange juice");
            return new Juice();
        }

        private static void ApplyJam(Toast toast) => Console.WriteLine("Putting jam on the toast");

        private static void ApplyButter(Toast toast) => Console.WriteLine("Putting butter on the toast");

        private static Toast ToastBread(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Remove toast from toaster");

            return new Toast();
        }

        private static Bacon FryBacon(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            Task.Delay(3000).Wait();
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second side of bacon...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put bacon on plate");

            return new Bacon();
        }

        private static Egg FryEggs(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            Task.Delay(3000).Wait();
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs ...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put eggs on plate");

            return new Egg();
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
        }

        private static async Task<Toast> ToastBreadAsync(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            await Task.Delay(3000);
            Console.WriteLine("Remove toast from toaster");

            return new Toast();
        }

        private static async Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            await Task.Delay(3000);
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second side of bacon...");
            await Task.Delay(3000);
            Console.WriteLine("Put bacon on plate");

            return new Bacon();
        }

        private static async Task<Egg> FryEggsAsync(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            await Task.Delay(3000);
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs ...");
            await Task.Delay(3000);
            Console.WriteLine("Put eggs on plate");

            return new Egg();
        }
    }
}
