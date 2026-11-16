using DVLDBusiness;
using DVLDShared.DTOs.Applications;
using DVLDShared.DTOs.Test_Appointment;
using Microsoft.AspNetCore.Mvc;

namespace DVLDAPI.Controllers
{
    [Route("api/Applications")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly clsApplicationsBusiness _business;

        public ApplicationsController(clsApplicationsBusiness business)
        {
            _business = business;
        }



        [HttpGet("{Id}", Name = "GetApplicationByIdAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetApplicationByLocalDrivingLicenseApplicationIdDTO>> GetApplicationByLocalDrivingLicenseApplicationIdAsync(int Id)
        {
            GetApplicationByLocalDrivingLicenseApplicationIdDTO? application =
                await _business.GetApplicationByLocalDrivingLicenseApplicationIdAsync(Id);

            if (application == null)
            {
                return NotFound("No application found");
            }

            return Ok(application);
        }
    }
}