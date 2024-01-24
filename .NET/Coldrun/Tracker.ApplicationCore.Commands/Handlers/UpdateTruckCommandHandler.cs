using MediatR;
using Tracker.Repository;

namespace Tracker.ApplicationCore.Commands.Handlers
{
    public class UpdateTruckCommandHandler : IRequestHandler<UpdateTruckCommand>
    {
        private readonly ITruckRepository _repository;

        public UpdateTruckCommandHandler(ITruckRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(UpdateTruckCommand request, CancellationToken cancellationToken)
        {
            return _repository.UpdateTruckAsync(request.Truck);
        }
    }
}
