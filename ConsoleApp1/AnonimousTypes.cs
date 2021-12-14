namespace ConsoleApp1
{
    public class AnonimousTypes
    {
        public void Main() 
        {
            var v = new { Amount = 108, Message = "Hello" };

            // состав (набор полей и типы данных) д.б. одинаковым
            // Нельзя типизировать https://stackoverflow.com/questions/19388065/how-to-explicit-anonymous-declaration
            
            var anonArray = new[] 
            //object anonArray = new[] 
            //dynamic anonArray = new[] 
            { 
                new { name = "apple", diam = 4 }, 
                new { name = "grape", diam = 1 } 
            };

            //var apple = new { Item = "apples", Price = 1.35 };
            //var onSale = apple with { Price = 0.79 };

            var anonimousObjectVar = new { Id = 0, Name = "xxx" }; // создание анонимного объекта
            object anonimousObjectObject = new { Id = 0, Name = "xxx" };
            dynamic anonimousObjectDynamic = new { Id = 0, Name = "xxx" };
        }
    }
}
