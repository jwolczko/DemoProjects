using MediatR;
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
            return _repository.CreateTruckAsync(request.Truck);
        }
    }
}
