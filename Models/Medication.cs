using DroneManagementSystem.Core.Models;

namespace DroneManagementSystem.Models
{
    public class Medication: IModelBase
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public float Weight { get; set; }
        public string ImagePath { get; set; }        
    }
}
