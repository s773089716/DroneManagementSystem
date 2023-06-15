/**************************************************************************************************
 * Author   : Sampath Kumara
 * Date     : 2023-05-22
 *************************************************************************************************/
using DroneManagementSystem.Core.Repositories;
using DroneManagementSystem.Core.Services;
using DroneManagementSystem.DTOs;
using DroneManagementSystem.Infrastructure;

namespace DroneManagementSystem.Services
{
    /// <summary>
    /// Dispatch service details
    /// </summary>
    public class DispatchService : IDispatchService
    {
        #region Private Variables -----------------------------------------------------------------
        IDroneRepository _droneRepository;
        #endregion

        #region Constructors ----------------------------------------------------------------------
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="droneRepository"></param>
        public DispatchService(IDroneRepository droneRepository)
        {
            _droneRepository = droneRepository;
        }
        #endregion

        #region Methods ---------------------------------------------------------------------------
        /// <summary>
        /// This method GetAvailableDrones
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<DronesListResponse> GetAvailableDrones(DronesListRequest request)
        {
            return new DronesListResponse()
            {
                Drones = await _droneRepository.FindDronesByStatusEnum(DroneState.IDLE)
            };
        }

        /// <summary>
        /// This method GetDroneBatteryLevel
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<DroneBatteryLevelResponse> GetDroneBatteryLevel(DroneBatteryLevelRequest request)
        {
            return new DroneBatteryLevelResponse()
            {
                BatteryLevel = await _droneRepository.GetBatteryLevelBySerialNumber(request.SerialNumber)
            };                  
        }

        /// <summary>
        /// This method GetDronesList
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<DronesListResponse> GetDronesList(DronesListRequest request)
        {
            return new DronesListResponse()
            {
                Drones = await _droneRepository.GetDronesList()
            };
        }

        /// <summary>
        /// This method RegisterDrone
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<RegisterDroneResponse> RegisterDrone(RegisterDroneRequest request)
        {
            if (request.Drone == null)
                throw new Exception("Drone is empty");

            return new RegisterDroneResponse()
            {
                Drone = await _droneRepository.AddNewDrone(request.Drone)
            };
        }

        /// <summary>
        /// This method AddMedicationItemsToDrone
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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

        /// <summary>
        /// This method GetMedicationItemsOfDrone
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<GetMedicationResponse> GetMedicationItemsOfDrone(GetMedicationRequest request)
        {
            if (String.IsNullOrEmpty(request.SerialNumber))
                throw new Exception("Serial number is empty");

            return new GetMedicationResponse()
            {
                Medications = await _droneRepository.GetMedicationItemsOfDrone(request.SerialNumber)
            };
        }
        #endregion
    }
}

