/**************************************************************************************************
 * Author   : Sampath Kumara
 * Date     : 2023-06-14
 *************************************************************************************************/
using DroneManagementSystem.Core.DTOs;
using DroneManagementSystem.Models;

namespace DroneManagementSystem.DTOs
{
    public class DronesListResponse : ResponseBase
    {
        public IList<Drone> Drones { get; set; } = new List<Drone>();
    }
}
