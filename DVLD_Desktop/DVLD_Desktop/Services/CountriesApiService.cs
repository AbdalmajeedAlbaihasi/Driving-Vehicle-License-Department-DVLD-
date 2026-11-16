using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLDShared.DTOs.Nationality;

namespace DVLD_Desktop_Net8.Services
{
    public class CountriesApiService: BaseApiService
    {
        public string LastError { get; private set; } = string.Empty;
        public async Task<List<NationalityListDTO>?> GetAllCountriesAsync()
        {
            return await GetAsync<List<NationalityListDTO>>("NationalityAPI/All");
        }
        public async Task<NationalityListDTO?> GetCountryByIdAsync(int id)
        {
            return await GetAsync<NationalityListDTO>($"NationalityAPI/{id}");
        }
    }
}
