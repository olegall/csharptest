using System;
using System.Collections.Generic;
using static System.Math; // используем класс, а не неймспейс. поэтому static

namespace ConsoleApp1
{
    #region Namespace
    namespace Namespace2     // можно вкладывать
    {
    }

    namespace Namespace2     // можно дублировать
    {
    }

    namespace Namespace2.V2  // можно именовато через точку
    {
    }

    //namespace Namespace2.1  // цифру после точки - нельзя
    //{
    //}
    #endregion

    public class Keywords
    {
        public Keywords()
        {
            int readonlyArgument = 44;
            InArgExample(readonlyArgument);
        }

        #region As
        public void As()
        {
            double? d1 = 1.1;
            int? null1 = d1 as int?; // null, потому что int? не инициализирован и по дефолту null
            double? res1 = d1 as double?;

            int? i1 = 0;
            double? null2 = i1 as double?; // null, потому что double? не инициализирован и по дефолту null
            // d1 as int; // ошибка
            // d1 as null; // ошибка

            double d2 = 2.2;
            int res_2 = (int)(d2); // 2 - потеря точности

            double d3 = 3.3;
            int res_3 = Convert.ToInt32(d3); // 3 - потеря точности

            string str = "str";
            object res_str = str as object;
            // object as str; // нельзя

            string res_null = new object() as string;
            //new object() as ""; // обязательно тип

            IEnumerable<int> numbers = new[] { 10, 20, 30 };
            IList<int> res_list = numbers as IList<int>;

            // 1 as int; // д.б. ссылочный тип или nullable int
        }
        #endregion

        #region Checked
        public void Checked()
        {
            int overflowValue = 1;
            int res_minus2147483648 = int.MaxValue + overflowValue; // переполнилось
            // int.MaxValue + 1; // ошибка на этапе компиляции. прямо 1 нельзя

            // checked(int.MaxValue + overflowValue); // просто нельзя. checked вовращает int. это как просто написать число

            //var res1 = checked(int.MaxValue + overflowValue); // OverflowException

            checked
            {
                //var res2 = int.MaxValue + overflowValue; // OverflowException
            } 
        }
        #endregion

        #region Unchecked
        public void Unchecked()
        {
            int overflowValue = 1;

            // эксепшна нигде нет. с checked - есть

            unchecked
            {
                int res1 = int.MaxValue + overflowValue;
            }

            // эквивалентно
            int res2 = unchecked(int.MaxValue + overflowValue);
            unchecked
            {
                int res3 = int.MaxValue + overflowValue;
            }

            int res4 = int.MaxValue + overflowValue;
        }
        #endregion

        #region Default
        public void Default()
        {
            var res_0 = default(int);
            var res_null = default(object);
            var res2_null = default(string);
            DefaultOf<double>();
        }

        private void DefaultOf<T>()
        {
            var res_0 = default(T);
        }
        #endregion

        #region Enum
        public enum Season
        {
            Spring,
            Summer,
            Autumn,
            Winter
        }

        [Flags]
        public enum Bits : byte
        {
            _1,
            _2,
            _3,
            _4,
            _5,
            _6,
            _7,
            _8,
            _9, // лишние биты не приводят к ошибке!
            _10
        }

        public enum Enum1
        {
            Field1 = 1,
            Field2,
            Field3 = Field1 + Field2
        }


        public void Enum()
        {
            Season result_Spring = Season.Spring;
            int res_zero = (int)Season.Spring;

            Season res1_Summer = (Season)1;
            Season res2_Summer = (Season)Season.Summer;
            Season res3_Summer = (Season)(Season)(Season)Season.Summer;

            var res_9 = (byte)Bits._10;

            var res_3 = (int)Enum1.Field3;

            Enum a = null;
            //Enum res_a = new Enum();

            // внутри метода нельзя, т.к. тип. Такой же эффект - если объявить класс
            //enum Season
            //{
            //    Spring,
            //    Summer,
            //    Autumn,
            //    Winter
            //}
        }


        #endregion

        #region Is
        public void Is()
        { 
            int i = 27;
            object iBoxed = i;
            var true1 = iBoxed is int;
            var false1 = iBoxed is long;

            int? a = 42;
            var true2 = a is int valueOfA; // нигде не объявлена
            var true3 = a is int;
            var true4 = a is object;
            var false2 = a is double;
        }

        public void Is2()
        {
            int i = 23;
            object iBoxed = i;
            int? jNullable = 7;
            if (iBoxed is int a && jNullable is int b)
            {
                //var a1 = iBoxed + jNullable; // ошибка. здесь ещё типы object и int?
                var a2 = iBoxed.GetType();
                var a3 = jNullable.GetType();
                var a4 = a.GetType();
                var a5 = b.GetType();
                var a6 = a + b;  // 30
            }
        }
        #endregion

        #region New
        public class BaseC
        {
            public int x = 55; // public обязательно

            public virtual void Foo()
            {
                Console.WriteLine("BaseC Foo");
            }
            
            //public virtual void Foo2()
            //{
            //    Console.WriteLine("BaseC Foo2");
            //}
        }

        public class DerivedC : BaseC
        {
            // Hide field 'x'.
            // если убрать new, будет предупреждение, эффект останется
            public new int x = 100;

            public override void Foo()
            //public void Foo()
            {
                Console.WriteLine("DerivedC Foo");
            }
        }

        public void New1()
        {
            BaseC baseC = new BaseC();
            DerivedC derivedC = new DerivedC();
            // Display the hidden value of x:
            Console.WriteLine(baseC.x);
            // Display the new value of x:
            Console.WriteLine(derivedC.x);
            baseC.Foo();
            derivedC.Foo();
            
            baseC = new DerivedC();
            Console.WriteLine(baseC.x);
            Console.WriteLine(derivedC.x);
            baseC.Foo();
            derivedC.Foo();
        }
        #endregion

