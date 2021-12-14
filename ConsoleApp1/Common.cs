using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // var vs object vs dynamic
    class Common
    {
        class Compare1 { }
        class Compare2 { }

        public void Main()
        {
            //var obj = null; // нельзя - не типизирована
            object obj1 = null;
            object obj2 = (string)null; 
            object obj3;

            #region Типы данных
            DateTime time = new DateTime();
            /* оператор == будет передавать свои операнды в разные допустимые типы, чтобы получить общий тип, который он может затем сравнить */
            var res1 = time != null; // true
            #endregion

            //var obj = null; // нельзя - не типизирована
            object obj = null;

            bool res2 = null == null; // true

            //bool res3 = Compare2 == Compare2;

            GetInt(); // можно вызвать без присваивания метод, который что-то возвращает

            //msdn delegate T MyDelegate<T>() where T : new();
        }

        private int GetInt() 
        {
            return 1;
        }

        public void CompareTypes()
        {
            //bool res1 = Compare2 == Compare2;
            //var c1 = new Compare1();
            //var c2 = new Compare2();
            //bool res2 = new Compare1() == new Compare2();
            //bool res3 = c1 == c2;
        }

        // нельзя в классе, структуре и интерфейсе, т.к. такое оборачивание - только в методах
        //try 
        //{
        //}
        //catch 
        //{
        //}

        // Вместо IEnumerable<int>
        List<Task<int[]>> tasks = new List<Task<int[]>>();

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

        // все способы инициализации массива?
        public void ArrayInit()
        {
            //int[][] k1 = new int[2][3];
            int[,] k2 = new int[2, 3];
            //int k3[][] = new int[2][3];
            int[][] k4 = new int[2][];
            //int k5[,] = new int[2, 3];
            var k6 = new int[2, 3];

            double[,] myDoubles = new double[1, 2];
            myDoubles[0, 1] = 1;

            // нельзя
            //double[,] myDoubles = new double[,];

            //double[][] myDoubles2 = new double[0][1];
        }

        public void Ex3()
        {
            string @str = "abc"; // собака только впереди. в других местах - ошибка
            var a1 = str;
            var a2 = @str;
        }

        class Ex4_
        {
        }
        // метод нельзя называть как класс
        public void Ex4()
        {
        }

        public void Nullable() // ещё примеры nullable
        {
            // An array of a nullable t
            int?[] arr = new int?[10];
        }
                                                                                                                                                    
        public void Ex6()
        {
            object iBoxed = new object(); // если не присвоить - null reference exception
            var a1 = iBoxed.GetType(); // Object
            int i = 23;
            iBoxed = i;
            var a2 = iBoxed.GetType(); // Int32
        }

        #region PROPERTIES
        public int Prop1 // свойства могут не иметь геттера
        {
            set
            {
                value = 1; // что тут происходит? скорее всего эта строка бессмысленна, раз нет геттера
            }
        }

        public int Prop2 // свойства могут не иметь сеттера
        {
            get
            {
                return 1;
            }
        }

        private int field; // а экземплярное поле, статическое свойство быть не может
        private static int staticField; // private static можно менять местами

        int Prop3 // м.б. поле static, свойство не static
        {
            set
            {
                field = value; // для нестатического поля, метода или св-ва требуется ссылка на объект
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
                //field = value; // для нестатического поля, метода или св-ва требуется ссылка на объект. Т.к. св-во static - накладывается ограничение
                staticField = value;
            }

            get
            {
                //return field; // для нестатического поля, метода или св-ва требуется ссылка на объект
                return staticField;
                //return 0;
            }
        }

        //public abstract int Prop6 // может быть абстрактное свойство
        //{
        //    get // не может объявить тело, потому что помечен как abstract
        //    {
        //        return 0;
        //    }
        //}

        public int[] Prop7 // может иметь тип массива
        { 
            get
            {
                return new[]{0};
            }
        }
        
        //public int Prop8 // для свойства или индексатора должен быть указан хотя бы 1 метод доступа
        //{ 
        //}
        #endregion

        #region КОВАРИАНТНОСТЬ КОНРВАРИАНТНОСТЬ

        static object GetObject() 
        { 
            return null; 
        }
        
        static void SetObject(object obj) 
        {
        }

        static string GetString() 
        { 
            return "xxx"; 
        }

        static void SetString(string str)
        {
        }

        public void CovarianceContravariance()
        {
            object[] array = new String[10];
            // The following statement produces a run-time exception.  
            //array[0] = 10; // System.ArrayTypeMismatchException: "Попытка обратиться к элементу, тип которого несовместим с данным массивом."

            // Covariance. A delegate specifies a return type as object, but you can assign a method that returns a string.  
            Func<object> del = GetString; // базовой инициализируется наследником
            object obj = "xxx"; // а так работает

            // Contravariance. A delegate specifies a parameter type as string, but you can assign a method that takes an object.  
            Action<string> del2 = SetObject; // наследник инициализируется базовым
            var str = new object();
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

        //interface IBank<T> // можно так
        //interface IBank<in T> // можно так
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
            IBank<DepositAccount> bankCasting = (IBank<DepositAccount>)ordinaryBank; // только с кастом
            //IBank<DepositAccount> depositBank2 = (IBank<DepositAccount>)new Bank<Account>(); // только с кастом. нельзя наследник инициализировать базовым
        }
        #endregion

        #region КОВАРИАНТНОСТЬ МОЯ
        class Acc
        {
        }

        class DepositAcc : Acc
        {
        }

        interface IBankVoid<out T> // без out - ошибка преобразования
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
        interface IBankVoidContr<in T> // без in - ошибка преобразования
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
            DepositAccount da = (DepositAccount)new Account(); // только с кастом
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