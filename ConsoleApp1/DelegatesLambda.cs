using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    /*
    async delegate
    
    передать Action в качестве параметра
    Foo(Action a) - видимо передаётся тело метода, анонимный метод
    */

    // и при объявлении, и при вызове используется слово delegate
    // var a1 = delegate { }; // нельзя
    //delegate void a1 = delegate { }; // нельзя

    // функция с делегатом в качестве параметра

    class DelegatesLambda
    {
        delegate void MessageDelegate(string message); // можно модификаторы доступа public, private, т.к. делегат - это тип

        delegate void Del1(); // объявляем тип делегата?
        
        delegate string Del2();

        public void Main()
        {
            // delegate добавляется циклически, однако параметр i передаётся по ссылке
            List<Del1> delegates = new List<Del1>();
            for (int i = 0; i < 3; i++)
            {
                // код в .Add, нет параметров и ничего не возвращает. Соответствует Сигнатуре делегата Printer
                // почему так можно добавлять? это не список. видимо так можно, т.к. соответсвует формату объявлённого делегата
                delegates.Add(delegate // этот блок внутри Add срабатывает при каждом вызове del() на последней итерации этого цикла
                { 
                    Console.WriteLine(i);
                    Console.WriteLine(i.GetType());
                }); // напечатано ещё ничего не будет - потому что экземпляры делегата, только добавлены, но не вызваны. в target у delegates везде 3-ки. Почему?

                //delegates.Add(new Del1()); // Printer не содержит конструктор, который принимает аргументы 0. Т.к. это не класс, а делегат
            }

            foreach (var del in delegates)
            {
                del(); // будет напечатано, т.к. вызываются экземпляры делегата
                // дёрнется предыдущий цикл на последней итерации. Как так?
            }
            // будет выведено 3, 3, 3. Почему?

            List<Del2> delegates2 = new List<Del2>();
            delegates2.Add(delegate { return ""; }); // return "" - т.к. delegate string Printer2(); возвращает string

            Action greet = delegate { Console.WriteLine("Hello!"); };
            greet();
            greet.Invoke(); // эквивалентно greet()
            //greet.BeginInvoke

            Action greet2; // можно так объявить, потом присвоить. Уже объявлен public delegate void Action(); в mscorlib.dll. Здесь готовим экземпляр
            greet2 = delegate { Console.WriteLine("Hello! Action greet2;"); };
            greet2();

            // msdn
            Action<string> stringAction = str => { var a = str; };
            Action<string> stringAction2 = str => { var a = str; };
            Action<string> stringAction3 = str => { };
            //Action<string> stringAction4 = str => ();
            //Action<string> stringAction5 = () => {};
            
            // делегат без параметров и ничего не возвращающий
            Del1 del1 = () => 
            {
            };
            del1();
            
            Action<object> objectAction = param => 
            { 
                var a = param; 
            }; // <object> - исключение    <string> - исключения не будет
            objectAction("aaa");

            // Valid due to implicit reference conversion of objectAction to Action<string>, but may fail at runtime.
            // System.ArgumentException: "Делегаты должны принадлежать к одному типу."
            // Action<string> combination = stringAction + objectAction; // ошибка в рантайме
            // var combinationVar = stringAction + objectAction;
        }

        public void Ex1()
        {
            Del1 o2 = delegate () { }; // объявить можно, только указав тип делегата. var, object, dynamic, delegate - нельзя. Видимо потому что анонимный тип
            o2();
            
            //object del1 = delegate() { };
            //Delegate del2 = delegate() { };
            //var del3 = delegate() { };
            //dynamic del4 = delegate() { };
            //Delegate del5 = new Delegate(); // нельзя создать экземпляр, т.к. абстрактный класс

            // все объявления не являются типом делегата
        }

        private int Sum(int a, int b) => a + b;

        private delegate int Del3();

        private void InterVoid(int a) => Console.WriteLine(a);

        // как проинициализировать делегат?
        public delegate void Del4(int value); // можно объявлять в классе, вне класса, как обычный класс, т.к. делегат - это тип. в методе - нельзя

        private delegate int Del5(int a);

        public void Ex2()
        {
            var res1 = Sum(1, 2);

            Del3 del1 = delegate() { return 5; };

            //InterVoid(del1()); // параметр InterVoid не делегат, а идёт делегат
            //InterVoid(del1); // нельзя

            Del4 print = delegate (int val)
            {
                Console.WriteLine("Anonymous method: {0}", val);
            };

            TakeDel(print);
            //TakeDel(print(1)); // Del4 возвращает void, пытаемся передать void, а параметр - делегат

            TakeDel2(x => x);
            //TakeDel2(x => x * 2);
            //TakeDel2(x => { return x * 2; });
            //TakeDel2((x) => { return x * 2; });
        }

        private void TakeDel(Del4 del) // передаётся делегат
        {
            del(100);
        }

        private void TakeDel2(Del5 del) // передаётся делегат. принимает фактически метод
        {
            var res_1 = del(1);
            var res_2 = del.Invoke(2);
        }

        public void TestFunc()
        {
            var t = 0;
            Func<int, int> f =      x => { t += x; return t; };
            var res1 = f(1); // 1
            var res2 = f(2); // 3
            var res3 = f(3); // 6
        }

        //class DelDerived : Delegate // нельзя наследовать, т.к. Delegete - абстрактный класс
        //{
        //}

        #region COMPARE DELEGATES
        delegate void Delegate1();

        delegate void Delegate2();

        delegate int Delegate3();

        public void CompareDelegates()
        {
            Delegate1 d1 = null;
            Delegate2 d2 = null;
            Delegate3 d3 = null; // почему подчёркнуто, а d1, d2 нет? т.к. int возвращает?
            
            Delegate d_mscorlib = null;
            Delegate d_mscorlib2 = null;

            var res1_true = d1 == d1; // Compile-time error.
            //var res2 = d1 == d2;
            var res2_null = (Delegate)d1;
            var res3_null = (Delegate1)d1;
            //var res5 = (Delegate2)d1;
            var res6_null = (Delegate)d1 == d2; // нельзя сравнивать. сигнатуры одинаковые, а сами типы разные. почему?    без каста нельзя. почему? - результат каста будет null
            //var res7_null = d1 == d2; // у объявленных типов делегатов нет реализованного оператора сравнения ==, а у Delegate в mscorlib - есть
            var res8_true = d_mscorlib == d_mscorlib2;
            // OK at compile-time. False if the run-time type of f is not the same as that of d
            var res9_true = d1 == d_mscorlib; // true
        }
        #endregion

        #region instance static method
        // Declare a delegate
        
        delegate void Del6();
        
        class Class
        {
            public void InstanceMethod() { }

            public static void StaticMethod() { }
        }

        public void InstanceStaticMethod()
        {
            var c = new Class();

            Del6 del = c.InstanceMethod; // Map the delegate to the instance method:
            del();

            del = Class.StaticMethod; // Map to the static method:. Перекрываем делегат. Не нужен новый
            del();
        }
        #endregion
    }
}