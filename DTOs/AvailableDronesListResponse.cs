using DroneManagementSystem.Core.DTOs;
using DroneManagementSystem.Models;

namespace DroneManagementSystem.DTOs
{
    public class AvailableDronesListResponse : ResponseBase
    {
        public IList<Drone> Drones { get; set; } = new List<Drone>();
    }
}
