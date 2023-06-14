using DroneManagementSystem.Core.DTOs;
using DroneManagementSystem.Models;

namespace DroneManagementSystem.DTOs
{
    public class DronesListResponse : ResponseBase
    {
        public IList<Drone> Drones { get; set; } = new List<Drone>();
    }
}
