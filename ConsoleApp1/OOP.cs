using System;
using System.Collections.ObjectModel;
using ByteCollection1 = System.Collections.ObjectModel.Collection<byte>;

namespace ConsoleApp1
{
    public class OOP
    {
        private readonly string subcaption;

        public OOP(string subcaption)
        {
            this.subcaption = subcaption;
        }

        // проиллюстрировать копирование объекта по ссылке и их равенство/неравенство после этого

        public class Person
        {
            public string Name { get; set; }
            public Person(string name)
            {
                Name = name;
            }
            public virtual void Display()
            {
                Console.WriteLine(Name);
            }

            /// <summary>
            /// Можно не переопределять
            /// </summary>
            public virtual void NotOverrided()
            {
            }

            /// <summary>
            /// Сокрытие
            /// </summary>
            public void Hided()
            {
            }

            /// <summary>
            /// Сокрытие
            /// </summary>
            public void Hided2()
            {
            }
        }

        public class Employee : Person
        {
            public string Company { get; set; }
            public Employee(string name, string company)
                : base(name)
            {
                Company = company;
            }

            public override void Display()
            {
            }

            public void Hided()
            {
            }

            public new void Hided2()
            {
            }
        }

        public class Animal
        {
            public void Info() { Console.WriteLine("Animal"); }
            public virtual void Say() { Console.WriteLine("Nothing to say"); }
        }

        public class Cat : Animal
        {
            public void Info() { Console.WriteLine("Cat"); }
            // virtual в базовом классе - обязательно
            // override - не обязательно
            public override void Say() { Console.WriteLine("Meow"); }
        }

        public class Dog : Animal
        {
            public void Info() { Console.WriteLine("Dog"); }
            public override void Say() { Console.WriteLine("Woof"); }
        }



        public class A
        {
            public virtual void Foo()
            {
                Console.WriteLine("Class A");
            }
        }
        public class B : A
        {
            public override void Foo()
            {
                Console.WriteLine("Class B");
            }
        }

        #region ABSTRACT
        public abstract class Abstract // можно назвать Abstract
        {
            public Abstract() // сработает, для наследников
            {
            }

            public abstract int GetAreaAbstract(); // нельзя тело, д.б. public

            public virtual int GetAreaOverride() // д.б. тело
            {
                return 0;
            }

            public int FooProp { get; set; } // м.б. свойство

            public abstract int FooPropAbstract { get; set; } // м.б. свойство

            int fooField { get; set; } // м.б. поле

            void Foo() // м.б. метод с реализацией
            {
            }
        }

        public class Square : Abstract
        {
            // д.б. переопределённый GetArea
            public override int GetAreaAbstract() // д.б. public
            {
                return 100;
            }

            public override int GetAreaOverride() // д.б. public
            {
                return 100;
            }

            public override int FooPropAbstract
            {
                get
                {
                    return 0;
                }
                set
                {
                }
            }
        }

        abstract class Abstract2
        {
            abstract public int Foo();
        }

        abstract class Abstract3
        {
            // public int Foo(); // д.б. abstract раз нет тела
        }

        class Abstract4 // д.б. abstract раз есть абстрактный метод
        {
            //abstract public int Foo();
        }

        abstract class Abstract5
        {
        }

        interface I
        {
            void M();
        }

        abstract class C : I
        {
            public abstract void M();
        }

        abstract class DerivaedFromClass : A // абстрактный класс может наследоваться от обычного
        {
        }
        #endregion

        /// <summary>
        /// В ходе выполнения данного кода генерируется исключение при вызове метода Sort()
        /// Выберите одно из решений, реализация которого позволит этому коду отработать
        /// корректно
        /// </summary>
        public class A2: IComparable
        {
            private int id { get; set; }
            public A2(int newID)
            {
                id = newID;
            }

            public int CompareTo(object obj)
            {
                if (obj == null) return 1;

                A2 a2 = obj as A2;
                if (a2 != null)
                    return this.id.CompareTo(a2.id);
                else
                    throw new ArgumentException("Object is not a a2");
            }
        }



        public class Point
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Point(int xVal, int yVal) {
                X = xVal;
                Y = yVal;
            }
        }






        public class Base
        {
            public string className = "Base";
        }

        public class Derived1 : Base
        {
            private string className = "Derived1";
        }

        public class Derived2 : Base
        {
            public string className = "Derived2";
        }



        public abstract class B3
        {
            // private нельзя
            // private virtual void Print()
            
            // protected можно
            //protected virtual void Print()
            
            public virtual void Print()
            {
                Console.WriteLine("This is B3");
            }
        }

        public class A3 : B3
        {
            //public virtual void Print()
            //public new void Print()
            private void Print()
            //public override void Print()
            {
                Console.WriteLine("This is A3");
            }
        }





