using System;

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
        public void Ex1()
        {
            // нельзя
            //public delegate void Print(int value);

            Print prnt = delegate (int val)
            {
                Console.WriteLine("Anonymous method: {0}", val);
            };

            Print prnt2 = delegate (int val)
            {
                Console.WriteLine("Anonymous method: {0}", val);
                Console.WriteLine("Anonymous method: {0}", val);
            };
            prnt(100);
            prnt(200);
        }

        public void Ex2()
        {
            //object o3 = delegate () { return 0; };
            //Delegate d = delegate () { return 0; };
        }

        int Sum(int a, int b) => a + b;
        void InterVoid(int a) => Console.WriteLine(a);

        delegate int Del1();
        delegate int Del2(int a);

        public void Ex3()
        {
            var res1 = Sum(1, 2);
            Del1 del1 = delegate() { return 5; };
            InterVoid(del1());

            Print prnt = delegate (int val)
            {
                Console.WriteLine("Anonymous method: {0}", val);
            };

            Foo1(prnt);

            Foo2((x)=> { return x * 2; });
            Foo2(x => x * 2);
        }

        private void Foo1(Print print)
        {
            print(100);
        }

        private void Foo2(Del2 del)
        {
            var res1 = del(11);
            var res2 = del.Invoke(22);
        }

        public void TestFunc()
        {
            var t = 0;
            Func<int, int> f = x => { t += x; return t; };
            t = 1;
            var a1 = f(1); // 2
            var a2 = f(2); // 4
            var a3 = f(3); // 7
        }
    }
}