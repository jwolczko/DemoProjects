using Tracker.Domain;

namespace Tracker.Repository
{
    public interface ITruckRepository
    {
        Task<IEnumerable<Truck>> GetTrucks();
        Task<string> CreateTruck(Truck truck);
        Task UpdateTruck(Truck truck); 
        Task DeleteTruck(Truck truck);
    }

    public class InMemoryTruckRepository : ITruckRepository
    {
        private static List<Truck> trucks = 
        [
            new Truck { Code = "ABC69", Description = "Truck 1", Name = "Track 1", Status = TrackStatus.OutOfService },
            new Truck { Code = "ABC70", Description = "Truck 2", Name = "Track 2", Status = TrackStatus.Loading }
        ];

        public async Task<IEnumerable<Truck>> GetTrucks()
        {
            return trucks.AsEnumerable();
        }

        public async Task<string> CreateTruck(Truck truck)
        {
            trucks.Add(truck);
            return truck.Code;
        }


        public async Task UpdateTruck(Truck truck)
        {
            var trackToUpdate = trucks.FirstOrDefault(t =>  t.Code == truck.Code);

            if (trackToUpdate != null)
            {
                trackToUpdate.Status = truck.Status;
                trackToUpdate.Name = truck.Name;
                trackToUpdate.Description = truck.Description;  
            }

        }

        public async Task DeleteTruck(Truck truck)
        {
            trucks.Remove(truck);
        }
    }
}