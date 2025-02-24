using Domain.Interfaces;
using Domain.Models.Requests;
using Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService) => _contactService = contactService;

        [HttpPost("CreateContact")]
        public async Task<IActionResult> CreateContactAsync([FromBody] ContactDTO request) =>
            Created(string.Empty, await _contactService.CreateContactAsync(request));

        [HttpGet("GetContacts")]
        public async Task<IActionResult> GetContacts()
        {
            var contacts = await _contactService.GetContactsAsync();
            return contacts?.Any() == true ? Ok(contacts) : NotFound();
        }

        [HttpPost("UpdateContact")]
        public async Task<IActionResult> UpdateContactAsync(int id, [FromBody] ContactDTO request) =>
            await _contactService.UpdateContactAsync(id, request) is var contact && contact != null ? Ok(contact) : NotFound();

        [HttpPost("DeleteContact")]
        public async Task<IActionResult> DeleteContactAsync(int id)
        {
            await _contactService.DeleteContactAsync(id);
            return NoContent();
        }

        [HttpGet("FilterContact")]
        public async Task<IActionResult> FilterContact(int companyId, int countryId) =>
            Ok(await _contactService.FilterContactsAsync(companyId, countryId));

        [HttpGet("GetContactsWithCompanyAndCountry")]
        public async Task<IActionResult> GetContactsWithCompanyAndCountry()
        {
            var contacts = await _contactService.GetContactsWithCompanyAndCountryAsync();
            return contacts?.Any() == true ? Ok(contacts) : NotFound();
        }
    }
}
