using MediatR;
using Vote.Data;

namespace Vote.Api.Commands
{
    public class VoteCommandHandler : IRequestHandler<VoteCommand>
    {
        private readonly VoteDb _context;

        public VoteCommandHandler(VoteDb context)
        {
            _context = context;
        }

        public Task Handle(VoteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var voter = _context.Persons.FirstOrDefault(e => e.Id == request.Vote.Voter.Id);
                var candidate = _context.Persons.FirstOrDefault(e => e.Id == request.Vote.Candidate.Id);

                var newVote = new Vote.Data.Entities.Vote
                {
                    Voter = voter,
                    Candidate = candidate
                };

                _context.Votes.Add(newVote);

                return _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}