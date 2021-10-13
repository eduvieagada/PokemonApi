using PokemonApi.Core;
using System;
using System.Threading.Tasks;
using PokemonApi.Core.Dto;
using System.Net.Http;
using System.Net.Http.Json;
using PokemonApi.Core.Exceptions;
using System.Linq;

namespace PokemonApi.PokeApi
{
    public class PokeApiService : IPokemonDataSource
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly string baseUrl;

        public PokeApiService(IHttpClientFactory httpClientFactory, string baseUrl)
        {
            this.httpClientFactory = httpClientFactory;
            this.baseUrl = baseUrl;
        }

        public async Task<Core.Dto.Pokemon> FetchPokemon(string pokemonName)
        {
            var client = httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(baseUrl);

            var response = await client.GetFromJsonAsync<PokeApiResponse>($"/pokemon-species/{pokemonName}");

            if (response is null) throw new PokemonNotFoundException(pokemonName);

            return new Core.Dto.Pokemon
            {
                Name = response.name,
                Description = response.flavor_text_entries.FirstOrDefault()?.flavor_text,
                Habitat = response.habitat?.name,
                IsLegendary = response.is_legendary
            };
        }
    }
}
