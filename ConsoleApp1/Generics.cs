using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Generics
    {
        class NewRestriction<T> where T : new() // нужен new, чтобы вернуть T()
        {
            public T Foo(int sum)
            {
                return new T();  // создаем счет
            }
        }



        class TypeA { }
        class TypeB { }

        void SomeMethod<T>(T t)
        {
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

        class Test
        {

            /*public void Foo<T> (List<int> list, T el) where T : Int32
            {
                List<T> xlist = (List<T>)list; //OK
                xlist.add(el);
            }*/

            /*public static void main(String[] args)
            {

                List<Integer> list = new ArrayList<>();
                t(list, "a");
                t(list, "b");

                //prints [a, b] even if List type is Integer
                System.out.println(list);

            }*/
        }
    }
}