using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using GameWiki.Models.Register;
using System.IO;
using Xamarin.Essentials;
using GameWiki.Models.Login;

namespace GameWiki.Servises
{
    public class ApiServises
    {

        private static ApiServises _ServiceClientInstance;
        public static ApiServises ServiceClientInstance
        {
            get
            {
                if (_ServiceClientInstance == null)
                    _ServiceClientInstance = new ApiServises();
                return _ServiceClientInstance;
            }
        }

        private JsonSerializer _serialazer = new JsonSerializer();
        private HttpClient client;

        public ApiServises()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://game-wiki-web-api.herokuapp.com/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        // Регистрация
        public async Task<LoginApiResponseModel> RegisterUserAsync(string email, string login, string password, string nickname)
        {
            try
            {
                RegisterApiRequestModel registerRequestModel = new RegisterApiRequestModel()
                {
                    Email = email,
                    Login = login,
                    Password = password,
                    Nickname = nickname
                };
                var content = new StringContent(JsonConvert.SerializeObject(registerRequestModel), Encoding.UTF8, "application/json");
                var responce = await client.PostAsync("api/Accounts/add", content);
                responce.EnsureSuccessStatusCode();
                using (var stream = await responce.Content.ReadAsStreamAsync())
                using (var reader = new StreamReader(stream))
                using (var json = new JsonTextReader(reader))
                {
                    var jsoncontent = _serialazer.Deserialize<LoginApiResponseModel>(json);
                    return jsoncontent;
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        // Аунтефикация
        public async Task<string> AuthenticateUserAsync(string login, string password)
        {
            try
            {
                LoginApiRequestModel loginRequestModel = new LoginApiRequestModel()
                {
                    Login = login,
                    Password = password
                };
                using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, client.BaseAddress + "api/Accounts/auth");
                request.Headers.Add("login", loginRequestModel.Login);
                request.Headers.Add("password", loginRequestModel.Password);
                using HttpResponseMessage response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
