using System;
using System.Collections.ObjectModel;
using ByteCollection1 = System.Collections.ObjectModel.Collection<byte>;

namespace ConsoleApp1
{
    public class OOP
    {
        private readonly string subcaption;

        // проиллюстрировать копирование объекта по ссылке и их равенство/неравенство после этого

        #region Сокрытие virtual override new полиморфизм
        public class Person
        {
            public virtual void VirtualOverride() // Переопределим. Можно не переопределять
            {
            }

            public void Hidden() // сокрытие
            {
            }

            public void HiddenNew() // сокрытие
            {
            }

            public virtual void NotOverrided() // Не переопределим. Можно не переопределять
            {
            }
        }

        public class Employee : Person
        {
            public override void VirtualOverride()
            {
            }

            #region Скорее всего аналоги
            public void Hidden() // скрывает наследуемый член
            {
            }

            public new void HiddenNew()
            {
            }
            #endregion
        }

        public class ExampleBase
        {
            public readonly int x = 10;
            public const int G = 5;
        }

        public class ExampleDerived : ExampleBase
        {
            public readonly int x = 20;
            public const int G = 15;
        }

        public class ExampleDerivedNew : ExampleBase
        {
            public new readonly int x = 20;
            public new const int G = 15;
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
            //public new void M()
            public override void M()
            {
                Console.WriteLine("This is B");
            }

            public void M2()
            {
                Console.WriteLine("This is B M2");
                base.M();
            }
        }
        
        public class Animal
        {
            public void Info() 
            { 
                Console.WriteLine("Animal"); 
            }

            public virtual void Say() 
            { 
                Console.WriteLine("Nothing to say"); 
            }
        }

        public class Cat : Animal
        {
            // 3 варианта: virtual/override, неявное сокрытие, явное сокрытие с new
            public void Info() { Console.WriteLine("Cat"); }

            // если есть override - обязательно д.б. virtual
            // если есть virtual - override может быть, может не быть. если override работает видимо неявное сокрытие
            // если без override - Say не знают друг о друге в иерархии
            // с override - Лисков
            public override void Say() { Console.WriteLine("Meow"); }
            
            // нельзя, если есть override рядом
            //public void Say() { Console.WriteLine("Meow"); }
        }

        public class Dog : Animal
        {
            public void Info() { Console.WriteLine("Dog"); }
            public override void Say() { Console.WriteLine("Woof"); }
        }
        #endregion

        public class Base3
        {
            public void Method()
            {
                
            }
                   // перед void
            public virtual void MethodVirtualOverride()
            {
                
            }

            public void MethodNew()
            {
                
            }
        }

        public class Derived3 : Base3
        {
            // 3 варианта: virtual/override, неявное сокрытие, явное сокрытие с new
            public void Method()
            {
                
            }
                   // перед void
            public override void  MethodVirtualOverride()
            {
                
            }

            public new void MethodNew()
            {
                
            }
        }

        #region BASE
        #endregion

        #region ABSTRACT
        public abstract class Abstract // можно назвать Abstract
        {
            public Abstract() // сработает, для наследников
            {
            }

            public abstract int GetAreaAbstract(); // нельзя тело, private нельзя, protected можно вирткальные и абстрактные члены не м.б. закрытыми

            public virtual int GetAreaOverride() // д.б. тело. private нельзя, protected можно вирткальные и абстрактные члены не м.б. закрытыми
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

        class A { }
        abstract class DerivaedFromClass : A // абстрактный класс может наследоваться от обычного
        {
        }
        #endregion

        #region BaseDerivedMain 
        public class Point
        {
            public int x { get; set; }
            public int y { get; set; }

            public Point(int xVal, int yVal)
            {
                x = xVal;
                y = yVal;
            }
        }

        public struct PointStruct
        {
            public int x { get; set; }
            public int y { get; set; }

            public PointStruct(int xVal, int yVal)
            {
                x = xVal;
                y = yVal;
            }
        }

        public class Base
        {
            public string className = "Base";
        }

        public class DerivedPrivate : Base
        {
            private string className = "DerivedPrivate";
            public string ClassName
            {
                get
                {
                    return className;
                }
            }
        }

        public class DerivedPublic : Base
        {
            public string className = "DerivedPublic";
        }

