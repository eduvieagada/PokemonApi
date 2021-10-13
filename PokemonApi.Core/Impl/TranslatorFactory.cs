using PokemonApi.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApi.Core.Impl
{
    public class TranslatorFactory
    {
        private readonly List<ITranslator> translators;

        public TranslatorFactory(List<ITranslator> translators)
        {
            this.translators = translators;
        }

        public ITranslator GetTranslator(TranslatorType translatorType)
        {
            return translators.First(t => t.Type == translatorType);
        }

        public ITranslator GetTranslator(Pokemon pokemon)
        {
            if (pokemon is null)
                throw new ArgumentNullException(nameof(pokemon));

            if (pokemon.Habitat.Equals("cave", StringComparison.OrdinalIgnoreCase) || pokemon.IsLegendary)
            {
                return GetTranslator(TranslatorType.Yoda);
            }

            return GetTranslator(TranslatorType.Shakespeare);
        }
    }
}
