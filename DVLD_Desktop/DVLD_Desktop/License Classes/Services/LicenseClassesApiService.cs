using DVLD_Desktop_Net8.Services;
using DVLDShared.DTOs.LicenseClass;
using DVLDShared.DTOs.LocalDrivingLicenseApplications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Desktop_Net8.License_Classes.Services
{
    public class LicenseClassesApiService : BaseApiService
    {
        public string LastError { get; private set; } = string.Empty;


        public async Task<List<LicenseClassesNameDTO>?> GetAllLicenseClassesNameAsync()
        {
            return await GetAsync<List<LicenseClassesNameDTO>>("LicenseClasses/All");
        }
    }
}
