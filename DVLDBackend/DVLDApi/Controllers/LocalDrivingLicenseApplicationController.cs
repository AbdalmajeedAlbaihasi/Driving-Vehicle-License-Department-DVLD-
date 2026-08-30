using DVLDBusiness;
using DVLDShared.DTOs.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVLDAPI.Controllers
{
    [Route("api/LocalDrivingLicenseApplication")]
    [ApiController]
    public class LocalDrivingLicenseApplicationController : Controller
    {
        private readonly clsLocalDrivingLicenseApplicationBusiness _localDrivingLicenseApplicationBusiness;
        public LocalDrivingLicenseApplicationController(clsLocalDrivingLicenseApplicationBusiness localDrivingLicenseApplicationBusiness)
        {
            _localDrivingLicenseApplicationBusiness = localDrivingLicenseApplicationBusiness;
        }

        [HttpGet("All", Name = "GetAllLocalDrivingLicenseApplication")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetAllLocalDrivingLicenseApplication()
        {
            var result = await _localDrivingLicenseApplicationBusiness.GetAllLocalDrivingLicenseApplicationsAsync();
            if (!result.Success)
            {
                return NotFound(result.Message);
            }
            return Ok(result.Applications);
        }
        
        [HttpPut("Update", Name = "UpdateLocalDrivingLicenseApplicationStatus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateLocalDrivingLicenseApplicationStatus(int applicationId, byte newStatus)
        {
            var result = await _localDrivingLicenseApplicationBusiness.UpdateLocalDrivingLicenseApplicationStatusAsync(applicationId, newStatus);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }
    }
}