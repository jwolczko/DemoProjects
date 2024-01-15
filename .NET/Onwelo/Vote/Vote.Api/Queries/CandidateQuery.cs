using MediatR;
using Vote.Model;

namespace Vote.Api.Queries
{
    public class CandidateQuery : IRequest<IEnumerable<Candidate>>
    {
    }
}
