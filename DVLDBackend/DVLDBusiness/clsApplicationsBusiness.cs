using System;
using DVLDDataAccess;
using DVLDShared.DTOs.Applications;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusiness
{
    public class clsApplicationsBusiness
    {
        private readonly clsApplicationsDataAccess _dataAccess;
        public clsApplicationsBusiness(clsApplicationsDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }


        public async Task<GetApplicationByLocalDrivingLicenseApplicationIdDTO?> GetApplicationByLocalDrivingLicenseApplicationIdAsync(int LocalDrivingLicenseApplicationId)
        {
            return await _dataAccess.GetApplicationByLocalDrivingLicenseApplicationIdAsync(LocalDrivingLicenseApplicationId);
        }



    }
}