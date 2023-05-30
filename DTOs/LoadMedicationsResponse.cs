using DroneManagementSystem.Core.DTOs;
using DroneManagementSystem.Models;

namespace DroneManagementSystem.DTOs
{
    public class LoadMedicationsResponse : ResponseBase
    {
        public Drone? Drone { get; set; }
    }
}
