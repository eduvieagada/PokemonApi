using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PokemonApi.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PokemonApi.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly ILogger _logger;
        public BaseController(ILogger logger)
        {
            _logger = logger;
        }
        protected IActionResult FormatResult(Pokemon pokemon) => pokemon is null ? NotFound() : Ok(pokemon);
        protected IActionResult LogAndFormatError(Exception ex)
        {
            _logger.LogError(ex.Message, ex);

            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }
}
