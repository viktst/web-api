using Domain.Entities;
using Domain.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ServiceInterfaces
{
    public interface ICountryService
    {
        public Task<List<CountryEntity>> GetCountriesAsync();

        public Task<CountryEntity> CreateCountryAsync(CountryDTO Country);

        public Task<CountryEntity> UpdateCountryAsync(int id, CountryDTO Country);

        public Task DeleteCountryAsync(int id);
    }
}
