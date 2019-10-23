using autocomplete.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace autocomplete.Extensions
{
    public static class ElasticsearchExtensions
    {
        public static void AddElasticsearch(
            this IServiceCollection services, string url, string index)
        {
            var settings = new ConnectionSettings(new Uri(url))
                .DefaultIndex(index)
                .DefaultMappingFor<HintSection>(m => m
                    .Ignore(p => p.CreatedOn)
                    .PropertyName(p => p.Id, "id")
                )
                .DefaultMappingFor<HintWord>(m => m
                    .PropertyName(c => c.Id, "id")
                );

            var client = new ElasticClient(settings);

            services.AddSingleton<IElasticClient>(client);
        }
    }
}
