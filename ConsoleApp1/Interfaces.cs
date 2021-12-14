using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Interfaces
    {
        interface Interface1
        {
            void F();
            void G();
            //virtual void VirtualInInterface(); // virtual нельзя
        }

        public class A1
        {
            public void F() { }
            public void G() { }
            public virtual void VirtualInClass() { }
        }

        // Скомпилируется ли данный класс?
        // я хочу вызвать извне этот класс, объявил как public. надо так же объявить public и class1, но он должен оставаться приватным. как быть?
        public class DerivedA1 : A1, Interface1
        {
            //new public void G() { }
            // можно реализовать, несмотря на то, что такой же метод реализован в базовом классе
            // при вызове не вызовется G класса Class1
            //public void G() { }
            //base.G(); // в классе так нельзя
            public void InvokeBase() 
            { 
                base.G();
            }
            //VirtualInClass();
        }


        /*
         Это явная реализация интерфесов
         В C# нельзя реализовать несколько интерфесов
       - Такой код позволит сделать разные реализацииметода f для каждого из реализованных интерфейсов
         Это неявная реализация интерфейсов
         Такой код не скомпилируется, потому что возникнет конфликт имён
         */
        interface A2
        {
            void f();
        }

        interface B1
        {
            void f();
        }

        class C : A2, B1
        {
            void A2.f() { }
            void B1.f() { }
        }



        public interface InvokeSignature
        {
            void Foo();
        }
        
        // или класс или метод д.б. публичными, т.к. реализуют интерфейс, который по своей природе публичный
        public class InvokeSignatureClass : InvokeSignature
        {
            public void Foo() // обязательно public, если класс не public
            {
            }
        }



        public interface IEmpty 
        {
        }

        public interface IBase : IEmpty // IEmpty обязательно д.б. публичным
        {
            void Print(); // может не быть в интерфейсе. private, public, protected нельзя
        }

        interface IDerived : IBase, IEmpty
        {
        }

        class A4 : IDerived
        {
            void Print()
            {
            }

            // ошибка - Print нет в IDerived
            //void IDerived.Print() 
            //{
            //}

            void IBase.Print() // если в вызывающем коде вызвать Print интерфейса IBase, вызовется именно этот метод
            {
            }
        }




        public interface IA // может быть public
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




        interface I1
        {
            void Foo();
        }

        struct S1 : I1 // можно public
        {
            // обязательно public
            public void Foo() { }
        }
        
        class C1 : I1 // можно public
        {
            // обязательно public
            public void Foo() { }
        }
        


        public interface IControl
        {
            void Paint();
        }

        interface IForm
        {
            void Paint();
        }

        public class Page : IControl, IForm
        {
            public void Paint() 
            { 
            }
        }

        public class Page2 : IControl, IForm
        {
            void IControl.Paint() 
            {
            }

            void IForm.Paint() 
            {
            }
        }

        /*public*/ interface I2
        {
            // нельзя объявлять модификаторы
            // нельзя static
            void Foo();
            
            // интерфейсы не могу содержать поля
            // int foo;

            // CS0524 Интерфейс не может содержать пользовательский тип; 
            // в интерфейсах должны содержаться только методы и свойства.
            
            //delegate void Print(int value);
            
            //public class Cly {}  // CS0524, delete user-defined type  

            event Action<String> UpdateStatusText; // может содержать события
        }
    }
}
