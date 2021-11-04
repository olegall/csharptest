using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class LINQ
    {
        // как увидеть текст SQL запроса? 
        // передать в select анонимный метод, универсальный метод-делегат или дерево выражения
        // получение данных из связанных словарей. Сделать навороченные словари, со сложными олбъектами, с транзитивной зависимостью
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
            var query = from item in arr select new { Num = item, NumStr = item.ToString() };
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

        #region Отложенное выполнение/инициализация Lazy
        public void Lazy()
        {
            string[] teams = { "Бавария", "Боруссия", "Реал Мадрид", "Манчестер Сити", "ПСЖ", "Барселона" };
            
            IOrderedEnumerable<string> q = from t in teams where t.ToUpper().StartsWith("Б") orderby t select t; // определение и выполнение LINQ-запроса
            var a1 = q.Count(); //3 // выполнение LINQ-запроса
            teams[1] = "Ювентус";
            var a2 = q.Count(); //2 // выполнение LINQ-запроса
        }

        /// <summary>
        /// Сколько раз выполниться Where, если t - IEnumerable? IQueryable?
        /// Ответ: 2 раза
        /// </summary>
        public void LazyInitialization()
        {
            var t = Enumerable.Range(1, 1000).Where(z => z % 3 == 0);
            t.Count();
            t.Any();
        }

        /// <summary>
        /// Как изменится q? Какой тип у переменной q?
        /// Ответ: 15. запрос сработает когда ToList()
        /// </summary>
        public void Lazy2()
        {
            var list = new List<int>();
            var q = list.Where(x => x > 10 && x < 20);
            list.Add(5);
            list.Add(11); // q=[11]     на лету перевычисляется q - после каждого добавления
            list.Add(15); // q=[11, 15]
            list.Add(25);
        }
        #endregion

        #region Pagination
        public void Pagination()
        {
            int[] numbers = { -3, -2, -1, 0, 1, 2, 3 };
            var a1 = numbers.Skip(4).Take(3);
            var a2 = numbers.Take(4).Skip(3);
            var a3 = numbers.Take(4);
        }
        #endregion

        public enum VerificationCenterType
        {
            /// <summary>
            /// Пусто
            /// </summary>
            None = 0,
            /// <summary>
            /// НЭП 
            /// </summary>
            NEP = 1,
            /// <summary>
            /// КЭП
            /// </summary>
            KEP = 2,
            /// <summary>
            /// Мобильный ключ (Pay Control)
            /// </summary>
            PayControl = 4
        }

        //public void Any() 
        //{
        //    var nonBlockedVerificationCenterTypes = new[] { 10, 11, 12 };
        //    var authorizedUserCryptoprofiles = new[] { 1, 2, 3 };
        //    var res1 = authorizedUserCryptoprofiles.Any(x => nonBlockedVerificationCenterTypes.Contains(x));
        //}
        
        public void Any()
        {
            var nonBlockedVerificationCenterTypes = new[] { VerificationCenterType.NEP, VerificationCenterType.KEP, VerificationCenterType.PayControl };
            var authorizedUserCryptoprofiles = new[] { VerificationCenterType.None, VerificationCenterType.NEP};
            // true
            var res1 = authorizedUserCryptoprofiles.Any(x => nonBlockedVerificationCenterTypes.Contains(x));
            
            var authorizedUserCryptoprofilesNone = new[] { VerificationCenterType.None };
            // false
            var res2 = authorizedUserCryptoprofilesNone.Any(x => nonBlockedVerificationCenterTypes.Contains(x));
        }
    }
}
