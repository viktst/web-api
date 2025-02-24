using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ContactRepository : BaseRepository<ContactEntity>, IContactRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ContactRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<List<ContactEntity>> FilterContacts(int? countryId = null, int? companyId = null)
        {
            IQueryable<ContactEntity> query = _applicationDbContext.Set<ContactEntity>();

            // if countryId is provided, filter by CountryId
            if (countryId.HasValue)
            {
                query = query.Where(c => c.CountryId == countryId.Value);
            }

            // if companyId is provided, filter by CompanyId
            if (companyId.HasValue)
            {
                query = query.Where(c => c.CompanyId == companyId.Value);
            }

            // execute the query and return the list of filtered contacts
            return await query.ToListAsync();
        }

        public async Task<List<ContactEntity>> GetContactsWithCompanyAndCountryAsync()
        {
            var contacts = await _applicationDbContext.Set<ContactEntity>()
                .Include(c => c.Company) 
                .Include(c => c.Country)
                .ToListAsync();

            return contacts;
        }

    }
}
