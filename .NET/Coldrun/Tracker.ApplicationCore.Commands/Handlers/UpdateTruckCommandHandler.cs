using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            throw new NotImplementedException();
        }
    }
}
