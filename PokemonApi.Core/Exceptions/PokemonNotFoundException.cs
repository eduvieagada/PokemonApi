﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApi.Core.Exceptions
{
    public class PokemonNotFoundException : ArgumentNullException
    {
        public PokemonNotFoundException(string pokemonName) : base(pokemonName)
        {

        }
    }
}
