using Domain.Models.Requests;
using Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly ILogger<CompanyController> _logger;

        // Constructor to inject ICompanyService and ILogger
        public CompanyController(ICompanyService companyService, ILogger<CompanyController> logger)
        {
            _companyService = companyService;
            _logger = logger;
        }

        [HttpPost("CreateCompany")]
        public async Task<IActionResult> CreateCompanyAsync([FromBody] CompanyDTO request)
        {
            try
            {
                _logger.LogInformation("Creating company: {Name}", request.Name);

                var company = await _companyService.CreateCompanyAsync(request);

                _logger.LogInformation("Company created with ID: {CompanyId}", company.CompanyId);

                return Created(string.Empty, company);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating company.");
                return StatusCode(500, "Error creating company.");
            }
        }

        [HttpGet("GetCompanies")]
        public async Task<IActionResult> GetCompanies()
        {
            try
            {
                var companies = await _companyService.GetCompaniesAsync();

                return companies?.Any() == true
                    ? Ok(companies)
                    : LogAndReturnNotFound("No companies found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving companies.");
                return StatusCode(500, "Error retrieving companies.");
            }
        }

        [HttpPost("UpdateCompany")]
        public async Task<IActionResult> UpdateCompanyAsync(int id, [FromBody] CompanyDTO request)
        {
            try
            {
                var company = await _companyService.UpdateCompanyAsync(id, request);

                return company != null
                    ? Ok(company)
                    : LogAndReturnNotFound($"Company ID {id} not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating company.");
                return StatusCode(500, "Error updating company.");
            }
        }

        [HttpPost("DeleteCompany")]
        public async Task<IActionResult> DeleteCompanyAsync(int id)
        {
            try
            {
                await _companyService.DeleteCompanyAsync(id);

                _logger.LogInformation("Company {CompanyId} deleted.", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting company.");
                return StatusCode(500, "Error deleting company.");
            }
        }

        // Helper method to log and return NotFound
        private IActionResult LogAndReturnNotFound(string message)
        {
            _logger.LogWarning(message);
            return NotFound();
        }
    }
}
