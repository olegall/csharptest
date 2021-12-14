using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Generics
    {
        public class TypeA { }
        public class TypeB { }
        public class TypeC { }

        public void Main()
        {
            Node<double> doubleNode = new Node<double>(3d);
            //Node<int> intNodeConv = (Node<int>)doubleNode;

            Node<int> intNode = new Node<int>(3);
            //Node<double> doubleNodeConv = (Node<double>)intNode;

            Node<int> intNode2 = new Node<int>(3);
            Node<int> intNodeConv2 = (Node<int>)intNode2; // можно кастить дженерики

            var res1 = typeof(int) == typeof(float);

            var res2 = typeof(TypeA) == typeof(TypeB);

            //var res3 = TypeA == TypeB; // нельзя так сравнивать типы
        }

        class NewRestriction<T> where T : new() // нужен new, чтобы вернуть T()
        {
            public T Foo()
            {
                return new T();  // создаем счет
            }
        }

        //void SomeMethod<T>(T t) where T : TypeA
        //                        where T : TypeB // ограничение до ожидаемых типов TypeA, TypeB. так можно скорее всего если <T, T2>
        public void SomeMethod<T>(T t)
        {
            //проверка что приходят только ожидаемые типы
            if (!(t is TypeA || t is TypeB))
                throw new Exception("Wrong types");

            //проверка что приходят только ожидаемые типы
            /*if (!(typeof(T) == typeof(TypeA) || typeof(T) == typeof(TypeB)))
            {
                throw new Exception("Wrong types");
            }*/

            switch (t)
            {
                case TypeA a:
                    // Do some operation using a.
                    Console.WriteLine($"{a} is a TypeA!");
                    break;
                case TypeB b:
                    // Do some operation using b.
                    Console.WriteLine($"{b} is a TypeB!");
                    break;
                default:
                    // Handle this case.
                    Console.WriteLine("I don't know what this type is.");
                    break;
            }
        }

        class Foo { }

        class Test
        {
            public void Foo<T> (List<T> list, T el) /*where T : Foo*/ // where T : Int32 Ошибка CS0701	"int" не является допустимым ограничением.Тип, использованный в качестве ограничения, должен быть интерфейсом, незапечатанным классом или параметром-типом
            {
                List<T> xlist = (List<T>)list; //OK
                xlist.Add(el);
            }
        }

        public class Node<E>
        {
            E mValue;
            Node<E> mNext;
            Node<E> mPrevious;

            public Node(E value)
            {
                mValue = value;
            }

            public void linkAfter(Node<E> node)
            {
                node.mPrevious = this;
                node.mNext = mNext;
                if (mNext != null)
                {
                    node.mNext.mPrevious = node;
                }
                mNext = node;
            }

            public E getValue()
            {
                return mValue;
            }

            public Node<E> getNext()
            {
                return mNext;
            }

            public Node<E> getPrevious()
            {
                return mPrevious;
            }
        }
    }
}