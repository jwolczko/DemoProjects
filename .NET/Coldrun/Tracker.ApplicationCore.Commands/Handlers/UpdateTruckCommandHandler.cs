using MediatR;
using Tracker.Core;
using Tracker.Domain;
using Tracker.Repository;

namespace Tracker.ApplicationCore.Commands.Handlers
{
    public class UpdateTruckCommandHandler : BaseTruckRepositoryCommandHandler,
        IRequestHandler<UpdateTruckCommand>
    {
        public UpdateTruckCommandHandler(ITruckRepository repository) : base(repository)
        {
        }

        public Task Handle(UpdateTruckCommand request, CancellationToken cancellationToken)
        {
            return _repository.GetTruck(request.Code)
                .ContinueWith((task) =>
                {
                    if (task != null && task.Result != null)
                    {
                        if (request.Truck.Status.HasValue)
                            task.Result.Status = request.Truck.Status.Value;

                        if (!string.IsNullOrEmpty(request.Truck.Name))
                            task.Result.Name = request.Truck.Name;

                        task.Result.Description = request.Truck.Description;
                    }
                    return task.Result;

                }).ContinueWith(UpdateTruck);
        }
    }
}
