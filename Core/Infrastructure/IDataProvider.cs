using DroneManagementSystem.Models;
using System.Collections.Generic;

namespace DroneManagementSystem.Core.Infrastructure
{
    public interface IDataProvider
    {
        IList<Drone> GetDronesData();
    }
}
