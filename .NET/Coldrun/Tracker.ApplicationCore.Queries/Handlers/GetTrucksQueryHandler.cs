using MediatR;
using Tracker.Domain;
using Tracker.Repository;

namespace Tracker.ApplicationCore.Queries.Handlers;

public class GetTrucksQueryHandler : IRequestHandler<GetTrucksQuery, IEnumerable<Truck>>
{
    private readonly ITruckRepository _repository;
    public GetTrucksQueryHandler(ITruckRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Truck>> Handle(GetTrucksQuery request, CancellationToken cancellationToken)
    {
        return _repository.GetTrucksAsync();
    }
}
