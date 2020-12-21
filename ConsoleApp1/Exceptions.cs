using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace ConsoleApp1
{
    public class Exceptions
    {
        private int[] arr = new int[] { 1, 2, 3 };

        public void Ex1()
        {
            throw new Exception("Исключение в Ex1");
        }

        public void Ex2()
        {
            // ошибка компиляции. д.б. только в catch
            //throw;

            // в catch  не попадёт, т.к. в try ничего не происходит
            try
            {
            }
            catch
            {
                throw;
            }

            
            try
            {
                var item = arr[10];
            }
            catch
            {
                // CLR сама определяет тип исключения
                //throw; // System.IndexOutOfRangeException: "Индекс находился вне границ массива"
                
                // Принудительно бросаем искл-е
                //throw new Exception();// "Выдано исключение типа System.Exception"
            }

            try
            {
                var item = arr[10];
            }
            catch (Exception e)
            {
                throw e; // System.IndexOutOfRangeException: "Индекс находился вне границ массива"
            }

            try
            {
                var item = arr[10];
            }
            catch
            {
                // Принудительно бросаем искл-е
                throw new Exception();// "Выдано исключение типа System.Exception"
            }
        }

        public ISerializable Ex3()
        {
            try
            {
                // просто вернёт исключение. не бросит
                return new Exception("Исключение в Ex3");
            }
            catch
            {
                throw;
            }
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
                Console.WriteLine(ex);
            }
            // далее catch-и обрабатываться не будут
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex);
            }
            // Put the least specific exception last.
            catch (IOException ex)
            {
                Console.WriteLine(ex);
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
            public CustomException(string message)
            {
            }
        }

        public void CustomExceptionEx()
        {
            CustomException ex = new CustomException("Custom exception in TestThrow()");
            throw ex;
        }
        #endregion

        public void Ex7()
        { 
            try
            {
                var a = arr[10];
            }
            catch(Exception ex)
            {
                throw;
                throw ex;
                throw new Exception();
                throw new Exception("Exception raised");
            }
        }

        public void TryCatchFinally()
        {
            try
            {
                var a = arr[10];
                throw new Exception();
            }
            catch
            {
                // почему тут нельзя освободить ресурсы?
            }
            finally
            {
                // корректное освобождение ресурсов
            }
        }

        public void TryCatchFinallyException()
        {
            try
            {
                throw new Exception();
            }
            catch
            {
                // почему тут нельзя освободить ресурсы?
            }
            finally
            {
                // корректное освобождение ресурсов
            }
        }
    }
}