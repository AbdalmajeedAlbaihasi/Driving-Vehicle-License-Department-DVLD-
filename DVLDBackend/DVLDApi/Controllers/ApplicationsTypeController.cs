using DVLDBusiness;
using DVLDDataAccess.Entities;
using DVLDShared.DTOs.ApplicationsType;
using DVLDShared.DTOs.Users;
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
        public async Task<ActionResult<List<ApplicationsTypeDTO>>> GetAllApplicationTypesAsync()
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


        [HttpGet("{applicationTypeId}", Name = "GetOneApplicationType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApplicationsTypeDTO>> GetOneApplicationTypeAsync(int applicationTypeId)
        {
            ApplicationsTypeDTO? applicationType = await _applicationsTypeBusiness.GetOneApplicationsTypeAsync(applicationTypeId);

            if (applicationType == null )
            {
                return NotFound("No application type found");
            }

            return Ok(applicationType);
        }



        // Update Application Type Title
        [HttpPut("Update/{applicationTypeId}", Name = "UpdateApplicationTypeTitle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateApplicationsTypeAsync(int applicationTypeId, [FromBody] ApplicationsTypeDTO applicationsTypeDTO)
        {
            if (applicationsTypeDTO == null || applicationTypeId != applicationsTypeDTO.ApplicationTypeId)
            {
                return BadRequest(new
                {
                    Success = false,
                    Message = "Invalid data or ID mismatch."
                });
            }


            var result = await _applicationsTypeBusiness.UpdateApplicationsTypeAsync(applicationsTypeDTO);

            if (!result.Success)
            {
                return NotFound(new
                {
                    Success = result.Success,
                    Message = result.Message
                });
            }

            return Ok(new
            {
                Success = result.Success,
                Message = result.Message,
            });
        }




        [HttpGet("GetFees/{applicationTypeId}", Name = "GetApplicationTypeFeesById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetApplicationTypeFeesById(int applicationTypeId)
        {
            // 1. التحقق من صحة البرامتر
            if (applicationTypeId <= 0)
            {
                return BadRequest(new
                {
                    Success = false,
                    Message = "Invalid Application Type ID."
                });
            }

            // 2. استدعاء البيزنس
            var result = await _applicationsTypeBusiness.GetApplicationTypeFeesByIdAsync(applicationTypeId);

            // 3. معالجة حالة عدم العثور على البيانات
            if (!result.Success)
            {
                return NotFound(new
                {
                    Success = false,
                    Message = result.Message
                });
            }

            // 4. إرجاع الاستجابة بنجاح 200 OK متضمنة القيمة الماليّة
            return Ok(new
            {
                Success = true,
                Message = result.Message,
                Fees = result.Fees
            });
        }

    }
}