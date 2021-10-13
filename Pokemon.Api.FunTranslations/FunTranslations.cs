using PokemonApi.FunTranslations.Models;
using PokemonApi.Core;
using System;
using System.Net.Http;
using System.Threading.Tasks;

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
            var responseBody = await MakeApiCall(text);

            return responseBody.contents.translated;
        }

        internal abstract Task<ApiResponse> MakeApiCall(string text);
    }
}
