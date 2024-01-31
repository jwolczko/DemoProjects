using Tracker.Core;
using Tracker.Domain;
using Tracker.Repository;

namespace Tracker.ApplicationCore.Commands.Handlers;
public abstract class BaseTruckRepositoryCommandHandler
{
    protected readonly ITruckRepository _repository;

    protected BaseTruckRepositoryCommandHandler(ITruckRepository repository)
    {
        _repository = repository;
    }    

    protected Task UpdateTruck(Task<Truck> task)
    {
        if (task.Result == null)
            return Task.CompletedTask;

        return _repository.UpdateTruckAsync(task.Result);
    }
}
