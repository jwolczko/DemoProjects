using MediatR;
using Tracker.Domain;

namespace Tracker.ApplicationCore.Commands
{
    public class UpdateTruckCommand : IRequest
    {
        public string Code { get; set; }
        public Truck Truck { get; set; }
    }
}
