using System;
using System.Threading.Tasks;
using System.Net;

namespace ConsoleApp1
{
    public class HabraClass
    {
        public int Id { set; get; }
    }

    class Objects
    {
        public  async Task CompareObjects()
        {
            var byte1 = new byte();
            var byte2 = new byte();
            var result1 = new byte() == new byte();

            var arr1 = new byte[0];
            var arr2 = new byte[10];
            var result2 = new byte[0] == new byte[0];
        }

        public async Task CompareObjects2()
        {
            string remoteUrl = string.Format("http://google.com");
            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(remoteUrl);
            Task<WebResponse> response = httpRequest.GetResponseAsync();

            var asyncResult1 = response.Result;
            var asyncResult2 = response.GetAwaiter().GetResult();
            var asyncResult3 = await response;

            var a1 = asyncResult1 == asyncResult2;
            var a2 = asyncResult2 == asyncResult3;
            var a3 = asyncResult1 == asyncResult3;
            var a4 = asyncResult1.Equals(asyncResult2);
            var a5 = asyncResult2.Equals(asyncResult3);
            var a6 = asyncResult1.Equals(asyncResult3);
        }

        class User
        {
            private string name { get; set; }
            public User(string name)
            {
                this.name = name;
            }
        }

        public void Ex0()
        {
            // требует using.System
            var res1 = new Object();
            var res2 = new object();
        }

        public void Ex1()
        {
            var user1 = new User("Oleg");
            var user2 = new User("Oleg");
            var user3 = new User("Alex");

            var res1 = ReferenceEquals(user1, user1);
            var res2 = ReferenceEquals(user1, user2);
            user2 = user1;
            var res3 = ReferenceEquals(user1, user2);
            var res4 = ReferenceEquals(user1, user3);
            
            // при передаче произойдёт упаковка значимых типов и ссылки на них будут разные
            var res5 = ReferenceEquals(1, 1);
            var res6 = ReferenceEquals(1, 2);

            var res7 = ReferenceEquals(null, null);
                                                // требует using.System
            var res8 = ReferenceEquals(null, new Object());
            var res9 = ReferenceEquals(null, new object());

            var res10 = Equals(user1, user2);
            var res11 = Equals(user1, user3);
            var res12 = Equals(1, 1);
            var res13 = Equals(1, 2);

            var res14 = user1.Equals(user1);
            var res15 = user1.Equals(user2);
            var res16 = user1.Equals(user3);
        }

        public class Name
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        public void Ex2()
        {
            Name myName = new Name()
            {
                FirstName = "Oleg",
                LastName = "Aleynikov"
            };

            UpdateName(myName);

            // объект myName стал null
            UpdateName(ref myName);

            // восстановили объект
            RestoreName(ref myName);

            // объект myName стал null
            UpdateName_(out myName);

            // восстановили объект
            RestoreName_(out myName);
        }

        public void UpdateName(Name name)
        {
            name = null;
        }

        // Name д.б. проинициализирована
        public void UpdateName(ref Name name)
        {
            name = null;
        }

        public void RestoreName(ref Name name)
        {
            name = new Name()
            {
                FirstName = "Oleg",
                LastName = "Aleynikov"
            };
        }

        // Name м.б. не проинициализирована
        public void UpdateName_(out Name name)
        {
            name = null;
        }

        public void RestoreName_(out Name name)
        {
            name = new Name()
            {
                FirstName = "Oleg",
                LastName = "Aleynikov"
            };
        }

        #region Casting
        class Foo { }
        class Animal { }
        class Giraffe : Animal { }

        public void Ex3()
        {
            object res1 = (object)null;
            object res2 = (object)new object();
            object res3 = (string)null;
            object res4 = (Foo)null;
            Foo res5 = (Foo)null;
            // ошибка runtime 
            //var res4 = (string)new object();
            //string res5 = (string)new object();
            var res6 = (object)new String('a', 1);
            string res7 = (string)new String('a', 1);




            Giraffe g = new Giraffe();

            // Implicit conversion to base type is safe.  
            Animal a = g;
            Foo f = new Foo();

            // Explicit conversion is required to cast back  
            // to derived type. Note: This will compile but will  
            // throw an exception at run time if the right-side  
            // object is not in fact a Giraffe.  
            Giraffe g2 = (Giraffe)a;

            // Implicit Casting(automatically) - converting a smaller type to a larger type size
            // char -> int -> long -> float -> double
            int myInt = 9;
            double myDouble = myInt;

            // Explicit Casting(manually) - converting a larger type to a smaller size type
            // double -> float -> long -> int -> char
            double myDouble2 = 9.78;
            int myInt2 = (int)myDouble2;
            int myInt2_ = Convert.ToInt32(myDouble2);
        }
        #endregion

        public void Nullable()
        {
            int? i = null;

            object a = null;
            //object a = new object();

            // null-coalescing operator
            var res1 = i ?? Convert.ToInt32(i.HasValue);
            var res2 = a ?? "str";
        }
    }
}
