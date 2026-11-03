using DVLDDataAccess;
using DVLDShared.DTOs;
using DVLDShared.DTOs.Test_Appointment;

namespace DVLDBusiness
{
    public class clsTestAppointmentBusiness
    {
        private readonly clsTestAppointmentDataAccess _dataAccess;

        public clsTestAppointmentBusiness(
            clsTestAppointmentDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        // 1. Get Test Appointment Info By ID
        public async Task<TestAppointmentDTO?> GetTestAppointmentInfoByIDAsync(
            int testAppointmentID)
        {
            if (testAppointmentID <= 0)
                return null;

            return await _dataAccess.GetTestAppointmentInfoByIDAsync(
                testAppointmentID);
        }

        // 2. Get Last Test Appointment
        public async Task<TestAppointmentDTO?> GetLastTestAppointmentAsync(
            int localDrivingLicenseApplicationID,
            int testTypeID)
        {
            if (localDrivingLicenseApplicationID <= 0 || testTypeID <= 0)
                return null;

            return await _dataAccess.GetLastTestAppointmentAsync(
                localDrivingLicenseApplicationID,
                testTypeID);
        }

        // 3. Get All Test Appointments
        public async Task<List<TestAppointmentViewDTO>> GetAllTestAppointmentsAsync()
        {
            return await _dataAccess.GetAllTestAppointmentsAsync();
        }

        // 4. Get Application Test Appointments Per Test Type
        public async Task<List<TestAppointmentListDTO>>
            GetApplicationTestAppointmentsPerTestTypeAsync(
                int localDrivingLicenseApplicationID,
                int testTypeID)
        {
            if (localDrivingLicenseApplicationID <= 0 || testTypeID <= 0)
                return new List<TestAppointmentListDTO>();

            return await _dataAccess
                .GetApplicationTestAppointmentsPerTestTypeAsync(
                    localDrivingLicenseApplicationID,
                    testTypeID);
        }

        // 5. Add New Test Appointment
        public async Task<SuccessMessageResponseIdDTO>
            AddNewTestAppointmentAsync(AddNewTestAppointmentDTO dto)
        {
            if (dto == null)
            {
                return new SuccessMessageResponseIdDTO(
                    false, "Appointment data cannot be null.", -1);
            }

            int newID = await _dataAccess.AddNewTestAppointmentAsync(dto);

            if (newID <= 0)
            {
                return new SuccessMessageResponseIdDTO(
                    false, "Failed to add test appointment.", -1);
            }

            return new SuccessMessageResponseIdDTO(
                true, "Test appointment added successfully.", newID);
        }

        // 6. Update Test Appointment
        public async Task<SuccessMessageResponseIdDTO>
            UpdateTestAppointmentAsync(UpdateTestAppointmentDTO dto)
        {
            if (dto == null || dto.TestAppointmentId <= 0)
            {
                return new SuccessMessageResponseIdDTO(
                    false, "Invalid appointment data.", -1);
            }

            bool updated = await _dataAccess.UpdateTestAppointmentAsync(dto);

            if (!updated)
            {
                return new SuccessMessageResponseIdDTO(
                    false, "Failed to update test appointment.", -1);
            }

            return new SuccessMessageResponseIdDTO(
                true,
                "Test appointment updated successfully.",
                dto.TestAppointmentId);
        }

        // 7. Get Test ID
        public async Task<int> GetTestIDAsync(int testAppointmentID)
        {
            if (testAppointmentID <= 0)
                return -1;

            return await _dataAccess.GetTestIDAsync(testAppointmentID);
        }
    }
}
