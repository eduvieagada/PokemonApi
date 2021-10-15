using Microsoft.Extensions.Logging;
using Moq;
using PokemonApi.Controllers;
using PokemonApi.Core;
using PokemonApi.Core.Dto;
using PokemonApi.Core.Exceptions;
using PokemonApi.Core.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApi.Tests
{
    using static It;
    static class PokemonTestUtilities
    {
        public static IPokemonDataSource FetchDataSource()
        {
            var mockPokemon = new Pokemon
            {
                Description = "It was created by\na scientist after\nyears of horrific\fgene splicing and\nDNA engineering\nexperiments.",
                Habitat = "rare",
                IsLegendary = true,
                Name = "mewtwo"
            };
            var mockPokemonDataSource = new Mock<IPokemonDataSource>();
            mockPokemonDataSource.Setup(m => m.FetchPokemon("mewtwo"))
                .ReturnsAsync(mockPokemon);
            mockPokemonDataSource.Setup(m => m.FetchPokemon(IsIn("pikachu", "", null)))
                .ThrowsAsync(new PokemonNotFoundException("pikachu"));

            return mockPokemonDataSource.Object;
        }

        public static TranslatorFactory GetTranslatorFactory()
        {
            var mockShakespareTranslator = new Mock<ITranslator>();
            mockShakespareTranslator.Setup(m => m.TranslateText("It was created by\\na scientist after\\nyears of horrific\\fgene splicing and\\nDNA engineering\\nexperiments."))
                .ReturnsAsync("'t wast did create by\\na scientist after\\nyears of horrific\\fgene splicing and\\ndna engineering\\nexperiments.");
            mockShakespareTranslator.Setup(m => m.Type)
                .Returns(TranslatorType.Shakespeare);

            var mockYodaTranslator = new Mock<ITranslator>();
            mockYodaTranslator.Setup(m => m.Type).Returns(TranslatorType.Yoda);
            mockYodaTranslator.Setup(m => m.TranslateText("It was created by\\na scientist after\\nyears of horrific\\fgene splicing and\\nDNA engineering\\nexperiments."))
                .ReturnsAsync("Created by\\na scientist after\\nyears of horrific\\fgene splicing and\\ndna engineering\\nexperiments,  it was.");

            return new TranslatorFactory(new List<ITranslator>
            {
                mockShakespareTranslator.Object, mockYodaTranslator.Object
            });
        }

        public static IPokemonService GetPokemonService()
        {
            var mockPokemonService = new Mock<IPokemonService>();
            mockPokemonService.Setup(m => m.FetchPokemonData("mewtwo"))
                .ReturnsAsync(new Pokemon
                {
                    Description = "It was created by\na scientist after\nyears of horrific\fgene splicing and\nDNA engineering\nexperiments.",
                    Habitat = "rare",
                    IsLegendary = true,
                    Name = "mewtwo"
                });

            mockPokemonService.Setup(m => m.FetchTranslatedPokemonData("mewtwo"))
                .ReturnsAsync(new Pokemon
                {
                    Description = "Created by\\na scientist after\\nyears of horrific\\fgene splicing and\\ndna engineering\\nexperiments,  it was.",
                    Habitat = "rare",
                    IsLegendary = true,
                    Name = "mewtwo"
                });

            mockPokemonService.Setup(m => m.FetchPokemonData(IsIn("pikachu")))
                .ThrowsAsync(new PokemonNotFoundException("pikachu"));

            mockPokemonService.Setup(m => m.FetchTranslatedPokemonData(IsIn("pikachu")))
                .ThrowsAsync(new PokemonNotFoundException("pikachu"));

            mockPokemonService.Setup(m => m.FetchPokemonData("eduvie"))
                .ThrowsAsync(new PokemonDataException());

            return mockPokemonService.Object;
        }

        public static ILogger<PokemonController> GetLogger() => new Mock<ILogger<PokemonController>>().Object;
    }
}
