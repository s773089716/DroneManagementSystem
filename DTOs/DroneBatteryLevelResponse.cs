/**************************************************************************************************
 * Author   : Sampath Kumara
 * Date     : 2023-05-22
 *************************************************************************************************/
using DroneManagementSystem.Core.DTOs;
namespace DroneManagementSystem.DTOs
{
    public class DroneBatteryLevelResponse : ResponseBase
    {
        public short BatteryLevel { get; set; }
    }
}
