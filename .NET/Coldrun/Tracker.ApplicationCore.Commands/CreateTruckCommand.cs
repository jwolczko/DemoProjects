using MediatR;
using Tracker.Domain;

namespace Tracker.ApplicationCore.Commands;

// Truck Model
// Create Truck Command
public class CreateTruckCommand : IRequest<string>
{
    public Truck Truck { get; set; }
}