        public class Car
        {
            public Car()
            {
                Console.WriteLine("The Car constructor invoked");
            }
        }
        public class Bus : Car
        {
            public Bus()
            {
                Console.WriteLine("The Bus constructor invoked");
            }

            public static void Drive()
            {
                Console.WriteLine("The Drive method invoked");
            }
            public void Drive2()
            {
                Console.WriteLine("The Drive method invoked");
            }
        }




   




        public class Person2
        {
        }

        public class Student : Person2
        {
        }

        public class C<T>
        {
            public T x;
        }





        class A5
        {
            private string s;
            public string S {
                get
                {
                    return s;
                }
                set
                {
                    s = value;
                }
            }
            // Уже объявлен как геттер
            //public void get_S()
            //{
            //}
            //public void set_S()
            //{
            //}
        }



        

        public class A6
        {
            public A6() { Console.WriteLine("A created"); }
        }

        public class B6 : A6
        {
            private B6() { Console.WriteLine("B created"); }

            public B6(string parameter)
            {
                Console.WriteLine("B created with parameter: {0}", parameter);
            }
        }

        public class C6 : B6
        {   // base обязательно, если в базовом классе есть конструктор с параметрами
            public C6() : base("par")
            {
                Console.WriteLine("C created");
            }
        }





        public class A7
        {
            
        }
        // базовый класс д.б. public
        public class B7 : A7
        {
        }





        public class Parent
        {
            static Parent() { Console.WriteLine("Parent Type ctor"); }
            public Parent() { Console.WriteLine("Parent Instance ctor"); }
        }

        public class Child : Parent
        {
            public static int field1 = 0;
            static Child() { Console.WriteLine("Child Type ctor"); }
            public Child() { Console.WriteLine("Child Instance ctor"); }
            public static void Foo()
            {
            }
        }




        public class A9
        {
            public virtual void M()
            {
                Console.WriteLine("This is A");
            }
        }

        public class B9 : A9
        {

            //public void M()
            //public virtual void M()
            public new void M()
            //public override void M()
            {
                Console.WriteLine("This is B");
            }
        }



        public class A10
        {
            static A10()
            {
                Console.WriteLine("Static Hello from A");
            }
            public A10()
            {
                Console.WriteLine("Hello from A");
            }
        }

        public class B10
        {
            public static string x = "Hello";
            static B10()
            {
                Console.WriteLine("Static Hello from B");
            }
            public B10()
            {
                Console.WriteLine("Hello from B");
            }
        }





        public class A11
        {
            public A11()
            {
                Console.WriteLine("class A");
            }
        }

        public class B11 : A11
        {
            public B11()
            {
                Console.WriteLine("class B");
            }
        }




        private class A12
        {
            // если конструктор private - не скомпилируется
            public A12()
            {
            }
        }

        private class B12 : A12
        {
            private B12()
            {
            }
        }





        public class A13
        {
        }

        public class B13 : A13
        {
        }




        public class A14
        {
            public void Method()
            {
                Console.WriteLine("MethodA");
            }
        }

        public class B14 : A14
        {
            new public void Method()
            {
                Console.WriteLine("MethodB");
            }
        }

        public class C14 : B14
        {
            new public void Method()
            {
                Console.WriteLine("MethodC");
            }
        }




        public partial class A15
        {
            // сначала сработает конструктор типа
            public A15()
            {
                Console.WriteLine("A created instance ctor");
            }
        }

        partial class A15
        {
            static A15()
            {
                Console.WriteLine("A created static ctor");
            }
        }





        class OuterClass
        {
            private int i;
            protected int j;
            public int k;

            public OuterClass()
            {
                InnerClass nested = new InnerClass(this);
                // ошибка компиляции
                //nested.a = 1;
                //nested.b = 1;
                nested.c = 1;
            }

            class InnerClass
            {
                private int a;
                protected int b;
                public int c;

                public InnerClass(OuterClass outerClass)
                {
                    outerClass.i = 1;
                    outerClass.j = 1;
                    outerClass.k = 1;
                }
            }
        }


        public class A16
        {
            public virtual void GetValue(int a)
            {
                Console.WriteLine("A:GetValue:int a = {0}", a);
            }
        }
        public class B16 : A16
        {
            public override void GetValue(int a)
            {
                Console.WriteLine("B:GetValue:int a = {0}", a);
            }
            public void GetValue(object a)
            {
                Console.WriteLine("B:GetValue:object a = {0}", a);
            }
        }



        #region Ex1
        private class User
        {
            private string name;
            public User(string name)
            {
                this.name = name;
            }

            public string GetName()
            {
                return name;
            }
        }

        private class User_
        {
            public string Name { get; set; }
        }

