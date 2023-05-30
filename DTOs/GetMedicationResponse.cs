using DroneManagementSystem.Models;

namespace DroneManagementSystem.DTOs
{
    public class GetMedicationResponse
    {
        public List<Medication> Medications { get; set; } = new List<Medication>();
    }
}
