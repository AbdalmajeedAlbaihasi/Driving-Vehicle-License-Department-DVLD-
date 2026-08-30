using DVLDBusiness;
using DVLDShared.DTOs.Applications;
using Microsoft.AspNetCore.Mvc;

namespace DVLDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly clsApplicationsBusiness _business;

        public ApplicationsController(clsApplicationsBusiness business)
        {
            _business = business;
        }


        [HttpPost("Add", Name = "AddNewApplication")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddNewApplication([FromBody] AddNewApplicationDTO applicationDTO)
        {
            if (applicationDTO == null)
            {
                return BadRequest(new
                {
                    Error = "Application data is null."
                });
            }

            var result =
                await _business.AddNewApplicationAsync(applicationDTO);

            if (!result.Success)
            {
                return BadRequest(new
                {
                    Error = result.Message
                });
            }

            return StatusCode(
                StatusCodes.Status201Created,
                new
                {
                    LocalDrivingLicenseApplicationID =
                        result.newLocalDrivingLicenseApplicationID,

                    Message = result.Message
                });
        }
    }
}