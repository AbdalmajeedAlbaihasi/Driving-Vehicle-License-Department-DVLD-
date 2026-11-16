using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_Desktop_Net8.Services;
using DVLDShared.DTOs;
using DVLDShared.DTOs.LocalDrivingLicenseApplications;

namespace DVLD_Desktop_Net8.Local_Driving_License_Application.Services
{
    public class LocalDrivingLicenseApplicationService
    {
        private readonly LocalDrivingLicenseApplicationApiService _applicationApiService;
        public LocalDrivingLicenseApplicationService()
        {
            _applicationApiService = new LocalDrivingLicenseApplicationApiService();
        }

        public async Task<List<LocalDrivingLicenseApplicationListDTO>?> GetAllLocalDrivingLicenseApplication()
        {
            return await _applicationApiService.GetAllLocalDrivingLicenseApplication();
        }


        public async Task<LocalDrivingLicenseApplicationInfoDTO?>
            GetLocalDrivingLicenseApplicationInfoByIDAsync(int id)
        {
            if (id <= 0)
                return null;

            return await _applicationApiService
                .GetLocalDrivingLicenseApplicationInfoByIDAsync(id);
        }

        public async Task<GetOneLocalDrivingLicenseApplicationDTO?> GetOneLocalDrivingLicenseApplicationsAsync(int id)
        {
            return await _applicationApiService.GetOneLocalDrivingLicenseApplicationsAsync(id);
        }

        public async Task<SuccessMessageResponseDTO?> UpdateLocalDrivingLicenseApplicationStatus(int id, UpdateStatusDTO updateStatusDTO)
        {
            return await _applicationApiService.UpdateLocalDrivingLicenseApplicationStatus(id, updateStatusDTO);
        }

        public async Task<SuccessMessageResponseIdDTO> AddNewLocalDrivingLicenseApplicationAsync(AddNewLocalDrivingLicenseApplicationDTO dto)
        {
            return await _applicationApiService.AddNewLocalDrivingLicenseApplicationAsync(dto);
        }


    }
}