        public void Ex1()
        {
            User u = new User("Oleg");
            User_ u_ = new User_();
            u_.Name = "Oleg";

            var res1 = u.GetName();
            var res2 = u_.Name;
        }
        #endregion

        #region Полиморфизм
        public class BaseClass
        {
            public void DoWork() { Console.WriteLine("DoWork base"); }
            public virtual void DoWork2() { Console.WriteLine("DoWork2 base"); }
            public virtual void DoWork3() { Console.WriteLine("DoWork3 base"); }

            public int WorkField;
            public int WorkProperty
            {
                get { return 0; }
            }
        }

        public class DerivedClass : BaseClass
        {
            public new void DoWork() { Console.WriteLine("DoWork derived"); }
            public override void DoWork2() { Console.WriteLine("DoWork2 derived"); }
            public sealed override void DoWork3() { Console.WriteLine("DoWork3 sealed override derived"); }

            public new int WorkField;
            public new int WorkProperty
            {
                get { return 0; }
            }
        }

        public class DerivedClass2 : BaseClass
        {
            public override void DoWork3() { Console.WriteLine("DoWork3 override derived"); }
        }

        public void Ex2()
        {
            DerivedClass B = new DerivedClass();
            B.DoWork();  // Calls the new method.

            BaseClass A = (BaseClass)B;
            A.DoWork();  // Calls the old method.
            Console.WriteLine(subcaption);
            B.DoWork2(); // переопределённый метод
            A.DoWork2(); // переопределённый метод
            Console.WriteLine(subcaption);
            BaseClass C = new DerivedClass2();
            B.DoWork3();
            A.DoWork3();
            C.DoWork3();
        }

        #endregion

        #region Example
        public class TypeA
        {
            public class TypeB : TypeA
            {
                public override void MethodA()
                {
                    Console.WriteLine("TypeB");
                }
            }

            public virtual void MethodA()
            {
                Console.WriteLine("TypeA");
            }
        }
        #endregion

        #region Example
        public void ModifyInt(int i)
        {
            i = 99;
        }

        public void ModifyString(string s)
        {
            s = "Hello, I've been modified";
        }
        #endregion

        #region Example 
        class A17
        {
            static A17()
            {
            }
        }
        class B17 : A17
        {   
            // public нельзя
            static B17() //: base()
            {            // нельзя т.к. static
            }
        }
        #endregion

        #region Example
        /*[private | public]*/
        class A18
        {
            public A18()
            {
            }
        }
        /*[private | public]*/
        private class B18 : A18
        {
            /*[private | public]*/
            private B18() : base() // констр A18 д.б. public
            {
            }
        }
        #endregion

        #region Example
        public class Clz
        {
            /*public*/ static Clz()   // CS0515, remove public keyword  
            {
            }
        }
        #endregion

        #region Example
        class ByteCollection2 : Collection<byte> { }
        public void Ex3()
        {
            // это истинный класс, поэтому равны
            Console.WriteLine(typeof(ByteCollection1) == typeof(Collection<byte>));
            // это наследник, поэтому не равны
            Console.WriteLine(typeof(ByteCollection2) == typeof(Collection<byte>));
        }
        #endregion

        #region Example
        class A19 { }
        interface Inner { }
        struct S : //A19,
                   Inner
        {
            // иниц-ть нельзя
            //int num = 10;
            public int num2;
            // без параметров нельзя
            //S() { }
            S(int num2)
            {
                this.num2 = num2;
            }
            static S() { }
        }
        #endregion

        #region Example
        protected internal class A20 { }
        //internal protected class A20 { }
        #endregion

        #region Example
        public class A21
        {
            public virtual void Print()
            {
                Console.WriteLine("A::Print");
            }
        }

        public class B21 : A21
        {
            public override void Print()
            {
                Console.WriteLine("B::Print");
            }
        }

        public class C21 : A21
        {
            //public void Print()
            public new void Print()
            {
                base.Print();
                Console.WriteLine("C::Print");
            }
        }
        #endregion

        #region BASE
        public class A22
        {
            public A22()
            {
            }

            public A22(string param)
            {
            }
        }
        public class B22 : A22
        {
            public B22() : base()
            {
            }

            public B22(string param) : base(param)
            {
            }
        }
        #endregion

        #region OBJECT INHERITANCE
        class A23 : Object
        {
        }
        #endregion

        //enum E1 { One, Two }

        //struct S1 : E1
        //{
        //}

        //class A16 : E1, S1
        //{
        //}

        /*
		отличия когда асинхронный метод возвращает то void то Task
		когда void - нужно чтобы просто асинхронно выполнился метод
		когда Task - нужно чтобы вернулась задача, чтобы потом получить её результат
		
		в асинхронном методе выполняется await ... метод . если в этом внутреннем методе возникло исключение
		то его можно поймать в вызывающем методе try/catch
		
		если объявить задачу или thread в вызывающем методе и там вызвать исключение, то try/catch не обработает
		*/

