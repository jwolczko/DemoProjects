using MediatR;
using Tracker.Core;
using Tracker.Domain;
using Tracker.Repository;

namespace Tracker.ApplicationCore.Commands.Handlers;

public class SetNextStatusCommandHandler : BaseTruckRepositoryCommandHandler, 
    IRequestHandler<SetNextStatusCommand>
{
    protected readonly ITruckState _truckState;

    public SetNextStatusCommandHandler(ITruckState truckState, ITruckRepository truckRepository)
        :base (truckRepository)
    {
        _truckState = truckState;
    }

    public Task Handle(SetNextStatusCommand request, CancellationToken cancellationToken)
    {
        return _repository.GetTruck(request.Code)
            .ContinueWith(SetNextState)
            .ContinueWith(UpdateTruck);
    }

    protected Truck SetNextState(Task<Truck> task)
    {
        if (task.Result == null)
            return null;

        _truckState.SetNextState(task.Result);
        return task.Result;
    }
}