        public class DerivedNewPrivate : Base
        {
            private new string className = "DerivedNewPrivate"; // нет предупреждения, если new
            public string ClassName
            {
                get
                {
                    return className;
                }
            }
        }

        public class DerivedNewPublic : Base
        {
            public new string className = "DerivedNewPublic";
        }
        #endregion

        #region MAIN
        private class A18
        {
            public A18() // д.б. public, т.к. наследник дёргает через base
            {
            }
        }

        private class B18 : A18 // работает наследование от приватного класса
        {
            B18() : base()
            {
            }
        }



        class ByteCollection2 : Collection<byte> { }

        public void ClassEquality()
        {
            var a1 = typeof(ByteCollection1) == typeof(Collection<byte>); // true - истинный класс. можно удалить, и using вверху
            var a2 = typeof(Collection<byte>) == typeof(Collection<byte>); // true - истинный класс
            var a3 = typeof(ByteCollection2) == typeof(Collection<byte>); // false - наследник. тип другой - вот и false (typeof)
        }



        public class Person2 { }

        public class Student : Person2 { }

        public class C<T>
        {
            public T x;
        }

        protected internal class ProtectedInternal { }
        internal protected class InternalProtected { }

        class GetterSetter
        {
            private string s;
            public string S
            {
                get
                {
                    return s;
                }
                set
                {
                    s = value;
                }
            }
            //public void get_S() // Уже объявлен как геттер
            //{
            //}
            //public void set_S() // Уже объявлен как геттер
            //{
            //}
        }

        class DerivedFromObject : Object
        {
        }

        class A24 // Поле класса с типом как сам класс
        {
            A24 Foo { get; set; }
        }
        #endregion

        #region CTOR chain
        public class A6
        {
            public A6() { Console.WriteLine("A created"); }
        }

        public class B6 : A6
        {
            public B6() { Console.WriteLine("B created"); }

            public B6(string parameter)
            {
                Console.WriteLine("B created with parameter: {0}", parameter);
            }
        }

        public class C6 : B6
        {   
            public C6() : base("par") // base обязательно, если в базовом классе есть конструктор с параметрами
            {
                Console.WriteLine("C created");
            }
        }

        public class C7 : B6
        {
            public C7() : base()
            {
                Console.WriteLine("C created");
            }
        }

        public class C8 : B6 // эквивалентно C7
        {
            public C8()
            {
                Console.WriteLine("C created");
            }
        }
        #endregion

        #region Derived public CTOR
        public class A7
        {
        }
        public class B7 : A7 // базовый класс д.б. public, если у наследника public
        {
        }
        #endregion

        #region Type Instance CTOR
        public class Parent
        {
            static Parent()
            {
            }
            public Parent()
            {
            }
        }

        public class Child : Parent
        {
            public static int field1 = 0;
            static Child()
            {
            }
            public Child()
            {
            }
            public static void Foo()
            {
            }
        }
        #endregion

        #region private class, private CTOR
        private class A12
        {
            public A12() // д.б. public
            {
            }
        }

        private class B12 : A12
        {
            private B12()
            {
            }
        }
        #endregion

        #region IS TEST
        public class A13
        {
        }

        public class B13 : A13
        {
        }

        public void IsTest()
        {
            var a1 = new A13() is B13;
            var a2 = new B13() is A13;
            var a3 = new A13() is A13;
            var a4 = new B13() is B13;
        }
        #endregion

        #region new 
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
        #endregion

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

        #region Outer Inner
        /// <summary>
        /// Override корректно работает во вложенном классе
        /// </summary>
        public class Outer
        {
            public class Inner : Outer
            {
                public override void A()
                {
                    Console.WriteLine("Inner");
                }
            }

            public virtual void A()
            {
                Console.WriteLine("Outer");
            }
        }
        #endregion

        #region By value by reference
        public void ModifyInt(int i)
        {
            i = 99;
        }

        public void ModifyString(string s)
        {
            s = "Hello, I've been modified";
        }

        public class PassByReference
        {
            public int Foo = 0;
        }

        public void ModifyObject(PassByReference obj)
        {
            obj.Foo = 1;
        }
        #endregion

        #region STRUCT
        interface Inner { }
        enum E1 { One, Two }
        struct S : Inner//, Base, E1 // в списке интерфейсов не является интерфейсом
        {
            //int num = 10; // в структуре не могут содержаться инициализаторы свойств или полей экземпляров
            public int num2;
            // без параметров нельзя
            //S() { } // структуры не могут сожержать явных конструкторов без параметров
            S(int num2)
            {
                this.num2 = num2;
            }
            static S()
            {
            }
        }

