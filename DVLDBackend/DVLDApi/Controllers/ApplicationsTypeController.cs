using DVLDBusiness;
using DVLDShared.DTOs.ApplicationsType;
using Microsoft.AspNetCore.Mvc;

namespace DVLDAPI.Controllers
{
    [Route("api/applicationtypes")]
    [ApiController]
    public class ApplicationsTypeController : ControllerBase
    {
        private readonly clsApplicationsTypeBusiness _applicationsTypeBusiness;

        public ApplicationsTypeController(
            clsApplicationsTypeBusiness applicationsBusiness)
        {
            _applicationsTypeBusiness = applicationsBusiness;
        }


        // Get All Application Types
        [HttpGet("All", Name = "GetAllApplicationTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<ApplicationsTypeDTO>>>
            GetAllApplicationTypesAsync()
        {
            List<ApplicationsTypeDTO> applicationTypes =
                await _applicationsTypeBusiness.GetAllApplicationsTypeAsync();

            if (applicationTypes == null ||
                applicationTypes.Count == 0)
            {
                return NotFound("No application types found");
            }

            return Ok(applicationTypes);
        }


        // Update Application Type Title
        [HttpPut(
            "UpdateTitle/{applicationTypeId}",
            Name = "UpdateApplicationTypeTitle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateApplicationTypeTitleAsync(
            int applicationTypeId,
            [FromBody] string newTitle)
        {
            if (applicationTypeId <= 0)
            {
                return BadRequest("Invalid application type ID");
            }

            if (string.IsNullOrWhiteSpace(newTitle))
            {
                return BadRequest("New title cannot be empty");
            }

            var result =
                await _applicationsTypeBusiness.UpdateTitleNameAsync(
                    applicationTypeId,
                    newTitle);

            if (!result.Success)
            {
                return BadRequest(new
                {
                    Message = result.Message
                });
            }

            return Ok(new
            {
                Message = result.Message
            });
        }


        // Update Application Type Fees
        [HttpPut(
            "UpdateFees/{applicationTypeId}",
            Name = "UpdateApplicationTypeFees")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateApplicationTypeFeesAsync(
            int applicationTypeId,
            [FromBody] decimal newFees)
        {
            if (applicationTypeId <= 0)
            {
                return BadRequest("Invalid application type ID");
            }

            if (newFees < 0)
            {
                return BadRequest("New fees cannot be negative");
            }

            var result =
                await _applicationsTypeBusiness.UpdateApplicationFeesAsync(
                    applicationTypeId,
                    newFees);

            if (!result.Success)
            {
                return BadRequest(new
                {
                    Message = result.Message
                });
            }

            return Ok(new
            {
                Message = result.Message
            });
        }
    }
}