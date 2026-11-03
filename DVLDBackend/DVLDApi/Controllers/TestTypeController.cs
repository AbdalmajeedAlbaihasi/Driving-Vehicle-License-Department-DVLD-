using DVLDBusiness;
using DVLDDataAccess.Entities;
using DVLDShared.DTOs.ApplicationsType;
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


        [HttpGet("{TestTypeID}", Name = "GetOneTestTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TestTypeDTO>> GetOneTestTypes(int TestTypeID)
        {
            TestTypeDTO? testTypeDTO = await _testTypeBusiness.GetOneTestTypes(TestTypeID);

            if (testTypeDTO == null)
            {
                return NotFound("No application type found");
            }

            return Ok(testTypeDTO);
        }


        // Update Test Type
        [HttpPut("Update/{testTypeID}", Name = "UpdateTestType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateTestType(int testTypeID, [FromBody] TestTypeDTO testTypeDTO)
        {
            if (testTypeDTO == null || testTypeID != testTypeDTO.TestTypeId)
            {
                return BadRequest(new
                {
                    Success = false,
                    Message = "Invalid data or ID mismatch."
                });
            }

            var result = await _testTypeBusiness.UpdateTestTypeAsync(testTypeDTO);


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

       

    }
}