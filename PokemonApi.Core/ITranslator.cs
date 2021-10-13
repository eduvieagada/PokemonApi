using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApi.Core
{
    public interface ITranslator
    {
        public TranslatorType Type { get; }
        public Task<string> TranslateText(string text);
    }
}
