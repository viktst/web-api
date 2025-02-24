using Domain.Entities;
using Domain.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IContactService
    {
        public Task<List<ContactEntity>> GetContactsAsync();

        public Task<ContactEntity> CreateContactAsync(ContactDTO Contact);

        public Task<ContactEntity> UpdateContactAsync(int id, ContactDTO Contact);

        public Task DeleteContactAsync(int id);

        public Task<List<ContactEntity>> FilterContactsAsync(int? companyId, int? countryId);
        public Task<List<ContactEntity>> GetContactsWithCompanyAndCountryAsync();
    }
}
