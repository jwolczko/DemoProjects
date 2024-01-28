using Tracker.Domain;

namespace Tracker.Core;

public class TruckState : ITruckState
{
    public void SetNextState(Truck truck)
    {
        switch (truck.Status)
        {
            case TrackStatus.OutOfService:
                SetLoading(truck);
                break;
            case TrackStatus.Loading:
                SetToJob(truck);
                break;
            case TrackStatus.ToJob:
                SetAtJob(truck);
                break;
            case TrackStatus.AtJob:
                SetReturning(truck);
                break;
            case TrackStatus.Returning:
                SetLoading(truck);
                break;
            default:
                SetOutOfService(truck);
                break;
        }
    }


    private void SetAtJob(Truck truck)
    {
        truck.Status = TrackStatus.AtJob;
    }

    private void SetLoading(Truck truck)
    {
        truck.Status = TrackStatus.Loading;
    }

    private void SetOutOfService(Truck truck)
    {
        truck.Status = TrackStatus.OutOfService;
    }

    private void SetReturning(Truck truck)
    {
        truck.Status = TrackStatus.Returning;
    }

    private void SetToJob(Truck truck)
    {
        truck.Status = TrackStatus.ToJob;
    }
}
