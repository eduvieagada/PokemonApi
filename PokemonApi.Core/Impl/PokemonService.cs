using PokemonApi.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApi.Core.Impl
{
    public class PokemonService : IPokemonService
    {
        private readonly TranslatorFactory translatorFactory;
        private readonly IPokemonDataSource pokemonDataSource;

        public PokemonService(TranslatorFactory translatorFactory, IPokemonDataSource pokemonDataSource)
        {
            this.translatorFactory = translatorFactory;
            this.pokemonDataSource = pokemonDataSource;
        }

        public Task<Pokemon> FetchPokemonData(string pokemonName)
        {
            return pokemonDataSource.FetchPokemon(pokemonName);
        }

        public async Task<Pokemon> FetchTranslatedPokemonData(string pokemonName)
        {
            var pokemon = await pokemonDataSource.FetchPokemon(pokemonName);

            var translator = translatorFactory.GetTranslator(pokemon);

            var translatedDescription = await translator.TranslateText(pokemon.Description);
            pokemon.Description = translatedDescription is not null ? translatedDescription : pokemon.Description;

            return pokemon;
        }
    }
}
