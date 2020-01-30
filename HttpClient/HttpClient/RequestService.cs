using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientApp
{
    public class RequestService
    {
        public async Task<string> SignUp(string login, string password)
        {
            var json = JsonConvert.SerializeObject(new User { Login = login, Password = password });
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "http://localhost/user/signup";
            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(url, data);
                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        return "Аккаунт создан";
                    case HttpStatusCode.Forbidden:
                        return "Пользователь существует";
                    case HttpStatusCode.NotFound:
                        return "Пользователь не найден";
                    default: return "Ошибка!";
                }
            }
        }

        public async Task<string> SignIn(string login, string password)
        {
            var json = JsonConvert.SerializeObject(new User { Login = login, Password = password });
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "http://localhost/user/auth";
            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(url, data);
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return "Вы авторизированы!";
                    case HttpStatusCode.Forbidden:
                        return "Пользователь существует";
                    case HttpStatusCode.NotFound:
                        return "Пользователь с такими данными не найден!";
                    default: return "Ошибка!";
                }
            }
        }
    }
}
