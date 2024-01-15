using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vote.Api.Commands;
using Vote.Api.Queries;
using Vote.Model;

namespace Vote.Api.Controllers
{

    [ApiController]
    public class VotersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VotersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("api/voters")]
        [HttpGet]
        public async Task<IEnumerable<Voter>> GetVoters()
        {
            var query = new VotersQuery();
            var result = await _mediator.Send(query);
            return result;
        }

        [Route("api/voter")]
        [HttpPost]
        public IActionResult AddVoter([FromBody] Voter voter)
        {
            var query = new CreatePersonCommand { Person = voter };
            var result = _mediator.Send(query);
            return Ok(result);
        }
    }
}
