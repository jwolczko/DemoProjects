namespace Tracker.Domain;

public enum TrackStatus
{
    OutOfService = 0,
    Loading = 1,
    ToJob = 2,
    AtJob = 3,
    Returning = 4
}