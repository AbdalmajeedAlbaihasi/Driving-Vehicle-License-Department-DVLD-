using DVLD_Desktop_Net8.Application.Services;
using DVLDShared.DTOs.Applications;
using DVLDShared.DTOs.ApplicationsType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Desktop_Net8.Applications.Services
{
    public class ApplicationService
    {
        private readonly ApplicationApiService _api;

        public ApplicationService()
        {
            _api = new ApplicationApiService();
        }

        public string LastError => _api.LastError;

        

        public async Task<GetApplicationByLocalDrivingLicenseApplicationIdDTO?> GetApplicationByLocalDrivingLicenseApplicationId(int LocalDrivingLicenseApplicationId)
        {
            if (LocalDrivingLicenseApplicationId <= 0) return null;
            return await _api.GetApplicationByLocalDrivingLicenseApplicationId(LocalDrivingLicenseApplicationId);
        }






    }
}
