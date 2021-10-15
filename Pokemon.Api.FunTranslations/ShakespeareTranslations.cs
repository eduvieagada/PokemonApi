using PokemonApi.FunTranslations.Models;
using PokemonApi.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PokemonApi.Core.Exceptions;

namespace PokemonApi.FunTranslations
{
    public class ShakespeareTranslations : FunTranslations
    {
        public ShakespeareTranslations(string baseUrl, IHttpClientFactory httpClientFactory) : base(baseUrl, httpClientFactory)
        {

        }
        public override TranslatorType Type => TranslatorType.Shakespeare;
        internal override Task<ApiResponse> MakeApiCall(string text, string url)
        {
            return base.MakeApiCall(text, $"{baseUrl}/shakespeare.json?text={text}");
        }
    }
}
