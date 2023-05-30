﻿using DroneManagementSystem.Core.DTOs;
using DroneManagementSystem.Models;

namespace DroneManagementSystem.DTOs
{
    public class GetMedicationResponse : ResponseBase
    {
        public List<Medication> Medications { get; set; } = new List<Medication>();
    }
}
