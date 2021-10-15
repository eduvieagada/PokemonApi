using FluentAssertions;
using NUnit.Framework;
using PokemonApi.Core.Exceptions;
using PokemonApi.PokeApi;
using PokemonApi.Tests.TestUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApi.Tests
{
    using static MockHttpClientFactory;
    [TestFixture]
    class PokeApiTests
    {
        [Test]
        public async Task GivenPokemonname_Return_PokemonData_FromApi()
        {
            var pokeApiService = new PokeApiService(AddMockHttpClientFactory(), "https://pokeapi.co/api/v2");
            var pokemon = await pokeApiService.FetchPokemon("mewtwo");

            pokemon.Should().NotBeNull();
            pokemon.Name.Should().Be("mewtwo");
            pokemon.IsLegendary.Should().BeTrue();
        }

        [Test]
        public void GivenInvalidPokemonName_ThrowPokemonNotFoundException()
        {
            var pokeApiService = new PokeApiService(AddMockHttpClientFactory(), "https://pokeapi.co/api/v2");

            Assert.ThrowsAsync<PokemonNotFoundException>(async () => await pokeApiService.FetchPokemon("eduvie"));
        }

        [Test]
        public void Given500ResponseFromApi_ThrowPokemonDataException()
        {
            var pokeApiService = new PokeApiService(AddUnavailableApi(), "https://pokeapi.co/api/v2");

            Assert.ThrowsAsync<PokemonDataException>(async () => await pokeApiService.FetchPokemon("mewtwo"));
        }
    }
}
