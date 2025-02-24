using Domain.Entities;
using Domain.Interfaces;

namespace Repositories
{
    public class CompanyRepository : BaseRepository<CompanyEntity>, ICompanyRepository
    {
        public CompanyRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        // these methods are if we dont use generic repository

        //public async Task<CompanyEntity> Create(CompanyEntity company)
        //{
        //    await applicationDbContext.Set<CompanyEntity>().AddAsync(company);

        //    await applicationDbContext.SaveChangesAsync();

        //    return company;
        //}

        //public async Task<List<CompanyEntity>> GetAll()
        //{
        //    return await applicationDbContext.Set<CompanyEntity>().ToListAsync();
        //}

        //public async Task<CompanyEntity> Update(CompanyEntity company)
        //{
        //    var existingCompany = await applicationDbContext.Set<CompanyEntity>().FindAsync(company.Id);

        //    if (existingCompany == null)
        //    {
        //        return null; 
        //    }

        //    existingCompany.CompanyName = company.CompanyName;

        //    applicationDbContext.Set<CompanyEntity>().Update(existingCompany);
        //    await applicationDbContext.SaveChangesAsync();

        //    return existingCompany;
        //}

    }
}
