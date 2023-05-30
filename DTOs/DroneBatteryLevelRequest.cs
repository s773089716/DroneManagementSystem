/**************************************************************************************************
 * Author   : Sampath Kumara
 * Date     : 2023-05-22
 *************************************************************************************************/
using DroneManagementSystem.Core.DTOs;

namespace DroneManagementSystem.DTOs
{
    public class DroneBatteryLevelRequest : RequestBase
    {
        public string? SerialNumber { get; set; }
    }
}
