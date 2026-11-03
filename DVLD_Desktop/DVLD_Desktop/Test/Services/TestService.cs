using DVLDShared.DTOs;
using DVLDShared.DTOs.People;
using DVLDShared.DTOs.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Desktop_Net8.Test.Services
{
    public class TestService
    {
        private readonly TestApiService _api;

        public TestService()
        {
            _api = new TestApiService();
        }

        public string LastError => _api.LastError;

        public async Task<TestDTO?> GetTestByIdAsync(int id)
        {
            if (id <= 0) return null;
            return await _api.GetTestByIdAsync(id);
        }

        public async Task<TestDTO?> GetLastTestAsync(int personId, int licenseClassId, int testTypeId)
        {
            return await _api.GetLastTestAsync(personId, licenseClassId, testTypeId);
        }

        public async Task<List<TestDTO>?> GetAllTestsAsync()
        {
            return await _api.GetAllTestsAsync();
        }

        public async Task<byte> GetPassedTestCountAsync(int localDrivingId)
        {
            if (localDrivingId <= 0) return 0;
            return await _api.GetPassedTestCountAsync(localDrivingId);
        }

        public async Task<bool> PassedAllTestsAsync(int localDrivingId)
        {
            if (localDrivingId <= 0) return false;
            return await _api.PassedAllTestsAsync(localDrivingId);
        }

        public async Task<SuccessMessageResponseIdDTO?> UpdateTestAsync(UpdateTestDTO dto)
        {
            if (dto == null) return null;
            return await _api.UpdateTestAsync(dto);
        }

        public async Task<SuccessMessageResponseIdDTO?> AddNewTest(AddNewTestDTO dto)
        {
            if (dto == null) return null;
            return await _api.AddNewTestAsync(dto);
        }
    }
}
