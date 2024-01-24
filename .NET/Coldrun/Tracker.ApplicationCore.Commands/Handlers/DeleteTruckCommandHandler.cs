using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            throw new NotImplementedException();
        }
    }
}
