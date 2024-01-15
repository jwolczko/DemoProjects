using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vote.Api.Commands;
using Vote.Api.Queries;
using Vote.Model;

namespace Vote.Api.Controllers
{
    
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CandidatesController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        [Route("api/candidates")]
        public async Task<IEnumerable<Candidate>> GetCandidates()
        {
            var query = new CandidateQuery();
            var result = await _mediator.Send(query);
            return result;
        }

        [Route("api/candidate")]
        [HttpPost]
        public IActionResult AddVoter([FromBody] Candidate voter)
        {
            var query = new CreatePersonCommand { Person = voter };
            var result = _mediator.Send(query);
            return Ok(result);
        }


    }
}
