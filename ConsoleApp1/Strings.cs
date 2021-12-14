using System;
using System.Text;

namespace ConsoleApp1
{
    public class Strings
    {
        // как правильно сравнивать ссылки? когда по значению, когда по ссылке?
        
        // equals и ==  - одно и то же
        
        // Интернирование строк — это механизм, при котором одинаковые литералы представляют собой один объект в памяти.
        
        // Когда использовать интернирование? Когда предполагается работа со множеством одинаковых строк?

        /*
            Habr
            При использовании строк в C#, CLR делает что-то хитрое и это что-то называется интернирование строк. 
            Это способ хранения одной копии любой строки. Если вы храните в ста или, что еще хуже, в миллионе строковых переменных одинаковое значение получится, 
            что память для хранения значений строк будет выделяться снова и снова. Интернирование строки это способ обойти эту проблему. 
            Среда CLR поддерживает таблицу называемую пул интернирования. Эта таблица содержит одну уникальную ссылку на каждую строку, которая либо объявлена, 
            либо создана программно во время выполнения вашей программы. А .NET Framework предоставляет два полезных метода для взаимодействия с пулом интернирования: String.Intern() и String.IsInterned().
            Метод String.Intern() работает очень простым способом. Вы передадите ему в качестве аргумента строку. Если эта строка уже находится в пуле интернирования, метод возвращает ссылку на эту строку. Если её еще не нет, он добавляет строку в пул и возвращает на неё ссылку         
         */



        class Foo1 { }

        class Foo2 { }

        public void Equality()
        {
            string s1 = "foo";
            string s2 = s1;
            string s3 = "foo";
            string s4 = "bar";

            var obj1 = new Foo1 { };
            
            var obj2 = new Foo1 { };

            //s1[0] = ''; // нельзя изменить строку

            // по ссылке
            var true1 = s1 == s2;
            var false1 = s1 == s4;
            var true2 = s1 == s3; 

            // по значению
            var true3 = s1.Equals(s2);
            var true4 = s1.Equals(s3);

            // по ссылке
            var true5 = Object.ReferenceEquals(s1, s2);

            var true6 = Object.ReferenceEquals(s1, s3); // почему? 2 независимые строки в памяти, хоть и одинаково названные. интернирование? .Net оптимизирует - не размещает 2 одинаковые строки в разных областях памяти
            var false2 = Object.ReferenceEquals(obj1, obj2); // в случае с обычными ссылочными типами всё ок
            
            var false3 = Object.ReferenceEquals(s1, s4);

            var true7 = Object.ReferenceEquals(null, null);
            object true8 = null == null; // var нельзя
            var false4 = "".Equals(null);

            var foo1 = new Foo1();
            var foo2 = foo1;
            var false5 = Object.ReferenceEquals(new Foo1(), new Foo1()); // false т.к. 2 созданных объекта возвращают разные ссылки
            var true9 = Object.ReferenceEquals(foo1, foo1);
            var false6 = Object.ReferenceEquals(foo1, foo2);
        }

        public void Equality2()
        {
            string hello = "hello";
            string helloWorld1 = "hello world";
            string helloWorld_ConcatParam = hello + " world";
            string helloWorld_ConcatStr = "hello" + " world";

            var true1 = helloWorld1 == helloWorld_ConcatParam; // по значению
            var true2 = helloWorld1 == helloWorld_ConcatStr; // по значению

            var false1 = object.ReferenceEquals(helloWorld1, helloWorld_ConcatParam); // по ссылке false. как-то влияет переменная hello, которая имеет свой адрес, влияет на результирующий адрес. получить адрес переменных, проверить
            var true3 = object.ReferenceEquals(helloWorld1, helloWorld_ConcatStr); // по ссылке true. Почему 2 разные строки имеют разный адрес

            helloWorld1 = helloWorld_ConcatParam;
            var true4 = object.ReferenceEquals(helloWorld1, helloWorld_ConcatParam); // по ссылке true

            helloWorld1 = helloWorld_ConcatStr;
            var true5 = object.ReferenceEquals(helloWorld1, helloWorld_ConcatStr); // по ссылке true
        }

        public void Intern()
        {
            string hello = "hello";
            string helloWorld = "hello world";
            string helloWorld2 = hello + " world";

            var true1 = helloWorld == helloWorld2; // по значению true
            var false1 = object.ReferenceEquals(helloWorld, helloWorld2); // по ссылке false
            helloWorld2 = "hello world"; // вроде как смысла нет, т.к. string helloWorld2 = hello + " world"; - тем не менее влияет

            // сработало интернирование. приравняли ко 2-й ссылки то же значение, что и для первой, а сами ссылки не приравнивали. 
            // Несмотря на это проверка по ссылкам true. то true
            var true2 = object.ReferenceEquals(helloWorld, helloWorld2);
        }

        public void InternMsdn()
        {
            string s1_str = "MyTest";
            string s2_builder = new StringBuilder().Append("My").Append("Test").ToString();
            string s3_intern = String.Intern(s2_builder); // 2 строки на одно место в памяти
            
            var res1 = $"s1 == {s1_str}"; // str
            var res2 = $"s2 == {s2_builder}"; // builder
            var res3 = $"s3 == {s3_intern}"; // intern
            var res4 = $"Is s2 the same reference as s1?: {(Object)s2_builder == (Object)s1_str}";
            var res5 = $"Is s3 the same reference as s1?: {(Object)s3_intern == (Object)s1_str}";

            /*
            This example produces the following results:
            s1 == MyTest
            s2 == MyTest
            s3 == MyTest
            Is s2 the same reference as s1?: False
            Is s3 the same reference as s1?: True
            */
        }

        public void ReverseStringHabr()
        {
            var s = "Strings are immutuble";
            int length = s.Length;
            for (int i = 0; i < length / 2; i++)
            {
                var c = s[i];
                //s[i] = s[length - i - 1];
                //s[length - i - 1] = c;
            }
        }

        //public void ReverseStringUnsafeHabr()
        //{
        //    var s = "Strings are immutable";
        //    int length = s.Length;
        //    unsafe
        //    {
        //        fixed (char* c = s)
        //        {
        //            for (int i = 0; i < length / 2; i++)
        //            {
        //                var temp = c[i];
        //                c[i] = c[length - i - 1];
        //                c[length - i - 1] = temp;
        //            }
        //        }
        //    }
        //}
    }
}

