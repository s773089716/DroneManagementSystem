using DroneManagementSystem.Core.Infrastructure;
using DroneManagementSystem.Models;
using System.Net;

/**************************************************************************************************
 * Author   : Sampath Kumara
 * Date     : 2023-05-24
 *************************************************************************************************/
namespace DroneManagementSystem.Infrastructure
{
    public class InMemoryDataProvider : IDataProvider
    {
        #region Public methods --------------------------------------------------------------------
        /// <summary>
        /// This method connect to the text file and scrape data
        /// </summary>
        /// <returns></returns>
        public IList<Drone> GetDronesData()
        {
            return new List<Drone>() 
            { 
                    new Drone() { SerialNumber = "01" , State = DroneState.IDLE},
                    new Drone() { SerialNumber = "02" , State = DroneState.IDLE}
            };
        }
        #endregion
    }
}

