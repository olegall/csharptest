using System;

namespace ConsoleApp1
{
    class ReferenceTypes
    {
        class C1
        {
            public int Num;
        }

        // msdn
        class InOverloads 
        {
            public void SampleMethod(in int i) { }
            public void SampleMethod(int i) { }
        }

        class Student 
        {
            public string StudentName { get; set; }
        }
        
        Student std1 = new Student(); // var std1 на уровне класса нельзя
        

        public void Main()
        {
            int[] arr = new int[4] { 2, 1, 3, 4 };
            Array.Sort(arr); // исходный массив отсортируется. повлияет по ссылке

            var a1 = new C1 { Num = 1 }; // изменится при вызове ChanngeNum
            var res1 = a1.Num; // не изменится при вызове ChanngeNum
            ChangeNumByRef(a1);  // проверить корневой переданный объект
            ChangeNumByRef(a1); // проверить корневой переданный объект
            ChangeNumByIn(a1); // проверить корневой переданный объект

            
            std1.StudentName = "Bill";
            ChangeReferenceType(std1);

            /*
            String is a reference type, but it is immutable. It means once we assigned a value, it cannot be changed. 
            If we change a string value, then the compiler creates a new string object in the memory and point a variable to the new memory location. 
            So, passing a string value to a function will create a new variable in the memory, 
            and any change in the value in the function will not be reflected in the original value, as shown below.
             */
            string name = "Bill";
            ChangeReferenceTypeString(name);
        }

        private void ChangeReferenceType(Student std2)
        {
            std2.StudentName = "Steve";
            // std1.StudentName так же = "Steve";
        }

        void ChangeReferenceTypeString(string name)
        {
            name = "Steve";
            // исходный name всё равно изменился, а написано что нет. возможно другая версия языка
        }

        private void ChangeNumByRef(C1 c1) => c1.Num += 1; // передаём не сам класс С1, а ссылку на него

        // обязательно тип после in
        // эффект тот же как ChangeNumByRef. Слово in лишнее, т.к. и так ссылочный тип. смысл в нём?
        private void ChangeNumByIn(in C1 c1) => c1.Num += 1;

        private void ChangeNumValue(in int num) 
        { 
            //num += 1; // нельзя
        }

        // msdn
        void InArgExample(in int number)
        {
            // Uncomment the following line to see error CS8331
            //number = 19;
        }


    }
}
