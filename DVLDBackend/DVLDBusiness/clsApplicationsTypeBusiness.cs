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

        public async Task<ApplicationsTypeDTO?> GetOneApplicationsTypeAsync(int ApplicationsTypeID)
        {
            if (ApplicationsTypeID < 1)
            {
                return null;
            }

            return await _applicationsDataAccess.GetOneApplicationsTypeAsync(ApplicationsTypeID);
        }

        public async Task<(bool Success, string Message)> UpdateApplicationsTypeAsync(ApplicationsTypeDTO applicationsTypeDTO)
        {
            if (applicationsTypeDTO.ApplicationTypeId <= 0)
            {
                return (false, "Invalid application type ID.");
            }
            if(string.IsNullOrWhiteSpace(applicationsTypeDTO.ApplicationTypeTitle))
            {
                return (false, "New title cannot be empty.");
            }

            if (applicationsTypeDTO.ApplicationFees < 0)
            {
                return (false, "New fees cannot be negative.");
            }

            var result = await _applicationsDataAccess.UpdateApplicationsTypeAsync(applicationsTypeDTO);
            if (result)
            {
                return (true, "Title updated successfully.");
            }
            else
            {
                return (false, "Failed to update title.");
            }
        }


        public async Task<(bool Success, string Message, decimal Fees)> GetApplicationTypeFeesByIdAsync(int applicationTypeId)
        {
            // 1. الفحص الوقائي للمُدخلات
            if (applicationTypeId <= 0)
            {
                return (false, "Invalid Application Type ID.", 0m);
            }

            try
            {
                // 2. استدعاء طبقة الداتا أكسس
                decimal? fees = await _applicationsDataAccess.GetApplicationTypeFeesByIdAsync(applicationTypeId);

                if (fees == null)
                {
                    return (false, $"Application Type with ID [{applicationTypeId}] was not found.", 0m);
                }

                // 3. النجاح وإرجاع قيمة الرسوم
                return (true, "Application fees retrieved successfully.", fees.Value);
            }
            catch (Exception ex)
            {
                return (false, $"Server error while fetching fees: {ex.Message}", 0m);
            }
        }
    }
}
