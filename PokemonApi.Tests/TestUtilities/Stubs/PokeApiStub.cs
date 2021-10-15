using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApi.Tests.TestUtilities.Stubs
{
    static class PokeApiStub
    {
        public static string MewTwoData()
        {
            string workDirectory = TestContext.CurrentContext.WorkDirectory;
            return File.ReadAllText($"{workDirectory}/TestUtilities/Stubs/mewtwo.json");
        }
    }
}
