/**************************************************************************************************
 * Author   : Sampath Kumara
 * Date     : 2023-06-14
 *************************************************************************************************/
using DroneManagementSystem.Core.DTOs;
using DroneManagementSystem.Models;

namespace DroneManagementSystem.DTOs
{
    public class LoadMedicationsResponse : ResponseBase
    {
        public Drone? Drone { get; set; }
    }
}
