using MediatR;
using Tracker.Core;
using Tracker.Domain;
using Tracker.Repository;

namespace Tracker.ApplicationCore.Commands.Handlers;

public class SetNextStatusCommandHandler : IRequestHandler<SetNextStatusCommand>
{
    private readonly ITruckRepository _repository;
    private readonly ITruckState _truckState;

    public SetNextStatusCommandHandler(ITruckState truckState, ITruckRepository truckRepository)
    {
        _repository = truckRepository;
        _truckState = truckState;
    }

    public async Task Handle(SetNextStatusCommand request, CancellationToken cancellationToken)
    {
        Truck truckToUpodate = await _repository.GetTruck(request.Code).ConfigureAwait(false);
        _truckState.SetNextState(truckToUpodate);
        _ = _repository.UpdateTruckAsync(truckToUpodate);
    }
}
