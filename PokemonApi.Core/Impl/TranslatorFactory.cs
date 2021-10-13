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
    }
}
