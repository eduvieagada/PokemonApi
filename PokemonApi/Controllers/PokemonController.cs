using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PokemonApi.Core;
using PokemonApi.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly ILogger<PokemonController> _logger;
        private readonly IPokemonService _pokemonService;

        public PokemonController(ILogger<PokemonController> logger, IPokemonService pokemonService)
        {
            _logger = logger;
            _pokemonService = pokemonService;
        }

        [HttpGet("{pokemonName}")]
        public async Task<IActionResult> GetPokemon(string pokemonName)
        {
            if (string.IsNullOrWhiteSpace(pokemonName))
            {
                return BadRequest($"invalid pokemon name");
            }

            var pokemon = await _pokemonService.FetchPokemonData(pokemonName);


            return FormatResult(pokemon);
        }

        [HttpGet("/translated/{pokemonName}")]
        public async Task<IActionResult> GetPokemonTranslated(string pokemonName)
        {
            if (string.IsNullOrWhiteSpace(pokemonName))
            {
                return BadRequest($"invalid pokemon name");
            }

            var pokemon = await _pokemonService.FetchTranslatedPokemonData(pokemonName);

            return FormatResult(pokemon);
        }

        private IActionResult FormatResult(Pokemon pokemon) => pokemon is null ? NotFound() : Ok(pokemon);
    }
}
