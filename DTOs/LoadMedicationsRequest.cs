using DroneManagementSystem.Models;

namespace DroneManagementSystem.DTOs
{
    public class LoadMedicationsRequest
    {
        public string? SerialNumber { get; set; }
        public IList<string> MedicationCodes { get; set; } = new List<string>();
    }
}
