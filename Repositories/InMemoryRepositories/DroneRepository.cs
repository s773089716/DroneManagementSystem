﻿/**************************************************************************************************
 * Author   : Sampath Kumara
 * Date     : 2023-05-22
 *************************************************************************************************/
using DroneManagementSystem.Core.Repositories;
using DroneManagementSystem.Infrastructure;
using DroneManagementSystem.Models;

namespace DroneManagementSystem.Repositories.InMemoryRepositories
{
    public class DroneRepository : IDroneRepository
    {
        #region Private Variables -----------------------------------------------------------------
        private static IList<Drone> _dronesList = null;
        private static IList<Medication> _medicationsList = null;
        private static IList<DispatchConfiguration> _dispatchConfigurationList = null;
        #endregion

        #region Constructors ----------------------------------------------------------------------
        public DroneRepository()
        {            
        }
        #endregion

        #region Properties ------------------------------------------------------------------------
        private IList<Drone> DronesList
        {
            get
            {
                if (_dronesList == null)
                    _dronesList = new InMemoryDataProvider().GetDronesData();

                return _dronesList;

            }
        }

        private IList<Medication> MedicationsList
        {
            get
            {
                if (_medicationsList == null)
                    _medicationsList = new InMemoryDataProvider().GetMedicationsData();

                return _medicationsList;

            }
        }

        private IList<DispatchConfiguration> DispatchConfigurationList
        {
            get
            {
                if (_dispatchConfigurationList == null)
                    _dispatchConfigurationList = new InMemoryDataProvider().GetDispatchConfigurationData();

                return _dispatchConfigurationList;

            }
        }
        #endregion

        #region Methods ---------------------------------------------------------------------------
        /// <summary>
        /// This method returns the list of drones of given status
        /// </summary>
        /// <param name="status">Given status</param>
        /// <returns>Drones list</returns>
        public async Task<IList<Drone>> FindDronesByStatusEnum(DroneState status)
        {
            IList<Drone> Drones = new List<Drone>();

            await Task.Run(() =>
            {
                Drones =
                (
                    from w in DronesList
                    where w.State == status
                    select w
                ).ToList<Drone>();
            });

            return Drones;
        }

        /// <summary>
        /// This method returns the list of drones
        /// </summary>
        /// <returns>Drones list</returns>
        public async Task<IList<Drone>> GetDronesList()
        {
            IList<Drone> Drones = new List<Drone>();

            await Task.Run(() =>
            {
                Drones =
                (
                    from w in DronesList                    
                    select w
                ).ToList<Drone>();
            });

            return Drones;
        }

        /// <summary>
        /// This method returns the battery level of particular drone
        /// </summary>
        /// <param name="serialNumber"></param>
        /// <returns></returns>
        public async Task<short> GetBatteryLevelBySerialNumber(string serialNumber)
        {                   
            Drone? drone = null; 
            await Task.Run(() =>
            {
                drone =
                (
                    from w in DronesList
                    where w.SerialNumber == serialNumber
                    select w
                ).FirstOrDefault();
            });

            if (drone == null)
                return -1;

            return drone.BatteryCapacity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="drone"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Drone> AddNewDrone(Drone drone)
        { 
            Drone? existingDrone = null;
            await Task.Run(() =>
            {
                existingDrone =
                (
                    from w in DronesList
                    where w.SerialNumber == drone.SerialNumber
                    select w
                ).FirstOrDefault();

                if (existingDrone != null)
                    throw new Exception("Serial number already exists.");

                DronesList.Add(drone);
            });            

            return drone;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serialNumber"></param>
        /// <param name="medicationItemCodes"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>             
        public async Task<Drone> AddMedicationItemsToDrone(string serialNumber, List<string> medicationItemCodes)
        {
            Drone? drone = null;
            await Task.Run(() =>
            {                
                drone =
                (
                    from w in DronesList
                    where w.SerialNumber == serialNumber
                    select w
                ).FirstOrDefault();

                DispatchConfiguration? configuration = 
                (
                    from w in DispatchConfigurationList                    
                    select w
                ).FirstOrDefault();

                if (drone == null)
                    throw new Exception("Drone does not exists.");

                if (configuration == null)
                    throw new Exception("Configuration does not exists.");
                
                if (drone.BatteryCapacity <= configuration.MinimumWeight)
                    throw new Exception("Drone battery capasity is lower.");

                List<Medication> medications = (from ml in MedicationsList
                                                where medicationItemCodes.Contains(ml.Code)
                                                select ml).ToList();

                if (medications.Count != medicationItemCodes.Count)                
                    throw new Exception("One or more medication code/s invalid.");

                float totalWeight = drone.Medications.Sum(m => m.Weight) + medications.Sum(m => m.Weight);   

                if (totalWeight > drone.WeightLimit)
                    throw new Exception("Drone weight limit exceeds.");

                if (drone.State == DroneState.LOADED)
                    throw new Exception("Drone already loaded.");

                if (drone.State != DroneState.IDLE && drone.State != DroneState.LOADING)
                    throw new Exception("Drone state is not in idle/loading.");

                if (drone.State != DroneState.LOADING)
                    drone.State = DroneState.LOADING;

                drone.Medications.AddRange(medications);

                float smallestMedication = MedicationsList.Min(m => m.Weight);

                if (smallestMedication > drone.WeightLimit - totalWeight)
                    drone.State = DroneState.LOADED;
            });

            return drone;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serialNumber"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<Medication>> GetMedicationItemsOfDrone(string serialNumber)
        {
            Drone? drone = null;
            await Task.Run(() =>
            {
                drone =
                (
                    from w in DronesList
                    where w.SerialNumber == serialNumber
                    select w
                ).FirstOrDefault();

                if (drone == null)
                    throw new Exception("Drone does not exists.");                                
            });

            return drone.Medications;
        }

        
        #endregion
    }
}
