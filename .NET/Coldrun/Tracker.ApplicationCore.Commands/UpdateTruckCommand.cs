using MediatR;
using Tracker.Domain.ValueObjects;

namespace Tracker.ApplicationCore.Commands
{
    public class UpdateTruckCommand : IRequest
    {
        public string Code { get; set; }
        public UpdateTruck Truck { get; set; }
    }
}
