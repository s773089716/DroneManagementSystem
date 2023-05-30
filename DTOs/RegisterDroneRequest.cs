using DroneManagementSystem.Core.DTOs;
using DroneManagementSystem.Models;

namespace DroneManagementSystem.DTOs
{
    public class RegisterDroneRequest : RequestBase
    {
        public Drone? Drone { get; set; }
    }
}
