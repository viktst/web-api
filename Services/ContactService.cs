using Domain.Entities;
using Domain.Interfaces;
using Domain.Models.Requests;
using Domain.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository contactRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly ICountryRepository countryRepository;

        public ContactService(IContactRepository contactRepository, ICompanyRepository companyRepository, ICountryRepository countryRepository)
        {
            this.contactRepository = contactRepository;
            this.companyRepository = companyRepository;
            this.countryRepository = countryRepository;
        }

        public async Task<ContactEntity> CreateContactAsync(ContactDTO request)
        {
            if (await companyRepository.GetByIdAsync(request.CompanyId) == null ||
                await countryRepository.GetByIdAsync(request.CountryId) == null)
                throw new Exception("Company or Country does not exist.");

            var contact = new ContactEntity
            {
                ContactName = request.ContactName,
                CompanyId = request.CompanyId,
                CountryId = request.CountryId
            };

            return await contactRepository.CreateAsync(contact);
        }

        public async Task<List<ContactEntity>> GetContactsAsync() =>
            await contactRepository.GetAllAsync();

        public async Task<ContactEntity> UpdateContactAsync(int id, ContactDTO request)
        {
            var existingContact = await contactRepository.GetByIdAsync(id) ??
                throw new Exception("Contact does not exist.");

            if (await companyRepository.GetByIdAsync(request.CompanyId) == null ||
                await countryRepository.GetByIdAsync(request.CountryId) == null)
                throw new Exception("Company or Country does not exist.");

            existingContact.ContactName = request.ContactName;
            existingContact.CompanyId = request.CompanyId;
            existingContact.CountryId = request.CountryId;

            return await contactRepository.UpdateAsync(existingContact);
        }

        public async Task DeleteContactAsync(int id)
        {
            var contactToDelete = await contactRepository.GetByIdAsync(id);
            if (contactToDelete != null)
                await contactRepository.DeleteAsync(id);
        }

        public async Task<List<ContactEntity>> FilterContactsAsync(int? countryId = null, int? companyId = null) =>
            await contactRepository.FilterContacts(countryId, companyId);

        public async Task<List<ContactEntity>> GetContactsWithCompanyAndCountryAsync() =>
            await contactRepository.GetContactsWithCompanyAndCountryAsync();
    }

}
