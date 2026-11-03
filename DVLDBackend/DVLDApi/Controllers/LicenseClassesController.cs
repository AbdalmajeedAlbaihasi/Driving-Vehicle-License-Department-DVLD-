using DVLDBusiness;
using DVLDDataAccess.Entities;
using DVLDShared.DTOs.LicenseClass;
using DVLDShared.DTOs.TestType;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVLDAPI.Controllers
{
    [Route("api/LicenseClasses")]
    [ApiController]
    public class LicenseClassesController : Controller
    {
        private readonly clsLicenseClassesBusiness _clsLicenseClassesBusiness;
        public LicenseClassesController(clsLicenseClassesBusiness clsLicenseClassesBusiness)
        {
            _clsLicenseClassesBusiness = clsLicenseClassesBusiness;
        }


        [HttpGet("All", Name = "GetAllLicenseClassesNameAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<LicenseClassesNameDTO>>> GetAllLicenseClassesNameAsync()
        {
            List<LicenseClassesNameDTO> licenseClasses =
                await _clsLicenseClassesBusiness.GetAllLicenseClassesNameAsync();

            if (licenseClasses == null || licenseClasses.Count == 0)
            {
                return NotFound("No License Classes Name found");
            }

            return Ok(licenseClasses);
        }
    }
    
}
