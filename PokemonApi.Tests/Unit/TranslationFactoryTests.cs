using FluentAssertions;
using NUnit.Framework;
using PokemonApi.Core;
using PokemonApi.Core.Dto;
using PokemonApi.Core.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApi.Tests
{
    using static PokemonTestUtilities;
    [TestFixture]
    class TranslationFactoryTests
    {
        private TranslatorFactory _factory;

        [SetUp]
        public void Setup()
        {
            _factory = GetTranslatorFactory();
        }

        [Test]
        public void GivenTranslators_ReturnYodaTranslator()
        {
            var translator = _factory.GetTranslator(TranslatorType.Yoda);

            translator.Should().NotBeNull();
            translator.Type.Should().Be(TranslatorType.Yoda);
        }

        [Test]
        public void GivenPokemon_ReturnTranslator()
        {
            var pokemon = new Pokemon
            {
                Description = "test description",
                Habitat = "rare",
                IsLegendary = false,
                Name = "Dragonite"
            };

            var translator = _factory.GetTranslator(pokemon);

            translator.Should().NotBeNull();
            translator.Type.Should().Be(TranslatorType.Shakespeare);
        }

        [Test]
        public void GivenNullPokemon_ThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => _factory.GetTranslator(null));
        }
    }
}
