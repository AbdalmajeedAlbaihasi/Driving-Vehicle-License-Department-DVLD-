using DVLD_Desktop_Net8.Application.Services;
using DVLDShared.DTOs;
using DVLDShared.DTOs.ApplicationsType;
using DVLDShared.DTOs.TestType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Desktop_Net8.Test_Type.Services
{
    public class TestTypeService
    {
        private readonly TestTypeApiService _api;

        public TestTypeService()
        {
            _api = new TestTypeApiService();
        }

        public string LastError => _api.LastError;

      

        public async Task<List<TestTypeDTO>?> GetAllTestTypes()
        {
            return await _api.GetAllTestTypes();
        }

        public async Task<TestTypeDTO?> GetOneTestType(int id)
        {
            if (id <= 0) return null;
            return await _api.GetOneTestType(id);
        }


        public async Task<SuccessMessageResponseDTO?> UpdateTestTypeAsync(int id, TestTypeDTO dto)
        {
            if (id <= 0 || dto == null) return null;
            return await _api.UpdateTestTypeAsync(id, dto);
        }
    }
}
