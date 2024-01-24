using MediatR;
using Tracker.Domain;

namespace Tracker.ApplicationCore.Commands;

public class CreateTruckCommand : IRequest<string>
{
    public Truck Truck { get; set; }
}