using DVLDBusiness;
using DVLDShared.DTOs.TestType;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVLDAPI.Controllers
{
    [Route("api/testtypes")]
    [ApiController]
    public class TestTypesController : ControllerBase
    {
        private readonly clsTestTypeBusiness _testTypeBusiness;

        public TestTypesController(clsTestTypeBusiness testTypeBusiness)
        {
            _testTypeBusiness = testTypeBusiness;
        }


        // Get All Test Types
        [HttpGet("All", Name = "GetAllTestTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<TestTypeDTO>>> GetAllTestTypes()
        {
            List<TestTypeDTO> testTypes =
                await _testTypeBusiness.GetAllTestTypesAsync();

            if (testTypes == null || testTypes.Count == 0)
            {
                return NotFound("No test types found");
            }

            return Ok(testTypes);
        }


        // Update Test Type
        [HttpPut("Update/{testTypeID}", Name = "UpdateTestType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateTestType(
            int testTypeID,
            [FromBody] TestTypeDTO testTypeDTO)
        {
            if (testTypeID <= 0)
            {
                return BadRequest("Invalid test type ID");
            }

            if (testTypeDTO == null)
            {
                return BadRequest("Invalid data");
            }

            testTypeDTO.TestTypeId = testTypeID;

            var result =
                await _testTypeBusiness.UpdateTestTypeAsync(testTypeDTO);

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