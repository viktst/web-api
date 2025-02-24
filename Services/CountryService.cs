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
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository countryRepository;

        public CountryService(ICountryRepository countryRepository) =>
            this.countryRepository = countryRepository;

        public async Task<CountryEntity> CreateCountryAsync(CountryDTO request) =>
            await countryRepository.CreateAsync(new CountryEntity { CountryName = request.Name });

        public async Task<List<CountryEntity>> GetCountriesAsync() =>
            await countryRepository.GetAllAsync();

        public async Task<CountryEntity> UpdateCountryAsync(int id, CountryDTO request)
        {
            var existingCountry = await countryRepository.GetByIdAsync(id) ??
                throw new Exception("Not exists");

            existingCountry.CountryName = request.Name;

            return await countryRepository.UpdateAsync(existingCountry);
        }

        public async Task DeleteCountryAsync(int id)
        {
            var countryToDelete = await countryRepository.GetByIdAsync(id);
            if (countryToDelete != null)
                await countryRepository.DeleteAsync(id);
        }
    }
}
