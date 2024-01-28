using MediatR;
using Tracker.Repository;

namespace Tracker.ApplicationCore.Commands.Handlers
{
    public class DeleteTruckCommandHandler : IRequestHandler<DeleteTruckCommand>
    {
        private readonly ITruckRepository _repository;
        
        public DeleteTruckCommandHandler(ITruckRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(DeleteTruckCommand request, CancellationToken cancellationToken)
        {
            return _repository.DeleteTruckAsync(request.Code);
        }
    }
}
