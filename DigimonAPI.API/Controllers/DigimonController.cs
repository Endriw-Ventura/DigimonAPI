using DigimonAPI.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DigimonAPI.APÍ.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DigimonController : ControllerBase
    {
        private readonly IDigimonService _digimonService;

        public DigimonController(IDigimonService digimonService)
        {
            _digimonService = digimonService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDigimons()
        {
            var digimons = await _digimonService.GetAllDigimons();
            return Ok(digimons);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetDigimonByName(string name)
        {
           var digimon = await _digimonService.GetDigimonByName(name);
            if (digimon is null)
                return NotFound();

            return Ok(digimon);
        }

        [HttpGet("level/{level}")]
        public async Task<IActionResult> GetDigimonByLevel(string level)
        {
            var digimons = await _digimonService.GetDigimonsByLevel(level);
            return Ok(digimons);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetDigimonBySearchBar([FromQuery] string search)
        {
            var digimons = await _digimonService.GetDigimonsBySeachBar(search);
            return Ok(digimons);
        }
    }
}
