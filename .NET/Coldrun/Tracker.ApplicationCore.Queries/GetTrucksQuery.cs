using MediatR;
using Tracker.Domain;

namespace Tracker.ApplicationCore.Queries;

public class GetTrucksQuery : IRequest<IEnumerable<Truck>>
{
}
