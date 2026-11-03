using DVLDShared.DTOs.Nationalities;
using DVLDBusiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DVLDBackend.DVLDApi.Controllers
{
    //[Authorize(Policy = "CanManageDVLD")]
    [Route("api/[controller]")]
    [ApiController]
    public class NationalityAPIController : ControllerBase
    {
        private readonly clsNationalitiesBusiness _nationalitiesBusiness;

        public NationalityAPIController(
            clsNationalitiesBusiness nationalitiesBusiness)
        {
            _nationalitiesBusiness = nationalitiesBusiness;
        }


        // GET: api/NationalityAPI/All
        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<NationalityListDTO>>>GetAllNationalities()
        {
            var list =
                await _nationalitiesBusiness.GetAllNationalities();

            if (list == null || list.Count == 0)
                return NotFound("No Nationalities");

            return Ok(list);
        }


        // GET: api/NationalityAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NationalityListDTO>>
            GetNationalityById(int id)
        {
            if (id < 1)
                return BadRequest("Invalid ID");

            var nationality =
                await _nationalitiesBusiness.GetNationalityByID(id);

            if (nationality == null)
                return NotFound("Nationality Not Found");

            return Ok(nationality);
        }
    }
}