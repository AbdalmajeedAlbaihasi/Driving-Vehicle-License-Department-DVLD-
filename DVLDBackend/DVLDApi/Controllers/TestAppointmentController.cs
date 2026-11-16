
using DVLDBusiness;
using DVLDShared.DTOs;
using DVLDShared.DTOs.Test_Appointment;
using Microsoft.AspNetCore.Mvc;

namespace DVLDApi.Controllers
{
    [Route("api/TestAppointment")]
    [ApiController]
    public class TestAppointmentController : ControllerBase
    {
        private readonly clsTestAppointmentBusiness _business;

        public TestAppointmentController(
            clsTestAppointmentBusiness business)
        {
            _business = business;
        }

        // 1. Get Test Appointment Info By ID
        [HttpGet("{id:int}", Name = "GetTestAppointmentInfoByID")]
        public async Task<ActionResult<TestAppointmentDTO>>
            GetTestAppointmentInfoByID(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Test Appointment ID.");

            var appointment =
                await _business.GetTestAppointmentInfoByIDAsync(id);

            if (appointment == null)
                return NotFound(
                    $"Test appointment with ID {id} was not found.");

            return Ok(appointment);
        }

        // 2. Get Last Test Appointment
        [HttpGet("last/local-driving/{localDrivingLicenseApplicationID:int}/test-type/{testTypeID:int}",
            Name = "GetLastTestAppointment")]
        public async Task<ActionResult<TestAppointmentDTO>>
            GetLastTestAppointment(
                int localDrivingLicenseApplicationID,
                int testTypeID)
        {
            if (localDrivingLicenseApplicationID <= 0 || testTypeID <= 0)
                return BadRequest("Invalid application ID or test type ID.");

            var appointment =
                await _business.GetLastTestAppointmentAsync(
                    localDrivingLicenseApplicationID,
                    testTypeID);

            if (appointment == null)
                return NotFound("No test appointment found.");

            return Ok(appointment);
        }

        // 3. Get All Test Appointments
        [HttpGet("all", Name = "GetAllTestAppointments")]
        public async Task<ActionResult<List<TestAppointmentViewDTO>>>
            GetAllTestAppointments()
        {
            var appointments =
                await _business.GetAllTestAppointmentsAsync();

            return Ok(appointments);
        }

        // 4. Get Application Test Appointments Per Test Type
        [HttpGet("local-driving/{localDrivingLicenseApplicationID:int}/test-type/{testTypeID:int}",
            Name = "GetApplicationTestAppointmentsPerTestType")]
        public async Task<ActionResult<List<TestAppointmentListDTO>>>
            GetApplicationTestAppointmentsPerTestType(
                int localDrivingLicenseApplicationID,
                int testTypeID)
        {
            if (localDrivingLicenseApplicationID <= 0 || testTypeID <= 0)
                return BadRequest("Invalid application ID or test type ID.");

            var appointments =
                await _business
                    .GetApplicationTestAppointmentsPerTestTypeAsync(
                        localDrivingLicenseApplicationID,
                        testTypeID);

            return Ok(appointments);
        }

        // 5. Add New Test Appointment
        [HttpPost(Name = "AddNewTestAppointment")]
        public async Task<ActionResult<SuccessMessageResponseIdDTO>>
            AddNewTestAppointment(
                [FromBody] AddNewTestAppointmentDTO dto)
        {
            if (dto == null)
                return BadRequest(
                    new SuccessMessageResponseIdDTO(
                        false, "Invalid appointment data.", -1));

            var result =
                await _business.AddNewTestAppointmentAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // 6. Update Test Appointment
        [HttpPut(Name = "UpdateTestAppointment")]
        public async Task<ActionResult<SuccessMessageResponseIdDTO>>
            UpdateTestAppointment(
                [FromBody] UpdateTestAppointmentDTO dto)
        {
            if (dto == null)
                return BadRequest(
                    new SuccessMessageResponseIdDTO(
                        false, "Invalid appointment data.", -1));

            var result =
                await _business.UpdateTestAppointmentAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // 7. Get Test ID By Test Appointment ID
        [HttpGet("{id:int}/test-id", Name = "GetTestID")]
        public async Task<ActionResult<int>> GetTestID(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Test Appointment ID.");

            int testID = await _business.GetTestIDAsync(id);

            if (testID == -1)
                return NotFound("No test found for this appointment.");

            return Ok(testID);
        }
    }
}
