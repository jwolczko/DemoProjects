using MediatR;
using Tracker.Domain;
using Tracker.Repository;

namespace Tracker.ApplicationCore.Commands.Handlers
{
    public class CreateTruckCommandHandler : IRequestHandler<CreateTruckCommand, string>
    {
        private readonly ITruckRepository _repository;

        public CreateTruckCommandHandler(ITruckRepository repository)
        {
            _repository = repository;
        }

        public Task<string> Handle(CreateTruckCommand request, CancellationToken cancellationToken)
        {
            Truck newTruck = new()
            {
                Code = request.Truck.Code,
                Name = request.Truck.Name,
                Description = request.Truck.Description,
                Status = TrackStatus.OutOfService
            };

            return _repository.CreateTruckAsync(newTruck);
        }
    }
}
