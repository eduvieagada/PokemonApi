using Microsoft.Extensions.Logging;
using PokemonApi.Core.Dto;
using PokemonApi.Core.Exceptions;
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
        private readonly ILogger<PokemonService> logger;

        public PokemonService(TranslatorFactory translatorFactory,
            IPokemonDataSource pokemonDataSource, ILogger<PokemonService> logger)
        {
            this.translatorFactory = translatorFactory;
            this.pokemonDataSource = pokemonDataSource;
            this.logger = logger;
        }

        public Task<Pokemon> FetchPokemonData(string pokemonName)
        {
            return pokemonDataSource.FetchPokemon(pokemonName) ?? throw new PokemonNotFoundException(nameof(pokemonName));
        }

        public async Task<Pokemon> FetchTranslatedPokemonData(string pokemonName)
        {
            var pokemon = await pokemonDataSource.FetchPokemon(pokemonName) ?? throw new PokemonNotFoundException(nameof(pokemonName));

            var translator = translatorFactory.GetTranslator(pokemon);

            try
            {
                var translatedDescription = await translator.TranslateText(pokemon.Description);
                pokemon.Description = translatedDescription is not null ? translatedDescription : pokemon.Description;
            }
            catch (TranslationException ex)
            {
                logger.LogError(ex.Message, ex);
            }

            return pokemon;
        }
    }
}
