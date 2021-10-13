using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PokemonApi.Core;
using PokemonApi.PokeApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PokemonApi.Dependencies
{
    public static class PokemonDataSourceDependencyResolver
    {
        public static IServiceCollection AddPokeApi(this IServiceCollection services, IConfiguration configuration)
        {
            var baseUrl = configuration["PokeApi"] ??
                throw new InvalidOperationException("Unable to instantiate Pokemon data source)");

            using var scope = services.BuildServiceProvider().CreateScope();
            var httpClientFactory = scope.ServiceProvider.GetRequiredService<IHttpClientFactory>();

            services.AddScoped<IPokemonDataSource>(_ => new PokeApiService(httpClientFactory, baseUrl));

            return services;
        }
    }
}
