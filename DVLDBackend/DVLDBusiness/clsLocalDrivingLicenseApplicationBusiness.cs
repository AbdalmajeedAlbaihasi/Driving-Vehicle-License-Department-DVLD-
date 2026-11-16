using DVLDDataAccess;
using DVLDShared.DTOs.Applications;
using DVLDShared.DTOs.LocalDrivingLicenseApplications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusiness
{
    public class clsLocalDrivingLicenseApplicationBusiness
    {
        private readonly clsLocalDrivingLicenseApplicationDataAccess _dataAccess;
        public clsLocalDrivingLicenseApplicationBusiness(clsLocalDrivingLicenseApplicationDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        




        public async Task<(bool Success, string Message, List<LocalDrivingLicenseApplicationListDTO> ApplicationsList)>
            GetAllLocalDrivingLicenseApplicationsAsync()
        {
            var Applications = await _dataAccess.GetAllLocalDrivingLicenseApplicationsAsync();

            if (Applications.Count == 0)
            {
                return (false, "No applications found", new List<LocalDrivingLicenseApplicationListDTO>());
            }

            return (true, "Applications retrieved successfully", Applications);
        }


        public async Task<LocalDrivingLicenseApplicationInfoDTO?>
            GetLocalDrivingLicenseApplicationInfoByIDAsync(
                int localDrivingLicenseApplicationID)
        {
            if (localDrivingLicenseApplicationID <= 0)
                return null;

            return await _dataAccess
                .GetLocalDrivingLicenseApplicationInfoByIDAsync(
                    localDrivingLicenseApplicationID);
        }

        public async Task<GetOneLocalDrivingLicenseApplicationDTO?> GetOneLocalDrivingLicenseApplicationsAsync(int id)
        {
            return await _dataAccess.GetOneLocalDrivingLicenseApplicationsAsync(id);
        }

        public async Task<(bool Success, string Message)> UpdateLocalDrivingLicenseApplicationStatusAsync(UpdateStatusDTO updateStatusDTO)
        {
            var result = await _dataAccess.UpdateLocalDrivingLicenseApplicationStatusAsync(updateStatusDTO);
            if (updateStatusDTO.ApplicationId <= 0)
            {
                return (false,"Invalid application ID"
                );
            }
            if (updateStatusDTO.NewStatus < 1 || updateStatusDTO.NewStatus > 3)
            {
                return (false, "Invalid application status");
            }
            if (!result)
            {
                return (false, "Failed to update application status");
            }
            return (true, "Application status updated successfully");
        }

        public async Task<(bool Success, string Message, int ID)> AddNewLocalDrivingLicenseApplicationAsync(AddNewLocalDrivingLicenseApplicationDTO applicationDTO)
        {
            if (applicationDTO == null)
            {
                return (false, "Application data is null.", -1);
            }

            if (applicationDTO.PersonID <= 0)
            {
                return (false, "Invalid Applicant Person ID.", -1);
            }

           
            if (applicationDTO.ApplicationDate == default)
            {
                return (false, "Invalid Application Date.", -1);
            }

            if (applicationDTO.LisansClassID <= 0 )
            {
                return (false, "Invalid Application Lisans Class.", -1);
            }

            if (applicationDTO.ApplicationsFees < 0)
            {
                return (false, "Paid Fees cannot be negative.", -1);
            }

            if (applicationDTO.CreatedBy <= 0)
            {
                return (false, "Invalid Created By User ID .", -1);
            }
            

            if (await _dataAccess.HasActiveApplicationWithSameLicenseClassAsync(applicationDTO.PersonID, applicationDTO.LisansClassID))
            {
                return (false, "An active application with the same license class already exists.", -1);
            }


            int newLocalDrivingLicenseApplicationID = await _dataAccess.AddNewLocalDrivingLicenseApplicationAsync(applicationDTO);
            if (newLocalDrivingLicenseApplicationID <= 0)
            {
                return (false, "Failed to add new Local Driving License Application.", -1);
            }

            return (true, "Local Driving License Application added successfully.", newLocalDrivingLicenseApplicationID);
        }


    }
}
