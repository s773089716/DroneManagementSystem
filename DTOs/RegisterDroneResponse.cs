using DroneManagementSystem.Core.DTOs;
using DroneManagementSystem.Models;

namespace DroneManagementSystem.DTOs
{
    public class RegisterDroneResponse : ResponseBase
    {
        public Drone? Drone { get; set; }
    }
}
