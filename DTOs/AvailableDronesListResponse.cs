using DroneManagementSystem.Models;

namespace DroneManagementSystem.DTOs
{
    public class AvailableDronesListResponse
    {
        public IList<Drone> Drones { get; set; } = new List<Drone>();
    }
}
