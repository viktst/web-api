using Domain.Interfaces;
using Domain.Models.Requests;
using Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly ILogger<ContactController> _logger;

        public ContactController(IContactService contactService, ILogger<ContactController> logger)
        {
            _contactService = contactService;
            _logger = logger;
        }

        [HttpPost("CreateContact")]
        public async Task<IActionResult> CreateContactAsync([FromBody] ContactDTO request)
        {
            try
            {
                _logger.LogInformation("Creating contact for {Company} in {Country}", request.CompanyId, request.CountryId);

                var contact = await _contactService.CreateContactAsync(request);

                _logger.LogInformation("Contact created with ID: {ContactId}", contact.Id);
                return Created(string.Empty, contact);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating contact.");
                return StatusCode(500, "Error creating contact.");
            }
        }

        [HttpGet("GetContacts")]
        public async Task<IActionResult> GetContacts()
        {
            try
            {
                var contacts = await _contactService.GetContactsAsync();
                return contacts?.Any() == true ? Ok(contacts) : LogAndReturnNotFound("No contacts found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving contacts.");
                return StatusCode(500, "Error retrieving contacts.");
            }
        }

        [HttpPost("UpdateContact")]
        public async Task<IActionResult> UpdateContactAsync(int id, [FromBody] ContactDTO request)
        {
            try
            {
                var contact = await _contactService.UpdateContactAsync(id, request);
                return contact != null ? Ok(contact) : LogAndReturnNotFound($"Contact ID {id} not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating contact.");
                return StatusCode(500, "Error updating contact.");
            }
        }

        [HttpPost("DeleteContact")]
        public async Task<IActionResult> DeleteContactAsync(int id)
        {
            try
            {
                await _contactService.DeleteContactAsync(id);
                _logger.LogInformation("Contact ID {ContactId} deleted.", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting contact.");
                return StatusCode(500, "Error deleting contact.");
            }
        }

        [HttpGet("FilterContact")]
        public async Task<IActionResult> FilterContact(int companyId, int countryId)
        {
            try
            {
                var contacts = await _contactService.FilterContactsAsync(companyId, countryId);
                return Ok(contacts);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error filtering contacts.");
                return StatusCode(500, "Error filtering contacts.");
            }
        }

        [HttpGet("GetContactsWithCompanyAndCountry")]
        public async Task<IActionResult> GetContactsWithCompanyAndCountry()
        {
            try
            {
                var contacts = await _contactService.GetContactsWithCompanyAndCountryAsync();
                return contacts?.Any() == true ? Ok(contacts) : LogAndReturnNotFound("No contacts found with company and country.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving contacts with company and country.");
                return StatusCode(500, "Error retrieving contacts with company and country.");
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
