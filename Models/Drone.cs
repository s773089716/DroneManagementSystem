using DroneManagementSystem.Core.Models;
using DroneManagementSystem.Infrastructure;

namespace DroneManagementSystem.Models
{
    public class Drone : IModelBase
    {
        //public Drone() { }

        public List<Medication> Medications { get; set; } = new List<Medication>();

        public string SerialNumber { get; set;}
        public DroneModel Model { get; set; }
        public decimal WeightLimit { get; set; }
        public short BatteryCapacity { get; set; }
        public DroneState State { get; set; }
    }
}
