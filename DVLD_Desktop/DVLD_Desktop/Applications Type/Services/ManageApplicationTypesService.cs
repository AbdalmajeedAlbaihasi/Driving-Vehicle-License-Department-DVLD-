using DVLD_Desktop_Net8.Services;
using DVLDShared.DTOs;
using DVLDShared.DTOs.Applications;
using DVLDShared.DTOs.ApplicationsType;
using DVLDShared.DTOs.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DVLD_Desktop_Net8.Application.Services
{
    public class ManageApplicationTypesService
    {
        private readonly ManageApplicationTypesApiService _api;

        public ManageApplicationTypesService()
        {
            _api = new ManageApplicationTypesApiService();
        }

        public string LastError => _api.LastError;

       

        public async Task<List<ApplicationsTypeDTO>?> GetAllApplicationTypesAsync()
        {
            return await _api.GetAllApplicationTypesAsync();
        }

        public async Task<ApplicationsTypeDTO?> GetOneApplicationTypeAsync(int id)
        {
            if (id <= 0) return null;
            return await _api.GetOneApplicationTypeAsync(id);
        }


        public async Task<GetApplicationTypeFeesByIdDTO?> GetApplicationTypeFeesById(int id)
        {
            if (id <= 0) return null;
            return await _api.GetApplicationTypeFeesById(id);
        }

        public async Task<SuccessMessageResponseDTO?> UpdateApplicationsTypeAsync(int id, ApplicationsTypeDTO dto)
        {
            if (id <= 0 || dto == null) return null;
            return await _api.UpdateApplicationsTypeAsync(id, dto);
        }


    }
}