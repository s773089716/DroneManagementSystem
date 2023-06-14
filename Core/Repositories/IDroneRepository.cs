using DroneManagementSystem.Infrastructure;
using DroneManagementSystem.Models;

namespace DroneManagementSystem.Core.Repositories
{
    public interface IDroneRepository : IRepositoryBase
    {
        Task<IList<Drone>> FindDronesByStatusEnum(DroneState status);

        Task<IList<Drone>> GetDronesList();

        Task<short> GetBatteryLevelBySerialNumber(string SerialNumber);

        Task<Drone> AddNewDrone(Drone drone);

        Task<Drone> AddMedicationItemsToDrone(string serialNumber, IList<string> medicationItemCodes);

        Task<List<Medication>> GetMedicationItemsOfDrone(string serialNumber);
    }
}
