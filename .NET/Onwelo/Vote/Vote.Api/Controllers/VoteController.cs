using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vote.Api.Commands;

namespace Vote.Api.Controllers
{

    [ApiController]
    public class VoteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VoteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("api/vote")]
        [HttpPost]
        public IActionResult Vote([FromBody] Model.Vote vote)
        {
            var voteCommand = new VoteCommand { Vote = vote };
            _mediator.Send(voteCommand);

            return Ok();
        }        
    }
}
