/**************************************************************************************************
 * Author   : Sampath Kumara
 * Date     : 2023-06-14
 *************************************************************************************************/
using DroneManagementSystem.Core.DTOs;
using DroneManagementSystem.Models;
using System.Text.Json.Serialization;

namespace DroneManagementSystem.DTOs
{
    public class RegisterDroneRequest : RequestBase
    {
        [JsonPropertyName("drone")]
        public Drone? Drone { get; set; }
    }
}
