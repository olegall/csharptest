using System;

namespace ConsoleApp1
{
    class ReferenceTypes
    {
        public void Main()
        {
            int[] arr = new int[4] { 2, 1, 3, 4 };
            Array.Sort(arr); // исходный массив отсортируется. повлияет по ссылке

            var a2 = new MyClass { Num = 1 };
            ChangeNum(a2);  // проверить корневой переданный объект
            ChangeNum2(a2); // проверить корневой переданный объект
        }

        private void ChangeNum(MyClass myClass)
        {
            myClass.Num += myClass.Num;
        }

        private void ChangeNum2(MyClass myClass)
        {
            myClass.Num += myClass.Num;
        }
    }
}
