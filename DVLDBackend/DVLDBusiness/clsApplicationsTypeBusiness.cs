using System;
using DVLDDataAccess;
using DVLDShared.DTOs.ApplicationsType;

namespace DVLDBusiness
{
    public class clsApplicationsTypeBusiness
    {
        private readonly clsApplicationsTypeDataAccess _applicationsDataAccess;
        public clsApplicationsTypeBusiness(clsApplicationsTypeDataAccess applicationsDataAccess)
        {
            _applicationsDataAccess = applicationsDataAccess;
        }
        
        public async Task<List<ApplicationsTypeDTO>> GetAllApplicationsTypeAsync()
        {
            return await _applicationsDataAccess.GetAllApplicationsTypeAsync();
        }

        public async Task<(bool Success, string Message)> UpdateTitleNameAsync(int applicationTypeId, string newTitle)
        {
            if (applicationTypeId <= 0)
            {
                return (false, "Invalid application type ID.");
            }
            if(string.IsNullOrWhiteSpace(newTitle))
            {
                return (false, "New title cannot be empty.");
            }

            var result = await _applicationsDataAccess.UpdateTitleNameAsync(applicationTypeId, newTitle);
            if (result)
            {
                return (true, "Title updated successfully.");
            }
            else
            {
                return (false, "Failed to update title.");
            }
        }

        public async Task<(bool Success, string Message)> UpdateApplicationFeesAsync(int applicationTypeId, decimal newFees)
        {
            if (applicationTypeId <= 0)
            {
                return (false, "Invalid application type ID.");
            }
            if (newFees < 0)
            {
                return (false, "New fees cannot be negative.");
            }

            var result = await _applicationsDataAccess.UpdateApplicationFeesAsync(applicationTypeId, newFees);
            if (result)
            {
                return (true, "Application fees updated successfully.");
            }
            else
            {
                return (false, "Failed to update application fees.");
            }
        }
    }
}
