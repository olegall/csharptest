using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class LINQ
    {
        // как увидеть текст SQL запроса? 

        // передать в select анонимный метод, универсальный метод-делегат или дерево выражения

        public void Ex1()
        {
            IEnumerable<int> arr = new int[] { 1, 2, 3 };

            // здесь ещё нет массива. Почему в запросе уже есть результат?
            IEnumerable<int> result1 = arr.Select(x => x * 2);
            var numQuery = from num in result1 select num;

            foreach (var item in result1)
            {
                // есть элементы. Отложенное выполнение запроса
            }

            // уже есть массив. Немедленное выполнение запроса
            IEnumerable<int> result2 = arr.Select(x => x * 2).ToArray();

            IEnumerable<int> result3 = arr.Select(x => x * 2).AsEnumerable();

            // результат одинаковый
            IEnumerable<int> result4 = arr.Select(x => x * 2);
            IEnumerable<int> result5 = arr.Select(x => x = x * 2).ToArray();
        }

        public void Ex2()
        {
            IEnumerable<int> arr = new int[] { 1, 2, 3 };
            var query = from item in arr
                        select new { Num = item, NumStr = item.ToString() };
            var result = query.ToArray();
            var first = query.First();
            var num = first.Num;
            var NumStr = first.NumStr;
        }

        public delegate string Upper(string str);
        public void Ex3()
        {
            // Declare a Func variable and assign a lambda expression to the  
            // variable. The method takes a string and converts it to uppercase.
            Func<string, string> selector = str => str.ToUpper();

            Upper upper = delegate (string str)
            {
                return str.ToUpper();
            };


            // Create an array of strings.
            string[] words = { "orange", "apple", "Article", "elephant" };
            // Query the array and select strings according to the selector method.
            IEnumerable<String> res1 = words.Select(selector).ToArray();
            IEnumerable<String> res2 = words.Select(x => x.ToUpper()).ToArray();
            //IEnumerable<String> res3 = words.Select(upper).ToArray();

            int[] ints = { 1, 2, 3 };
            IEnumerable<int> res4 = ints.Select<int, int>(x => x).ToArray();
        }

        public class Fruit
        {
            private int idx { get; set; }
            public string frt { get; set; }
            public Fruit(int index, string fruit)
            {
                idx = index;
                frt = fruit;
            }
        }

        public void Ex4()
        {
            string[] fruits = { "apple", "banana", "mango", "orange", "passionfruit", "grape" };

            var query = fruits.Select((fruit, index) => new { index, str = fruit.Substring(0, index) });

            // в анонимном классе new {... поля создаются самми и именуются как параметры: index, fruit
            // IEnumerable
            var query2 = fruits.Select((fruit, index) => new { index, fruit });
            var query3 = fruits.Select((fruit, index) => new { fruit, index });

            // в анонимном классе переопределили дефолтные названия полей
            var query4 = fruits.Select((fruit, index) => new { Index = index, Fruit = fruit });

            // в явном классе инициализируются его поля
            IEnumerable<Fruit> query5 = fruits.Select((fruit, index) => new Fruit(index, fruit)).ToArray();

            int[] ints = { 10, 20, 30 };
            var query6 = ints.Select((int_, index) => new { index, int_ }).ToArray();
            IEnumerable<int> query7 = ints.Select(int_ => int_);
            // нельзя типизировать анонимный тип
            var query8 = ints.Select(int_ => new { int_ });
        }
    }
}
