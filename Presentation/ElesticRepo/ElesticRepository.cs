using autocomplete.Entity;
using autocomplete.TempData;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Nest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace autocomplete.ElesticRepo
{
    public class ElesticRepository
    {
        private IElasticClient _elasticClient;

        public readonly string hintWordIndex;
        public readonly string sectionWordIndex;

        public ElesticRepository(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
            hintWordIndex = "a" + typeof(HintWord).Name.ToLower();
            sectionWordIndex = "a" + typeof(HintSection).Name.ToLower();
        }


        public async Task<List<HintSection>> GetHintSections()
        {
            var result = await _elasticClient.SearchAsync<HintSection>(x => x.Index(sectionWordIndex));
            return result.Documents.ToList();
        }

        public async Task<List<HintWord>> GetAllHintWords(string pattern)
        {
            var result = await _elasticClient.SearchAsync<HintWord>(x =>
            x
            .Index(hintWordIndex)
            .Query(q =>
            q.Match(m => m.Field(f => f.Word).Query(pattern)))
            .Take(10)
            );
            return result.Documents.ToList();
        }

        public async Task<List<HintWord>> GetHintWordsBySection()
        {
            var result = await _elasticClient.SearchAsync<HintWord>(x => x.Index(sectionWordIndex));
            return result.Documents.ToList();
        }


        public async Task SaveSection(HintSection section)
        {
            var response = await _elasticClient.IndexAsync(section, x => x.Index(sectionWordIndex));
        }

        public async Task SaveHintWord(string sectionId, string title)
        {
            var hints = await GetSectionById(sectionId);
            var hintWords = new HintWord(hints, title);
            var response = await _elasticClient.IndexAsync(hintWords, x => x.Index(hintWordIndex));
        }

        public async Task<BulkResponse> LoadCitiesAsHints()
        {
            var section = (await GetHintSections()).FirstOrDefault();
            if (section is null)
            {
                section = new HintSection("hello world");
                await SaveSection(section);
            }

            var hints = Cities.GetHints(section);
            int bulkAmount = 10000;

            for (var i = 0; hints.Count > i; i += bulkAmount)
            {
                var selectedHints = hints.Skip(i).Take(bulkAmount).ToList();
                var response = _elasticClient.Bulk(x => x
                .Index(hintWordIndex)
                .IndexMany(selectedHints));
            }
            return null;
        }

        private async Task<HintSection> GetSectionById(string Id)
        {
            return (await _elasticClient.GetAsync<HintSection>(Id)).Source;
        }
    }
}
