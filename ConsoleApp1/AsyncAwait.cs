﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.IO;
using System.Threading;

namespace ConsoleApp1
{
    /* 
    ВОПРОСЫ

    var awaiter = response.GetAwaiter();            
    так работает. 
            
    TaskAwaiter<WebResponse> awaiter = response.GetAwaiter();
    если явно типизировать, то требует сборку. Навести мышью и можно применить сборку. Почему с var сборку можно не применять?

    -------------------------------

    Task использует поток?

    -------------------------------

    Is Task a thread

    -------------------------------

    Visual C#: Thread.Sleep vs. Task.Delay 

    -------------------------------

    a) var task = MethodA(123); b) await task;
    Сколько секунд будет выполняться метод? Ответ: 5
    Каак сделать, чтобы метод выполнился мгновенно? Что нужно изменить в MethodA
    
    //MainAsync(args).GetAwaiter().GetResult();
    //Delay();
    */

    class AsyncAwait
    {
        public async Task MethodA(double val)
        {
            var res = Math.Sin(val); // let's assume it takes 5sec
            //await httpClient.Post(...); // let's assume it takes 2sec
        }

        public void HttpRequest()
        {
            string remoteUrl = string.Format("http://city-move.ru/");
            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(remoteUrl);
            WebResponse response = httpRequest.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string result = reader.ReadToEnd();
        }

        public async Task HttpRequestAsync()
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

            StreamReader reader = new StreamReader(response.Result.GetResponseStream());
            StreamReader reader2 = new StreamReader(response.GetAwaiter().GetResult().GetResponseStream());

            var awaiter1 = response.GetAwaiter();

            string result = reader.ReadToEnd();
        }

        public async Task<int> TaskDelay()
        {
            CancellationTokenSource source = new CancellationTokenSource();


            // Эквивалентный код
            var t = Task.Run(async delegate
            {
                await Task.Delay(TimeSpan.FromSeconds(5), source.Token);
                return 100;
            });

            await Task.Run(async () =>      // 1
            {
                await Task.Delay(5000);     
                var stop1 = true;           // 2. через 5 сек
            });
            var stop2 = true;               // 3. сразу же


            Action action = async delegate
            {
                await Task.Delay(TimeSpan.FromSeconds(5), source.Token);
            };
            var t2 = Task.Run(action);

            var t4 = Task.Run(async () => // сразу после этой строки код пойдёт дальше. через 5 сек сработает колбэк
            {
                await Task.Delay(5000);
                var t4_stop = true; // сработает через 5 сек
            });

            var t5 = Task.Run(() => Task.Delay(5000));

            // чем отличаются эти 2 строки?
            Task.Run(() => Task.Delay(5000)); // код доходит до этой строки. следующая строка выполняется тут же, т.к. нет await. смысла в этой строки нет
            await Task.Run(() => Task.Delay(5000));  // при прохождении этой точки код сюда должен вернуться через 5 сек. почему-то не возвращается
            Task.Delay(5000); // код доходит до этой строки. следующая строка выполняется тут же, т.к. нет await. смысла в этой строки нет
            await Task.Delay(5000); // код доходит до этой строки. следующая строка пройдёт через 5 сек, т.к. await



            //var t6 = Task.Run(async () => Task.Delay(5000)); // Тут же сработает следующая строка кода (т.к. нет await)

            //var t7 = Task.Delay(5000); // возвращает Task. Тут же сработает следующая строка кода.




            //t.Wait();
            //var t1_stop = t.Result; // 100 через 5 сек

            //t2.Wait();
            //var t2_stop = t2; // через 10 сек

            //t5.Wait(); // задача завершится, несмотря на то, что нет async и await
            //var t5_stop = true;

            //t6.Wait(); // задача завершится, несмотря на то, что нет await
            //var t6_stop = true;


            var tx = Task.Run(async () => await Task.Yield());

            return 5;
        }

    }
}