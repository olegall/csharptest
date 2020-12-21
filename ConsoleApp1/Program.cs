using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using static ConsoleApp1.OOP;
using static ConsoleApp1.Interfaces;
using static ConsoleApp1.LINQ;

namespace ConsoleApp1
{
    class Program
    {

        //LINQ LINQ = new LINQ();
        

        private static string result;
        
        #region Делегаты
        delegate void Printer();
        public delegate void MessageDelegate(string message);
        #endregion

        public const string CAPTION_BEGIN = "\r\n\r\n\r\n*****";
        public const string CAPTION_END = "*****";
        public const string SUB_CAPTION = "-----";

        static OOP OOP = new OOP(SUB_CAPTION);
        static Keywords keywords = new Keywords(SUB_CAPTION);
        static LINQ LINQ = new LINQ();
        static DelegatesLambda delegatesLambda = new DelegatesLambda();
        static Exceptions exceptions = new Exceptions();
        static Common common = new Common();

        static void Main(string[] args)
        {
            #region Типы данных
            DateTime time = new DateTime();
            /* оператор == будет передавать свои операнды в разные допустимые типы,
             * чтобы получить общий тип, который он может затем сравнить */
            if (time == null)
            {
                /* do something */
            }
            #endregion

            #region Делегаты
            /*
                delegate добавляется циклически, однако параметр i передаётся по ссылке
             */
            List<Printer> printers = new List<Printer>();
            for (int i = 0; i < 10; i++)
            {
                printers.Add(delegate { Console.WriteLine(i); });
            }
            foreach (var printer in printers)
            {
                printer();
            }

            Action greet = delegate { Console.WriteLine("Hello!"); };
            greet.Invoke();
            //greet.BeginInvoke
            greet();
            #endregion

            #region Virtual
            Person p = new Person("Tom");
            p.Display();
            //p.NotOverrided();

            Employee e = new Employee("Tom", "Microsoft");
            e.Display();

            Person tom = new Employee("Tom", "Microsoft");
            tom.Display();

            //ошибка
            //Employee e1 = (Employee)new Person("Tom");

            //сокрытие
            (new Person("")).Hided();
            (new Employee("", "")).Hided();

            (new Person("")).Hided2();
            (new Employee("", "")).Hided2();

            Animal a = new Animal();
            Dog dog1 = new Dog();
            Animal dog2 = new Dog();

            // ошибка design time (вверх по иерархии нельзя)
            //Dog dog3 = new Animal();
            // ошибка run time (вверх по иерархии нельзя)
            // Dog dog4 = (Dog)new Animal();
            // Не виртуальный метод - вызовется метод класса, указанного у переменной 
            dog1.Info(); // напишет Dog
            dog2.Info(); // напишет Animal
                         // Виртуальный метод - вызовется метод класса, которого переменная реально имеет
            a.Say(); // напишет nothing to say
            dog1.Say(); // напишет Woof
            dog2.Say(); // напишет Woof


            //B obj1 = new A();
            //obj1.Foo();
            B obj2 = new B();
            obj2.Foo();
            A obj3 = new B();
            obj3.Foo();
            #endregion

            #region Async/Await
            //new AsyncAwait().HttpRequest();
            //new AsyncAwait().HttpRequestAsync();
            new AsyncAwait().TaskDelay();
            new AsyncAwait().CancellationTokenMicrosoft();
            new AsyncAwait().CancellationTokenSimple();
            //new AsyncAwait().CancellationTokenSimple2();
            #endregion





            int[] arr = new int[4] { 2, 1, 3, 4};
            Array.Sort(arr);



            var a1 = new A2(103);
            A2[] arrayOfA = new A2[4];
            arrayOfA[0] = new A2(103);
            arrayOfA[1] = new A2(4);
            arrayOfA[2] = new A2(58);
            arrayOfA[3] = new A2(31);
            Array.Sort(arrayOfA);

            // X = 100, Y = 100
            Point p2 = new Point(10, 16) { X = 100, Y = 100 };
            // X = 10, Y = 16
            Point p3 = new Point(10, 16);


            var a3 = new Derived1().className;
            var a4 = new Derived2().className;

            Console.WriteLine(CAPTION_END);
            new A3().Print();


            Console.WriteLine(CAPTION_END);
            Bus.Drive();
            Console.WriteLine(SUB_CAPTION);
            new Bus().Drive2();

            Console.WriteLine(CAPTION_END);
            Person2 p4 = new Person2();
            Student s = new Student();
            C<Person2> cp = new C<Person2>();
            C<Student> cs = new C<Student>();
            p4 = s;
            //s = p4;
            s = (Student)p4;
            //cp = cs;
            cp.x = p4;
            //cs = cp;
            s = cs.x;
            

            Console.WriteLine(CAPTION_END);
            new B6("Quizful");
            Console.WriteLine(SUB_CAPTION);
            new C6();

            Console.WriteLine(CAPTION_END);
            new B8().Somework();
            (new B8() as IA).Somework();

            Console.WriteLine(CAPTION_END);
            new Child();
            Console.WriteLine(SUB_CAPTION);
            // вызывается статический конструктор (убрать new Child())
            Child.field1 = 1;
            // вызывается статический конструктор (или этот вариант или выше)
            Type type = typeof(Child);
            System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(type.TypeHandle);
            // не вызывается статический конструктор
            Child.Foo();

            Console.WriteLine(CAPTION_END);
            //A9 a9 = new A9();
            //B9 b9 = new B9();
            //a9.M();
            //b9.M();
            //a9 = b9;
            //a9.M();
            //b9.M();

            B9 b9 = new B9();
            A9 a9 = b9;
            a9.M();
            //b9.M();

            Console.WriteLine(CAPTION_END);
            A10 a10 = new A10();
            Console.WriteLine(B10.x);

            Console.WriteLine(CAPTION_END);
            A11 a11 = new B11();
            B11 b11 = new B11();

            Console.WriteLine(CAPTION_END);
            A13 a13 = new B13();
            Console.WriteLine(a13.GetType() == typeof(A13));
            Console.WriteLine(a13.GetType() == typeof(B13));
            Console.WriteLine(a13 is A13);
            Console.WriteLine(a13 is B13);
            Console.WriteLine(SUB_CAPTION);
            Console.WriteLine(new A13() is B13);
            Console.WriteLine(new B13() is A13);
            Console.WriteLine(new A13() is A13);
            Console.WriteLine(new B13() is B13);
            Console.WriteLine(SUB_CAPTION);
            B13 b13 = new B13();
            //if (a13 as B13) { }
            //         Type 
            //if (a13 is typeof(B13)) { }
            //if (B13 as B13) { }
            if (a13 is B13) { }
            //if (a13 is b13) { }
            if (a13 is B13 == null) { }
            //if (a as B == null) { }
            Console.WriteLine(CAPTION_END);
            B14 a1_ = new B14();
            A14 a2_ = new B14();
            A14 a3_ = a1_;
            C14 a4_ = new C14();
            A14 a5_ = a4_;

            a1_.Method();
            a2_.Method();
            a3_.Method();
            a4_.Method();
            a5_.Method();

            Console.WriteLine($"{CAPTION_BEGIN} OOP {CAPTION_END}");
            new A15();

            #region OOP
            Console.WriteLine($"{CAPTION_BEGIN} OOP {CAPTION_END}");


            int value = 10;
            A16 a16 = new A16();
            B16 b16 = new B16();
            A16 a17 = new B16();
            a16.GetValue(value);
            b16.GetValue(value);
            a17.GetValue(value);
            OOP.Ex1();
            OOP.Ex2();
            OOP.UpcastingDowncasting();

            // Static
            InstanceClassStaticConstructor ICSC;
            new InstanceClassStaticConstructor();
            //StaticClassStaticConstructor SCSC; // не удаётся объявить переменную статического типа
            //new StaticClassStaticConstructor(); // не удаётся создать экземпляр статического класса
            StaticClassStaticConstructor.foo = 100;
            StaticClassStaticConstructor.GetFoo();

            // Strings
            var strings = new Strings();
            strings.TestEquality();
            strings.TestEquality2();
            strings.TestIntern();
            #endregion

            #region
            TypeA a18 = new TypeA();
            TypeA.TypeB b18 = new TypeA.TypeB();
            a18.MethodA();
            b18.MethodA();
            #endregion

            #region OOP
            Console.WriteLine(SUB_CAPTION);
            int i2 = 10;
            string s2 = "HelloWorld";

            Console.WriteLine("i = " + i2);
            OOP.ModifyInt(i2);
            Console.WriteLine("i = " + i2);

            Console.WriteLine("s = " + s2);
            // строка не меняется
            OOP.ModifyString(s2);
            Console.WriteLine("s = " + s2);

            new Square();
            #endregion

            #region
            Console.WriteLine(SUB_CAPTION);
            OOP.Ex3();
            #endregion

            #region
            Console.WriteLine(SUB_CAPTION);
            A21 a21 = new A21();
            B21 b21 = new B21();
            C21 c21 = new C21();
            a21.Print();
            b21.Print();
            c21.Print();
            #endregion

            #region LINQ
            Console.WriteLine($"{CAPTION_BEGIN} LINQ {CAPTION_END}");
            LINQ . Ex1(); // так можно
            LINQ.Ex2();
            LINQ.Ex3();
            LINQ.Ex4();
            LINQ.LazyInitialization();
            LINQ.LINQ1();
            #endregion

            #region DELEGATES
            Console.WriteLine($"{CAPTION_BEGIN} DELEGATES LAMBDA {CAPTION_END}");
            delegatesLambda.Ex1();
            delegatesLambda.Ex3();
            delegatesLambda.TestFunc();
            #endregion

            #region OBJECTS
            Console.WriteLine($"{CAPTION_BEGIN} OBJECTS {CAPTION_END}");
            //new Objects().CompareObjects();
            //new Objects().Ex0();
            //new Objects().Ex1();
            //new Objects().Ex2();
            //new Objects().Ex3();
            new Objects().Nullable();

            new Objects().DoRefObj();
            #endregion

            #region EXCEPTIONS
            Console.WriteLine($"{CAPTION_BEGIN} EXCEPTIONS {CAPTION_END}");
            //new Exceptions().Ex1();
            //new Exceptions().Ex2();
            //var exc_ex3 = exceptions().Ex3();
            //exceptions.TestThrow();
            //exceptions.Ex4();
            exceptions.Ex5();
            exceptions.TryCatchFinally();
            #endregion

            #region COMMON
            Console.WriteLine($"{CAPTION_BEGIN} COMMON {CAPTION_END}");
            common.Ex1();
            common.Ex2();
            common.Ex3();
            common.Ex5();
            common.Ex6();
            common.Ex7();
            common.Ex8();
            common.Nullable();
            #endregion

            #region KEYWORDS
            Console.WriteLine($"{CAPTION_BEGIN} KEYWORDS {CAPTION_END}");
            keywords.As();
            //new Keywords().Checked();
            keywords.Unchecked();
            keywords.Default();
            keywords.Enum();
            keywords.Is();
            keywords.Is2();

            #region Yield
            Console.WriteLine($"{SUB_CAPTION} Yield {SUB_CAPTION}");
            foreach (string s_ in Keywords.GetStrings())
            {
                Console.WriteLine(s_);
                Console.WriteLine("C#");
            }
            
            foreach (char ch in Keywords.GetLetters())
            {
                Console.WriteLine(ch);
            }
            #endregion

            
            keywords.Params();
            

            Console.WriteLine($"{SUB_CAPTION} New1 {SUB_CAPTION}");
            keywords.New1();

            keywords.ImplicitExplicitOperator();
            keywords.Operator();
            keywords.This1();
            keywords.This2();
            #endregion

            #region OPERATORS
            Console.WriteLine($"{CAPTION_BEGIN} OPERATORS {CAPTION_END}");
            new Operators().NullCoalescing();
            #endregion

            #region ASYNC/AWAIT
            Console.WriteLine($"{CAPTION_BEGIN} ASYNC/AWAIT {CAPTION_END}");
            AsyncAwait.Process();
            Console.WriteLine("C");
            #endregion

            Console.ReadKey();
        }

