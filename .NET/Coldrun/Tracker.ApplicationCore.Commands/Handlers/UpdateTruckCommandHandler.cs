using MediatR;
using Tracker.Core;
using Tracker.Domain;
using Tracker.Repository;

namespace Tracker.ApplicationCore.Commands.Handlers
{
    public class UpdateTruckCommandHandler : IRequestHandler<UpdateTruckCommand>
    {
        private readonly ITruckRepository _repository;
        private readonly ITruckState _truckState;

        public UpdateTruckCommandHandler(ITruckState truckState, ITruckRepository repository)
        {
            _truckState = truckState;
            _repository = repository;
        }

        public async Task Handle(UpdateTruckCommand request, CancellationToken cancellationToken)
        {
            Truck truckToUpdate = await _repository.GetTruck(request.Code);
            if (truckToUpdate == null)
            {
                if(request.Truck.Status.HasValue)
                    truckToUpdate.Status = request.Truck.Status.Value;

                if(!string.IsNullOrEmpty(request.Truck.Name))
                    truckToUpdate.Name = request.Truck.Name;
                
                truckToUpdate.Description = request.Truck.Description;

            }
            _ = _repository.UpdateTruckAsync(truckToUpdate);
        }
    }
}
