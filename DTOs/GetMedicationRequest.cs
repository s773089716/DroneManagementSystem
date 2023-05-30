using DroneManagementSystem.Core.DTOs;
using DroneManagementSystem.Models;

namespace DroneManagementSystem.DTOs
{
    public class GetMedicationRequest : RequestBase
    {
        public string? SerialNumber { get; set; }
    }
}
