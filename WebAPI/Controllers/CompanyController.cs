using Domain.Models.Requests;
using Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService) => _companyService = companyService;

        [HttpPost("CreateCompany")]
        public async Task<IActionResult> CreateCompanyAsync([FromBody] CompanyDTO request) =>
            Created(string.Empty, await _companyService.CreateCompanyAsync(request));

        [HttpGet("GetCompanies")]
        public async Task<IActionResult> GetCompanies()
        {
            var companies = await _companyService.GetCompaniesAsync();
            return companies?.Any() == true ? Ok(companies) : NotFound();
        }

        [HttpPost("UpdateCompany")]
        public async Task<IActionResult> UpdateCompanyAsync(int id, [FromBody] CompanyDTO request) =>
            await _companyService.UpdateCompanyAsync(id, request) is var company && company != null ? Ok(company) : NotFound();

        [HttpPost("DeleteCompany")]
        public async Task<IActionResult> DeleteCompanyAsync(int id)
        {
            await _companyService.DeleteCompanyAsync(id);
            return NoContent();
        }
    }
}