        #region Params
        public void Params()
        {
            // можно без params
            FooParams(new string[] { "A", "B", "C" });

            // необходимо params
            FooParams("A", "B", "C");

            // можно без аргументов. эквивалентно
            FooParams();
            FooParams(new string[0]);
        }

        private void FooParams(params string[] lines) { }
        //private void FooParams2(params string line) {} // нельзя не массив
        #endregion

        #region Switch
        static bool IsFormat(int value)
        {
            switch (value)
            {
                case 0:
                case 1:
                {
                    return true;
                }
                default:
                {
                    return false;
                }
            }
        }
        #endregion

        #region Yield
        public IEnumerable<string> GetStrings()
        {
            yield return "a";
            yield return "b";
            yield return "c";
        }

        public IEnumerable<char> GetLetters()
        {
            yield return 'A';
            yield break;
            yield return 'B';
        }
        #endregion

        #region IMPLICIT EXPLICIT OPERATOR
        public class Digit
        {
            private readonly byte digit;

            // м.б. конструктор
            public Digit()
            {
            }

            public Digit(byte digit)
            {
                if (digit > 9)
                    throw new ArgumentOutOfRangeException(nameof(digit), "Digit cannot be greater than nine.");

                this.digit = digit;
            }

            // д.б. формат public static implicit|explicit operator
            public static implicit operator byte(Digit d) => d.digit; // объявляем для дальнейшего использования

                                            // при касте к Digit  получаем объект Digit
                                                                  // Cработает конструктор public Digit(byte digit).
            public static explicit operator Digit(byte b) =>      new Digit(b); // объявляем для дальнейшего использования.

                                                            // Cработает конструктор public Digit()
            //public static explicit operator Digit(int a) => new Digit();

            
        }

        public void ImplicitExplicit()
        {
            byte res_1 = new Digit(1); // implicit. output: 7. Объект Digit присваиваем байту

                          // explicit
            Digit digit = (Digit)2; // кастим 5 к Digit. 

            // если раскомментировать оба public static explicit operator Digit(byte b) =>, public static explicit operator Digit(int a) =>
        }
        #endregion

        #region OPERATOR
        public struct Fraction
        {
            private readonly int num;
            private readonly int den;

            public Fraction(int numerator, int denominator)
            {
                num = numerator;
                den = denominator;
            }

            public static Fraction operator +(Fraction a) => a;

            // везде д.б. тип Fraction, т.к. перегружаем внутри типа
            public static Fraction operator -(Fraction a) => new Fraction(-a.num, a.den);

            public static Fraction operator +(Fraction a, Fraction b) => new Fraction(a.num + b.num, a.den + b.den);
        }

        public void Operator()
        {
            var a = new Fraction(4, 5);
            var b = new Fraction(1, 2);

            var res1_4_5 = +a;   // 4 5
            var res2_4_5 = a;    // 4 5
            var res3_4_minus5 = -a; // 4 -5
            var res4_7_10 = a + b; // 5 7
        }
        #endregion

        #region THIS1
        class Employee
        {
            private string name;

            public Employee(string name)
            {
                this.name = name;
            }

            public Employee Get()
            {
                return this; // возвращает то же, что new Employee("Tom")
            }
        }

        public void This1()
        {
            var e1 = new Employee("Tom").Get();
        }
        #endregion

        #region THIS2
        class SampleCollection<T>
        {
            // Declare an array to store the data elements.
            private T[] arr = new T[100];

            // Define the indexer to allow client code to use [] notation.
            public T this[int i]
            {
                get { return arr[i]; }
                set { arr[i] = value; }
            }
        }

        string[] strs = new string[] { "1", "2" };

        public void This2()
        {
            var stringCollection = new SampleCollection<string>();
            stringCollection[0] = "Hello, World";
            var a1 = stringCollection[0];
        }
        #endregion

        #region USING STATIC
        public void UsingStatic()
        {
            var a1 = Math.PI;
            var a2 = PI; // доступна без Math. засчёт using static
        }
        #endregion

        #region OUT REF IN
        public void OutArgExample(out int number) // out arguments must be modified by the called method
        {
            number = 44; // обязательно присвоить. ошибка
        }

        // что происходит под капотом? работает упаковка и распаковка?
        // https://stackoverflow.com/questions/53317484/c-sharp-pass-by-ref-under-the-hood-is-it-really-pass-by-reference
        public void RefArgExample(ref int number) // ref arguments may be modified
        {
            number = 10; // не обязательно присваивать
        }

        class CS0663_Example
        {
            // Compiler error CS0663: "Cannot define overloaded methods that differ only on ref and out".
            public void SampleMethod(out int i) { i = 0; }
            //public void SampleMethod(ref int i) { }
        }

        class RefOverloadExample
        {
            public void SampleMethod(int i) { }
            public void SampleMethod(ref int i) { }
        }

        class OutOverloadExample
        {
            public void SampleMethod(int i) { }
            public void SampleMethod(out int i) { i = 0; }
        }

        class Product
        {
            public string Name { get; set; }
            public int Id { get; set; }

            public Product(string name, int id)
            {
                Name = name;
                Id = id;
            }
        }

        private static void ChangeByReference(ref Product itemRef) // Какой смысл так делать, если и так ссылочный тип
        {
            // Change the address that is stored in the itemRef parameter.
            itemRef = new Product("Stapler", 99999);

            // You can change the value of one of the properties of
            // itemRef. The change happens to item in Main as well.
            itemRef.Id = 12345;
        }

        public void InArgExample(in int number)
        {
            // Uncomment the following line to see error CS8331
            //number = 19; // доступна только для чтения
        }
        #endregion
    }
}