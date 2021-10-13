﻿using Pokemon.Api.FunTranslations.Models;
using PokemonApi.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Api.FunTranslations
{
    public class YodaTranslations : FunTranslations
    {
        public YodaTranslations(string baseUrl, IHttpClientFactory httpClientFactory) :base(baseUrl, httpClientFactory)
        {

        }
        public override TranslatorType Type => TranslatorType.Yoda;
        internal override Task<ApiResponse> MakeApiCall(string text)
        {
            var httpClient = httpClientFactory.CreateClient();

            httpClient.BaseAddress = new Uri(baseUrl);
            return httpClient.GetFromJsonAsync<ApiResponse>($"/yoda.json?text={text}");
        }
    }
}
