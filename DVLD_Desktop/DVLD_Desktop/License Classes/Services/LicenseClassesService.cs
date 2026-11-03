using DVLDShared.DTOs.LicenseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Desktop_Net8.License_Classes.Services
{
    public class LicenseClassesService
    {
        private readonly LicenseClassesApiService _apiService;
        public LicenseClassesService()
        {
            _apiService = new LicenseClassesApiService();
        }

        public async Task<List<LicenseClassesNameDTO>?> GetAllLicenseClassesNameAsync()
        {
            return await _apiService.GetAllLicenseClassesNameAsync();
        }
    }
}
