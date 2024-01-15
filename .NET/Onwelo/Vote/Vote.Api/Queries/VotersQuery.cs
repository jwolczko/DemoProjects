using Vote.Model;

namespace Vote.Api.Queries
{
    public class VotersQuery : MediatR.IRequest<IEnumerable<Voter>>
    {
    }
}
