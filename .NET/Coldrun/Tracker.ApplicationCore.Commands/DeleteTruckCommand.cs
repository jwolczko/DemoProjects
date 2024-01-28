using MediatR;

namespace Tracker.ApplicationCore.Commands
{
    public class DeleteTruckCommand : IRequest
    {
        public string Code { get; set; }
    }
}
