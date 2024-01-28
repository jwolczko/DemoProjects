using Tracker.Domain;

namespace Tracker.Core;

public interface ITruckState
{
    void SetNextState(Truck truck);
}
