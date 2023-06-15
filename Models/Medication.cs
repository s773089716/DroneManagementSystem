/**************************************************************************************************
 * Author   : Sampath Kumara
 * Date     : 2023-05-22
 *************************************************************************************************/
using DroneManagementSystem.Core.Models;

namespace DroneManagementSystem.Models
{
    public class Medication: ModelBase
    {
        public string? Name { get; set; }
        public string Code { get; set; }
        public float Weight { get; set; }
        public string ImagePath { get; set; }        
    }
}
