using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IContactRepository : IBaseRepository<ContactEntity>
    {
        public Task<List<ContactEntity>> FilterContacts(int? companyId, int? countryId);
        public Task<List<ContactEntity>> GetContactsWithCompanyAndCountryAsync();

    }
}
