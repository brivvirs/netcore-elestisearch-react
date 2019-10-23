using autocomplete.ElesticRepo;
using autocomplete.Entity;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test
{
    public class ElesticTest
    {
        readonly IElasticClient _esInstance;
        readonly ElesticRepository _esRepo;
        public ElesticTest()
        {
            _esInstance = Resolvers.GetElesticSearchInstance("http://localhost:9200/", "aautocompeletehints");
            _esRepo = new ElesticRepository(_esInstance);
        }


        [Fact]
        public async Task RemoveAll()
        {
            var result = _esInstance.DeleteIndex(new DeleteIndexRequest(_esRepo.sectionWordIndex));
            result = _esInstance.DeleteIndex(new DeleteIndexRequest(_esRepo.hintWordIndex));
        }

        [Fact]
        public async Task GetAllWords()
        {
            var sections = await _esRepo.GetHintSections();
            var items = await _esRepo.GetAllHintWords("hello");
        }

        [Fact]
        public async Task LoadData()
        {
            await _esRepo.LoadCitiesAsHints();
        }
    }
}
