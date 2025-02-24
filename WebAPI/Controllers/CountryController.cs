using Domain.Models.Requests;
using Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService) => _countryService = countryService;

        [HttpPost("CreateCountry")]
        public async Task<IActionResult> CreateCountryAsync([FromBody] CountryDTO request) =>
            Created(string.Empty, await _countryService.CreateCountryAsync(request));

        [HttpGet("GetCountries")]
        public async Task<IActionResult> GetCountries()
        {
            var countries = await _countryService.GetCountriesAsync();
            return countries?.Any() == true ? Ok(countries) : NotFound();
        }

        [HttpPost("UpdateCountry")]
        public async Task<IActionResult> UpdateCountryAsync(int id, [FromBody] CountryDTO request) =>
            await _countryService.UpdateCountryAsync(id, request) is var country && country != null ? Ok(country) : NotFound();

        [HttpPost("DeleteCountry")]
        public async Task<IActionResult> DeleteCountryAsync(int id)
        {
            await _countryService.DeleteCountryAsync(id);
            return NoContent();
        }
    }
}
