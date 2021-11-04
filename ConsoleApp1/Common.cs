using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class MyClass 
    {
        public int Num;
    }

    class Common
    {
        public void Main() 
        {
            //var obj = null; // нельзя - не типизирована
            object obj = null;

            object a1 = (string)null;


            #region Типы данных
            DateTime time = new DateTime();
            /* оператор == будет передавать свои операнды в разные допустимые типы,
             * чтобы получить общий тип, который он может затем сравнить */
            if (time == null)
            {
                /* do something */
            }
            #endregion
        }

        // нельзя в классе, структуре и интерфейсе
        //try 
        //{
        //}
        //catch 
        //{
        //}

        // Вместо IEnumerable<int>
        //List<Task<int[]>> tasks = new List<Task<int[]>>();

        // Преобразование объекта в массив int. Ещё способы
        //IEnumerable<int> a2 = new object() as IEnumerable<int>;

        public void Ex1()
        {
            int i, j, s = 0;
            for (i = 0, j = 6; i < j; ++i, --j)
            {
                s += i;
            }
            Console.WriteLine(s);
        }

        public void Ex2()
        {
            //int[][] k1 = new int[2][3];
            int[,] k2 = new int[2, 3];
            //int k3[][] = new int[2][3];
            int[][] k4 = new int[2][];
            //int k5[,] = new int[2, 3];
        }

        public void Ex3()
        {
            string @string = "ABC";
            //Console.WriteLine(string);
            Console.WriteLine(@string);
        }

        class Ex4_
        {
        }
        // метод нельзя называть как класс
        public void Ex4()
        {
        }

        public void Ex5()
        {
            double[,] myDoubles = new double[1, 2];
            myDoubles[0, 1] = 1;

            // нельзя
            //double[,] myDoubles = new double[,];

            //double[][] myDoubles2 = new double[0][1];
        }

        public void Nullable()
        {
            // An array of a nullable t
            int?[] arr = new int?[10];
        }
                                                                                                                                                    
        public void Ex6()
        {
            object iBoxed = null;
            //var a1 = iBoxed.GetType();
            int i = 23;
            iBoxed = i;
            var a2 = iBoxed.GetType();
        }

        public void Ex7()
        {
            object iBoxed;
            //var a1 = iBoxed.GetType(); // ошибка. чтобы получить тип надо присвоить null
        }

        public void Ex8()
        {
            //var obj = null; // нельзя - не типизирована
            object obj = null;
        }

        #region PROPERTIES
        int Prop1 // свойства могут не иметь геттера
        {
            set
            {
                value = 1; // что тут происходит?
            }
        }

        int Prop2 // свойства могут не иметь сеттера
        {
            get
            {
                return 1;
            }
        }

        static private int staticField; 

        int Prop3 // м.б. поле static, свойство не static
        {
            set
            {
                staticField = value;
            }

            get
            {
                return staticField;
            }
        }

        static int Prop4 // м.б. поле, свойство static
        {
            set
            {
                staticField = value;
            }

            get
            {
                return staticField;
            }
        }

        private int field;
        static int Prop5
        {
            set
            {
                //field = value; // для нестатического поля, метода или св-ва требуется ссылка на объект
            }

            get
            {
                //return field; // для нестатического поля, метода или св-ва требуется ссылка на объект
                return 0;
            }
        }

        //public abstract int Prop6
        //{
        //get // не может объявить тело, потомучто помечен как abstract
        //{
        //    return 0;
        //}
        //}

        public int[] Prop7 // может иметь тип массива
        { 
            get
            {
                return new[]{0};
            }
        }
        #endregion

        #region КОВАРИАНТНОСТЬ КОНРВАРИАНТНОСТЬ

        static object GetObject() { return null; }
        static void SetObject(object obj) { }

        static string GetString() { return ""; }
        static void SetString(string str) { }

        public void CovarianceContravariance()
        {
            object[] array = new String[10];
            // The following statement produces a run-time exception.  
            array[0] = 10;

            // Covariance. A delegate specifies a return type as object,  
            // but you can assign a method that returns a string.  
            Func<object> del = GetString;

            // Contravariance. A delegate specifies a parameter type as string,  
            // but you can assign a method that takes an object.  
            Action<string> del2 = SetObject;
        }

        class Account
        {
            public virtual void DoTransfer(int sum)
            {
            }
        }
        
        class DepositAccount : Account
        {
            public override void DoTransfer(int sum)
            {
            }
        }

        interface IBank<out T>
        {
            T CreateAccount(int sum);
        }

        class Bank<T> : IBank<T> where T : Account, new()
        {
            public T CreateAccount(int sum)
            {
                T acc = new T();
                return acc;
            }
        }


        public void CovarianceContravarianceMetanit()
        {
            IBank<Account> ordinaryBank = new Bank<DepositAccount>(); // д.б. out T

            IBank<DepositAccount> depositBank = new Bank<DepositAccount>();
            IBank<Account> ordinaryBank3 = depositBank; // д.б. out T

            //IBank<DepositAccount> depositBank2 = new Bank<Account>(); // нельзя преобразовать тип
        }
        #endregion

        #region КОВАРИАНТНОСТЬ МОЯ
        class Acc
        {
        }
        class DepositAcc : Acc
        {
        }
        interface IBankVoid<out T>
        {
            void CreateAccount(int sum);
        }
        class BankNoRestrictions<T> : IBankVoid<T>
        {
            public void CreateAccount(int sum)
            {
            }
        }
        public void CovarianceMy()
        {
            //DepositAccount da = new Account();
            Acc ad = new DepositAcc(); // базовый класс видит всех наследников
            
            // сигнатуры дженерик классов и классы, которыми типизируем - разные
            IBankVoid<Acc> ordinaryBank2 = new BankNoRestrictions<DepositAcc>(); // д.б. out T
        }
        #endregion

        #region КОНТРВАРИАНТНОСТЬ МОЯ
        interface IBankVoidContr<in T>
        {
            void CreateAccount(int sum);
        }
        class BankNoRestrictionsContr<T> : IBankVoidContr<T>
        {
            public void CreateAccount(int sum)
            {
            }
        }
        public void ContrvarianceMy()
        {
            //DepositAccount da = new Account();
            Acc ad = new DepositAcc(); // базовый класс видит всех наследников

            // сигнатуры дженерик классов и классы, которыми типизируем - разные
            IBankVoidContr<DepositAcc> ordinaryBank2 = new BankNoRestrictionsContr<Acc>(); // д.б. in T
        }
        #endregion

        #region VARIANCE CONTRAVARIANCE MICROSOFT
        class Base { }
        class Derived : Base { }
        
        void ConvarianceMicrosoft()
        {
            IEnumerable<Derived> d = new List<Derived>(); // IEnumerable уже ковариантный
            IEnumerable<Base> b = d;

            IEnumerable<Base> b2 = new List<Base>(); // IEnumerable уже ковариантный
            // IEnumerable<Derived> d2 = b2; // не удаётся преобразовать
        }
        #endregion
    }
}
