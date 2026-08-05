using DVLDBusiness;
using DVLDShared.DTOs.People;
using Microsoft.AspNetCore.Mvc;

namespace DVLDAPI.Controllers;

[Route("api/people")]
[ApiController]
public sealed class PeopleController : ControllerBase
{
    private readonly PeopleService _peopleService;

    public PeopleController(PeopleService peopleService)
    {
        _peopleService = peopleService;
    }

    [HttpGet]
    [ProducesResponseType(
        typeof(List<PersonListDto>),
        StatusCodes.Status200OK)]
    public async Task<ActionResult<List<PersonListDto>>> GetAll(
        CancellationToken cancellationToken)
    {
        List<PersonListDto> people =
            await _peopleService.GetAllAsync(
                cancellationToken);

        return Ok(people);
    }
}