using MediatR;
using Microsoft.EntityFrameworkCore;
using Vote.Data;
using Vote.Model;

namespace Vote.Api.Queries
{
    public class VotersQueryHandler : IRequestHandler<VotersQuery, IEnumerable<Voter>>
    {
        private readonly VoteDb _context;

        public VotersQueryHandler(VoteDb context)
        {
            _context = context;
        }

        public Task<IEnumerable<Voter>> Handle(VotersQuery request, CancellationToken cancellationToken)
        {
            var allVoters = new List<Voter>();
            try
            {
                var voters = _context.Voters.FromSql($"GetVoters").ToList();

                foreach (var voter in voters)
                {
                    allVoters.Add(new Voter 
                    { 
                        Id = voter.Id, 
                        FirstName = voter.FirstName, 
                        LastName = voter.LastName,
                        HasVote = voter.HasVote? "v": "x"                        
                    });
                }

                return Task.FromResult(allVoters.AsEnumerable());
            }
            catch (Exception e)
            {
                return Task.FromResult(new List<Voter>().AsEnumerable());
            }
        }
    }
}
