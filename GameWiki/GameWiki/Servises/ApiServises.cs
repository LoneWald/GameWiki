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

        protected static ApiServises _ServiceClientInstance;
        public static ApiServises ServiceClientInstance
        {
            get
            {
                if (_ServiceClientInstance == null)
                    _ServiceClientInstance = new ApiServises();
                return _ServiceClientInstance;
            }
        }

        protected JsonSerializer _serialazer;
        protected static HttpClient client;

        public ApiServises()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://game-wiki-web-api.herokuapp.com/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _serialazer = new JsonSerializer();
        }

    }
}
