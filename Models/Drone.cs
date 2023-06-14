using DroneManagementSystem.Core.Models;
using DroneManagementSystem.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace DroneManagementSystem.Models
{
    public class Drone : ModelBase
    {
        //public Drone() { }

        public List<Medication>? Medications { get; set; } = new List<Medication>();

        //[Required(ErrorMessage = "Serial number is required")]
        public string? SerialNumber { get; set; }
        //[Required(ErrorMessage = "Model is required")]
        public DroneModel Model { get; set; }
        //[Range(0, 500, ErrorMessage = "Weight must be between 0g and 500g")]
        public float WeightLimit { get; set; } = 0;
        //[Range(0, 100, ErrorMessage = "Battery capasity must be between 0 and 100")]
        public short BatteryCapacity { get; set; }
        //[Required(ErrorMessage = "State is required")]
        public DroneState State { get; set; }
    }
}
