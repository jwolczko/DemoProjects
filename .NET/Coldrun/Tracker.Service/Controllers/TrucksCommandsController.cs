using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tracker.ApplicationCore.Commands;

namespace Tracker.Service.Controllers;

[Route("api/trucks")]
[ApiController]
public class TrucksCommandsController : ControllerBase
{
    private readonly IMediator _mediator;
    public TrucksCommandsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTruck(CreateTruckCommand command)
    {
        var truckId = await _mediator.Send(command);
        return Ok(truckId);
    }

    [HttpPut("{code}")]
    public async Task<IActionResult> UpdateTruck(string code, UpdateTruckCommand command)
    {
        command.Code = code;
        await _mediator.Send(command);
        return Ok();
    }

    [HttpDelete("{code}")]
    public async Task<IActionResult> DeleteTruck(string code)
    {
        await _mediator.Send(new DeleteTruckCommand { Code = code });
        return NoContent();
    }

}