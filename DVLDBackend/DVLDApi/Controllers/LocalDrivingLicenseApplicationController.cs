using DVLDBusiness;
using DVLDDataAccess.Entities;
using DVLDShared.DTOs.Applications;
using DVLDShared.DTOs;
using DVLDShared.DTOs.LocalDrivingLicenseApplications;
using DVLDShared.DTOs.TestType;
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
        public async Task<ActionResult<List<LocalDrivingLicenseApplicationListDTO>>> GetAllLocalDrivingLicenseApplication()
        {
            var result = await _localDrivingLicenseApplicationBusiness.GetAllLocalDrivingLicenseApplicationsAsync();

            // إذا فشلت العملية أو لم توجد بيانات، نرجع قائمة فارغة بدلاً من كائن Error
            if (!result.Success || result.ApplicationsList == null)
            {
                return Ok(new List<LocalDrivingLicenseApplicationListDTO>());
            }

            // إرجاع القائمة مباشرة ليتم استلامها كـ JSON Array [...]
            return Ok(result.ApplicationsList);
        }







        [HttpGet("{id}", Name = "GetOneLocalDrivingLicenseApplicationsAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetOneLocalDrivingLicenseApplicationDTO>> GetOneLocalDrivingLicenseApplicationsAsync(int id)
        {
            var result = await _localDrivingLicenseApplicationBusiness.GetOneLocalDrivingLicenseApplicationsAsync(id);


            return Ok(result);
        }

        [HttpGet("{id:int}", Name = "GetLocalDrivingLicenseApplicationInfoByID")]
        public async Task<ActionResult<LocalDrivingLicenseApplicationInfoDTO>>
            GetLocalDrivingLicenseApplicationInfoByID(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Local Driving License Application ID.");

            var result = await _localDrivingLicenseApplicationBusiness
                .GetLocalDrivingLicenseApplicationInfoByIDAsync(id);

            if (result == null)
                return NotFound(
                    $"Local Driving License Application with ID {id} was not found.");

            return Ok(result);
        
    }


        [HttpPut("UpdateStatus", Name = "UpdateLocalDrivingLicenseApplicationStatus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateLocalDrivingLicenseApplicationStatus(UpdateStatusDTO updateStatusDTO)
        {
            var result = await _localDrivingLicenseApplicationBusiness.UpdateLocalDrivingLicenseApplicationStatusAsync(updateStatusDTO);
            if (!result.Success)
            {
                return BadRequest(new
                {
                    Success = result.Success,
                    Message = result.Message
                });
            }
            return Ok(new
            {
                Success = result.Success,
                Message = result.Message
            });
        }





        [HttpPost("Add", Name = "AddNewApplication")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddNewLocalDrivingLicenseApplicationAsync([FromBody] AddNewLocalDrivingLicenseApplicationDTO applicationDTO)
        {
            if (applicationDTO == null)
            {
                return BadRequest(new SuccessMessageResponseIdDTO(false, "Application data is null.", 0 ));
            }

            var result = await _localDrivingLicenseApplicationBusiness.AddNewLocalDrivingLicenseApplicationAsync(applicationDTO);

            if (!result.Success)
            {
                // ✅ تم تصحيح إسناد Success لـ false بدلاً من result.Message
                return BadRequest(new SuccessMessageResponseIdDTO(
                    false,
                    result.Message,
                    -1
                    
                ));
            }

            return StatusCode(
                StatusCodes.Status201Created,
                new SuccessMessageResponseIdDTO(
                    true,
                    result.Message,
                    result.ID
                )
            );
        }
   
    
    
    }
}