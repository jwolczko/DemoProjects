using MediatR;
using Tracker.Domain;

namespace Tracker.ApplicationCore.Queries;

// Get Trucks Query
public class GetTrucksQuery : IRequest<IEnumerable<Truck>>
{
    // Add parameters for filtering and sorting if needed
}
