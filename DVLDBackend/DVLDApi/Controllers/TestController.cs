using DVLDBusiness;
using DVLDShared.DTOs;
using DVLDShared.DTOs.Test;
using Microsoft.AspNetCore.Mvc;

namespace DVLDApi.Controllers
{
    [Route("api/Test")]
    [ApiController]
    public class TestController : Controller
    {
        private readonly clsTestBusiness _business;

        public TestController(clsTestBusiness business)
        {
            _business = business;
        }

        [HttpGet("{id:int}", Name = "GetTestById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TestDTO>> GetTestById(int id)
        {
            var test = await _business.GetTestInfoByIdAsync(id);
            if (test == null) return NotFound($"Test with ID {id} not found.");
            return Ok(test);
        }



        [HttpGet("last/person/{personId:int}/license-class/{licenseClassId:int}/test-type/{testTypeId:int}", Name = "GetLastTest")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TestDTO>> GetLastTest(int personId, int licenseClassId, int testTypeId)
        {
            var test = await _business.GetLastTestByPersonAndTestTypeAndLicenseClassAsync(personId, licenseClassId, testTypeId);
            if (test == null) return NotFound("No test found matching criteria.");
            return Ok(test);
        }



        [HttpGet(Name = "GetAllTests")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<TestDTO>>> GetAllTests()
        {
            var tests = await _business.GetAllTestsAsync();
            if (tests == null || tests.Count == 0) return NotFound("No tests found.");
            return Ok(tests);
        }



        [HttpGet("passed-count/{localDrivingId:int}", Name = "GetPassedTestCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<byte>> GetPassedTestCount(int localDrivingId)
        {
            byte count = await _business.GetPassedTestCountAsync(localDrivingId);
            return Ok(count);
        }



        [HttpGet("passed-all/{localDrivingId:int}", Name = "PassedAllTests")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> PassedAllTests(int localDrivingId)
        {
            bool passedAll = await _business.PassedAllTestsAsync(localDrivingId);
            return Ok(passedAll);
        }




        [HttpPost(Name = "AddNewTest")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<SuccessMessageResponseIdDTO>> AddNewTest([FromBody] AddNewTestDTO testDTO)
        {
            if (testDTO == null)
            {
                return BadRequest(new SuccessMessageResponseIdDTO(false, "Invalid test data provided.", -1));
            }

            try
            {
                // استدعاء طبقة الـ Business
                SuccessMessageResponseIdDTO result = await _business.AddNewTestAsync(testDTO);

                if (!result.Success)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new SuccessMessageResponseIdDTO(false, $"An unexpected server error occurred: {ex.Message}", -1));
            }
        }



        [HttpPut(Name = "UpdateTest")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SuccessMessageResponseIdDTO>> UpdateTest([FromBody] UpdateTestDTO dto)
        {
            if (dto == null) return BadRequest(new SuccessMessageResponseIdDTO(false, "Invalid test data.", -1));
            var result = await _business.UpdateTestAsync(dto);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }
    }
}