using FluentAssertions;
using Moq;
using NUnit.Framework;
using PokemonApi.Core;
using PokemonApi.Core.Dto;
using PokemonApi.Core.Exceptions;
using PokemonApi.Core.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApi.Tests.Unit
{
    using static TestUtilities;
    [TestFixture]
    class PokemonServiceTests
    {
        private PokemonService pokemonService;

        [SetUp]
        public void Setup()
        {
            var pokemonDataSource = FetchDataSource();
            var translatorFactory = GetTranslatorFactory();

            pokemonService = new PokemonService(translatorFactory, pokemonDataSource);
        }

        [Test]
        public async Task GivenPokemonName_FetchPokemon()
        {
            var pokemon = await pokemonService.FetchPokemonData("mewtwo");

            pokemon.Should().NotBeNull();
            pokemon.Name.Should().Be("mewtwo");
            pokemon.Habitat.Should().Be("rare");
        }

        [Test]
        public async Task GivenInvalidPokemonName_ThrowException()
        {
            Assert.ThrowsAsync<PokemonNotFoundException>(async () => await pokemonService.FetchPokemonData("pikachu"));
        }
    }
}
