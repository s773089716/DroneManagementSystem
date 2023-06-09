﻿/**************************************************************************************************
 * Author   : Sampath Kumara
 * Date     : 2023-06-14
 *************************************************************************************************/
using DroneManagementSystem.Core.DTOs;
using DroneManagementSystem.Models;

namespace DroneManagementSystem.DTOs
{
    public class LoadMedicationsRequest : RequestBase
    {
        public string? SerialNumber { get; set; }
        public List<string> MedicationCodes { get; set; } = new List<string>();
    }
}
