using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


        public async Task<string> Handle(CreateTruckCommand request, CancellationToken cancellationToken)
        {
            _repository.CreateTruck(request.Truck);
        }
    }
}
