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
    public class CountryRepository : BaseRepository<CountryEntity>, ICountryRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CountryRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Dictionary<string, int>> GetCompanyStatisticsByCountryId(int countryId)
        {
            var companyStatistics = await _applicationDbContext.Contacts
                .Where(c => c.CountryId == countryId)
                .GroupBy(c => c.CompanyId)
                .Select(group => new
                {
                    CompanyName = group.FirstOrDefault()!.Company.CompanyName, // Get the company name
                    ContactCount = group.Count() // Count the contacts for this company
                })
                .ToListAsync();

            var result = companyStatistics.ToDictionary(stat => stat.CompanyName, stat => stat.ContactCount);

            return result;
        }
    }
}
