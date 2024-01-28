using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tracker.ApplicationCore.Queries;

namespace Tracker.Service.Controllers;

[Route("api/trucks")]
[ApiController]
public class TrucksQueriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public TrucksQueriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetTrucks([FromQuery] GetTrucksQuery query)
    {
        var trucks = await _mediator.Send(query);
        return Ok(trucks);
    }
}
