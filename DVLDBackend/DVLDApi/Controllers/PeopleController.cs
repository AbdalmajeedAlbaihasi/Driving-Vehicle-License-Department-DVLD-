using DVLDBusiness;
using DVLDShared.DTOs.People;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DVLDAPI.Controllers
{
    [Route("api/people")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly clsPeopleBusiness _clsPeopleBusiness;

        public PeopleController(clsPeopleBusiness clsPeopleBusiness)
        {
            _clsPeopleBusiness = clsPeopleBusiness;
        }


        [HttpGet("All", Name = "GetAllPeople")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<PersonListDTO>>> GetAllPeople()
        {
            var peopleList = await _clsPeopleBusiness.GetAllPeopleAsync();

            if (!peopleList.Success)
            {
                return NotFound(peopleList);
            }

            return Ok(peopleList.People);
        }


        [HttpGet("{PersonID}", Name = "GetPersonByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OnePeopleDTO>> GetPersonByID(int PersonID)
        {
            if (PersonID < 1)
            {
                return BadRequest("Invalid Person ID");
            }

            OnePeopleDTO person =
                await _clsPeopleBusiness.GetPersonByIDAsync(PersonID);

            if (person == null)
            {
                return NotFound("Person Not Found");
            }

            return Ok(person);
        }


        [HttpGet(
            "ByNationalNo/{nationalNo}",
            Name = "GetPersonByNationalNo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OnePeopleDTO>> GetPersonByNationalNo(
            string nationalNo)
        {
            if (string.IsNullOrWhiteSpace(nationalNo))
            {
                return BadRequest("Invalid National Number");
            }

            OnePeopleDTO person =
                await _clsPeopleBusiness.GetPersonByNationalNoAsync(nationalNo);

            if (person == null)
            {
                return NotFound("Person Not Found");
            }

            return Ok(person);
        }


        [HttpPost("Add", Name = "AddNewPerson")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddNewPerson(
            [FromBody] AddNewPeopleDTO addNewPeopleDTO)
        {
            var result =
                await _clsPeopleBusiness.AddNewPersonAsync(addNewPeopleDTO);

            if (!result.Success)
            {
                return BadRequest(new
                {
                    Error = result.Message
                });
            }

            return CreatedAtRoute(
                "GetPersonByID",
                new
                {
                    PersonID = result.PersonID
                },
                new
                {
                    PersonID = result.PersonID,
                    Message = result.Message
                });
        }


        [HttpPut(
            "Update/{PersonID}",
            Name = "UpdatePerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdatePerson(
            int PersonID,
            [FromBody] UpdatePeopleDTO updatePeopleDTO)
        {
            if (PersonID < 1)
            {
                return BadRequest("Invalid Person ID");
            }

            if (updatePeopleDTO == null)
            {
                return BadRequest("Invalid Data");
            }

            OnePeopleDTO person =
                await _clsPeopleBusiness.GetPersonByIDAsync(PersonID);

            if (person == null)
            {
                return NotFound("Person Not Found");
            }

            updatePeopleDTO.PersonID = PersonID;

            var result =
                await _clsPeopleBusiness.UpdatePersonAsync(updatePeopleDTO);

            if (!result.Success)
            {
                return BadRequest(new
                {
                    Error = result.Message
                });
            }

            return Ok(new
            {
                Message = result.Message
            });
        }


        [HttpDelete(
            "Delete/{PersonID}",
            Name = "DeletePerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeletePerson(int PersonID)
        {
            if (PersonID < 1)
            {
                return BadRequest("Invalid Person ID");
            }

            OnePeopleDTO person =
                await _clsPeopleBusiness.GetPersonByIDAsync(PersonID);

            if (person == null)
            {
                return NotFound("Person Not Found");
            }

            var result =
                await _clsPeopleBusiness.DeletePersonAsync(PersonID);

            if (!result.Success)
            {
                return BadRequest(new
                {
                    Error = result.Message
                });
            }

            return Ok(new
            {
                Message = result.Message
            });
        }


        [HttpGet("IsNationalNoExists/{nationalNo}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> IsNationalNoExists(string nationalNo)
        {
            bool exists =
                await _clsPeopleBusiness.IsNationalNoExistsAsync(nationalNo);

            return Ok(exists);
        }
    }
}