        #region ASYNC/AWAIT
        static async Task MainAsync(string[] args)
        {
            await Delay1Async();
            await Delay2Async();
            //Delay1Async();
            //Delay2Async();
            Console.WriteLine($"{CAPTION_END}");
            //Task t1 = Delay1Async();
            //Task t2 = Delay2Async();
            //await t1;
            //await t2;
            await SaySomething();
            Console.WriteLine(result);
            result = await SaySomething();
            Console.WriteLine(result);
            result = await SaySomething2();
            Console.WriteLine(result);

        }
    

        public static async Task Delay1Async()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 200; i++)
                {
                    //Console.Write(Thread.CurrentThread.ManagedThreadId + " ");
                    Console.Write("1 ");
                }
                Console.WriteLine("Task1 stopped");
            });
        }

        public static async Task Delay2Async()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 300; i++)
                {
                    //Console.Write(Thread.CurrentThread.ManagedThreadId + " ");
                    Console.Write("2 ");
                }
                Console.WriteLine("Task2 stopped");
            });
        }

        static async Task<string> SaySomething()
        {
            await Task.Delay(3000);
            result = "Hello world!";
            return "Something";
        }

        static async Task<string> SaySomething2()
        {
            Thread.Sleep(3000);
            result = "Hello world 2!";
            return "Something 2";
        }

        public static void Delay()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.Write(Thread.CurrentThread.ManagedThreadId+" ");
            }
        }
        #endregion
    }
}