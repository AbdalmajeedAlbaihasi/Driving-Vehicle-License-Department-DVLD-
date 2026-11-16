
using DVLDShared.DTOs;
using DVLDShared.DTOs.TestAppointment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DVLD_Desktop_Net8.Test.Service
{
    public class TestAppointmentService
    {
        private readonly TestAppointmentApiService _api;

        public TestAppointmentService()
        {
            _api = new TestAppointmentApiService();
        }

        public string LastError => _api.LastError;


        // 1. Get Test Appointment Info By ID
        public async Task<TestAppointmentDTO?> GetTestAppointmentInfoByIDAsync(
            int id)
        {
            if (id <= 0)
                return null;

            return await _api.GetTestAppointmentInfoByIDAsync(id);
        }


        // 2. Get Last Test Appointment
        public async Task<TestAppointmentDTO?> GetLastTestAppointmentAsync(
            int localDrivingLicenseApplicationID,
            int testTypeID)
        {
            if (localDrivingLicenseApplicationID <= 0 || testTypeID <= 0)
                return null;

            return await _api.GetLastTestAppointmentAsync(
                localDrivingLicenseApplicationID,
                testTypeID);
        }


        // 3. Get All Test Appointments
        public async Task<List<TestAppointmentViewDTO>?>
            GetAllTestAppointmentsAsync()
        {
            return await _api.GetAllTestAppointmentsAsync();
        }


        // 4. Get Application Test Appointments Per Test Type
        public async Task<List<TestAppointmentListDTO>?>
            GetApplicationTestAppointmentsPerTestTypeAsync(
                int localDrivingLicenseApplicationID,
                int testTypeID)
        {
            if (localDrivingLicenseApplicationID <= 0 || testTypeID <= 0)
                return null;

            return await _api.GetApplicationTestAppointmentsPerTestTypeAsync(
                localDrivingLicenseApplicationID,
                testTypeID);
        }


        // 5. Add New Test Appointment
        public async Task<SuccessMessageResponseIdDTO?>
            AddNewTestAppointmentAsync(AddNewTestAppointmentDTO dto)
        {
            if (dto == null)
                return null;

            return await _api.AddNewTestAppointmentAsync(dto);
        }


        // 6. Update Test Appointment
        public async Task<SuccessMessageResponseIdDTO?>
            UpdateTestAppointmentAsync(UpdateTestAppointmentDTO dto)
        {
            if (dto == null)
                return null;

            return await _api.UpdateTestAppointmentAsync(dto);
        }


        // 7. Get Test ID By Test Appointment ID
        public async Task<int?> GetTestIDAsync(int id)
        {
            if (id <= 0)
                return null;

            return await _api.GetTestIDAsync(id);
        }
    }
}
