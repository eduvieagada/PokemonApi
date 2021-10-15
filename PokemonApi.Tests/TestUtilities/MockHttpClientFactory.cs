using Moq;
using Moq.Contrib.HttpClient;
using PokemonApi.Tests.TestUtilities.Stubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApi.Tests.TestUtilities
{
    static class MockHttpClientFactory
    {
        public static IHttpClientFactory AddMockHttpClientFactory()
        {
            var handler = new Mock<HttpMessageHandler>();
            handler.SetupRequest(HttpMethod.Get, "https://pokeapi.co/api/v2/pokemon-species/mewtwo")
                .ReturnsResponse(HttpStatusCode.OK, PokeApiStub.MewTwoData(), "application/json");

            handler.SetupRequest(HttpMethod.Get, "https://pokeapi.co/api/v2/pokemon-species/eduvie")
                .ReturnsResponse(HttpStatusCode.NotFound);

            return handler.CreateClientFactory();
        }

        public static IHttpClientFactory AddUnavailableApi()
        {
            var handler = new Mock<HttpMessageHandler>();
            handler.SetupRequest(HttpMethod.Get, "https://pokeapi.co/api/v2/pokemon-species/mewtwo")
                .ReturnsResponse(HttpStatusCode.ServiceUnavailable);

            return handler.CreateClientFactory();
        }
    }
}
