using DroneManagementSystem.Infrastructure;
using DroneManagementSystem.Models;
using Microsoft.Extensions.Caching.Memory;

namespace DroneManagementSystem.Repositories.InMemoryRepositories
{
    public class DroneRepository
    {
        #region Private Variables -----------------------------------------------------------------
        private static IList<Drone> _dronesList = null;        
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
        #endregion

        #region Methods ---------------------------------------------------------------------------
        /// <summary>
        /// Service method to search data related to the prefix
        /// </summary>
        /// <param name="prefix">Prefix to be searched</param>
        /// <returns>String array</returns>
        public async Task<IList<Drone>?> FindDronesByStatusEnum(DroneState status)
        {
            IList<Drone>? Drones = null;

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
        #endregion
    }
}
