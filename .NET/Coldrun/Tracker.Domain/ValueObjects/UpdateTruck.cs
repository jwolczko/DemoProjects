namespace Tracker.Domain.ValueObjects;

public class UpdateTruck
{
    public string Name { get; set; }
    public string Description { get; set; }
    public TrackStatus? Status { get; set; }
    public string ReasonOfUpdateStatus { get; set; }
}
