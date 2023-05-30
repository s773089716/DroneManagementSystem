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

        public async Task<RegisterDroneResponse> RegisterDrone(RegisterDroneRequest request)
        {
            if (request.Drone == null)
                throw new Exception("Drone is empty");

            return new RegisterDroneResponse()
            {
                Drone = await _droneRepository.AddNewDrone(request.Drone)
            };
        }

        public async Task<LoadMedicationsResponse> AddMedicationItemsToDrone(LoadMedicationsRequest request)
        {
            if (String.IsNullOrEmpty(request.SerialNumber))
                throw new Exception("Serial number is empty");

            if (request.MedicationCodes == null || request.MedicationCodes.Count == 0)
                throw new Exception("Medictaions list is empty");

            return new LoadMedicationsResponse()
            {
                Drone = await _droneRepository.AddMedicationItemsToDrone(request.SerialNumber, request.MedicationCodes)
            };
        }

        public async Task<GetMedicationResponse> GetMedicationItemsOfDrone(GetMedicationRequest request)
        {
            if (String.IsNullOrEmpty(request.SerialNumber))
                throw new Exception("Serial number is empty");

            return new GetMedicationResponse()
            {
                Medications = await _droneRepository.GetMedicationItemsOfDrone(request.SerialNumber)
            };
        }
    }
}

