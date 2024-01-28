using MediatR;
using Tracker.Domain.ValueObjects;

namespace Tracker.ApplicationCore.Commands;

public class CreateTruckCommand : IRequest<string>
{
    public NewTruck Truck { get; set; }
}