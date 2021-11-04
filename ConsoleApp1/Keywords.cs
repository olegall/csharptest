using System;
using System.Collections.Generic;
using static System.Math;

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
            // почему null?
            double? d1 = 1234.7;
            int? a1 = d1 as int?;

            double d2 = 21.34;
            int res1 = (int)(d2);

            double d3 = 22.34;
            int res2 = Convert.ToInt32(d3);

            int? a3 = 1234.7 as int?;

            string str = "str";
            object obj1 = str as object;

            object obj2 = new object();
            string str2 = obj2 as string;

            IEnumerable<int> numbers = new[] { 10, 20, 30 };
            IList<int> indexable = numbers as IList<int>;

            //int a4 = 1 as int;
        }
        #endregion

        #region Checked
        public void Checked()
        {
            int ten = 10;
            int i2 = 2147483647 + ten; // переполнилось

            //int i3 = 2147483647 + 10; // ошибка компиляции

            // checked(2147483647 + ten); // просто нельзя. вовращает int. это как просто написать число

            var a1 = checked(2147483647 + ten); // OverflowException

            checked
            {
                var a2 = 2147483647 + ten; // OverflowException
            } 
        }
        #endregion

        #region Default
        private void DisplayDefaultOf<T>()
        {
            var val = default(T);
        }

        public void Default()
        {
            var a1 = default(int);
            var a2 = default(object);
            DisplayDefaultOf<double>();
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
            Field3 = Field1 * Field2
        }


        public void Enum()
        {
            Season spring = Season.Spring;
            int springVal = (int)Season.Spring;

            Season summer1 = (Season)1;
            Season summer2 = (Season)Season.Summer;
            Season summer3 = (Season)(Season)(Season)Season.Summer;

            var bits = (byte)Bits._10;

            var enum1 = (int)Enum1.Field3;

            Enum a;
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
            var a1 = iBoxed is int;
            var a2 = iBoxed is long;

            int? a = 42;
            var a3 = a is int valueOfA;
            var a4 = a is int;
            var a5 = a is object;
            var a6 = a is double;


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
                Console.WriteLine(a + b);  // output 30
            }
        }
        #endregion

        #region New
        public class BaseC
        {
            public int x = 55;
            // public обязательно

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
        private void FooParams(params string[] lines)
        {
        }

        // нельзя не массив
        //private void FooParams2(params string line)
        //{
        //}

        public void Params()
        {
            // можно без params
            FooParams(new string[] { "1", "2", "3" });

            // необходимо params
            FooParams("A", "B", "C");

            // можно без аргументов. эквивалентно
            FooParams();
            FooParams(new string[0]);
        }
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

        #region Unchecked
        public void Unchecked()
        {
            unchecked
            {
                int a1 = 2147483647 + 10;
            }
            int a2 = unchecked(2147483647 + 10);

            int ten = 10;

            // эквивалентно
            unchecked
            {
                int a3 = 2147483647 + ten;
            }
            int a4 = 2147483647 + ten;
        }
        #endregion

        #region Yield
        public static IEnumerable<string> GetStrings()
        {
            yield return "Hello";
            //Console.WriteLine("Borland");
            yield return "World";
            yield return "1";
            yield return "2";
            yield return "3";
        }

        public static IEnumerable<char> GetLetters()
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
                {
                    throw new ArgumentOutOfRangeException(nameof(digit), "Digit cannot be greater than nine.");
                }
                this.digit = digit;
            }

            // д.б. формат public static implicit|explicit operator
            public static implicit operator byte(Digit d) => d.digit;
            public static explicit operator Digit(byte b) => new Digit(b);

            public override string ToString() => $"{digit}";
        }

        public void ImplicitExplicitOperator()
        {
            var d = new Digit(7);
            byte number = d; // implicit. output: 7
            Digit digit = (Digit)number; // explicit. output: 7
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

            public static Fraction operator +(Fraction a, Fraction b) => new Fraction(a.num * b.den, 
                                                                                      a.num + b.den);
        }

        public void Operator()
        {
            var a = new Fraction(5, 4);
            var b = new Fraction(1, 2);

            var a1 = +a;   // 5 4
            var a2 = a;    // 5 4
            var a3 = -a;   // -5 4
            var a4 = a + b; // 10 7
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
                return this;
            }
        }

        public void This1()
        {
            Employee E1 = new Employee("Mingda Pan").Get();
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

        public void RefArgExample(ref int number) // ref arguments may be modified
        {
            number = 10; // не обязательно присваивать
        }

        class CS0663_Example
        {
            // Compiler error CS0663: "Cannot define overloaded
            // methods that differ only on ref and out".
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
            public Product(string name, int newID)
            {
                ItemName = name;
                ItemID = newID;
            }

            public string ItemName { get; set; }
            public int ItemID { get; set; }
        }

        /// <summary>
        /// Какой смысл так делать, если и так ссылочный тип
        /// </summary>
        /// <param name="itemRef"></param>
        private static void ChangeByReference(ref Product itemRef)
        {
            // Change the address that is stored in the itemRef parameter.
            itemRef = new Product("Stapler", 99999);

            // You can change the value of one of the properties of
            // itemRef. The change happens to item in Main as well.
            itemRef.ItemID = 12345;
        }

        public void InArgExample(/*in*/ int number) // возможность "Ссылки только для чтения недоступна для в C# 7.0. Используйте версию 7.2 или более позднюю"
        {
            // Uncomment the following line to see error CS8331
            //number = 19;
        }
        #endregion
    }
}