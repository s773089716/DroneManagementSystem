using DroneManagementSystem.Core.Repositories;
using DroneManagementSystem.Core.Services;
using DroneManagementSystem.DTOs;
using DroneManagementSystem.Infrastructure;
using DroneManagementSystem.Repositories.InMemoryRepositories;

namespace DroneManagementSystem.Services
{
    
    public class DispatchService : IDispatchService
    {
        IDroneRepository _droneRepository;

        public DispatchService(IDroneRepository droneRepository)
        {
            _droneRepository = droneRepository;
        }

        public async Task<AvailableDronesListResponse> GetAvailableDrones(AvailableDronesListRequest request)
        {
            return new AvailableDronesListResponse()
            {
                Drones = await _droneRepository.FindDronesByStatusEnum(DroneState.IDLE)
            };
        }

        public async Task<DroneBatteryLevelResponse> GetDroneBatteryLevel(DroneBatteryLevelRequest request)
        {
            return new DroneBatteryLevelResponse()
            {
                BatteryLevel = await _droneRepository.GetBatteryLevelBySerialNumber(request.SerialNumber)
            };                  
        }
    }
}

