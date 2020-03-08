using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Interfaces
    {
        /// <summary>
        /// Скомпилируется ли данный класс?
        /// </summary>
        interface Interface1
        {
            void F();
            void G();
        }
        class Class1
        {
            public void F() { }
            public void G() { }
        }
        class Class2 : Class1, Interface1
        {
            new public void G() { }
        }


        /*
         Это явная реализация интерфесов
         В C# нельзя реализовать несколько интерфесов
       - Такой код позволит сделать разные реализацииметода f для каждого из реализованных интерфейсов
         Это неявная реализация интерфейсов
         Такой код не скомпилируется, потому что возникнет конфликт имён
         */
        interface A1
        {
            void f();
        }

        interface B1
        {
            void f();
        }

        class C : A1, B1
        {
            void A1.f() { }
            void B1.f() { }
        }





        interface IEmpty { }

        interface IBase : IEmpty
        {
            void Print();
        }

        interface IDerived : IBase, IEmpty
        {
        }

        class A4 : IDerived
        {
            public void Print()
            {
                Console.WriteLine("A.Print()");
            }
            // IDerived.Print не может быть явной реализацией
            // т.к. Print не является членом интерфейса IDerived
            //void IDerived.Print() {
            //    Console.WriteLine("A.Print()");
            //}
            void IBase.Print()
            {
                Console.WriteLine("A.Print()");
            }
        }




        public interface IA
        {
            void Somework();
        }

        public class B8 : IA
        {
            void IA.Somework()
            {
                Console.WriteLine("Some work in B");
            }

            public void Somework()
            {
                Console.WriteLine("Some work in B");
            }
        }




        interface I
        {
            // private, public, protected нельзя
            void Foo();
        }

        interface I1
        {
            void Foo();
        }
        struct S1 : I1
        {
            // обязательно public
            public void Foo() { }
        }




        interface IControl
        {
            void Paint();
        }

        interface IForm
        {
            void Paint();
        }

        class Page : IControl, IForm
        {
            public void Paint() { }
        }

        class Page2 : IControl, IForm
        {
            void IControl.Paint() { }
            void IForm.Paint() { }
        }

        #region
        /*[public]*/ interface I2
        {
            // нельзя объявлять модификаторы
            // нельзя static
            void Foo();
            
            // интерфейсы не могу содержать поля
            // int foo;

            // CS0524 Интерфейс не может содержать пользовательский тип; 
            // в интерфейсах должны содержаться только методы и свойства.
            // delegate void Print(int value);
            //public class Cly   // CS0524, delete user-defined type  
            //{
            //}

            event Action<String> UpdateStatusText;
        }
        #endregion

        // пустой интерфейс
    }
}
