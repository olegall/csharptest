using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public delegate void Print(int value);

    /*
    ВОПРОСЫ
    
    async delegate
    
    передать Action в качестве параметра
    Foo(Action a) - видимо передаётся тело метода, анонимный метод
    */

    class DelegatesLambda
    {
        public delegate void MessageDelegate(string message); // параметр, public

        // объявляем тип делегата?
        // объявлять только в классе
        delegate void Printer();


        public void Main()
        {
            // delegate добавляется циклически, однако параметр i передаётся по ссылке
            List<Printer> printers = new List<Printer>();
            for (int i = 0; i < 3; i++)
            {
                // и при объявлении, и при вызове используется слово delegate
                // var a1 = delegate { Console.WriteLine(i); }; // нельзя
                printers.Add(delegate { Console.WriteLine(i); }); // код в теле, нет параметров и ничего не возвращает
                //printers.Add(new Printer()); // нельзя
            }

            foreach (var printer in printers)
            {
                printer();
            }

            Action greet = delegate { Console.WriteLine("Hello!"); };
            greet();
            greet.Invoke();
            //greet.BeginInvoke


            // msdn
            Action<string> stringAction = str => {};
            Action<object> objectAction = obj => {}; // <object> - исключение    <string> - исключения не будет
            //Action<string> objectAction = obj => {};

            // Valid due to implicit reference conversion of objectAction to Action<string>, but may fail at runtime.
            // System.ArgumentException: "Делегаты должны принадлежать к одному типу."
            //Action<string> combination = stringAction + objectAction; 

            // нельзя
            // public delegate void Print(int value);
            // delegate можно присваивать только при объявлении
            Print prnt = delegate (int val)
            {
                Console.WriteLine("Anonymous method: {0}", val);
            };
            prnt(100);
            prnt(200);
        }

        delegate void Del();
        public void Ex1()
        {
            Del o2 = delegate () { }; // объявить можно, только указав делегат. var, object, delegate - нельзя
            //object o3 = delegate() { return 0; };
            //Delegate d = delegate() { return 0; };
            //var d = delegate() { return 0; };
            //dynamic d = delegate() { return 0; };
        }

        int Sum(int a, int b) => a + b;
        void InterVoid(int a) => Console.WriteLine(a);

        delegate int Del1();
        delegate int Del2(int a);

        public void Ex2()
        {
            var res1 = Sum(1, 2);
            Del1 del1 = delegate() { return 5; };
            InterVoid(del1());

            Print prnt = delegate (int val)
            {
                Console.WriteLine("Anonymous method: {0}", val);
            };

            Foo1(prnt);

            Foo2((x) => { return x * 2; });
            Foo2(x => x * 2);
        }

        private void Foo1(Print print) // передаётся делегат
        {
            print(100);
        }

        private void Foo2(Del2 del) // передаётся делегат
        {
            var res1 = del(11);
            var res2 = del.Invoke(22);
        }

        public void TestFunc()
        {
            var t = 0;
            Func<int, int> f = x => 
            {
                t += x;
                return t;
            };
            var a1 = f(1); // 1
            var a2 = f(2); // 3
            var a3 = f(3); // 6

            t = 1;
            var a4 = f(1); // 2
            var a5 = f(2); // 4
            var a6 = f(3); // 7
        }

        //class DelDerived : Delegate // нельзя наследовать, т.к. Delegete - абстрактный класс
        //{
        //}

        #region COMPARE DELEGATES
        public delegate void Delegate1();
        public delegate void Delegate2();
        public void CompareDelegates()
        {
            Delegate1 d = null;
            Delegate2 e;
            Delegate f = null;
            // Compile-time error.
            //Console.WriteLine(d == e);

            // OK at compile-time. False if the run-time type of f is not the same as that of d
            var result1 = (Delegate)d == f;
            bool result2 = null == null; // true
        }
        #endregion

        #region instance static method
        // Declare a delegate
        delegate void Del3();
        class SampleClass
        {
            public void InstanceMethod()
            {
                Console.WriteLine("A message from the instance method.");
            }

            static public void StaticMethod()
            {
                Console.WriteLine("A message from the static method.");
            }
        }

        public void InstanceStaticMethod()
        {
            var sc = new SampleClass();

            // Map the delegate to the instance method:
            Del3 d = sc.InstanceMethod;
            d();

            // Map to the static method:
            d = SampleClass.StaticMethod;
            d();
        }
        #endregion
    }
}