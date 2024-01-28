namespace Tracker.Domain;

// Truck Model
public class Truck
{
    public string Code { get; set; }
    public string Name { get; set; }
    public TrackStatus Status { get; set; }
    public string Description { get; set; }
}