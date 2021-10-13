using PokemonApi.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApi.Core
{
    public interface IPokemonService
    {
        public Task<Pokemon> FetchPokemonData(string pokemonName);
        public Task<Pokemon> FetchTranslatedPokemonData(string pokemonName);

    }
}
