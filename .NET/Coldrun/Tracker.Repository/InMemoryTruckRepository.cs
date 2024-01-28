using Tracker.Domain;

namespace Tracker.Repository;

public class InMemoryTruckRepository : ITruckRepository
{
    private static readonly Dictionary<string, Truck> _trucks = new();
    
    public InMemoryTruckRepository()
    {
        _trucks["ABC69"] = new Truck { Code = "ABC69", Description = "Truck 1", Name = "Track 1", Status = TrackStatus.OutOfService };
        _trucks["ABC70"] = new Truck { Code = "ABC70", Description = "Truck 2", Name = "Track 2", Status = TrackStatus.Loading };
    }

    public Task<IEnumerable<Truck>> GetTrucksAsync()
    {
        return Task.FromResult(_trucks.Values.AsEnumerable());
    }

    public Task<Truck> GetTruck(string code)
    {
        if (string.IsNullOrEmpty(code))
            return null;

        if(_trucks.TryGetValue(code, out Truck truck))
        {
            return Task.FromResult(truck);
        }
        return null;
    }

    public Task<string> CreateTruckAsync(Truck truck)
    {
        _trucks[truck.Code] = truck;
        return Task.FromResult(truck.Code);
    }

    public Task UpdateTruckAsync(Truck truck)
    {
        _trucks[truck.Code] = truck;
        return Task.CompletedTask;
    }

    public Task DeleteTruckAsync(string code)
    {
        _trucks.Remove(code);
        return Task.CompletedTask;
    }
}