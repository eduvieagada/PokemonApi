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
    public class PokemonController : BaseController
    {
        private readonly IPokemonService _pokemonService;

        public PokemonController(ILogger<PokemonController> logger, IPokemonService pokemonService) : base(logger)
        {
            _pokemonService = pokemonService;
        }

        [HttpGet("{pokemonName}")]
        public async Task<IActionResult> GetPokemon(string pokemonName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(pokemonName))
                {
                    return BadRequest($"invalid pokemon name");
                }

                var pokemon = await _pokemonService.FetchPokemonData(pokemonName);


                return FormatResult(pokemon);
            }
            catch(Exception ex)
            {
                return LogAndFormatError(ex);
            }
        }

        [HttpGet("/translated/{pokemonName}")]
        public async Task<IActionResult> GetPokemonTranslated(string pokemonName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(pokemonName))
                {
                    return BadRequest($"invalid pokemon name");
                }

                var pokemon = await _pokemonService.FetchTranslatedPokemonData(pokemonName);

                return FormatResult(pokemon);
            }
            catch (Exception ex)
            {
                return LogAndFormatError(ex);
            }
        }

       
    }
}
