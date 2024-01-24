using Tracker.Domain;

namespace Tracker.Repository
{
    public interface ITruckRepository
    {
        Task<IEnumerable<Truck>> GetTrucksAsync();
        Task<string> CreateTruckAsync(Truck truck);
        Task UpdateTruckAsync(Truck truck); 
        Task DeleteTruckAsync(string code);
    }
}