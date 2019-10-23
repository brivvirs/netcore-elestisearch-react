using autocomplete.ElesticRepo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace autocomplete.Controllers
{
    [Route("hints")]
    public class AutocompleteController : Controller
    {
        readonly ElesticRepository _esRepo;
        public AutocompleteController(ElesticRepository esRepo)
        {
            _esRepo = esRepo;
        }

        [HttpGet("sections")]
        public async Task<IActionResult> GetSections()
        {
            return Ok(await _esRepo.GetHintSections());
        }

        [HttpGet("getwords/{sectionId}/{pattern}")]
        public async Task<IActionResult> GetHintWords(string sectionId, string pattern)
        {
            return Ok(await _esRepo.GetAllHintWords(pattern));
        }

        [HttpPost("add/section/{title}")]
        public async Task<IActionResult> AddSection(string title)
        {
            await _esRepo.SaveSection(new Entity.HintSection(title));
            return Ok();
        }

        [HttpPost("add/word/{sectionId}/{word}")]
        public async Task<IActionResult> AddSection(string sectionId, string word)
        {
            await _esRepo.SaveHintWord(sectionId, word);
            return Ok();
        }

        [HttpGet("init")]
        public async Task<IActionResult> LoadInitialData()
        {
            return Ok(await _esRepo.LoadCitiesAsHints());
        }
    }
}
