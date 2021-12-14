using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    // как увидеть текст SQL запроса? 
    // передать в select анонимный метод, универсальный метод-делегат или дерево выражения
    // получение данных из связанных словарей. Сделать навороченные словари, со сложными олбъектами, с транзитивной зависимостью
    // отложенное выполннение запросы - LINQ lazy loading
    // немедленное выполнение запроса - ...

    class LINQ
    {
        public void Ex1()
        {
            IEnumerable<int> arr = new int[] { 1, 2, 3 };
            
            // зачем AsEnumerable, если можно без него?
            /*IEnumerable<int>*/ int[] resultToArray = arr.Select(x => x)/*.AsEnumerable()*/.ToArray(); // уже есть результат. Немедленное выполнение запроса
            
            IEnumerable<int> resultSelect = arr.Select(x => x); // здесь ещё нет массива. Почему в запросе в дебаггере виден результат?
            var result1Query = from num in resultSelect select num; // эквивалентно предыдущему результату
            foreach (var item in resultSelect)
            {
                // есть элемент в каждой итерации. Отложенное выполнение запроса
            }

            // результат одинаковый
            IEnumerable<int> resultToArray2 = arr.Select(x => x * 2).ToArray();
            IEnumerable<int> resultWeirdLambda = arr.Select(x => x = x * 2).ToArray(); // в лямбде странное выражение
        }

        public void AnonimousType()
        {
            IEnumerable<int> arr = new int[] { 1, 2, 3 };
            var query = from item in arr select new { Num = item, NumStr = item.ToString() }; // вернёт анонимный тип. как типизировать?
            var result = query.ToArray();
            var first = query.First();
            var num = first.Num;
            var NumStr = first.NumStr;
        }

        delegate string Upper(string str); // объявили делегат. в методе объявлять нельзя, только в классе или вне класса в пространстве имён, т.к. это тип
        
        public void Delegate()
        {
            // Declare a Func variable and assign a lambda expression to the variable. The method takes a string and converts it to uppercase
            Func<string, string> selector = str => str.ToUpper();

            Upper upper = delegate (string str) // проинициализировали делегат
            {
                return str.ToUpper();
            };

            // Create an array of strings.
            string[] words = { "orange", "apple", "Article", "elephant" };
            // Query the array and select strings according to the selector method.
            
            // одинаковые результаты
            IEnumerable<String> res1 = words.Select(selector).ToArray();
            IEnumerable<String> res2 = words.Select(x => x.ToUpper()).ToArray();
            //IEnumerable<String> res3 = words.Select(upper).ToArray(); // в Select на вход должен идти только Func
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

            // в анонимном классе new {... поля создаются самми и именуются как параметры: index, fruit
            // IEnumerable
            IEnumerable<object/*dynamic*/> query1 = fruits.Select((fruit, index) => new { fruit, index }); // явно типизировать

            // в анонимном классе переопределили дефолтные названия полей
            var query2 = fruits.Select((fruit, index) => new { Index = index, Fruit = fruit });

            // в явном классе инициализируются его поля
            IEnumerable<Fruit> query3 = fruits.Select((fruit, index) => new Fruit(index, fruit)); // явно типизировать

            int a1 = 1;
            var obj1 = new { a1 }; // обернули объектом, который содержит свойство. как сделать, чтобы содержал private поле?
            var obj2 = new { int.MaxValue };
            // var obj3 = new { 1 }; // нельзя
            // var obj4 = new { new Int16(1) }; // нельзя

            int[] ints = { 1, 2, 3 };
            var query5 = ints.Select(int_ => new { int_ }); // нельзя типизировать анонимный тип? см. AnonimousTypes
        }

        #region Отложенное выполнение/инициализация Lazy
        public void Lazy()
        {
            string[] teams = { "Бавария", "Боруссия", "Реал Мадрид", "Манчестер Сити", "ПСЖ", "Барселона" };
            
            IOrderedEnumerable<string> query = from t in teams where t.StartsWith("Б") orderby t select t; // определение и выполнение LINQ-запроса

            var res_3 = query.Count(); //3 выполнение LINQ-запроса
            teams[1] = ""; // query изменился "на лету", хотя мы его не трогали
            var res_2 = query.Count(); //2 выполнение LINQ-запроса
        }

        /// <summary>
        /// Сколько раз выполниться Where, если t - IEnumerable? IQueryable?
        /// Ответ: 2 раза
        /// </summary>
        public void Lazy2()
        {
            var t = Enumerable.Range(1, 1000).Where(z => z % 3 == 0);
            //var t = Enumerable.Range(1, 1000).Where(z => { z % 3 == 0; });
            t.Count();
            t.Any();
        }

        /// <summary>
        /// Как изменится q? Какой тип у переменной q?
        /// Ответ: 15. запрос сработает когда ToList()
        /// </summary>
        public void Lazy3()
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
            var a1 = numbers.Skip(4).Take(3); // 1, 2, 3
            var a2 = numbers.Take(4).Skip(3); // 0
            var a3 = numbers.Take(4).Skip(4); // перечисление не дало результатов
            var a4 = numbers.Take(4).Skip(5); // перечисление не дало результатов
            var a5 = numbers.Take(4); // -3, -2, -1, 0
        }
        #endregion

        public enum Enum { Zero = 0, One = 1, Two = 2, Three = 4 }

        public void Any()
        {
            var allElements = new[] { Enum.One, Enum.Two, Enum.Three };
            var twoElements = new[] { Enum.Zero, Enum.One };
            var true1 = twoElements.Any(x => allElements.Contains(x)); // true
        }

        #region SelectMany
        class User
        {
            public string Name { private get; set; } // get не нужен, без него нельзя
            public int Age { get; set; }
            public List<string> Languages { get; set; }
        }

        public void SelectMany() 
        {
            List<User> users = new List<User>
            {
                new User {Name="Том", Age=23, Languages = new List<string> {"английский", "немецкий" }},
                new User {Name="Боб", Age=27, Languages = new List<string> {"английский", "французский" }},
                new User {Name="Джон", Age=29, Languages = new List<string> {"английский", "испанский" }},
                new User {Name="Элис", Age=24, Languages = new List<string> {"испанский", "немецкий" }}
            };

            var allLanguages = users.SelectMany(u => u.Languages).ToArray();



            var selectedUsers = users.SelectMany(u => u.Languages, (u, l) => new { User = u, Lang = l })
                                     .Where(u => u.Lang == "английский" && u.User.Age < 28)
                                     .Select(u => u.User);

            var selectedLanguages = selectedUsers.SelectMany(u => u.Languages).ToArray();
        }
        #endregion
    }
}
