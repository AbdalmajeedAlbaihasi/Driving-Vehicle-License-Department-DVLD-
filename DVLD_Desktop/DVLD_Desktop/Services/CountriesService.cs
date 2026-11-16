using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLDShared.DTOs.Nationality;

namespace DVLD_Desktop_Net8.Services
{
    public class CountriesService
    {
        private readonly CountriesApiService _api;

        public CountriesService()
        {
            _api = new CountriesApiService();
        }

        public string LastError => _api.LastError;

        public async Task<List<NationalityListDTO>?> GetAllCountries()
        {
            return await _api.GetAllCountriesAsync();
        }

        public async Task<NationalityListDTO?> GetCountryById(int id)
        {
            if (id <= 0) return null;
            return await _api.GetCountryByIdAsync(id);
        }

    }
}
