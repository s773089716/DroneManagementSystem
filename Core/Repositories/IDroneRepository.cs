using DroneManagementSystem.Infrastructure;
using DroneManagementSystem.Models;

namespace DroneManagementSystem.Core.Repositories
{
    public interface IDroneRepository : IRepositoryBase
    {
        Task<IList<Drone>> FindDronesByStatusEnum(DroneState status);

        Task<short> GetBatteryLevelBySerialNumber(string SerialNumber);
    }
}
