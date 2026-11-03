using DVLD_Desktop_Net8.Services;
using DVLDShared.DTOs.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Desktop_Net8.Applications.Services
{
    public class ApplicationApiService : BaseApiService
    {
        public string LastError { get; private set; } = string.Empty;



        public async Task<GetApplicationByLocalDrivingLicenseApplicationIdDTO?> GetApplicationByLocalDrivingLicenseApplicationId(int LocalDrivingLicenseApplicationId)
        {
            return await GetAsync<GetApplicationByLocalDrivingLicenseApplicationIdDTO>($"Applications/{LocalDrivingLicenseApplicationId}");
        }
    }
}
