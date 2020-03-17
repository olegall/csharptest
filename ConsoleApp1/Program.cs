using System;
using System.Linq;
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
        OOP OOP = new OOP();
        //LINQ LINQ = new LINQ();
        Keywords keywords = new Keywords();

        private static string result;
        
        #region Делегаты
        delegate void Printer();
        public delegate void MessageDelegate(string message);
        #endregion

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

            Console.WriteLine("|||||||||||||||||||||||||||||||||||||||");
            new A3().Print();


            Console.WriteLine("|||||||||||||||||||||||||||||||||||||||");
            Bus.Drive();
            Console.WriteLine("---");
            new Bus().Drive2();

            Console.WriteLine("|||||||||||||||||||||||||||||||||||||||");
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
            

            Console.WriteLine("|||||||||||||||||||||||||||||||||||||||");
            new B6("Quizful");
            Console.WriteLine("---");
            new C6();

            Console.WriteLine("|||||||||||||||||||||||||||||||||||||||");
            new B8().Somework();
            (new B8() as IA).Somework();

            Console.WriteLine("|||||||||||||||||||||||||||||||||||||||");
            new Child();
            Console.WriteLine("---");
            // вызывается статический конструктор (убрать new Child())
            Child.field1 = 1;
            // вызывается статический конструктор (или этот вариант или выше)
            Type type = typeof(Child);
            System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(type.TypeHandle);
            // не вызывается статический конструктор
            Child.Foo();

            Console.WriteLine("|||||||||||||||||||||||||||||||||||||||");
            //A9 a9 = new A9();
            //B9 b9 = new B9();
            //a9.M();
            //b9.M();
            //Console.WriteLine("---");
            //a9 = b9;
            //a9.M();
            //b9.M();

            B9 b9 = new B9();
            A9 a9 = b9;
            a9.M();
            //b9.M();

            Console.WriteLine("|||||||||||||||||||||||||||||||||||||||");
            A10 a10 = new A10();
            Console.WriteLine(B10.x);

            Console.WriteLine("|||||||||||||||||||||||||||||||||||||||");
            A11 a11 = new B11();
            B11 b11 = new B11();

            Console.WriteLine("|||||||||||||||||||||||||||||||||||||||");
            A13 a13 = new B13();
            Console.WriteLine(a13.GetType() == typeof(A13));
            Console.WriteLine(a13.GetType() == typeof(B13));
            Console.WriteLine(a13 is A13);
            Console.WriteLine(a13 is B13);
            Console.WriteLine("---");
            Console.WriteLine(new A13() is B13);
            Console.WriteLine(new B13() is A13);
            Console.WriteLine(new A13() is A13);
            Console.WriteLine(new B13() is B13);
            Console.WriteLine("---");
            B13 b13 = new B13();
            //if (a13 as B13) { }
            //         Type 
            //if (a13 is typeof(B13)) { }
            //if (B13 as B13) { }
            if (a13 is B13) { }
            //if (a13 is b13) { }
            if (a13 is B13 == null) { }
            //if (a as B == null) { }
            Console.WriteLine("|||||||||||||||||||||||||||||||||||||||");
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

            Console.WriteLine("|||||||||||||||| OOP |||||||||||||||||||||||");
            new A15();

            #region OOP

            #region
            int value = 10;
            A16 a16 = new A16();
            B16 b16 = new B16();
            A16 a17 = new B16();
            a16.GetValue(value);
            b16.GetValue(value);
            a17.GetValue(value);
            new OOP().Ex1();
            new OOP().Ex2();
            #endregion

            #region
            TypeA a18 = new TypeA();
            TypeA.TypeB b18 = new TypeA.TypeB();
            a18.MethodA();
            b18.MethodA();
            #endregion

            #region
            Console.WriteLine("---------------------");
            int i2 = 10;
            string s2 = "HelloWorld";

            Console.WriteLine("i = " + i2);
            new OOP().ModifyInt(i2);
            Console.WriteLine("i = " + i2);

            Console.WriteLine("s = " + s2);
            // строка не меняется
            new OOP().ModifyString(s2);
            Console.WriteLine("s = " + s2);
            #endregion

            #region
            Console.WriteLine("---------------------");
            new OOP().Ex3();
            #endregion

            #region
            Console.WriteLine("------------------------------");
            A21 a21 = new A21();
            B21 b21 = new B21();
            C21 c21 = new C21();
            a21.Print();
            b21.Print();
            c21.Print();
            #endregion

            #endregion

            #region LINQ
            new LINQ().Ex1();
            new LINQ().Ex2();
            new LINQ().Ex3();
            new LINQ().Ex4();
            #endregion

            #region DELEGATES
            Console.WriteLine("|||||||||||||||| Delegates Lambda |||||||||||||||||||||||");
            new DelegatesLambda().Ex1();
            new DelegatesLambda().Ex3();
            #endregion

            #region OBJECTS
            //new Objects().CompareObjects();
            //new Objects().Ex0();
            //new Objects().Ex1();
            //new Objects().Ex2();
            //new Objects().Ex3();
            new Objects().Nullable();
            #endregion

            #region EXCEPTIONS
            Console.WriteLine("|||||||||||||||| EXCEPTIONS |||||||||||||||||||||||");
            //new Exceptions().Ex1();
            //new Exceptions().Ex2();
            //var exc_ex3 = new Exceptions().Ex3();
            //Exceptions.TestThrow();
            //new Exceptions().Ex4();
            new Exceptions().Ex5();
            #endregion

            #region COMMON
            Console.WriteLine("|||||||||||||||| COMMON |||||||||||||||||||||||");
            new Common().Ex1();
            new Common().Ex2();
            new Common().Ex3();
            new Common().Ex5();
            new Common().Ex6();
            new Common().Ex7();
            new Common().Ex8();
            new Common().Nullable();
            #endregion

            #region KEYWORDS
            Console.WriteLine("|||||||||||||||| KEYWORDS |||||||||||||||||||||||");

            new Keywords().As();
            //new Keywords().Checked();
            new Keywords().Unchecked();
            new Keywords().Default();
            new Keywords().Enum();
            new Keywords().Is();
            new Keywords().Is2();

            #region Yield
            Console.WriteLine("---------- Yield -----------");
            foreach (string s_ in Keywords.GetStrings())
            {
                Console.WriteLine(s_);
                Console.WriteLine("C#");
            }
            
            foreach (char ch in Keywords.GetLetters())
            {
                Console.WriteLine(ch);
            }
            Console.WriteLine("");
            #endregion

            
            new Keywords().Params();
            

            Console.WriteLine("---------- New1 -----------");
            new Keywords().New1();

            new Keywords().ImplicitExplicitOperator();
            new Keywords().Operator();
            new Keywords().This1();
            new Keywords().This2();
            #endregion

            #region OPERATORS
            new Operators().NullCoalescing();
            #endregion

            Console.ReadKey();
        }

        #region Async Await
        static async Task MainAsync(string[] args)
        {
            await Delay1Async();
            await Delay2Async();
            //Delay1Async();
            //Delay2Async();
            Console.WriteLine("|||||||||||||||||||||||||||||||||||||||||||||||||||||||");
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
                Console.WriteLine("||| Task1 stopped");
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
                Console.WriteLine("||| Task2 stopped");
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