using PokemonApi.FunTranslations.Models;
using PokemonApi.Core;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using PokemonApi.Core.Exceptions;
using Newtonsoft.Json;

namespace PokemonApi.FunTranslations
{
    public abstract class FunTranslations : ITranslator
    {
        protected readonly string baseUrl;
        protected readonly IHttpClientFactory httpClientFactory;

        public virtual TranslatorType Type => throw new NotImplementedException();
        public FunTranslations(string baseUrl, IHttpClientFactory httpClientFactory)
        {
            this.baseUrl = baseUrl;
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<string> TranslateText(string text)
        {
            var responseBody = await MakeApiCall(text, null);

            return responseBody.contents.translated;
        }

        internal virtual async Task<ApiResponse> MakeApiCall(string text, string url) 
        {
            var httpClient = httpClientFactory.CreateClient();

            var httpResponseMessage = await httpClient.GetAsync($"{baseUrl}/yoda.json?text={text}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var content = await httpResponseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ApiResponse>(content);
            }

            throw new TranslationException();
        }
    }
}
