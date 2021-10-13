using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PokemonApi.Core;
using PokemonApi.FunTranslations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PokemonApi.Dependencies
{
    public static class TranslatorsDependencyResolver
    {
        public static IServiceCollection AddShakespeareTranslator(this IServiceCollection services, IConfiguration configuration)
        {
            var baseUrl = configuration["FunTranslationsBaseUrl"] ?? 
                throw new InvalidOperationException("Unable to instantiate Shakespare translator)");

            using var scope = services.BuildServiceProvider().CreateScope();
            var httpClientFactory = scope.ServiceProvider.GetRequiredService<IHttpClientFactory>();

            services.AddScoped<ITranslator>(_ => new ShakespeareTranslations(baseUrl, httpClientFactory));

            return services;
        }

        public static IServiceCollection AddYodaTranslator(this IServiceCollection services, IConfiguration configuration)
        {
            var baseUrl = configuration["FunTranslationsBaseUrl"] ??
                throw new InvalidOperationException("Unable to instantiate Yoda translator)");

            using var scope = services.BuildServiceProvider().CreateScope();
            var httpClientFactory = scope.ServiceProvider.GetRequiredService<IHttpClientFactory>();

            services.AddScoped<ITranslator>(_ => new YodaTranslations(baseUrl, httpClientFactory));

            return services;
        }
    }
}
