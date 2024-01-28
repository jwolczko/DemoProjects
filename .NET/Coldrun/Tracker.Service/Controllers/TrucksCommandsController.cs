using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tracker.ApplicationCore.Commands;
using Tracker.Domain.ValueObjects;

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
    public async Task<IActionResult> CreateTruck([FromBody]NewTruck newTruck)
    {
        CreateTruckCommand command = new()
        {
            Truck = newTruck
        };
        var truckId = await _mediator.Send(command);
        return Ok(truckId);
    }

    [HttpPut("{code}")]
    public async Task<IActionResult> UpdateTruck(string code, [FromBody]UpdateTruck updateTruck)
    {
        UpdateTruckCommand command = new()
        {
            Truck = updateTruck,
            Code = code
        };
        await _mediator.Send(command);
        return Ok();
    }

    [HttpPut("{code}/next_status")]
    public async Task<IActionResult> SetNextStatus(string code)
    {
        SetNextStatusCommand command = new()
        {
            Code = code
        };

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