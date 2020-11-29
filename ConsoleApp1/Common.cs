using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Common
    {
        // нельзя в классе, структуре и интерфейсе
        //try 
        //{
        //}
        //catch 
        //{
        //}

        // Вместо IEnumerable<int>
        //List<Task<int[]>> tasks = new List<Task<int[]>>();

        // Преобразование объекта в массив int. Ещё способы
        //IEnumerable<int> a2 = new object() as IEnumerable<int>;

        public void Ex1()
        {
            int i, j, s = 0;
            for (i = 0, j = 6; i < j; ++i, --j)
            {
                s += i;
            }
            Console.WriteLine(s);
        }

        public void Ex2()
        {
            //int[][] k1 = new int[2][3];
            int[,] k2 = new int[2, 3];
            //int k3[][] = new int[2][3];
            int[][] k4 = new int[2][];
            //int k5[,] = new int[2, 3];
        }

        public void Ex3()
        {
            string @string = "ABC";
            //Console.WriteLine(string);
            Console.WriteLine(@string);
        }

        class Ex4_
        {
        }
        // метод нельзя называть как класс
        public void Ex4()
        {
        }

        public void Ex5()
        {
            double[,] myDoubles = new double[1, 2];
            myDoubles[0, 1] = 1;

            // нельзя
            //double[,] myDoubles = new double[,];

            //double[][] myDoubles2 = new double[0][1];
        }

        public void Nullable()
        {
            // An array of a nullable t
            int?[] arr = new int?[10];
        }
                                                                                                                                                    
        public void Ex6()
        {
            object iBoxed = null;
            //var a1 = iBoxed.GetType();
            int i = 23;
            iBoxed = i;
            var a2 = iBoxed.GetType();
        }

        public void Ex7()
        {
            object iBoxed;
            //var a1 = iBoxed.GetType(); // ошибка. чтобы получить тип надо присвоить null
        }

        public void Ex8()
        {
            //var obj = null; // нельзя - не типизирована
            object obj = null;

        }
        
    }
}
