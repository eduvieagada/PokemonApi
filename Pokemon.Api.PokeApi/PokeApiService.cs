using PokemonApi.Core;
using System;
using System.Threading.Tasks;
using PokemonApi.Core.Dto;

namespace PokemonApi.PokeApi
{
    public class PokeApiService : IPokemonDataSource
    {
        public Task<Pokemon> FetchPokemon(string pokemonName)
        {
            throw new NotImplementedException();
        }
    }
}
