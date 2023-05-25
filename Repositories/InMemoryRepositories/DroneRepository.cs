using DroneManagementSystem.Core.Repositories;
using DroneManagementSystem.Infrastructure;
using DroneManagementSystem.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Text;

namespace DroneManagementSystem.Repositories.InMemoryRepositories
{
    public class DroneRepository : IDroneRepository
    {
        #region Private Variables -----------------------------------------------------------------
        private static IList<Drone> _dronesList = null;
        private static IList<Medication> _medicationsList = null;
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
        #endregion

        #region Methods ---------------------------------------------------------------------------
        /// <summary>
        /// Service method to search data related to the prefix
        /// </summary>
        /// <param name="prefix">Prefix to be searched</param>
        /// <returns>String array</returns>
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

        public async Task<short> GetBatteryLevelBySerialNumber(string SerialNumber)
        {                   
            Drone? drone = null; 
            await Task.Run(() =>
            {
                drone =
                (
                    from w in DronesList
                    where w.SerialNumber == SerialNumber
                    select w
                ).FirstOrDefault();
            });

            if (drone == null)
                return -1;

            return drone.BatteryCapacity;
        }

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

                if (drone == null)
                    throw new Exception("Drone does not exists.");

                List<Medication> medications = (from ml in MedicationsList
                                                where medicationItemCodes.Contains(ml.Code)
                                                select ml).ToList();

                if (medications.Count != medicationItemCodes.Count)                
                    throw new Exception("One or more medication code/s invalid.");

                float totalWeight = drone.Medications.Sum(m => m.Weight) + medications.Sum(m => m.Weight);   

                if (totalWeight > drone.WeightLimit)
                    throw new Exception("Drone weight limit exceeds.");

                drone.Medications.AddRange(medications);
            });

            return drone;
        }
        #endregion
    }
}
