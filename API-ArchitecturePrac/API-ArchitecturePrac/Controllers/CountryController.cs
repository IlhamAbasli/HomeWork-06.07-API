using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Countries;
using Service.Services.Interfaces;

namespace API_ArchitecturePrac.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;
        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CountryCreateDto request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _countryService.Create(request);
            return CreatedAtAction(nameof(Create), new { response = "Success" });
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _countryService.GetAllAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] int? id)
        {
            if (id is null) return BadRequest();

            var existData = await _countryService.GetByIdAsync((int)id);

            if (existData is null) return NotFound();

            return Ok(existData);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllWithCities()
        {
            return Ok(await _countryService.GetAllWithCities());
        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int? id)
        {
            if (id is null) return BadRequest();

            await _countryService.DeleteAsync((int)id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] CountryEditDto request)
        {
            await _countryService.EditAsync(id, request);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetByNameWithCities([FromQuery] string name)
        {
            return Ok(await _countryService.GetCountryByNameWithCities(name));
        }
    }
}
