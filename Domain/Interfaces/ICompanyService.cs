using Domain.Entities;
using Domain.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ServiceInterfaces
{
    public interface ICompanyService
    {
        public Task<List<CompanyEntity>> GetCompaniesAsync();

        public Task<CompanyEntity> CreateCompanyAsync(CompanyDTO company);

        public Task<CompanyEntity> UpdateCompanyAsync(int id, CompanyDTO company);

        public Task DeleteCompanyAsync(int id);
    }
}
