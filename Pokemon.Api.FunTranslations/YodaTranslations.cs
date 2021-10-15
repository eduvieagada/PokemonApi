using PokemonApi.FunTranslations.Models;
using PokemonApi.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using PokemonApi.Core.Exceptions;
using Newtonsoft.Json;

namespace PokemonApi.FunTranslations
{
    public class YodaTranslations : FunTranslations
    {
        public YodaTranslations(string baseUrl, IHttpClientFactory httpClientFactory) :base(baseUrl, httpClientFactory)
        {

        }
        public override TranslatorType Type => TranslatorType.Yoda;
        internal override Task<ApiResponse> MakeApiCall(string text, string url)
        {
            return base.MakeApiCall(text, $"{baseUrl}/yoda.json?text={text}");
        }
    }
}
