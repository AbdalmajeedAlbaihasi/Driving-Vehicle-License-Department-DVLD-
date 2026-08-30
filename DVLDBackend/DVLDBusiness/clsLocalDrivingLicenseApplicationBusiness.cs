using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLDDataAccess;
using DVLDShared.DTOs.LocalDrivingLicenseApplications;

namespace DVLDBusiness
{
    public class clsLocalDrivingLicenseApplicationBusiness
    {
        private readonly clsLocalDrivingLicenseApplicationDataAccess _dataAccess;
        public clsLocalDrivingLicenseApplicationBusiness(clsLocalDrivingLicenseApplicationDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        
        public async Task<(bool Success, string Message, List<LocalDrivingLicenseApplicationListDTO> Applications)>
            GetAllLocalDrivingLicenseApplicationsAsync()
        {
            var Applications = await _dataAccess.GetAllLocalDrivingLicenseApplicationsAsync();

            if (Applications.Count == 0)
            {
                return (false, "No applications found", new List<LocalDrivingLicenseApplicationListDTO>());
            }

            return (true, "Applications retrieved successfully", Applications);
        }


        public async Task<(bool Success, string Message)> UpdateLocalDrivingLicenseApplicationStatusAsync(int applicationId, byte newStatus)
        {
            var result = await _dataAccess.UpdateLocalDrivingLicenseApplicationStatusAsync(applicationId, newStatus);
            if (applicationId <= 0)
            {
                return (false,"Invalid application ID"
                );
            }
            if (newStatus < 1 || newStatus > 3)
            {
                return (false, "Invalid application status");
            }
            if (!result)
            {
                return (false, "Failed to update application status");
            }
            return (true, "Application status updated successfully");
        }
    }
}
