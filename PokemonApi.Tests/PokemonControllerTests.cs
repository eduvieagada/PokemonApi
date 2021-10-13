﻿using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using PokemonApi.Controllers;
using PokemonApi.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApi.Tests
{
    using static PokemonTestUtilities;
    [TestFixture]
    class PokemonControllerTests
    {
        private PokemonController _pokemonController;

        [SetUp]
        public void Setup()
        {
            _pokemonController = new PokemonController(GetLogger(), GetPokemonService());
        }

        [Test]
        public async Task GivenValidPokemonName_Return200Response()
        {
            var actionResult = await _pokemonController.GetPokemon("mewtwo");

            var result = actionResult as ObjectResult;

            result.StatusCode.Should().Be(200);
            result.Value.Should().BeOfType<Pokemon>();
        }

        [Test]
        public async Task GivenAnInvalidPokemonName_Return400Response()
        {
            var actionResult = await _pokemonController.GetPokemon("");

            var statusCodeResult = actionResult as ObjectResult;

            statusCodeResult.StatusCode.Should().Be(400);
        }
    }
}
