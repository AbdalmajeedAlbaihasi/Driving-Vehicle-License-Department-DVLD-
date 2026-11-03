using DVLDDataAccess;
using DVLDShared.DTOs;
using DVLDShared.DTOs.Test;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DVLDBusiness
{
    public class clsTestBusiness
    {
        private readonly clsTestDataAccess _dataAccess;

        public clsTestBusiness(clsTestDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<TestDTO?> GetTestInfoByIdAsync(int testId)
        {
            if (testId <= 0) return null;
            return await _dataAccess.GetTestInfoByIdAsync(testId);
        }

        public async Task<TestDTO?> GetLastTestByPersonAndTestTypeAndLicenseClassAsync(int personId, int licenseClassId, int testTypeId)
        {
            if (personId <= 0 || licenseClassId <= 0 || testTypeId <= 0) return null;
            return await _dataAccess.GetLastTestByPersonAndTestTypeAndLicenseClassAsync(personId, licenseClassId, testTypeId);
        }

        public async Task<List<TestDTO>> GetAllTestsAsync()
        {
            return await _dataAccess.GetAllTestsAsync();
        }

        public async Task<SuccessMessageResponseIdDTO> AddNewTestAsync(AddNewTestDTO testDTO)
        {
            if (testDTO.TestAppointmentId <= 0) return new SuccessMessageResponseIdDTO(false, "Invalid Test Appointment ID.", -1);
            if (testDTO.CreatedByUserId <= 0) return new SuccessMessageResponseIdDTO(false, "Invalid User ID.", -1);

            int newTestId = await _dataAccess.AddNewTestAsync(testDTO);
            if (newTestId <= 0) return new SuccessMessageResponseIdDTO(false, "Failed to save the test.", -1);

            return new SuccessMessageResponseIdDTO(true, "Test added successfully.", newTestId);
        }

        public async Task<SuccessMessageResponseIdDTO> UpdateTestAsync(UpdateTestDTO dto)
        {
            if (dto is null || dto.TestId <= 0) return new SuccessMessageResponseIdDTO(false, "Invalid test data.", -1);

            bool updated = await _dataAccess.UpdateTestAsync(dto);
            if (!updated) return new SuccessMessageResponseIdDTO(false, "Failed to update the test.", -1);

            return new SuccessMessageResponseIdDTO(true, "Test updated successfully.", dto.TestId);
        }

        public async Task<byte> GetPassedTestCountAsync(int localDrivingLicenseApplicationId)
        {
            if (localDrivingLicenseApplicationId <= 0) return 0;
            return await _dataAccess.GetPassedTestCountAsync(localDrivingLicenseApplicationId);
        }

        public async Task<bool> PassedAllTestsAsync(int localDrivingLicenseApplicationId)
        {
            byte passedCount = await GetPassedTestCountAsync(localDrivingLicenseApplicationId);
            return passedCount == 3; // نظام DVLD يتطلب اجتياز 3 اختبارات للحصول على الرخصة
        }
    }
}