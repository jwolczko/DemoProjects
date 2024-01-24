using MediatR;

namespace Tracker.ApplicationCore.Commands
{
    // Delete Truck Command
    public class DeleteTruckCommand : IRequest
    {
        public string Code { get; set; }
    }
}
