using DroneManagementSystem.DTOs;
using DroneManagementSystem.Infrastructure;

namespace DroneManagementSystem.Core.Services
{
    public interface IDispatchService : IServiceBase
    {
        Task<AvailableDronesListResponse> GetAvailableDrones(AvailableDronesListRequest request);

        Task<DroneBatteryLevelResponse> GetDroneBatteryLevel(DroneBatteryLevelRequest request);
    }
}
