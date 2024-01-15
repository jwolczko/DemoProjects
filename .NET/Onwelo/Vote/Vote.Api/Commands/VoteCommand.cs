using MediatR;

namespace Vote.Api.Commands
{
    public class VoteCommand : IRequest
    {
        public Model.Vote Vote { get; set; }
    }
}