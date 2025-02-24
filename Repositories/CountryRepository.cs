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
        public CountryRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        //these methods are if we dont use generic repository
        //public async Task<CountryEntity> Create(CountryEntity Country)
        //{
        //    await applicationDbContext.Set<CountryEntity>().AddAsync(Country);

        //    await applicationDbContext.SaveChangesAsync();

        //    return Country;
        //}

        //public async Task<List<CountryEntity>> GetAll()
        //{
        //    return await applicationDbContext.Set<CountryEntity>().ToListAsync();
        //}

        //public async Task<CountryEntity> Update(CountryEntity Country)
        //{
        //    var existingCountry = await applicationDbContext.Set<CountryEntity>().FindAsync(Country.Id);

        //    if (existingCountry == null)
        //    {
        //        return null; 
        //    }

        //    existingCountry.CountryName = Country.CountryName;

        //    applicationDbContext.Set<CountryEntity>().Update(existingCountry);
        //    await applicationDbContext.SaveChangesAsync();

        //    return existingCountry;
        //}

    }
}
