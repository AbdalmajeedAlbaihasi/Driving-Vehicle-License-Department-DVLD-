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
        public async Task<(bool Success, string Message, int newLocalDrivingLicenseApplicationID)> AddNewApplicationAsync(AddNewApplicationDTO applicationDTO)
        {
            if (applicationDTO == null)
            {
                return (false, "Application data is null.", -1);
            }

            if (applicationDTO.ApplicationTypeID <= 0)
            {
                return (false, "Invalid Application Type ID.", -1);
            }
            if (applicationDTO.ApplicantPersonID <= 0)
            {
                return (false, "Invalid Applicant Person ID.", -1);
            }
            if (applicationDTO.ApplicationDate == default)
            {
                return (false, "Invalid Application Date.", -1);
            }
            if (applicationDTO.ApplicationStatus < 1 || applicationDTO.ApplicationStatus > 3)
            {
                return (false, "Invalid Application Status.", -1);
            }
            if (applicationDTO.PaidFees < 0)
            {
                return (false, "Paid Fees cannot be negative.", -1);
            }
            if (applicationDTO.CreatedByUserID <= 0)
            {
                return (false, "Invalid Created By User ID.", -1);
            }
            if (applicationDTO.LastStatusDate == default)
            {
                return (false, "Invalid Last Status Date.", -1);
            }
            if (await _dataAccess.HasActiveApplicationWithSameLicenseClassAsync(applicationDTO.ApplicantPersonID, applicationDTO.LicenseClassID))
            {
                return (false,"An active application with the same license class already exists.",-1);
            }
           

            int newLocalDrivingLicenseApplicationID = await _dataAccess.AddNewApplicationAsync(applicationDTO);
            if (newLocalDrivingLicenseApplicationID <= 0)
            {
                return (false, "Failed to add new application.", -1);
            }

            return (true, "Application added successfully.", newLocalDrivingLicenseApplicationID);
        }
     }
}