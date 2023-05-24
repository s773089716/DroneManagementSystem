/**************************************************************************************************
 * Author   : Sampath Kumara
 * Date     : 2023-05-22
 *************************************************************************************************/
using DroneManagementSystem.Core.DTOs;
namespace DroneManagementSystem.DTOs
{
    public class DroneBatteryLevelResponse : IResponseBase
    {
        public short BatteryLevel { get; set; }
    }
}
