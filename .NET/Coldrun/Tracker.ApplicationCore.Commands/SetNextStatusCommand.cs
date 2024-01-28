using MediatR;

namespace Tracker.ApplicationCore.Commands;

public class SetNextStatusCommand : IRequest
{
    public string Code { get; set; }
}
