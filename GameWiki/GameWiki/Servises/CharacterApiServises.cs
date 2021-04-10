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

    class CharacterApiServises : ApiServises
    {

        public string _selectAllPath;

        public CharacterApiServises()
            : base()
        {
            _selectAllPath = "api/Characters";
        }

        public CharacterApiServises(string selectAllPath)
            : base()
        {
            _selectAllPath = selectAllPath;
        }

        public async Task<string> SelectCharactersUserAsync()
        {
            try
            {

                using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, client.BaseAddress + _selectAllPath);
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
