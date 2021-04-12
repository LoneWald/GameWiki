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
    class AccountApiServises : ApiServises
    {

        public string _registerPath;
        public string _loginPath;

        public AccountApiServises()
            : base()
        {
            _registerPath = "api/Accounts/adds"; // adds для закоменченого
            _loginPath = "api/Accounts/auth";
        }

        public AccountApiServises(string registerPath, string loginPath)
            :base()
        {
            _registerPath = registerPath;
            _loginPath = loginPath;
        }

        // Регистрация
        public async Task<RegisterApiResponseModel> RegisterUserAsync(string email, string login, string password, string nickname)
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
                /*
                using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress + _registerPath);
                request.Headers.Add("email", registerRequestModel.Email);
                request.Headers.Add("login", registerRequestModel.Login);
                request.Headers.Add("password", registerRequestModel.Password);
                request.Headers.Add("nickname", registerRequestModel.Nickname);
                using HttpResponseMessage response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
                */
                
                var content = new StringContent(JsonConvert.SerializeObject(registerRequestModel), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(_registerPath, content);
                response.EnsureSuccessStatusCode();
                using (var stream = await response.Content.ReadAsStreamAsync())
                using (var reader = new StreamReader(stream))
                using (var json = new JsonTextReader(reader))
                {
                    var jsoncontent = _serialazer.Deserialize<RegisterApiResponseModel>(json);
                    return jsoncontent;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // Аунтефикация
        public async Task<LoginApiResponseModel> AuthenticateUserAsync(string login, string password)
        {
            try
            {
                LoginApiRequestModel loginRequestModel = new LoginApiRequestModel()
                {
                    Login = login,
                    Password = password
                };
                using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, client.BaseAddress + _loginPath);
                request.Headers.Add("login", loginRequestModel.Login);
                request.Headers.Add("password", loginRequestModel.Password);
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                using (var stream = await response.Content.ReadAsStreamAsync())
                using (var reader = new StreamReader(stream))
                using (var json = new JsonTextReader(reader))
                {
                    var jsoncontent = _serialazer.Deserialize<LoginApiResponseModel>(json);
                    return jsoncontent;
                }

                /*
                var responce = await client.GetAsync(_registerPath);
                responce.EnsureSuccessStatusCode();
                using (var stream = await responce.Content.ReadAsStreamAsync())
                using (var reader = new StreamReader(stream))
                using (var json = new JsonTextReader(reader))
                {
                    var jsoncontent = _serialazer.Deserialize<LoginApiResponceModel>(json);
                    return jsoncontent;
                }
                */
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
