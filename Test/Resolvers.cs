using autocomplete.Entity;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public static class Resolvers
    {
        public static ElasticClient GetElesticSearchInstance(string url, string index)
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
            return client;

        }
    }
}
