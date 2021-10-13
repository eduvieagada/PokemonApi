using PokemonApi.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApi.Core
{
    public interface IPokemonDataSource
    {
        public Task<Pokemon> FetchPokemon(string pokemonName);
    }
}
