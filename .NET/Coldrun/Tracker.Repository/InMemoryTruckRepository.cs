using Tracker.Domain;

namespace Tracker.Repository
{
    public class InMemoryTruckRepository : ITruckRepository
    {
        private static List<Truck> trucks = 
        [
            new Truck { Code = "ABC69", Description = "Truck 1", Name = "Track 1", Status = TrackStatus.OutOfService },
            new Truck { Code = "ABC70", Description = "Truck 2", Name = "Track 2", Status = TrackStatus.Loading }
        ];

        public Task<IEnumerable<Truck>> GetTrucksAsync()
        {
            return Task.FromResult(trucks.AsEnumerable());
        }

        public Task<string> CreateTruckAsync(Truck truck)
        {
            trucks.Add(truck);
            return Task.FromResult(truck.Code);
        }


        public Task UpdateTruckAsync(Truck truck)
        {
            var trackToUpdate = trucks.FirstOrDefault(t =>  t.Code == truck.Code);

            if (trackToUpdate != null)
            {
                trackToUpdate.Status = truck.Status;
                trackToUpdate.Name = truck.Name;
                trackToUpdate.Description = truck.Description;  
            }
            return Task.CompletedTask;
        }

        public Task DeleteTruckAsync(string code)
        {
            Truck trackToDelete = trucks.FirstOrDefault(t => t.Code == code);
            
            if(trackToDelete != null)
            {
                trucks.Remove(trackToDelete);
            }

            return Task.CompletedTask;
        }
    }
}