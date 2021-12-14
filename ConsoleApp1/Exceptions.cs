using System;
using System.IO;
using System.Runtime.Serialization;

namespace ConsoleApp1
{
    public class Exceptions
    {
        private int[] arr = new int[] { 1, 2, 3 };

        public void Ex2()
        {
            //throw; // Ошибка CS0156  Оператор throw без аргументов не может использоваться вне предложения catch.

            //throw new Exception(); // можно тут

            // в catch  не попадёт, если в try нет исключения
            try
            {
                //throw new Exception(); // можно тут
            }
            catch
            {
                // без аргументов можно только тут - потому что известен тип исключения - можно узнать в (Exception e). 
                //С аргументами - везде. Можем бросить исключение любого типа
                throw; 
            }

            // разные комбинации catch и throw
            try
            {
                var item = arr[10];
            }
            //catch
            catch (Exception e)
            //catch (Exception)
            {
                // CLR сама автоматически определяет тип исключения. Скорее всего производительность тут меньше чем при явном вбросе исключения
                //throw; // System.IndexOutOfRangeException: "Индекс находился вне границ массива"
                
                // Принудительно бросаем искл-е
                throw new Exception(e.Message);// "Выдано исключение типа System.Exception"
                
                //throw new Exception();// "Выдано исключение типа System.Exception" ctrl+shift+space - посмотреть сигнатуры
                
                throw e; // System.IndexOutOfRangeException: "Индекс находился вне границ массива"
            }
        }

        //public ISerializable Ex3()
        //public Exception Ex3()
        public System.Runtime.InteropServices._Exception Ex3()
        {
            try
            {
                // просто вернёт исключение. не бросит. catch не сработает
                return new Exception("Исключение в Ex3");
            }
            catch
            {
                throw; // обязательно, как return
            }
        }
        
        public Exception ReturnNewException()
        {
             return new Exception("Исключение");
        }

        public void Ex4()
        {
            try
            {
                using (var sw = new StreamWriter(@"C:\test\test.txt"))
                {
                    sw.WriteLine("Hello");
                }
            }
            // Put the more specific exceptions first.
            // директории нет - т.е. сработает этот, а не catch (FileNotFoundException ex)
            catch (DirectoryNotFoundException ex)
            {
            }

            // далее catch-и обрабатываться не будут
            catch (FileNotFoundException ex) 
            {
            }
            
            // Put the least specific exception last.
            catch (IOException ex)
            {
            }
        }

        public void Ex5()
        {
            try
            {
                // catch не сработает т.к. это не IO exception
                //var a = arr[10];
            }
            catch (IOException) 
            {
            }
        }

        public void Ex6()
        {
            try
            {
                // catch сработает т.к. это общий exception
                // взятие элемента по несуществующему индексу под него попадает
                var a = arr[10];
            }
            catch (Exception)  // нет аргумента e - в этом случае не нужна информация об исключении
            {
            }
        }

        #region CustomException
        class CustomException : Exception
        {
            //public CustomException(string message)
            //public CustomException(string message) : base()
            public CustomException(string message) : base(message)
            //public CustomException() : base()
            {
            }
        }

        public void CustomExceptionEx()
        {
            // где в искл-и инфо о строке, переданной в конструктор?
            // если : base(message) - ConsoleApp1.Exceptions.CustomException: "Custom exception in TestThrow()" - скорее всего перекрываем базовое исключение своим сообщении об исключении, пробрасывая его в конструктор
            // иначе "Выдано исключение типа "ConsoleApp1.Exceptions+CustomException".". message не видно
            CustomException ex = new CustomException("Custom exception in TestThrow()");
            //CustomException ex = new CustomException();
            
            //throw ex;
        }
        #endregion

        public void TryCatchFinally()
        {
            try
            {
                throw new Exception();
            }
            catch
            {
                // сработает. почему тут нельзя освободить ресурсы?
            }
            finally
            {
                // сработает. корректное освобождение ресурсов
            }
        }

        void DeclarationConflicts()
        {
            // Почему нет конфликта имён?. видимо try/catch создаёт свои области видимости
            try
            {
                var a = 0;
            }
            catch
            {
                var b = 0; // в catch можно объявить переменные
            }

            try
            {
                var a = 0;
            }
            catch
            {
                var b = 0;
            }
        }
    }
}