using DroneManagementSystem.DTOs;
using DroneManagementSystem.Infrastructure;

namespace DroneManagementSystem.Core.Services
{
    public interface IDispatchService : IServiceBase
    {
        Task<AvailableDronesListResponse> GetAvailableDrones(AvailableDronesListRequest request);

        Task<DroneBatteryLevelResponse> GetDroneBatteryLevel(DroneBatteryLevelRequest request);

        Task<RegisterDroneResponse> RegisterDrone(RegisterDroneRequest request);

        Task<LoadMedicationsResponse> AddMedicationItemsToDrone(LoadMedicationsRequest request);

        Task<GetMedicationResponse> GetMedicationItemsOfDrone(GetMedicationRequest request);
    }
}
