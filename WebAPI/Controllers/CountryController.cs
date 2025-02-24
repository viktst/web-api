using Domain.Models.Requests;
using Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;
        private readonly ILogger<CountryController> _logger;

        public CountryController(ICountryService countryService, ILogger<CountryController> logger)
        {
            _countryService = countryService;
            _logger = logger;
        }

        [HttpPost("CreateCountry")]
        public async Task<IActionResult> CreateCountryAsync([FromBody] CountryDTO request)
        {
            try
            {
                _logger.LogInformation("Creating country: {CountryName}", request.Name);
                var country = await _countryService.CreateCountryAsync(request);
                _logger.LogInformation("Country created with ID: {CountryId}", country.CountryId);
                return Created(string.Empty, country);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating country.");
                return StatusCode(500, "Error creating country.");
            }
        }

        [HttpGet("GetCountries")]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var countries = await _countryService.GetCountriesAsync();
                return countries?.Any() == true ? Ok(countries) : LogAndReturnNotFound("No countries found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving countries.");
                return StatusCode(500, "Error retrieving countries.");
            }
        }

        [HttpPost("UpdateCountry")]
        public async Task<IActionResult> UpdateCountryAsync(int id, [FromBody] CountryDTO request)
        {
            try
            {
                var country = await _countryService.UpdateCountryAsync(id, request);
                return country != null ? Ok(country) : LogAndReturnNotFound($"Country ID {id} not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating country.");
                return StatusCode(500, "Error updating country.");
            }
        }

        [HttpPost("DeleteCountry")]
        public async Task<IActionResult> DeleteCountryAsync(int id)
        {
            try
            {
                await _countryService.DeleteCountryAsync(id);
                _logger.LogInformation("Country {CountryId} deleted.", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting country.");
                return StatusCode(500, "Error deleting country.");
            }
        }

        private IActionResult LogAndReturnNotFound(string message)
        {
            _logger.LogWarning(message);
            return NotFound();
        }
    }
}
