using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var requestService = new RequestService();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1 - Регистрация");
                Console.WriteLine("2 - Авторизация");
                Console.Write("Выбрать: ");
                var choose = Console.ReadLine();
                Console.Write("Login: ");
                var log = Console.ReadLine();
                Console.Write("Password: ");
                var pas = Console.ReadLine();
                switch (choose)
                {
                    case "1":
                        Console.WriteLine(await requestService.SignUp(log, pas));
                        break;
                    case "2":
                        Console.WriteLine(await requestService.SignIn(log,pas));
                        break;
                    default:
                        Console.WriteLine("Am I joke to you?");
                        break;
                }
                Console.ReadKey();
            }
        }

    }
}