        #region Поле класса с типом как сам класс
        class A24
        {
            A24 Foo { get; set; }
        }
        #endregion

        #region STATIC
        static class Static { } // можно так назвать
        private static class PrivateStatic { } // можно private
        public static class PublicStatic { } // можно public
        protected static class ProtectedStatic { } // можно protected
        static class StaticDerivedFromObject : object { } // можно наследовать от объекта
        //static class StaticDerivedFromStatic : StaticBase {} // нельзя наследовать от статического
        //static class StaticDerivedFromInstance : A { } // нельзя наследовать от экземплярного
        //static class StaticDerivedFromInterface : Inner { } // нельзя наследовать от интерфейса

        // InstanceClassStaticConstructor ICSC - никакой конструктор не вызовется;
        // new InstanceClassStaticConstructor() - вызывается сначала статический, потом экземплярный конструктор
        public class InstanceClassStaticConstructor
        {
            // Static variable that must be initialized at run time.
            static readonly long baseline;

            // Static constructor is called at most one time, before any
            // instance constructor is invoked or member is accessed.
            static InstanceClassStaticConstructor()
            {
                baseline = DateTime.Now.Ticks;
            }

            public InstanceClassStaticConstructor()
            {
            }
        }

        // StaticClassStaticConstructor.foo = 100; // сработает статический конструктор. foo не проиниц-ся
        // StaticClassStaticConstructor.GetFoo(); // foo к этому моменту уже проиниц-ся
        public static class StaticClassStaticConstructor
        {
            // Static variable that must be initialized at run time.
            public static int foo;

            // Static constructor is called at most one time, before any
            // instance constructor is invoked or member is accessed.
            static StaticClassStaticConstructor()
            {
                
            }

            public static int GetFoo()
            {
                return foo;
            }

            //public StaticClassStaticConstructor() // нельзя
            //{
            //}
        }

        #endregion

        #region STRINGS
        public class Strings
        {
            public void TestEquality()
            {
                string s1 = "foo";
                string s2 = s1;
                string s3 = "foo";
                string s4 = "bar";
                var a1 = s1 == s2; // по ссылке
                var a2 = s1 == s4; 
                var a3 = s1 == s3; 
                var a4 = s1.Equals(s2); // по значению
                var a5 = Object.ReferenceEquals(s1, s2); // по ссылке
                var a6 = Object.ReferenceEquals(s1, s3); // по ссылке
                var a7 = Object.ReferenceEquals(s1, s4); // по ссылке
            }

            public void TestEquality2()
            {
                string hello = "hello";
                string helloWorld = "hello world";
                string helloWorld2 = hello + " world";

                var a1 = helloWorld;
                var a2 = helloWorld2;
                var a3 = helloWorld == helloWorld2; // по значению true
                var a4 = object.ReferenceEquals(helloWorld, helloWorld2); // по ссылке false
                helloWorld = helloWorld2;
                var a5 = object.ReferenceEquals(helloWorld, helloWorld2); // ссылке true
            }

            public void TestIntern()
            {
                string hello = "hello";
                string helloWorld = "hello world";
                string helloWorld2 = hello + " world";

                var a1 = helloWorld;
                var a2 = helloWorld2;
                var a3 = helloWorld == helloWorld2; // по значению true
                var a4 = object.ReferenceEquals(helloWorld, helloWorld2); // по ссылке false
                helloWorld2 = "hello world"; // вроде как смысла нет, т.к. string helloWorld2 = hello + " world"; - тем не менее влияет

                // сработало интернирование. приравняли ко 2-й ссылки то же значение, что и для первой, а сами ссылки не приравнивали. 
                // Несмотря на это проверка по ссылкам true. то true
                var a5 = object.ReferenceEquals(helloWorld, helloWorld2);
            }
        }
        #endregion

        #region UPCASTING/DOWNCASTING
        class Person_
        {
        }

        class PersonWithId_ : Person_
        {
        }
        
        public void UpcastingDowncasting()
        {
            Person_ p = new Person_();
            PersonWithId_ pId = new PersonWithId_();
            Person_ pCast = (Person_)pId; // upcasting - от специфичного к базовому - без приведения
            try
            {
                PersonWithId_ pIdCast = (PersonWithId_)p; // downcasting - от базового к специфичному - с приведением
                                                          // без приведения будет ошибка
            }
            catch (InvalidCastException e) // будет эксепшн
            {

            }

            p = pId;
            try
            {
                PersonWithId_ pIdCast = (PersonWithId_)p; 
            }
            catch (InvalidCastException e) // не будет эксепшна
            {

            }
        }
        #endregion
    }
}
