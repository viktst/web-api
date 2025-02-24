using Domain.Entities;
using Domain.Interfaces;
using Domain.Models.Requests;
using Domain.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository companyRepository;

        public CompanyService(ICompanyRepository companyRepository) =>
            this.companyRepository = companyRepository;

        public async Task<CompanyEntity> CreateCompanyAsync(CompanyDTO request) =>
            await companyRepository.CreateAsync(new CompanyEntity { CompanyName = request.Name });

        public async Task<List<CompanyEntity>> GetCompaniesAsync() =>
            await companyRepository.GetAllAsync();

        public async Task<CompanyEntity> UpdateCompanyAsync(int id, CompanyDTO request)
        {
            var existingCompany = await companyRepository.GetByIdAsync(id) ??
                throw new Exception("Not exists");

            existingCompany.CompanyName = request.Name;

            return await companyRepository.UpdateAsync(existingCompany);
        }

        public async Task DeleteCompanyAsync(int id)
        {
            var companyToDelete = await companyRepository.GetByIdAsync(id);
            if (companyToDelete != null)
                await companyRepository.DeleteAsync(id);
        }
    }
}
