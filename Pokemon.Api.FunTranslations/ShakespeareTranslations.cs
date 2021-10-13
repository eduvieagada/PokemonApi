using PokemonApi.FunTranslations.Models;
using PokemonApi.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApi.FunTranslations
{
    class ShakespeareTranslations : FunTranslations
    {
        public ShakespeareTranslations(string baseUrl, IHttpClientFactory httpClientFactory) : base(baseUrl, httpClientFactory)
        {

        }
        public override TranslatorType Type => TranslatorType.Shakespeare;
        internal override Task<ApiResponse> MakeApiCall(string text)
        {
            var httpClient = httpClientFactory.CreateClient();

            httpClient.BaseAddress = new Uri(baseUrl);
            return httpClient.GetFromJsonAsync<ApiResponse>($"/shakespeare.json?text={text}");
        }
    }
}
