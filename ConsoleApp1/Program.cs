using System;
using System.Threading;
using System.Threading.Tasks;
using static ConsoleApp1.OOP;
using static ConsoleApp1.Interfaces;
using Casting;
using OOP;
using Tasks;

namespace ConsoleApp1
{
    class Program
    {
        private static string result;
        
        public const string CAPTION_BEGIN = "\r\n\r\n\r\n*****";
        public const string CAPTION_END = "*****";
        public const string SUB_CAPTION = "-----";

        private static OOP OOP = new OOP();
        private static Keywords keywords = new Keywords();
        private static LINQ LINQ = new LINQ();
        private static DelegatesLambda delegatesLambda = new DelegatesLambda();
        private static Exceptions exceptions = new Exceptions();
        private static Common common = new Common();
        private static ReferenceTypes referenceTypes = new ReferenceTypes();


        // инвариантность ковариантность
        static void Main(string[] args)
        {

            Console.WriteLine(SUB_CAPTION);
            new B8().Somework();
            (new B8() as IA).Somework();

            Console.WriteLine(CAPTION_END);
            //A9 a9 = new A9();
            //B9 b9 = new B9();
            //a9.M();
            //b9.M();
            //a9 = b9;
            //a9.M();
            //b9.M();

            Console.WriteLine(CAPTION_END);
            new A10(); // вызовется статический, потом обычный к-р
            var b10x = B10.x; // вызовется только ст-й к-р

            Console.WriteLine(CAPTION_END);

            Console.WriteLine(CAPTION_END);
            A13 a13 = new B13();
            Console.WriteLine(a13.GetType() == typeof(A13));
            Console.WriteLine(a13.GetType() == typeof(B13));
            Console.WriteLine(a13 is A13);
            Console.WriteLine(a13 is B13);
            Console.WriteLine(SUB_CAPTION);
            
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

            #region COMMON
            Console.WriteLine($"***** COMMON *****");
            common.Main();
            common.Ex1();
            common.Ex2();
            common.Ex3();
            common.Ex5();
            common.Ex6();
            common.Ex7();
            common.Ex8();
            common.Nullable();
            #endregion

            #region REFERENCE TYPES
            referenceTypes.Main();
            #endregion

            #region STATIC
            // Static
            InstanceClassStaticConstructor ICSC;
            new InstanceClassStaticConstructor();
            //StaticClassStaticConstructor SCSC; // не удаётся объявить переменную статического типа
            //new StaticClassStaticConstructor(); // не удаётся создать экземпляр статического класса
            StaticClassStaticConstructor.foo = 100;
            StaticClassStaticConstructor.GetFoo();
            #endregion

            #region STRINGS
            var strings = new Strings();
            strings.TestEquality();
            strings.TestEquality2();
            strings.TestIntern();
            // сравнение строк 3 способа
            #endregion

            #region OOP
            Console.WriteLine($"***** OOP *****");
            new A15();
            Person p = new Person();
            p.VirtualOverride(); // вызовется у Person
            //p.NotOverrided();
            p.Hidden(); // вызовется у Person
            p.HiddenNew();  // вызовется у Person

            // должно всё вызываться у Employee
            Person personEmployee = new Employee();
            personEmployee.VirtualOverride(); // вызовется у Employee, тк оверрайд. проиниц-ли базовую переменную типом наследника
            personEmployee.Hidden(); // вызовется у Person
            personEmployee.HiddenNew(); // вызовется у Person. чем отличается?

            Employee employeeEmployee = new Employee();
            employeeEmployee.VirtualOverride(); // вызовется у Employee
            employeeEmployee.Hidden(); // вызовется у Employee
            employeeEmployee.HiddenNew(); // вызовется у Employee

            var exDerived = new ExampleDerived();
            var exDerivedNew = new ExampleDerivedNew();

            //employeeEmployee = personEmployee; // не удаётся неявно преобразовать тип Person в Employee. базовый класс не знает о наследниках
            employeeEmployee = (Employee)personEmployee; // можно кастить классы, наследуемые от одного типа
            personEmployee = employeeEmployee; // наследники знают о базовом классе, т.к. наследуют от него

            Animal a = new Animal();
            Dog dogDog = new Dog();
            Animal animalDog = new Dog();

            //Dog dog3 = a; // ошибка design time. нельзя наследнику присваиват родителя. почему? Нужно кастить (Dog)
            //Dog dog4 = (Dog)a; // ошибка run time - нельзя кастить к базовому классу. почему?
            a = (Animal)dogDog; // базовый класс видит всех наследников и без кастинга

            // Не виртуальный метод - вызовется метод класса, указанного у переменной
            dogDog.Info(); // Info класса Dog. Каким типом переменная объявлена, такой тип и вызовется
            animalDog.Info(); // Info класса Animal
            
            // Виртуальный метод - вызовется метод класса, которого переменная реально имеет
            a.Say(); // Say() класса Animal
            // как вызвать  public void Info() у Animal?
            dogDog.Say(); // напишет Woof
            animalDog.Say(); // напишет Woof

            

            //ошибка
            //Employee e1 = (Employee)new Person("Tom");

            //сокрытие
            (new Person()).Hidden();
            (new Employee()).HiddenNew();

            (new Person()).Hidden();
            (new Employee()).HiddenNew();

            Point p1 = new Point(10, 16);
            Point p2 = new Point(10, 16) { x = 100, y = 200 }; // инициализация свойств напрямую переопределяет иниц-ю св-в через конструктор

            Point pStruct1 = new Point(10, 16);
            Point pstruct2 = new Point(10, 16) { x = 100, y = 200 }; // инициализация свойств напрямую переопределяет иниц-ю св-в через конструктор

            // new не играет роли
            var a3 = new DerivedPrivate().className; // Base, т.к. у DerivedPrivate поле private, автоматический доступ с базовому классу
            var a4 = new DerivedPrivate().ClassName;
            var a5 = new DerivedPublic().className; // Derived, т.к. у DerivedPublic поле public
            var a6 = new DerivedNewPrivate().className;
            var a7 = new DerivedNewPrivate().ClassName;
            var a8 = new DerivedNewPublic().className;


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
            OOP.IsTest();

            int i2 = 10;
            string s2 = "HelloWorld";
            PassByReference pbr = new PassByReference();

            OOP.ModifyInt(i2); // число не меняется
            OOP.ModifyString(s2); // строка не меняется. передача по ссылке не работает почему-то. видимо потому-что изменилось значение
            OOP.ModifyObject(pbr); // до вызова PassByReference.Foo = 0, после = 1. изменилась по ссылке

            new Square();

            Person2 p4 = new Person2();
            Student s = new Student();
            C<Person2> cp = new C<Person2>();
            C<Student> cs = new C<Student>();
            p4 = s;
            //s = p4;
            s = (Student)p4;
            //cp = cs;
            //cp = (C<Person2>)cs; // как закастить? google: casting generic types
            cp.x = p4;
            //cs = cp;
            s = cs.x;

            Console.WriteLine(SUB_CAPTION);
            new C6(); // отработают конструкторы по цепочке
            Console.WriteLine(SUB_CAPTION);
            new C7(); // отработают конструкторы по цепочке
            Console.WriteLine(SUB_CAPTION);
            new C8(); // отработают конструкторы по цепочке

            // запускать поочерёдно - закомм-ть всё, оставить одно
            //new Child(); // вызываются к-ры по цепочке static Child() - static Parent() - public Parent() - public Child()
            //Child.field1 = 1; // вызывается к-р static Child() (убрать new Child())
            //System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(typeof(Child).TypeHandle); // вызывается к-р static Child()
            //Child.Foo(); // вызывается к-р static Child()

            B9 b9 = new B9();
            A9 a9 = b9;
            a9.M(); // если M - override - вызовется у класса B9
            b9.M();
            b9.M2();

            Outer outer = new Outer();
            Outer.Inner inner = new Outer.Inner();
            outer.A();
            inner.A();

            OOP.CheckType1(new Foo3());
            OOP.CheckType2(new Foo3());
            OOP.CheckType3(new Foo3());

            Console.WriteLine($"{CAPTION_BEGIN} OOP {CAPTION_END}");

            OOP.ClassEquality();

            IsOperatorExample.Main();

            double r = 3.0, h = 5.0;
            Shape c = new Circle(r);
            Shape s1 = new Sphere(r);
            Shape l = new Cylinder(r, h);
            // Display results.
            Console.WriteLine("Area of Circle   = {0:F2}", c.Area());
            Console.WriteLine("Area of Sphere   = {0:F2}", s1.Area());
            Console.WriteLine("Area of Cylinder = {0:F2}", l.Area());
            /*
                Output:
                Area of Circle   = 28.27
                Area of Sphere   = 113.10
                Area of Cylinder = 150.80
            */
            #endregion

            #region LINQ
            Console.WriteLine($"***** LINQ *****");
            LINQ . Ex1(); // так можно
            LINQ.Ex2();
            LINQ.Ex3();
            LINQ.Ex4();
            LINQ.Lazy();
            LINQ.LazyInitialization();
            LINQ.Lazy2();
            LINQ.Pagination();
            LINQ.Any();
            #endregion

            #region DELEGATES
            Console.WriteLine($"***** DELEGATES LAMBDA *****");
            delegatesLambda.Main();
            delegatesLambda.Ex1();
            delegatesLambda.Ex2();
            delegatesLambda.TestFunc();
            delegatesLambda.CompareDelegates();
            delegatesLambda.InstanceStaticMethod();
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
            new Objects().Ex1();

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

            int initializeInMethod; // можно не инициализировать
            keywords.OutArgExample(out initializeInMethod); // стал 44

            int initializeInMethodRef = 0; // нужно инициализировать
            keywords.RefArgExample(ref initializeInMethodRef); // стал 44
            #endregion

            #region OPERATORS
            //Console.WriteLine($"{CAPTION_BEGIN} OPERATORS {CAPTION_END}");
            //new Operators().NullCoalescing();
            #endregion

            #region ASYNC/AWAIT
            //Console.WriteLine($"{CAPTION_BEGIN} ASYNC/AWAIT {CAPTION_END}");
            //AsyncAwait.Process();
            //Console.WriteLine("C");
            //new AsyncAwait().HttpRequest();
            //new AsyncAwait().HttpRequestAsync();
            new AsyncAwait().TaskDelay();
            new AsyncAwait().CancellationTokenMicrosoft();
            new AsyncAwait().CancellationTokenSimple();
            //new AsyncAwait().CancellationTokenSimple2();
            #endregion

            #region CASTING
            CastingClass.Main();
            UnSafeCast.Main();
            #endregion

            #region MULTITHREADING
            //https://docs.microsoft.com/en-us/previous-versions/dotnet/netframework-1.1/1c9txz50(v=vs.71)
            //https://docs.microsoft.com/en-us/previous-versions/dotnet/netframework-1.1/f857xew0(v=vs.71)
            //WaitSleepJoin thread state

            /*if (Monitor.TryEnter(lockObject, 300))
            {
                try
                {
                    // Place code protected by the Monitor here.  
                }
                finally
                {
                    Monitor.Exit(lockObject);
                }
            }
            else
            {
                // Code to execute if the attempt times out.  
            }*/


            //Console.WriteLine($"{CAPTION_BEGIN} MULTITHREADING {CAPTION_END}");
            //ThreadCreationProgram.Main();
            //Example.Main();

            //var synchronizer = new Synchronizer<MySharedClass, IReadFromShared, IWriteToShared>(null);
            //new UsingSynchronizerClass().Foo(synchronizer);
            //Console.WriteLine("ThreadSleepExample");
            //ThreadSleepExample.Main();

            //Multithreading.Program.Main();
            //LongOperationSyncAsync.Main();
            #endregion

            #region TASKS
            /*for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("\n");
                ExampleDetachedChildTasks1.Main();
                Thread.Sleep(1000);
            }*/

            //Console.WriteLine("\n");
            //ExampleDetachedChildTasks2.Main();

            //Console.WriteLine("\n");
            //ExampleAttachedChildTasks1.Main();
            //Console.WriteLine("\n");
            //ExampleAttachedChildTasks1.Main();
            //Console.WriteLine("\n");
            //Console.WriteLine("\n");
            //ExampleTaskCancellation.Main();
            //Console.WriteLine("\n");
            //ExampleExceptionHandling.Main();
            //ExampleExceptionHandling2.Main();
            //ExampleExceptionHandlingWaitAll.Main();
            //TaskArray.Main();
            //ReturnValueFromTask.Main();
            //TreeWalk.Main();
            //CancelTaskAndItsChildren.Main();
            //ContinuationExample.Main();
            //WhenAll.Main();
            //TaskInstantiation.Main();

            //AsynchronousProgramming.MainSync();
            //AsynchronousProgramming.MainAsync(); // ничем не отличается от MainSync
            //AsynchronousProgramming.MainConcurrently();
            AsynchronousProgramming.MainConcurrently2(); // всё вперемешку
            //AsynchronousProgramming.MainComposition();
            #endregion

            #region DATA STRUCTURES
            //Console.WriteLine("***** DATA STRUCTURES *****");
            //BinaryTree binaryTree = new BinaryTree();

            //binaryTree.Add(1);
            //binaryTree.Add(2);
            //binaryTree.Add(7);
            //binaryTree.Add(3);
            //binaryTree.Add(10);
            //binaryTree.Add(5);
            //binaryTree.Add(8);

            //Node node = binaryTree.Find(5);
            //int depth = binaryTree.GetTreeDepth();

            //Console.WriteLine("PreOrder Traversal:");
            //binaryTree.TraversePreOrder(binaryTree.Root);
            //Console.WriteLine();

            //Console.WriteLine("InOrder Traversal:");
            //binaryTree.TraverseInOrder(binaryTree.Root);
            //Console.WriteLine();

            //Console.WriteLine("PostOrder Traversal:");
            //binaryTree.TraversePostOrder(binaryTree.Root);
            //Console.WriteLine();

            //binaryTree.Remove(7);
            //binaryTree.Remove(8);

            //Console.WriteLine("PreOrder Traversal After Removing Operation:");
            //binaryTree.TraversePreOrder(binaryTree.Root);
            //Console.WriteLine();

            //Console.ReadLine();
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