        class InheritsStruct //: S // не может быть производным от запечатанного типа S. в списке интерфейсов не является интерфейсом
        {
        }
        #endregion

        #region BASE
        class A22
        {
            public A22()
            {
            }

            public A22(string param)
            {
            }
        }
        class B22 : A22
        {
            B22() : base()
            {
            }

            B22(string param) : base(param)
            {
            }
        }
        #endregion

        /*
		отличия когда асинхронный метод возвращает то void то Task
		когда void - нужно чтобы просто асинхронно выполнился метод
		когда Task - нужно чтобы вернулась задача, чтобы потом получить её результат
		
		в асинхронном методе выполняется await ... метод . если в этом внутреннем методе возникло исключение
		то его можно поймать в вызывающем методе try/catch
		
		если объявить задачу или thread в вызывающем методе и там вызвать исключение, то try/catch не обработает
		*/

        #region STATIC
        static class Static { } // можно так назвать
        private static class PrivateStatic { } // можно private
        public static class PublicStatic { } // можно public
        protected static class ProtectedStatic { } // можно protected
        static class StaticDerivedFromObject : object { } // можно наследовать от Object. почему?
        //static class StaticDerivedFromStatic : StaticBase {} // нельзя наследовать от статического
        //static class StaticDerivedFromInstance : A { } // нельзя наследовать от экземплярного
        //static class StaticDerivedFromInterface : Inner { } // нельзя наследовать от интерфейса

        // InstanceClassStaticConstructor ICSC - никакой конструктор не вызовется;
        // new InstanceClassStaticConstructor() - вызывается сначала статический, потом экземплярный конструктор
        public class InstanceClassStaticConstructor
        {
            static readonly long baseline; // Static variable that must be initialized at run time.
            static InstanceClassStaticConstructor() // Вызывается 1 раз. Static constructor is called at most one time, before any instance constructor is invoked or member is accessed.
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
            public static int foo; // Static variable that must be initialized at run time. м.б. инициализирована

            // Static constructor is called at most one time, before any instance constructor is invoked or member is accessed.
            static StaticClassStaticConstructor() // public нельзя
            {
            }
            
            //public StaticClassStaticConstructor() // экземплярный конструктор нельзя
            //{
            //}

            public static int GetFoo()
            {
                return foo;
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

        /// <summary>
        /// Перегрузка по static
        /// </summary>
        public class Bus
        {
            public static void Drive()
            {
            }
            public void Drive2()
            {
            }
        }

        class A17
        {
            static A17()
            {
            }
        }
        class B17 : A17
        {
            // public нельзя. модификаторы доступа для статических конструкторов не разрешены
            static B17() //: base() // статический конструктор не может иметь явный вызов конструктора "this" или "base"
            {
            }
        }
        #endregion

        #region CTOR
        class CTOR
        {
            CTOR()
            {

            }

            CTOR(int a)
            {

            }
            
            // статический к-р не д. иметь параметров
            // модификаторы доступа для статических к-в не разрешены
            static CTOR() 
            {

            }
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
            catch (InvalidCastException e) // не будет эксепшна, т.к. p = pId;
            {

            }
        }
        #endregion

        #region Check Type
        public interface IFoo
        {
        }

        public class Foo1 : IFoo
        {
        }

        public class Foo2 : IFoo
        {
        }

        public class Foo3 : IFoo
        {
        }

        /// <summary>
        /// Type pattern
        /// </summary>
        public void CheckType1(IFoo foo)
        {
            /*switch(foo is IFoo) {
                case Foo1: break;
            }*/
            switch (foo)
            {
                case Foo1 _:
                    break;
                case Foo2 _:
                    break;
                case Foo3 _:
                    break;
            }
        }

        /// <summary>
        /// Reflection
        /// </summary>
        /// <param name="foo"></param>
        public void CheckType2(IFoo foo)
        {
            Type t = foo.GetType();
        }

        public void CheckType3(IFoo foo)
        {
            if (foo is Foo1)
            {
            }
            if (foo is Foo2)
            {
            }
            if (foo is Foo3)
            {
            }
            Type a1 = foo.GetType();
        }
        #endregion
    }
}