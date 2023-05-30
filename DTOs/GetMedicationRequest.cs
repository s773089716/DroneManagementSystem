using DroneManagementSystem.Core.DTOs;
using DroneManagementSystem.Models;

namespace DroneManagementSystem.DTOs
{
    public class GetMedicationRequest : IRequestBase
    {
        public string? SerialNumber { get; set; }
    }
}
